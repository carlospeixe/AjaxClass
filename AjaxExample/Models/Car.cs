//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AjaxExample.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web;

    public partial class Car
    {
        public int Id { get; set; }
        public Nullable<int> BrandId { get; set; }
        public string Model { get; set; }
        public string ImagePath { get; set; }
        public Nullable<bool> IsAvailable { get; set; }
        public Nullable<decimal> Price { get; set; }

        [NotMapped]
        HttpPostedFileBase CarImage { get; set; }

        public virtual Brand Brand { get; set; }
    }
}
