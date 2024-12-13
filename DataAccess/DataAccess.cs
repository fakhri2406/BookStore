using FinalADO.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;

namespace FinalADO.DataAccess
{
    public class DataAccess
    {
        private readonly string connectionString;

        public DataAccess()
        {
            connectionString = ConfigurationManager.ConnectionStrings["BookStoreDB"].ConnectionString;
        }
    }
}
