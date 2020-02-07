using System;
using System.Collections.Generic;

namespace DeviceApp.Models
{
    public partial class Devices
    {
        public Devices()
        {
            DeviceDetails = new HashSet<DeviceDetails>();
        }

        public int DId { get; set; }
        public string DName { get; set; }
        public string DProducer { get; set; }
        public int? DWarranty { get; set; }
        public string DPrice { get; set; }
        public string DBandwidth { get; set; }
        public bool DStatus { get; set; }
        public int DCId { get; set; }

        public DeviceCategories DC { get; set; }
        public ICollection<DeviceDetails> DeviceDetails { get; set; }
    }
}
