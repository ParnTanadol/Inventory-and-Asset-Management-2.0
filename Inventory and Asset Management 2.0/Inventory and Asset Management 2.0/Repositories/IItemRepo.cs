using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_and_Asset_Management_2._0.Repositories
{
    public interface IItemRepo
    {
        bool insertItem(Item item);
        bool updateItem(Item item);

        bool updateItemComponent(Item item);
        Item viewItemByitemId(int itemId);
        Item viewPreviousItem();
        List<Item> viewItemComponentbyItemId(int itemId);

        Item viewItemModelbySerialNum(string serialNumber);
        List<string> viewGroupByItemBrand();
        List<Item> viewExpireItem(DateTime timeStart, DateTime timeEnd);
        List<List<string>> viewOftenBrokenBrand();
        List<List<string>> viewOftenBrokenName();
    }
}
