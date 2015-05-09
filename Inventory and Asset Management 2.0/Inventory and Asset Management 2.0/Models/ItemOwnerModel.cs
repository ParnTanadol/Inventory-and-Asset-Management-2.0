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

        public List<ItemOwnerModel> viewAllItemOwner()
        {
            try
            {
                IItemOwnerRepo itemOwnerRepo = new ItemOwnerRepo(new INVENTORY_MANAGEMENT_2Entities());
                List<ItemOwner> itemOwnerListDb = new List<ItemOwner>();
                itemOwnerListDb = itemOwnerRepo.viewAllItemOwner();

                List<ItemOwnerModel> itemOwnerModelList = new List<ItemOwnerModel>();
                for (int i = 0; i < itemOwnerListDb.Count; i++)
                {
                    ItemOwnerModel itemOwnerModel = new ItemOwnerModel();
                    itemOwnerModel.itemOwner_id = itemOwnerListDb[i].itemOwner_id;

                    ItemModel itemModel = new ItemModel();
                    itemModel.viewItemModelByItemId(itemOwnerListDb[i].item_id);
                    itemOwnerModel.item_id = itemModel;

                    CAMTUserModel camtUserModel = new CAMTUserModel();
                    camtUserModel.viewUserByuserId(itemOwnerListDb[i].user_id);
                    itemOwnerModel.user_id = camtUserModel;
                    itemOwnerModelList.Add(itemOwnerModel);
                }

                return itemOwnerModelList;
            }
            catch
            {
                List<ItemOwnerModel> itemOwnerModelList = new List<ItemOwnerModel>();
                return itemOwnerModelList;
            }
        }
    }
}