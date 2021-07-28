using System;

namespace BeetrootTestApp.Common.Models.IncomeModels
{
    public class GetMessagesFilterIncomeModel
    {
        public string SenderIpAddress { get; set; }

        public DateTime FromMessagesDateTime { get; set; }

        public DateTime ToMessagesDateTime { get; set; }
    }
}
