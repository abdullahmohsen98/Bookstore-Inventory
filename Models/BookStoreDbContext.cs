using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bookstore.Models
{

    public class BookStoreDbContext
    {
        public string MongoConnectinString = ConfigurationManager.AppSettings["MongoConnectinString"];
        public string MongoDatabaseName = ConfigurationManager.AppSettings["MongoDatabaseName"];
        public IMongoDatabase Database;
        public BookStoreDbContext()
        {
            var context = new MongoClient(MongoConnectinString);
            Database = context.GetDatabase(MongoDatabaseName);
        }
        public IMongoCollection<Books> BooksCollection
        {
            get
            {
                return Database.GetCollection<Books>("Books");
            }
        }

       
    }
}