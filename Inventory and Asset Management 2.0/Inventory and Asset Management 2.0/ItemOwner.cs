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
    
    public partial class ItemOwner
    {
        public int itemOwner_id { get; set; }
        public int item_id { get; set; }
        public int user_id { get; set; }
    
        public virtual CAMTUser CAMTUser { get; set; }
        public virtual Item Item { get; set; }
    }
}
