using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WifiApi.Models
{
    public class WifiApiDatabaseSettings : IWifiApiDatabaseSettings
    {
        public string WifiCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IWifiApiDatabaseSettings
    {
        string WifiCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
