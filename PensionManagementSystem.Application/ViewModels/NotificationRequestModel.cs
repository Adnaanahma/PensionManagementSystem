using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PensionManagementSystem.Application.Enums;

namespace PensionManagementSystem.Application.ViewModels
{
    public class NotificationRequestModel
    {
        public Guid MemberId { get; set; }
        public NotificationChannel Channel { get; set; }
        public string Recipient { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}
