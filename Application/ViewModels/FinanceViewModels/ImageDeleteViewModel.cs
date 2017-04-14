namespace Application.ViewModels.FinanceViewModels
{
    using System;
    using System.Collections.Generic;
    using Core.Entities.IO;

    public class UploadViewModel
    {
        public Guid ReferenceId { get; set; }

        public ReferenceTypeEnum ReferenceType { get; set; }
        
        public IEnumerable<Guid?> ReferenceSids { get; set; }
    }
}
