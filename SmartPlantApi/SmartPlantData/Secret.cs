using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace SmartPlantApiData
{
    internal class Secret
    {
        private const string password = "HkER3A4ebFfdr96yBm5t";
        public const string ConnectionString = "" +
            "Data Source=mssql8.unoeuro.com;" +
            "Initial Catalog=heltengaston_dk_db_database;" +
            "User ID=heltengaston_dk;" +
            $"Password={password};" +
            "Connect Timeout=30;Encrypt=False;" +
            "Trust Server Certificate=True;" +
            "Application Intent=ReadWrite;" +
            "Multi Subnet Failover=False";
    }
}
