using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CakeMaker.Models
{
    public class MetaData
    {
    }
    public class ProductMetadata
    {

    }
    public class CustomerMetadata
    {

    }
    public class OrderDetailMetadata
    {
        [Required]
        public string Delivery_Date { get; set; }
        [Required]
        public string Delivery_Address { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}