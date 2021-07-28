using System.Collections.Generic;

namespace BeetrootTestApp.DataAccess.EntitesModel
{
    public class Sender : BaseEntity
    {
        public Sender()
        {
            Messages = new HashSet<Message>();
        }

        public string SenderIPAddress { get; set; }

        public virtual ICollection<Message> Messages { get; set; }
    }
}
