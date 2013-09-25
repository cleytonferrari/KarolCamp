using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Bson.Serialization.Options;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.GridFS;

namespace KarolCamp.UI.Web.Repositorio
{
    public class Contexto<T>
    {
        private readonly MongoDatabase database;

        private static string GetMongoDbConnectionString()
        {
            return ConfigurationManager.AppSettings.Get("MONGOLAB_URI") ??
                   ConfigurationManager.ConnectionStrings["KarolCamp"].ConnectionString;
        }

        public Contexto()
        {
            var url = new MongoUrl(GetMongoDbConnectionString());
            var client = new MongoClient(url);
            var server = client.GetServer();
            database = server.GetDatabase(url.DatabaseName);
            Collection = database.GetCollection<T>(typeof(T).Name.ToLower());
            DateTimeSerializationOptions.Defaults = new DateTimeSerializationOptions(DateTimeKind.Local, BsonType.Document);

            //Ajuda no migration, se tiver campo a mais no banco ele ignora
            var convensoes = new ConventionProfile();
            convensoes.SetIgnoreExtraElementsConvention(new AlwaysIgnoreExtraElementsConvention());
            BsonClassMap.RegisterConventions(convensoes, (type) => true);
        }

        public MongoCollection<T> Collection { get; private set; }

        public Dictionary<string, string> BuscarArquivo(string id, ref MemoryStream retorno)
        {
            var fileInfo = database.GridFS.FindOne(Query.EQ("_id", new BsonObjectId(id)));
            var gfs = new MongoGridFS(database);
            gfs.Download(retorno, fileInfo);
            return new Dictionary<string, string> { { fileInfo.ContentType, fileInfo.Name } };
        }

        public void ExcluirArquivo(string id)
        {
            //Todo: verificar que não esta excluido a foto
            var gfs = new MongoGridFS(database);
            gfs.Delete(Query.EQ("_id", new BsonObjectId(id)));
        }

        public string InserirArquivo(Stream arquivo, string nome, string contentType)
        {
            var gfs = new MongoGridFS(database);
            var fileInfo = gfs.Upload(arquivo, nome);
            gfs.SetContentType(fileInfo, contentType);
            return fileInfo.Id.AsObjectId.ToString();
        }
    }
}