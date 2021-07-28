using System;

namespace BeetrootTestApp.Common.Models.ViewModels
{
    public class BaseEntityViewModel
    {
        public Guid Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }
    }
}
