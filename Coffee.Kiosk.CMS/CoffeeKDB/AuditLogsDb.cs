using Coffee.Kiosk.CMS.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffee.Kiosk.CMS.CoffeeKDB
{
    internal class AuditLogsDb
    {

        public static Employee? _employee;

        public enum Action
        {
            INSERT,
            UPDATE,
            DELETE 
        }

        public enum Tables
        {
            ACCOUNTS,

            INVENTORY_ITEM,

            CATEGORY,
            PRODUCT,
            PRODUCT_RECIPE,
            MODIFIER_GROUP,
            MODIFIER_OPTION,
            
            CUSTOMER_ORDERS,
            CUSTOMER_ORDER_ITEM,
            CUSTOMER_ORDER_ITEM_MODIFIER,

            KIOSK,
            KIOSK_BANNERS,

            SHOP
        }

        internal static bool AddLogs(
            Tables tableAffected,
            int recordId,
            Action action,
            string summary
            )
        {
            if (_employee == null)
            {
                MessageBox.Show("Failed to auditLogs");
                return false;
            }
            try
            {
                using var conn = new MySqlConnection(DBhelper.connectionStringDatabase);
                conn.Open();

                using var cmd = conn.CreateCommand();
                cmd.CommandText = @"INSERT INTO logs
                (Table_Affected, Record_ID, Action, Changed_By, Changed_By_Name, summary)
                VALUES (@tableAffected, @recordId, @action, @changedBy, @changedByName, @summary)
                                    ;";

                cmd.Parameters.AddWithValue("@tableAffected", tableAffected.ToString());
                cmd.Parameters.AddWithValue("@recordId", recordId);
                cmd.Parameters.AddWithValue("@action", action.ToString());
                cmd.Parameters.AddWithValue("@changedBy", _employee.Id);
                cmd.Parameters.AddWithValue("@changedByName", $"{_employee.FirstName} {_employee.LastName}");
                cmd.Parameters.AddWithValue("@summary", summary);

                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
                return false;
            }
        }
    }
}
