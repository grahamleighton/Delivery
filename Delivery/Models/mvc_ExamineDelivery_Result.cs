//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Delivery.Models
{
    using System;
    using System.ComponentModel;

    public partial class mvc_ExamineDelivery_Result
    {
        public string Delivery { get; set; }
        [DisplayName("Cat No")]

        public string CatNo { get; set; }
        [DisplayName("Option")]

        public string OptNo { get; set; }
        public string Supplier { get; set; }
        public Nullable<int> Expected { get; set; }
        public Nullable<int> Delivered { get; set; }
        [DisplayName("Received OK")]

        public Nullable<int> ReceivedOK { get; set; }
        public Nullable<int> Blockers { get; set; }
        [DisplayName("First Item Keyed")]
        public Nullable<System.DateTime> FirstItem { get; set; }
        [DisplayName("Last Item Keyed")]
        public Nullable<System.DateTime> LastItem { get; set; }
        [DisplayName("Open/Closed")]
        public string DeliveryState { get; set; }
        [DisplayName("Date Started")]
        public Nullable<System.DateTime> DateStarted { get; set; }
        [DisplayName("Date Ended")]
        public Nullable<System.DateTime> DateDisappeared { get; set; }
    }
}

