//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfProject2
{
    using System;
    using System.Collections.Generic;
    
    public partial class Magazine
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Issue { get; set; }
        public Nullable<int> LogowanieId { get; set; }
        public Nullable<int> CategoryId { get; set; }
        public Nullable<int> StateId { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<short> Amount { get; set; }
        public Nullable<bool> Availability { get; set; }
    }
}
