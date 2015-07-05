using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Inventory_and_Asset_Management_2._0.Repositories;

namespace Inventory_and_Asset_Management_2._0.Models
{
    public class CAMTUserModel
    {
        public int user_id { get; set; }
        public string user_username { get; set; }
        public string user_password { get; set; }
        public string user_name { get; set; }
        public string user_department { get; set; }
        public string user_room { get; set; }
        public string user_address { get; set; }
        public string user_tel { get; set; }
        public string user_email { get; set; }
        public int user_type { get; set; }
        public bool user_active { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is CAMTUserModel)
            {
                CAMTUserModel other = (CAMTUserModel)obj;
                return Equals(other.user_id, this.user_id) && Equals(other.user_username, this.user_username) && Equals(other.user_password, this.user_password) && Equals(other.user_name, this.user_name) && Equals(other.user_department, this.user_department) && Equals(other.user_room, this.user_room) && Equals(other.user_address, this.user_address) && Equals(other.user_tel, this.user_tel) && Equals(other.user_email, this.user_email) && Equals(other.user_type, this.user_type);
            }
            return false;
        }

        public bool insertCAMTUser(string username, string password, string name, string dpartment, string room, string address, string tel, string email, int type, int active)
        {
            try
            {
                ICAMTUserRepo camtUserRepo = new CAMTUserRepo(new INVENTORY_MANAGEMENT_2Entities());
                CAMTUser camtUser = new CAMTUser();
                camtUser = camtUserRepo.viewUserByUsername(username);

                if (camtUser.user_id == 0)
                {
                    CAMTUser camtUser2 = new CAMTUser();
                    camtUser2.user_username = username;
                    camtUser2.user_password = password;
                    camtUser2.user_name = name;
                    camtUser2.user_department = dpartment;
                    camtUser2.user_room = room;
                    camtUser2.user_address = address;
                    camtUser2.user_tel = tel;
                    camtUser2.user_email = email;
                    camtUser2.user_type = type;
                    if (active == 0)
                    {
                        camtUser2.user_active = false;
                    }
                    else
                    {
                        camtUser2.user_active = true;
                    }

                    bool status = camtUserRepo.insertCAMTUser(camtUser2);

                    if (status == true)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
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

        public bool updateCAMTUser(int userId, string username, string password, string userName, string userDepartment, string userRoom, string userAddress, string userTel, string userEmail, int userType, bool userActive)
        {
            try
            {
                ICAMTUserRepo camtUserRepo = new CAMTUserRepo(new INVENTORY_MANAGEMENT_2Entities());
                CAMTUser camtUser = new CAMTUser();
                camtUser = camtUserRepo.viewUserByuserId(userId);

                    camtUser.user_id = userId;
                    camtUser.user_username = username;
                    camtUser.user_password = password;
                    camtUser.user_name = userName;
                    camtUser.user_department = userDepartment;
                    camtUser.user_room = userRoom;
                    camtUser.user_address = userAddress;
                    camtUser.user_tel = userTel;
                    camtUser.user_email = userEmail;
                    camtUser.user_type = userType;
                    camtUser.user_active = userActive;

                    bool status = camtUserRepo.updateCAMTUser(camtUser);
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

        public bool updateCAMTUserPass(int userId, string password)
        {
            try
            {
                ICAMTUserRepo camtUserRepo = new CAMTUserRepo(new INVENTORY_MANAGEMENT_2Entities());
                CAMTUser camtUser = new CAMTUser();
                camtUser = camtUserRepo.viewUserByuserId(userId);

                camtUser.user_id = userId;
                camtUser.user_password = password;

                bool status = camtUserRepo.updateCAMTUser(camtUser);
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

        public CAMTUserModel loginUser(string username, string password)
        {
            try
            {

                ICAMTUserRepo camtUserRepo = new CAMTUserRepo(new INVENTORY_MANAGEMENT_2Entities());
                CAMTUser camtUser = camtUserRepo.viewUserByUsernamePassword(username, password);

                this.user_id = camtUser.user_id;
                this.user_username = camtUser.user_username;
                this.user_password = camtUser.user_password;
                this.user_name = camtUser.user_name;
                this.user_department = camtUser.user_department;
                this.user_room = camtUser.user_room;
                this.user_address = camtUser.user_address;
                this.user_tel = camtUser.user_tel;
                this.user_email = camtUser.user_email;
                this.user_type = camtUser.user_type;
                this.user_active = camtUser.user_active;
                return this;

            }
            catch
            {
                return this;
            }
        }

        public bool removeCAMTUser(int userId)
        {
            try
            {
                ICAMTUserRepo camtUserRepo = new CAMTUserRepo(new INVENTORY_MANAGEMENT_2Entities());
                bool status = camtUserRepo.removeCAMTUser(userId);
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

        public List<CAMTUserModel> viewAllUserByUserType(int userType)
        {
            try
            {
                ICAMTUserRepo camtUserRepo = new CAMTUserRepo(new INVENTORY_MANAGEMENT_2Entities());
                List<CAMTUser> camtUserList = new List<CAMTUser>();
                camtUserList = camtUserRepo.viewAllUserByUserType(userType);

                List<CAMTUserModel> camtUserModelList = new List<CAMTUserModel>();

                for (int i = 0; i < camtUserList.Count; i++)
                {
                    CAMTUserModel camtUserModel = new CAMTUserModel();
                    camtUserModel.user_id = camtUserList[i].user_id;
                    camtUserModel.user_username = camtUserList[i].user_username;
                    camtUserModel.user_password = camtUserList[i].user_password;
                    camtUserModel.user_name = camtUserList[i].user_name;
                    camtUserModel.user_department = camtUserList[i].user_department;
                    camtUserModel.user_room = camtUserList[i].user_room;
                    camtUserModel.user_address = camtUserList[i].user_address;
                    camtUserModel.user_tel = camtUserList[i].user_tel;
                    camtUserModel.user_email = camtUserList[i].user_email;
                    camtUserModel.user_type = camtUserList[i].user_type;
                    camtUserModel.user_active = camtUserList[i].user_active;
                    camtUserModelList.Add(camtUserModel);
                }
                return camtUserModelList;
            }
            catch
            {
                List<CAMTUserModel> camtUserModelList = new List<CAMTUserModel>();
                return camtUserModelList;
            }
        }

        public List<CAMTUserModel> viewAllCAMTUser()
        {
            try
            {
                ICAMTUserRepo camtUserRepo = new CAMTUserRepo(new INVENTORY_MANAGEMENT_2Entities());
                List<CAMTUser> camtUserList = new List<CAMTUser>();
                camtUserList = camtUserRepo.viewAllCAMTUser();

                List<CAMTUserModel> camtUserModelList = new List<CAMTUserModel>();

                for (int i = 0; i < camtUserList.Count; i++)
                {
                    CAMTUserModel camtUserModel = new CAMTUserModel();
                    camtUserModel.user_id = camtUserList[i].user_id;
                    camtUserModel.user_username = camtUserList[i].user_username;
                    camtUserModel.user_password = camtUserList[i].user_password;
                    camtUserModel.user_name = camtUserList[i].user_name;
                    camtUserModel.user_department = camtUserList[i].user_department;
                    camtUserModel.user_room = camtUserList[i].user_room;
                    camtUserModel.user_address = camtUserList[i].user_address;
                    camtUserModel.user_tel = camtUserList[i].user_tel;
                    camtUserModel.user_email = camtUserList[i].user_email;
                    camtUserModel.user_type = camtUserList[i].user_type;
                    camtUserModel.user_active = camtUserList[i].user_active;
                    camtUserModelList.Add(camtUserModel);
                }
                return camtUserModelList;
            }
            catch
            {
                List<CAMTUserModel> camtUserModelList = new List<CAMTUserModel>();
                return camtUserModelList;
            }
        }

        public CAMTUserModel viewUserByuserId(int userId)
        {
            try
            {
                CAMTUser camtUser = new CAMTUser();
                ICAMTUserRepo camtUserRepo = new CAMTUserRepo(new INVENTORY_MANAGEMENT_2Entities());
                camtUser = camtUserRepo.viewUserByuserId(userId);

                this.user_id = camtUser.user_id;
                this.user_username = camtUser.user_username;
                this.user_password = camtUser.user_password;
                this.user_name = camtUser.user_name;
                this.user_department = camtUser.user_department;
                this.user_room = camtUser.user_room;
                this.user_address = camtUser.user_address;
                this.user_tel = camtUser.user_tel;
                this.user_email = camtUser.user_email;
                this.user_type = camtUser.user_type;
                this.user_active = camtUser.user_active;
                return this;
            }
            catch
            {
                return this;
            }
        }
    }
}