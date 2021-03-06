﻿namespace Application.ViewModels.ProcessViewModels
{
    using System;
    using System.Collections.Generic;

    public class FrameViewModel
    {
        public IEnumerable<FormViewModel> Forms { get; set; }

        public IEnumerable<ActionViewModel> Actions { get; set; }

        public IEnumerable<OpinionViewModel> InnerOpinions { get; set; }

        public IEnumerable<OpinionViewModel> ExnerOpinions { get; set; }

        public bool HasInnerOpinion { get; set; }

        public Guid? RootKey { get; set; }
    }
}
