using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WifiApi.Models;
using MongoDB.Driver;

namespace WifiApi.Services
{
    public class WifiService
    {
        private readonly IMongoCollection<Wifi> _wifi;

        public WifiService(IWifiApiDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _wifi = database.GetCollection<Wifi>(settings.WifiCollectionName);
        }

        public List<Wifi> GetAll() =>
           _wifi.Find(wifi => true).ToList();

        public Wifi GetOne(string name) =>
            _wifi.Find<Wifi>(wifi => wifi.Name == name).FirstOrDefault();

        public Wifi GetNearest(string latitude, string longitude) =>
            _wifi.Find<Wifi>(wifi => wifi.Latitude == latitude && wifi.Longitude == longitude).FirstOrDefault();

        public Wifi Create(Wifi wifi)
        {
            _wifi.InsertOne(wifi);
            return wifi;
        }
        public void Update(string id, Wifi updatedWifi) =>
            _wifi.ReplaceOne(wifi => wifi.Id == id, updatedWifi);

        public void Remove(Wifi wifiToRemove) =>
            _wifi.DeleteOne(wifi => wifi.Id == wifiToRemove.Id);

        public void Remove(string id) =>
            _wifi.DeleteOne(wifi => wifi.Id == id);
    }
}
