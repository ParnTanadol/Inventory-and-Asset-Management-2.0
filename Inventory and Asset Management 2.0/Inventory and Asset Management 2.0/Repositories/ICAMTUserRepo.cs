using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_and_Asset_Management_2._0.Repositories
{
    public interface ICAMTUserRepo
    {
        bool insertCAMTUser(CAMTUser user);
        bool updateCAMTUser(CAMTUser user);
        bool removeCAMTUser(int userId);
        CAMTUser viewUserByUsernamePassword(string usernameUser, string passwordUser);
        CAMTUser viewUserByuserId(int userId);
        List<CAMTUser> viewAllUserByUserType(int userType);
        List<CAMTUser> viewAllCAMTUser();
    }
}
