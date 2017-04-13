namespace Application.ViewModels.FinanceViewModels
{
    using System;
    using System.Collections.Generic;
    using Core.Entities.IO;

    public class ImageDeleteViewModel
    {
        public Guid rId { get; set; }

        public TableNameEnum tableName { get; set; }
        
        public IEnumerable<Guid?> ReferencedSids { get; set; }
    }
}
