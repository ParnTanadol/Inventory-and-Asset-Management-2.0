//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Inventory_and_Asset_Management_2._0
{
    using System;
    using System.Collections.Generic;
    
    public partial class CAMTUser
    {
        public CAMTUser()
        {
            this.ItemOwners = new HashSet<ItemOwner>();
            this.Reports = new HashSet<Report>();
            this.Reports1 = new HashSet<Report>();
        }
    
        public int user_id { get; set; }
        public string user_username { get; set; }
        public string user_password { get; set; }
        public string user_name { get; set; }
        public string user_department { get; set; }
        public string user_room { get; set; }
        public string user_address { get; set; }
        public string user_tel { get; set; }
        public string user_email { get; set; }
        public int user_type { get; set; }
        public bool user_active { get; set; }
    
        public virtual ICollection<ItemOwner> ItemOwners { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
        public virtual ICollection<Report> Reports1 { get; set; }
    }
}
