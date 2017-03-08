namespace Application
{
    using System;
    using Core.Entities;
    using Core.Entities.Other;
    using Core.Exceptions;
    using Core.Interfaces.Repositories;
    using ViewModels.OtherViewModels;

    public class DraftAppService
    {
        private readonly IDraftRepository repository;
        private readonly AppUserManager userManager;

        public DraftAppService(IDraftRepository repository, AppUserManager userManager)
        {
            this.repository = repository;
            this.userManager = userManager;
        }

        public void Save(DraftViewModel model)
        {
            var currentUser = userManager.CurrentUser();

            var draft = repository.GetByUserAndPageLink(currentUser.Id, model.PageLink);

            if (draft == null)
            {
                draft = new Draft {
                    UserId = currentUser.Id,
                    PageLink = model.PageLink
                };

                repository.Create(draft);
            }

            draft.PageData = model.PageData;

            repository.Commit();
        }

        public DraftViewModel Read(string pageLink)
        {
            if (string.IsNullOrEmpty(pageLink))
            {
                throw new ArgumentNullAppException(nameof(pageLink));
            }

            var currentUser = userManager.CurrentUser();

            var draft = repository.GetByUserAndPageLink(currentUser.Id, pageLink);

            DraftViewModel model = null;

            if (draft != null)
            {
                model = new DraftViewModel {
                    PageLink = draft.PageLink,
                    PageData = draft.PageData
                };
            }

            return model;
        }

        public void Clear(string pageLink)
        {
            if (string.IsNullOrEmpty(pageLink))
            {
                throw new ArgumentNullAppException(nameof(pageLink));
            }

            var currentUser = userManager.CurrentUser();

            var draft = repository.GetByUserAndPageLink(currentUser.Id, pageLink);

            if (draft != null)
            {
                repository.Remove(draft);
                repository.Commit();
            }
        }
    }
}
