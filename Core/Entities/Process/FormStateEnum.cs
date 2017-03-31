namespace Core.Entities.Process
{
    public enum FormStateEnum : byte
    {
        //// 全部禁用
        禁用 = 0,
        //// 不禁用
        启用 = 1,
        //// 部分禁用
        部分启用 = 2,
        //// 当状态为3时表示还款
        还款 = 3
    }
}
