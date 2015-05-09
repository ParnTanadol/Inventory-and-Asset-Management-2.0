using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventory_and_Asset_Management_2._0.Repositories
{
    public class ItemRepo : IItemRepo
    {

        private INVENTORY_MANAGEMENT_2Entities context;
        public ItemRepo(INVENTORY_MANAGEMENT_2Entities context)
        {
            this.context = context;
        }

        public bool insertItem(Item item)
        {
            try
            {
                context.Items.Add(item);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool updateItem(Item item)
        {
            try
            {
                Item ItemDb = context.Items.First(i => i.item_id == item.item_id);

                ItemDb.item_id = item.item_id;
                ItemDb.item_brand = item.item_brand;
                ItemDb.item_name = item.item_name;
                ItemDb.item_description = item.item_description;
                ItemDb.item_startDate = item.item_startDate;
                ItemDb.item_endDate = item.item_endDate;
                ItemDb.item_status = item.item_status;
                ItemDb.item_picture = item.item_picture;
                ItemDb.item_component = item.item_component;


                context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool removeItem(int itemId)
        {
            try
            {
                Item itemDb = context.Items.First(i => i.item_id == itemId);
                context.Items.Remove(itemDb);
                context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public Item viewItemByitemId(int itemId)
        {
            try
            {
                Item item = context.Items.First(i => i.item_id == itemId);
                context.SaveChanges();
                return item;
            }
            catch
            {
                Item item = new Item();
                return item;
            }
        }

        public List<Item> viewAllItem()
        {
            try
            {
                List<Item> itemDBList = context.Items.ToList();
                context.SaveChanges();

                return itemDBList;
            }
            catch
            {
                List<Item> itemDBList = new List<Item>();
                return itemDBList;
            }
        }

        public Item viewPreviousItem()
        {
            try
            {
                var query = from i in context.Items orderby i.item_id descending select i;
                Item itemDb = query.FirstOrDefault<Item>();
                context.SaveChanges();
                return itemDb;
            }
            catch
            {
                Item itemDb = new Item();
                return itemDb;
            }
        }

        // not sure to use
        public List<Item> viewItemComponentbyItemId(int itemId)
        {
            try
            {
                var query = from i in context.Items where i.item_component == itemId select i;
                List<Item> itemList = query.ToList();
                context.SaveChanges();
                return itemList;
            }
            catch
            {
                List<Item> itemList = new List<Item>();
                return itemList;
            }
        }


        public List<string> viewGroupByItemBrand()
        {
            try
            {
                var query = from i in context.Items group i.item_brand by i.item_brand;
                IQueryable<IGrouping<string, string>> groups = query;
                IQueryable<string> queryValue = groups.SelectMany(group => group);

                List<string> itemBrands = queryValue.ToList().Distinct().ToList();
                context.SaveChanges();
                return itemBrands;
            }
            catch
            {
                List<string> itemBrands = new List<string>();
                return itemBrands;
            }
        }
    }
}