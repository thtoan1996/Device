using System;
using System.Collections.Generic;

namespace DeviceApp.Models
{
    public partial class DeviceDetails
    {
        public int UId { get; set; }
        public int DId { get; set; }
        public DateTime DDDateTime { get; set; }
        public string DDOperated { get; set; }

        public Devices D { get; set; }
        public Users U { get; set; }
    }
}
