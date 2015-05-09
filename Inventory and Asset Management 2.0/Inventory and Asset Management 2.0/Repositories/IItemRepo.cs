﻿using System;
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
        bool removeItem(int itemId);
        Item viewItemByitemId(int itemId);
        List<Item> viewAllItem();
        Item viewPreviousItem();
        List<Item> viewItemComponentbyItemId(int itemId);
        List<string> viewGroupByItemBrand();
    }
}