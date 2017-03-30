namespace Application
{
    using Autofac;

    /// <summary>
    /// 依赖注入的配置
    /// </summary>
    public partial class Startup
    {
        public abstract void ConfigureAutofac(ContainerBuilder builder);

        public virtual void ConfigureAutofac()
        {
            var builder = new ContainerBuilder();

            // Logger
            builder.RegisterType<Infrastructure.Logger.Log4net>()
                .As<Core.Interfaces.ILogger>()
                .SingleInstance();

            builder.RegisterModule<Infrastructure.Logger.LoggingModule>();

            // Entity Framework
            builder.RegisterType<Data.MyContext>().AsSelf().InstancePerRequest();

            // Repository
            builder.RegisterAssemblyTypes(typeof(Data.Repositories.BaseRepository<>).Assembly)
                .Where(m => m.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerRequest();

            // Service
            builder.RegisterAssemblyTypes(typeof(Core.Interfaces.IEntity).Assembly)
                .Where(m => m.Name.EndsWith("Service"))
                .AsSelf()
                .InstancePerRequest();

            // Application Service
            builder.RegisterAssemblyTypes(typeof(Startup).Assembly)
                .Where(m => m.Name.EndsWith("AppService"))
                .AsSelf()
                .InstancePerRequest();

            // Application User
            builder.RegisterType<Data.Repositories.AppUserStore>()
                .As<Microsoft.AspNet.Identity.IUserStore<Core.Entities.AppUser>>()
                .InstancePerRequest();
            builder.RegisterType<Core.Entities.AppUserManager>()
                .AsSelf()
                .OnActivated(m => m.Instance.User = CurrentPrincipal())
                .InstancePerRequest();
            builder.Register(
                m => new Core.Entities.Identity.AppRoleManager(
                    new Microsoft.AspNet.Identity.EntityFramework.RoleStore<Core.Entities.Identity.AppRole>(m.Resolve<Data.MyContext>())))
                .AsSelf()
                .InstancePerRequest();

            ConfigureAutofac(builder);
        }

        protected abstract System.Security.Principal.IPrincipal CurrentPrincipal();
    }
}
