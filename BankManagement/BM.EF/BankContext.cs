using BM.EF.Properties;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.EF
{
    public class BankContext
    {
        public IMongoDatabase Database;

        public BankContext()
        {
            var ConnectionString = Settings.Default.DBConnectionString;
            var settings = MongoClientSettings.FromUrl(new MongoUrl(ConnectionString));
            var Client = new MongoClient(settings);
            Database = Client.GetDatabase(Settings.Default.DatabaseName);
        }

        public IMongoCollection<Bank> Bank => Database.GetCollection<Bank>("bank");
    }
}
