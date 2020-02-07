using System;
using System.Collections.Generic;

namespace DeviceApp.Models
{
    public partial class DeviceCategories
    {
        public DeviceCategories()
        {
            Devices = new HashSet<Devices>();
        }

        public int DCId { get; set; }
        public string DCName { get; set; }
        public bool? DCStatus { get; set; }

        public ICollection<Devices> Devices { get; set; }
    }
}
