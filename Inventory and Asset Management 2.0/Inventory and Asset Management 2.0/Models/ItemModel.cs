using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Inventory_and_Asset_Management_2._0.Repositories;

namespace Inventory_and_Asset_Management_2._0.Models
{
    public class ItemModel
    {

        public int item_id { get; set; }
        public string item_brand { get; set; }
        public string item_name { get; set; }
        public string item_description { get; set; }
        public System.DateTime item_startDate { get; set; }
        public Nullable<System.DateTime> item_endDate { get; set; }
        public int item_status { get; set; }
        public string item_picture { get; set; }
        public string item_cmuNumber { get; set; }
        public string item_camtNumber { get; set; }
        public string item_serialNumber { get; set; }
        public ItemModel item_component { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is ItemModel)
            {
                ItemModel other = (ItemModel)obj;
                return Equals(other.item_id, this.item_id) && Equals(other.item_brand, this.item_brand) && Equals(other.item_name, this.item_name) && Equals(other.item_description, this.item_description) && Equals(other.item_startDate, this.item_startDate) && Equals(other.item_endDate, this.item_endDate) && Equals(other.item_status, this.item_status) && Equals(other.item_picture, this.item_picture) && Equals(other.item_cmuNumber, this.item_cmuNumber) && Equals(other.item_camtNumber, this.item_camtNumber) && Equals(other.item_serialNumber, this.item_serialNumber) && Equals(other.item_component, this.item_component);
            }
            return false;
        }

        public bool insertItem(string itemBrand, string itemName, string itemDescription, DateTime itemStartDate, Nullable<DateTime> itemEndDate, int itemStatus, string item_cmuNumber, string item_camtNumber, string item_serialNumber, Nullable<int> itemComponent)
        {
            try
            {
                Item item = new Item();
                item.item_brand = itemBrand;
                item.item_name = itemName;
                item.item_description = itemDescription;
                item.item_startDate = itemStartDate;
                item.item_endDate = itemEndDate;
                item.item_status = itemStatus;
                item.item_picture = null;
                item.item_cmuNumber = item_cmuNumber;
                item.item_camtNumber = item_camtNumber;
                item.item_serialNumber = item_serialNumber;
                item.item_component = itemComponent;


                IItemRepo itemRepo = new ItemRepo(new INVENTORY_MANAGEMENT_2Entities());
                bool status = itemRepo.insertItem(item);

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


        public bool updateItem(int itemId, string itemBrand, string itemName, string itemDescription, DateTime itemStartDate, Nullable<DateTime> itemEndDate, int itemStatus, string itemPicture, string item_cmuNumber, string item_camtNumber, string item_serialNumber, Nullable<int> itemComponent)
        {
            try
            {
                Item item = new Item();
                item.item_id = itemId;
                item.item_brand = itemBrand;
                item.item_name = itemName;
                item.item_description = itemDescription;
                item.item_startDate = itemStartDate;
                item.item_endDate = itemEndDate;
                item.item_status = itemStatus;
                item.item_picture = itemPicture;
                item.item_cmuNumber = item_cmuNumber;
                item.item_camtNumber = item_camtNumber;
                item.item_serialNumber = item_serialNumber;
                item.item_component = itemComponent;

                IItemRepo itemRepo = new ItemRepo(new INVENTORY_MANAGEMENT_2Entities());
                bool status = itemRepo.updateItem(item);
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

        public ItemModel viewPreviousItem()
        {
            try
            {
                IItemRepo itemRepo = new ItemRepo(new INVENTORY_MANAGEMENT_2Entities());
                Item itemDb = new Item();
                itemDb = itemRepo.viewPreviousItem();

                this.item_id = itemDb.item_id;
                this.item_brand = itemDb.item_brand;
                this.item_name = itemDb.item_name;
                this.item_description = itemDb.item_description;
                this.item_startDate = itemDb.item_startDate;
                this.item_endDate = itemDb.item_endDate;
                this.item_status = itemDb.item_status;
                this.item_picture = itemDb.item_picture;
                this.item_cmuNumber = itemDb.item_cmuNumber;
                this.item_camtNumber = itemDb.item_camtNumber;
                this.item_serialNumber = itemDb.item_serialNumber;
                if (itemDb.item_component != null)
                {
                    int itemComponent = int.Parse(itemDb.item_component.ToString());
                    ItemModel itemModel = new ItemModel();
                    itemModel.viewItemModelByItemId(itemComponent);
                    this.item_component = itemModel;

                }
                else
                {
                    ItemModel itemModel = new ItemModel();
                    this.item_component = itemModel;
                }
                return this;
            }
            catch
            {
                return this;
            }
        }


        public ItemModel viewItemModelByItemId(int itemId)
        {
            try
            {
                IItemRepo itemRepo = new ItemRepo(new INVENTORY_MANAGEMENT_2Entities());
                Item itemDb = new Item();
                itemDb = itemRepo.viewItemByitemId(itemId);

                this.item_id = itemDb.item_id;
                this.item_brand = itemDb.item_brand;
                this.item_name = itemDb.item_name;
                this.item_description = itemDb.item_description;
                this.item_startDate = itemDb.item_startDate;
                this.item_endDate = itemDb.item_endDate;
                this.item_picture = itemDb.item_picture;
                this.item_cmuNumber = itemDb.item_cmuNumber;
                this.item_camtNumber = itemDb.item_camtNumber;
                this.item_serialNumber = itemDb.item_serialNumber;
                this.item_status = itemDb.item_status;
                if (itemDb.item_component != null)
                {
                    int itemComponent = int.Parse(itemDb.item_component.ToString());
                    ItemModel itemModel = new ItemModel();
                    itemModel.viewItemModelByItemId(itemComponent);
                    this.item_component = itemModel;

                }
                else
                {
                    ItemModel itemModel = new ItemModel();
                    this.item_component = itemModel;
                }

                return this;
            }
            catch
            {
                return this;
            }
        }
        
        public ItemModel viewItemModelbySerialNum(string serialNumber)
        {
            try
            {
                IItemRepo itemRepo = new ItemRepo(new INVENTORY_MANAGEMENT_2Entities());
                Item itemDb = new Item();
                itemDb = itemRepo.viewItemModelbySerialNum(serialNumber);

                this.item_id = itemDb.item_id;
                this.item_brand = itemDb.item_brand;
                this.item_name = itemDb.item_name;
                this.item_description = itemDb.item_description;
                this.item_startDate = itemDb.item_startDate;
                this.item_endDate = itemDb.item_endDate;
                this.item_picture = itemDb.item_picture;
                this.item_cmuNumber = itemDb.item_cmuNumber;
                this.item_camtNumber = itemDb.item_camtNumber;
                this.item_serialNumber = itemDb.item_serialNumber;
                this.item_status = itemDb.item_status;
                if (itemDb.item_component != null)
                {
                    int itemComponent = int.Parse(itemDb.item_component.ToString());
                    ItemModel itemModel = new ItemModel();
                    itemModel.viewItemModelByItemId(itemComponent);
                    this.item_component = itemModel;

                }
                else
                {
                    ItemModel itemModel = new ItemModel();
                    this.item_component = itemModel;
                }

                return this;
            }
            catch
            {
                return this;
            }
        }

        public List<ItemModel> viewExpireItem(DateTime timeStart, DateTime timeEnd)
        {
            try
            {
                List<Item> itemList = new List<Item>();
                IItemRepo itemRepo = new ItemRepo(new INVENTORY_MANAGEMENT_2Entities());
                itemList = itemRepo.viewExpireItem(timeStart, timeEnd);

                List<ItemModel> itemModelList = new List<ItemModel>();

                for (int i = 0; i < itemList.Count; i++)
                {
                    ItemModel itemModel = new ItemModel();
                    itemModel.item_id = itemList[i].item_id;
                    itemModel.item_brand = itemList[i].item_brand;
                    itemModel.item_name = itemList[i].item_name;
                    itemModel.item_description = itemList[i].item_description;
                    itemModel.item_startDate = itemList[i].item_startDate;
                    itemModel.item_endDate = itemList[i].item_endDate;
                    itemModel.item_picture = itemList[i].item_picture;
                    itemModel.item_cmuNumber = itemList[i].item_cmuNumber;
                    itemModel.item_camtNumber = itemList[i].item_camtNumber;
                    itemModel.item_serialNumber = itemList[i].item_serialNumber;
                    itemModel.item_status = itemList[i].item_status;

                    if (itemList[i].item_component != null)
                    {
                        int itemComponent = int.Parse(itemList[i].item_component.ToString());
                        ItemModel itemModel2 = new ItemModel();
                        itemModel2.viewItemModelByItemId(itemComponent);
                        itemModel.item_component = itemModel2;

                    }
                    else
                    {
                        ItemModel itemModel2 = new ItemModel();
                        itemModel.item_component = itemModel2;
                    }
                    itemModelList.Add(itemModel);
                }

                return itemModelList;

            }
            catch
            {
                List<ItemModel> itemModelList = new List<ItemModel>();
                return itemModelList;
            }
        }
         
        public List<string> viewGroupByItemBrand()
        {
            try
            {
                IItemRepo itemRepo = new ItemRepo(new INVENTORY_MANAGEMENT_2Entities());
                List<string> itemBrands = itemRepo.viewGroupByItemBrand();
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