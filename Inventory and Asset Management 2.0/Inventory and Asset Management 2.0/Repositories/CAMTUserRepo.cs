using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventory_and_Asset_Management_2._0.Repositories
{
    public class CAMTUserRepo : ICAMTUserRepo
    {
        private INVENTORY_MANAGEMENT_2Entities context;
        public CAMTUserRepo(INVENTORY_MANAGEMENT_2Entities context)
        {
            this.context = context;
        }


        public bool insertCAMTUser(CAMTUser user)
        {
            try
            {
                context.CAMTUsers.Add(user);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool updateCAMTUser(CAMTUser user)
        {
            try
            {
                CAMTUser camtUserDb = context.CAMTUsers.First(i => i.user_id == user.user_id);

                camtUserDb.user_id = user.user_id;
                camtUserDb.user_username = user.user_username;
                camtUserDb.user_password = user.user_password;
                camtUserDb.user_name = user.user_name;
                camtUserDb.user_department = user.user_department;
                camtUserDb.user_room = user.user_room;
                camtUserDb.user_address = user.user_address;
                camtUserDb.user_tel = user.user_tel;
                camtUserDb.user_email = user.user_email;
                camtUserDb.user_type = user.user_type;
                camtUserDb.user_active = user.user_active;

                context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool removeCAMTUser(int userId)
        {
            try
            {
                CAMTUser camtUserDb = context.CAMTUsers.First(i => i.user_id == userId);
                context.CAMTUsers.Remove(camtUserDb);
                context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public CAMTUser viewUserByUsernamePassword(string usernameUser, string passwordUser)
        {
            try
            {
                CAMTUser camtUser = context.CAMTUsers.First(i => i.user_username == usernameUser && i.user_password == passwordUser);
                context.SaveChanges();
                return camtUser;
            }
            catch
            {
                CAMTUser camtUser = new CAMTUser();
                return camtUser;
            }
        }

        public CAMTUser viewUserByuserId(int userId)
        {
            try
            {
                CAMTUser camtUser = context.CAMTUsers.First(i => i.user_id == userId);
                context.SaveChanges();
                return camtUser;
            }
            catch
            {
                CAMTUser camtUser = new CAMTUser();
                return camtUser;
            }
        }

        public List<CAMTUser> viewAllUserByUserType(int userType)
        {
            try
            {
                var query = from i in context.CAMTUsers where i.user_type == userType select i;
                List<CAMTUser> camtUserList = query.ToList();
                context.SaveChanges();
                return camtUserList;
            }
            catch
            {
                List<CAMTUser> camtUserList = new List<CAMTUser>();
                return camtUserList;
            }
        }

        public List<CAMTUser> viewAllCAMTUser()
        {
            try
            {
                List<CAMTUser> camtUserDBList = context.CAMTUsers.ToList();
                context.SaveChanges();

                return camtUserDBList;
            }
            catch
            {
                List<CAMTUser> camtUserDBList = new List<CAMTUser>();
                return camtUserDBList;
            }
        }


        public List<CAMTUser> viewAllUserByUserTypeActive(int userType, bool userActive)
        {
            try
            {
                var query = from i in context.CAMTUsers where i.user_type == userType && i.user_active == userActive select i;
                List<CAMTUser> camtUserList = query.ToList();
                context.SaveChanges();
                return camtUserList;
            }
            catch
            {
                List<CAMTUser> camtUserList = new List<CAMTUser>();
                return camtUserList;
            }
        }


        public CAMTUser viewUserByUsername(string username)
        {
            try
            {
                CAMTUser camtUser = context.CAMTUsers.First(i => i.user_username == username);
                context.SaveChanges();
                return camtUser;
            }
            catch
            {
                CAMTUser camtUser = new CAMTUser();
                return camtUser;
            }
        }
    }
}