using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RecordCollection.Model.DAL
{
    public class DALBase
    {

        private static string _connectionstring;

        static DALBase() { 
        
            //TODO: IMPLEMENTERA DALBASE-KONSTRUKTORN, TILLDELA FÄLTET _connectionstring
            //TODO: SKAPA EN CONNECTIONSTRING!!!!!!!!!!!!!
        }

        #region CreateConnection

        protected SqlConnection CreateConnection() {

            //TODO: IMPLEMENTERA DALBASE - CreateConnection()

            throw new NotImplementedException();
        }

        #endregion

    }
}