using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace RecordCollection.Model.DAL
{
    public class DALBase
    {

        private static string _connectionstring;

        static DALBase() {

            _connectionstring = WebConfigurationManager.ConnectionStrings["RecordCollectionConnectionString"].ConnectionString;
           
            
        }

        #region CreateConnection

        protected SqlConnection CreateConnection() {

            return new SqlConnection(_connectionstring);
        }

        #endregion

    }
}