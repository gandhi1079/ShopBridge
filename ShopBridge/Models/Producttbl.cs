using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ShopBridge.Models
{
    public partial class Producttbl
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDesc { get; set; }
        public string Image { get; set; }
        public int Price { get; set; }
        public int Quanity { get; set; }
        public int CategoryId { get; set; }

        public virtual Categorytbl Category { get; set; }
    }
}
