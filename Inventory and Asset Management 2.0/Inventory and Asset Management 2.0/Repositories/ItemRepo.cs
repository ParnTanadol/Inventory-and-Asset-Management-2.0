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

        public bool updateItemComponent(Item item)
        {
            try
            {
                Item ItemDb = context.Items.First(i => i.item_id == item.item_id);
                ItemDb.item_component = item.item_component;
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


        public Item viewItemModelbySerialNum(string serialNumber)
        {
            try
            {
                try
                {
                    Item item = context.Items.First(i => i.item_cmuNumber == serialNumber);
                    context.SaveChanges();
                    return item;
                }
                catch
                {
                    try
                    {
                        Item item = context.Items.First(i => i.item_camtNumber == serialNumber);
                        context.SaveChanges();
                        return item;
                    }
                    catch
                    {
                        try
                        {
                            Item item = context.Items.First(i => i.item_serialNumber == serialNumber);
                            context.SaveChanges();
                            return item;
                        }
                        catch
                        {
                            Item item = new Item();
                            return item;
                        }
                    }
                }

            }
            catch
            {
                Item item = new Item();
                return item;
            }
        }


        public List<Item> viewExpireItem(DateTime timeStart, DateTime timeEnd)
        {
            try
            {
                /*
                 var events = this.coreDomainContext.Events.Where(
                    e => e.EventDate.Value.Date >= DateTime.Today
                      && e.EventDate.Value.Date <= endPeriod.Date)
                    .OrderByDescending(e => e.EventDate)
                    .ToList();
                 * */
                var query = context.Items.Where(i => i.item_endDate >= timeStart && i.item_endDate <= timeEnd).OrderByDescending(i => i.item_endDate).ToList();
                List<Item> itemList = query.ToList();
                return itemList;
            }
            catch
            {
                List<Item> itemList = new List<Item>();
                return itemList;
            }
        }

        
        public List<List<string>> viewOftenBrokenBrand()
        {
            try
            {
                /*
                from s in db.Services
                join sa in db.ServiceAssignments on s.Id equals sa.ServiceId
                where sa.LocationId == 1
                select s 
                */
               /*
                var query = from i in context.Items group i.item_brand by i.item_brand;
                IQueryable<IGrouping<string, string>> groups = query;
                IQueryable<string> queryValue = groups.SelectMany(group => group);

                List<string> itemBrands = queryValue.ToList().Distinct().ToList();
                context.SaveChanges();
                return itemBrands;
                */

                var query = (from i in context.Items join j in context.Reports on i.item_id equals j.item_id group i.item_brand by i.item_brand into g select new { brand = g.Key, count = g.Count() }).OrderByDescending(i => i.count).ToList();
                List<List<string>> itemList = new List<List<string>>();
                foreach (var i in query)
                {          
                    List<string> item = new List<string>();
                    item.Add(i.brand);
                    item.Add(i.count.ToString());
                    itemList.Add(item);
                }
                context.SaveChanges();
                return itemList;
            }
            catch
            {
                List<List<string>> itemList = new List<List<string>>();
                return itemList;
            }
        }


        public List<List<string>> viewOftenBrokenName()
        {
            try
            {
                var query = (from i in context.Items join j in context.Reports on i.item_id equals j.item_id group i.item_name by i.item_name into g select new { name = g.Key, count = g.Count() }).OrderByDescending(i => i.count).ToList();
                List<List<string>> itemList = new List<List<string>>();
                foreach (var i in query)
                {
                    List<string> item = new List<string>();
                    item.Add(i.name);
                    item.Add(i.count.ToString());
                    itemList.Add(item);
                }
                context.SaveChanges();
                return itemList;
            }
            catch
            {
                List<List<string>> itemList = new List<List<string>>();
                return itemList;
            }
        }
    }
}