using System;
using System.Collections.Generic;
using System.Text;

namespace House.Core.Domain
{
    public class House_Fix
    {
        public Guid? Id { get; set; }
        public int Price { get; set; }
        public int Rooms { get; set; }
        public int Year { get; set; }
        public int Floors { get; set; }
        public string Address { get; set; }
        public string Information { get; set; }
    }
}
