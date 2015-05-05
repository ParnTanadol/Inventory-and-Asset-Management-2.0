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

        public bool insertCAMTUser(string username, string password, string userName, string userDepartment, string userRoom, string userAddress, string userTel, string userEmail, int userType, int userActive)
        {
            try
            {
                CAMTUser camtUser = new CAMTUser();
                camtUser.user_username = username;
                camtUser.user_password = password;
                camtUser.user_name = userName;
                camtUser.user_department = userDepartment;
                camtUser.user_room = userRoom;
                camtUser.user_address = userAddress;
                camtUser.user_tel = userTel;
                camtUser.user_email = userEmail;
                camtUser.user_type = userType;
                if (userActive == 0)
                {
                    camtUser.user_active = false;
                }
                else
                {
                    camtUser.user_active = true;
                }


                ICAMTUserRepo camtUserRepo = new CAMTUserRepo(new INVENTORY_MANAGEMENT_2Entities());
                bool status = camtUserRepo.insertCAMTUser(camtUser);

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
        public bool updateUserActive(int userId, bool userActive)
        {
            try
            {
                ICAMTUserRepo camtUserRepo = new CAMTUserRepo(new INVENTORY_MANAGEMENT_2Entities());
                CAMTUser camtUser = new CAMTUser();
                camtUser = camtUserRepo.viewUserByuserId(userId);
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
    }
}