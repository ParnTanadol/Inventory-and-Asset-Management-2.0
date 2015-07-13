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

        public override bool Equals(object obj)
        {
            if (obj is ItemOwnerModel)
            {
                ItemOwnerModel other = (ItemOwnerModel)obj;
                return Equals(other.itemOwner_id, this.itemOwner_id) && Equals(other.item_id, this.item_id) && Equals(other.user_id, this.user_id);
            }
            return false;
        }

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

        public bool updateItemOwner(int itemOwnerId, int userId)
        {
            try
            {
                ItemOwner itemOwner = new ItemOwner();
                itemOwner.itemOwner_id = itemOwnerId;
                itemOwner.user_id = userId;

                IItemOwnerRepo itemOwnerRepo = new ItemOwnerRepo(new INVENTORY_MANAGEMENT_2Entities());
                bool status = itemOwnerRepo.updateItemOwner(itemOwner);

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

        public ItemOwnerModel viewItemOwnerByItemId(int itemId)
        {
            try
            {
                IItemOwnerRepo itemOwnerRepo = new ItemOwnerRepo(new INVENTORY_MANAGEMENT_2Entities());
                ItemOwner itemOwner = new ItemOwner();
                itemOwner = itemOwnerRepo.viewItemOwnerByitemId(itemId);

                this.itemOwner_id = itemOwner.itemOwner_id;

                ItemModel itemModel = new ItemModel();
                itemModel.viewItemModelByItemId(itemOwner.item_id);
                this.item_id = itemModel;

                CAMTUserModel camtUserModel = new CAMTUserModel();
                camtUserModel.viewUserByuserId(itemOwner.user_id);
                this.user_id = camtUserModel;

                return this;
            }
            catch
            {
                ItemOwnerModel itemOwnerModel = new ItemOwnerModel();
                return itemOwnerModel;
            }
        }
        public List<ItemOwnerModel> viewItemOwnerInformation(int itemId)
        {
            try
            {
                List<ItemOwnerModel> itemOwnerModelList = new List<ItemOwnerModel>();
                IItemOwnerRepo itemOwnerRepo = new ItemOwnerRepo(new INVENTORY_MANAGEMENT_2Entities());
                IItemRepo itemRepo = new ItemRepo(new INVENTORY_MANAGEMENT_2Entities());
                List<Item> itemList = new List<Item>();
                itemList = itemRepo.viewItemComponentbyItemId(itemId);

                if(itemList.Count == 0)
                {
                    ItemOwner itemOwner = new ItemOwner();
                    itemOwner = itemOwnerRepo.viewItemOwnerByitemId(itemId);
                    ItemOwnerModel itemOwnerModel = new ItemOwnerModel();
                    itemOwnerModel.itemOwner_id = itemOwner.itemOwner_id;

                    ItemModel itemModel = new ItemModel();
                    itemModel.viewItemModelByItemId(itemOwner.item_id);
                    itemOwnerModel.item_id = itemModel;

                    CAMTUserModel camtUserModel = new CAMTUserModel();
                    camtUserModel.viewUserByuserId(itemOwner.user_id);
                    itemOwnerModel.user_id = camtUserModel;
                    itemOwnerModelList.Add(itemOwnerModel);
                }
                else{
                    ItemOwner itemOwner = new ItemOwner();
                    itemOwner = itemOwnerRepo.viewItemOwnerByitemId(itemId);
                    ItemOwnerModel itemOwnerModel = new ItemOwnerModel();
                    itemOwnerModel.itemOwner_id = itemOwner.itemOwner_id;

                    ItemModel itemModel = new ItemModel();
                    itemModel.viewItemModelByItemId(itemOwner.item_id);
                    itemOwnerModel.item_id = itemModel;

                    CAMTUserModel camtUserModel = new CAMTUserModel();
                    camtUserModel.viewUserByuserId(itemOwner.user_id);
                    itemOwnerModel.user_id = camtUserModel;
                    itemOwnerModelList.Add(itemOwnerModel);

                    for (int i = 0; i < itemList.Count; i++)
                    {
                        ItemOwner itemOwner2 = new ItemOwner();
                        itemOwner2 = itemOwnerRepo.viewItemOwnerByitemId(itemList[i].item_id);
                        ItemOwnerModel itemOwnerModel2 = new ItemOwnerModel();
                        itemOwnerModel2.itemOwner_id = itemOwner2.itemOwner_id;

                        ItemModel itemModel2 = new ItemModel();
                        itemModel2.viewItemModelByItemId(itemOwner2.item_id);
                        itemOwnerModel2.item_id = itemModel2;

                        CAMTUserModel camtUserModel2 = new CAMTUserModel();
                        camtUserModel2.viewUserByuserId(itemOwner2.user_id);
                        itemOwnerModel2.user_id = camtUserModel2;
                        itemOwnerModelList.Add(itemOwnerModel2);
                    }
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