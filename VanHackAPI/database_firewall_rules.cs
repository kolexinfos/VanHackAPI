//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VanHackAPI
{
    using System;
    using System.Collections.Generic;
    
    public partial class database_firewall_rules
    {
        public int id { get; set; }
        public string name { get; set; }
        public string start_ip_address { get; set; }
        public string end_ip_address { get; set; }
        public System.DateTime create_date { get; set; }
        public System.DateTime modify_date { get; set; }
    }
}
