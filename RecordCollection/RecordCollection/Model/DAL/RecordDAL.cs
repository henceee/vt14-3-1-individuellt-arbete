using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecordCollection.Model.DAL
{
    public class RecordDAL: DALBase
    {
        #region DeleteRecord

        public void DeleteRecord(int RecordID)
        {
            throw new NotImplementedException();

            ////using (var conn = CreateConnection()) {

            ////    try
            ////    {
            ////        //TODO: IMPLEMENTERA RECORDDAL - DeleteRecord()
                    

            ////    }
            ////    catch {


            ////        throw new ApplicationException("An error occured while getting customers from the database.");
            ////    }
            //}
        
        }

        #endregion

        #region GetRecords

        public IEnumerable<Record> GetRecords()
        {
            throw new NotImplementedException();

            //using (var conn = CreateConnection())
            //{

            //    try
            //    {
            //        //TODO: IMPLEMENTERA RECORDDAL - GetRecords()


            //    }
            //    catch
            //    {


            //        throw new ApplicationException("An error occured while getting customers from the database.");
            //    }
            //}

        }

        #endregion

        #region GetRecordsByID

        public Record GetRecordsByID(int RecordID)
        {
            throw new NotImplementedException();

            //using (var conn = CreateConnection())
            //{

            //    try
            //    {
            //        //TODO: IMPLEMENTERA RECORDDAL - GetRecordsByID()

                       /*using (sqlDataReader reader = cmd.ExecuteReader()){
                        
                                ...
                        
                        }
                        */
                      //return null;

            //    }
            //    catch
            //    {


            //        throw new ApplicationException("An error occured while getting customers from the database.");
            //    }
            //}

        }

        #endregion

        #region InsertRecord

        public void InsertRecord(Record record)
        {
            throw new NotImplementedException();

            //using (var conn = CreateConnection())
            //{

            //    try
            //    {
            //        //TODO: IMPLEMENTERA RECORDDAL - InsertRecord()


            //    }
            //    catch
            //    {


            //        throw new ApplicationException("An error occured while getting customers from the database.");
            //    }
            //}

        }

        #endregion

        #region UpdateRecord

        public void UpdateRecord(Record record)
        {
            throw new NotImplementedException();

            //using (var conn = CreateConnection())
            //{

            //    try
            //    {
            //        //TODO: IMPLEMENTERA RECORDDAL - UpdateRecord()


            //    }
            //    catch
            //    {


            //        throw new ApplicationException();
            //    }
            //}

        }

        #endregion


    }
}