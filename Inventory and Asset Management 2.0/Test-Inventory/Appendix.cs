using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Test_Inventory
{
    class Appendix
    {
        SqlConnection conn;
        SqlCommand cmd;
        public Appendix()
        {
            conn = new SqlConnection("Server=PARNTANADOL-PC; Database=INVENTORY_MANAGEMENT_2;Trusted_Connection=True;");
            cmd = new SqlCommand();
        }

        // ---------- Add CAMTUser -----------
        public bool addCAMTUser()
        {
            try
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = "USE INVENTORY_MANAGEMENT_2;";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "set IDENTITY_INSERT CAMTUser ON";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "INSERT INTO CAMTUser(user_id, user_username, user_password, user_name, user_department, user_room, user_address, user_tel, user_email, user_type, user_active ) values(1,'admin','123456','admin one', 'CAMT', '512', 'Chiang mai, Thailand', '0833201787', 'se542115021.developer@gmail.com', '1', 1 );";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "INSERT INTO CAMTUser(user_id, user_username, user_password, user_name, user_department, user_room, user_address, user_tel, user_email, user_type, user_active ) values(2,'staff1','123456','staff one', 'CAMT', '113', 'Chiang mai, Thailand', '0833201787', 'se542115021.developer@gmail.com', '2', 1 );";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "INSERT INTO CAMTUser(user_id, user_username, user_password, user_name, user_department, user_room, user_address, user_tel, user_email, user_type, user_active ) values(3,'staff2','123456','staff two', 'CAMT', '114', 'Chiang mai, Thailand', '0833201787', 'se542115021.developer@gmail.com', '2', 1 );";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "INSERT INTO CAMTUser(user_id, user_username, user_password, user_name, user_department, user_room, user_address, user_tel, user_email, user_type, user_active ) values(4,'reporter1','123456','reporter one', 'CAMT', '114', 'Chiang mai, Thailand', '0833201787', 'se542115021.developer@gmail.com', '3', 1 );";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "set IDENTITY_INSERT CAMTUser OFF";
                cmd.ExecuteNonQuery();

                return true;

            }
            catch
            {
                return false;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        // ---------- Add Item -----------
        public bool addItem()
        {
            try
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = "USE INVENTORY_MANAGEMENT_2;";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "set IDENTITY_INSERT Item ON";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "INSERT INTO Item(item_id, item_brand, item_name, item_description, item_startDate, item_endDate, item_status, item_picture, item_cmuNumber, item_camtNumber, item_serialNumber, item_component ) values(1,'Apple','iMac','iMac 27-inch', '2015-05-07 15:35:35.0000000', '2015-06-20 00:00:00.0000000', 1, 'picItem-1.jpg', 'CMU01', 'CAMT01', '', NULL );";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "INSERT INTO Item(item_id, item_brand, item_name, item_description, item_startDate, item_endDate, item_status, item_picture, item_cmuNumber, item_camtNumber, item_serialNumber, item_component ) values(2,'RAM Thailand','RAM','RAM', '2015-05-07 15:35:51.6317728', '2015-07-20 00:00:00.0000000', 1, 'picItem-2.jpg', '', '', 'Serial02', 1 );";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "INSERT INTO Item(item_id, item_brand, item_name, item_description, item_startDate, item_endDate, item_status, item_picture, item_cmuNumber, item_camtNumber, item_serialNumber, item_component ) values(3,'Intel','CPU Iris','CPU Iris core-i7', '2015-06-29 02:21:04.1492112', '2015-08-20 12:00:00.0000000', 1, 'picItem-3.jpg', '', '', 'Serial03', 1 );";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "set IDENTITY_INSERT Item OFF";
                cmd.ExecuteNonQuery();

                return true;

            }
            catch
            {
                return false;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }


        // ---------- Add ItemOwner------------
        public bool addItemOwner()
        {
            try
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = "USE INVENTORY_MANAGEMENT_2;";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "set IDENTITY_INSERT ItemOwner ON";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "INSERT INTO ItemOwner(itemOwner_id, item_id, user_id) values(1, 1, 4);";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "INSERT INTO ItemOwner(itemOwner_id, item_id, user_id) values(2, 2, 4);";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "INSERT INTO ItemOwner(itemOwner_id, item_id, user_id) values(3, 3, 4);";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "set IDENTITY_INSERT ItemOwner OFF";
                cmd.ExecuteNonQuery();

                return true;

            }
            catch
            {
                return false;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        // ---------- Add ItemOwner------------
        public bool addReport()
        {
            try
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = "USE INVENTORY_MANAGEMENT_2;";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "set IDENTITY_INSERT Report ON";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "INSERT INTO Report(report_id, technician_id, reporter_id, item_id, report_typeBroken, report_case, report_contact, report_repairDetail, report_startDate, report_endDate, report_statusComplete, report_recieveMsg) values(1, 2, 4, 1, 'Error about Application of Computer', 'Cannot open Keynote', '0833201787' , 'Complete', '2015-06-09 15:36:48.3488602', '2015-06-10 15:36:48.3488602', 3, 1);";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "INSERT INTO Report(report_id, technician_id, reporter_id, item_id, report_typeBroken, report_case, report_contact, report_repairDetail, report_startDate, report_endDate, report_statusComplete, report_recieveMsg) values(2, 2, 4, 1, 'Error about Application of Computer', 'Cannot open iPhoto', '0833201787' , 'Complete', '2015-06-11 15:36:48.3488602', '2015-06-12 15:36:48.3488602', 3, 1);";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "set IDENTITY_INSERT Report OFF";
                cmd.ExecuteNonQuery();

                return true;

            }
            catch
            {
                return false;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }


        //#######################-----------Delete----------#########################

        // ---------- Delete CAMTUser -----------
        public bool deleteCAMTUser()
        {
            try
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = "USE INVENTORY_MANAGEMENT_2;";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "DELETE FROM CAMTUser;";
                cmd.ExecuteNonQuery();
                return true;

            }
            catch
            {
                return false;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        // ---------- Delete Item -----------
        public bool deleteItem()
        {
            try
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = "USE INVENTORY_MANAGEMENT_2;";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "DELETE FROM Item;";
                cmd.ExecuteNonQuery();
                return true;

            }
            catch
            {
                return false;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        // ---------- Delete ItemOwner -----------
        public bool deleteItemOwner()
        {
            try
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = "USE INVENTORY_MANAGEMENT_2;";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "DELETE FROM ItemOwner;";
                cmd.ExecuteNonQuery();
                return true;

            }
            catch
            {
                return false;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        // ---------- Delete Report -----------
        public bool deleteReport()
        {
            try
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = "USE INVENTORY_MANAGEMENT_2;";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "DELETE FROM Report;";
                cmd.ExecuteNonQuery();
                return true;

            }
            catch
            {
                return false;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

    }
}
