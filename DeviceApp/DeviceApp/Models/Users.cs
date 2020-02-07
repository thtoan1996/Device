using System;
using System.Collections.Generic;

namespace DeviceApp.Models
{
    public partial class Users
    {
        public Users()
        {
            DeviceDetails = new HashSet<DeviceDetails>();
        }

        public int UId { get; set; }
        public string UFullName { get; set; }
        public string UPhone { get; set; }
        public DateTime? UBirthDay { get; set; }
        public string UAddress { get; set; }
        public string UEmail { get; set; }
        public bool UStatus { get; set; }
        public string UUserName { get; set; }
        public string UPassword { get; set; }

        public ICollection<DeviceDetails> DeviceDetails { get; set; }
    }
}
