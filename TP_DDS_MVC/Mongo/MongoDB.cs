using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using System.IO;
using Microsoft.Ajax.Utilities;
using System.Management.Instrumentation;

namespace TP_DDS_MVC.Mongo
{
    public class MongoDB
    {

        public static MongoDB instancia = null;

        public static void insertarDocumento(string tipoEntidad, string tipoOperacion, BsonDocument documento)
        {
            MongoClient dbClient = new MongoClient();
            var database = dbClient.GetDatabase("logGeSoc");
            var collection = database.GetCollection<BsonDocument>("operaciones");

            var doc = new BsonDocument { { "tipoEntidad", tipoEntidad }, { "tipoOperacion", tipoOperacion }, documento };

            collection.InsertOne(doc);

    }

    public static List<BsonDocument> leerDeMongo()
        {
            MongoClient dbClient = new MongoClient();

            var dbList = dbClient.ListDatabases().ToList();
            var database = dbClient.GetDatabase("logGeSoc");
            var collection = database.GetCollection<BsonDocument>("operaciones");

            var docs = collection.Find(new BsonDocument()).ToList();

            return docs;

            /*
            var filter = Builders<BsonDocument>.Filter.AnyEq("name", "holaaa");
                //Eq("exam", 1);

            var doc = collection.Find(filter);
            var arrayOfStrings = doc.ToString();
            Console.WriteLine(arrayOfStrings);*/
        }



    }
}