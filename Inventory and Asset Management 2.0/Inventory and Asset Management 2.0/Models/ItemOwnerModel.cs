using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Inventory_and_Asset_Management_2._0.Repositories;

namespace Inventory_and_Asset_Management_2._0.Models
{
    public class ItemOwnerModel
    {
        public int itemOwner_id { get; set; }
        public ItemModel item_id { get; set; }
        public CAMTUserModel user_id { get; set; }


        public bool insertItemOwner(int itemId, int userId)
        {
            try
            {
                ItemOwner itemOwner = new ItemOwner();
                itemOwner.item_id = itemId;
                itemOwner.user_id = userId;

                IItemOwnerRepo itemOwnerRepo = new ItemOwnerRepo(new INVENTORY_MANAGEMENT_2Entities());

                bool status = itemOwnerRepo.insertItemOwner(itemOwner);

                if (status == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}