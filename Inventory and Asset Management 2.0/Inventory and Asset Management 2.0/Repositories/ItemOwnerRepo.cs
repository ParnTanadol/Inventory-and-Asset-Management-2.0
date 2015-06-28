using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventory_and_Asset_Management_2._0.Repositories
{
    public class ItemOwnerRepo : IItemOwnerRepo
    {
        private INVENTORY_MANAGEMENT_2Entities context;
        public ItemOwnerRepo(INVENTORY_MANAGEMENT_2Entities context)
        {
            this.context = context;
        }

        public bool insertItemOwner(ItemOwner itemOwner)
        {
            try
            {
                context.ItemOwners.Add(itemOwner);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool updateItemOwner(ItemOwner itemOwner)
        {
            try
            {
                ItemOwner ItemOwnerDb = context.ItemOwners.First(i => i.itemOwner_id == itemOwner.itemOwner_id);

                ItemOwnerDb.itemOwner_id = itemOwner.itemOwner_id;
                ItemOwnerDb.user_id = itemOwner.user_id;
                context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public ItemOwner viewItemOwnerByitemId(int itemId)
        {
            try
            {
                ItemOwner itemOwner = context.ItemOwners.First(i => i.item_id == itemId);
                context.SaveChanges();
                return itemOwner;
            }
            catch
            {
                ItemOwner itemOwner = new ItemOwner();
                return itemOwner;
            }
        }

        public List<ItemOwner> viewAllItemOwner()
        {
            try
            {
                List<ItemOwner> itemOwnerDBList = context.ItemOwners.ToList();
                context.SaveChanges();

                return itemOwnerDBList;
            }
            catch
            {
                List<ItemOwner> itemOwnerDBList = new List<ItemOwner>();
                return itemOwnerDBList;
            }
        }
    }
}