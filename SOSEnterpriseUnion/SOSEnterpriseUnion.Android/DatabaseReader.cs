using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MySql.Data.MySqlClient;
using SOSEnterpriseUnion.Models;
using SOSEnterpriseUnion.Services;

namespace SOSEnterpriseUnion.Droid
{
    public class DatabaseReader : IDataStore<Gradiliste>
    {
        public DatabaseReader()
        {
        }

        public Task<bool> AddItemAsync(Gradiliste item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Gradiliste> GetItemAsync(string id)
        {
            var connectionString = "Server = 93.87.76.33; Port = 3306; Database = tbau; Uid = root; Pwd = soseu";
            var queryString = "select * from tbau.gradilista";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(queryString, connection);
                command.Connection.Open();
                var reader = command.ExecuteReader();
                while (reader.NextResult())
                {
                    var result = reader["NazivGra"];
                }
            }

            return null;
        }

        public Task<IEnumerable<Gradiliste>> GetItemsAsync(bool forceRefresh = false)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateItemAsync(Gradiliste item)
        {
            throw new NotImplementedException();
        }
    }
}