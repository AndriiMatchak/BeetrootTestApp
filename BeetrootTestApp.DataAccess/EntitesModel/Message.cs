using System;

namespace BeetrootTestApp.DataAccess.EntitesModel
{
    public class Message : BaseEntity
    {
        public string MessageText { get; set; }

        public Guid SenderId { get; set; }

        public virtual Sender Sender { get; set; }
    }
}
