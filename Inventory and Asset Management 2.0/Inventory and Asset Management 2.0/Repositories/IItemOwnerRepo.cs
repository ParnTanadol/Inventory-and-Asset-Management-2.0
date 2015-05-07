using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_and_Asset_Management_2._0.Repositories
{
    public interface IItemOwnerRepo
    {
        bool insertItemOwner(ItemOwner itemOwner);
        bool updateItemOwner(ItemOwner itemOwner);
        ItemOwner viewItemOwnerByitemIdUserId(int itemId, int userId);
        ItemOwner viewItemOwnerByItemOwnerId(int itemOwnerId);
        List<ItemOwner> viewAllItemOwner();
    }
}
