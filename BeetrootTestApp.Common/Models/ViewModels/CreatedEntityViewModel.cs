using System;

namespace BeetrootTestApp.Common.Models.ViewModels
{
    public class CreatedEntityViewModel
    {
        public CreatedEntityViewModel(Guid newEntityId)
        {
            EntityId = newEntityId;
        }

        public Guid EntityId { get; set; }
    }
}
