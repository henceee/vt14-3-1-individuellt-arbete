using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Records.Model.DAL
{
    public class RecordDAL:DALBase
    {
        /// <summary>
        /// DeleteRecord
        /// Tar bort en skiva ur databasen, med hjälp av dess SkivID(RecordID).
        /// OBS att Cascade som RI mellan skiva och fysisk skiva, resp. skiva och digital skiva
        /// gör att TVÅ tabeller påverkas vid borttagning.
        /// </summary>
        /// <param name="RecordID"></param>

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

        /// <summary>
        /// GetRecords
        /// Hämtar alla skivor ur databasen.
        /// </summary>
        /// <returns>En samling med referenser till Record-objekt</returns>

        #region GetRecords

        public IEnumerable<Record> GetRecords()
        {

            using (var conn = CreateConnection())
            {

                try
                {
                    var records = new List<Record>(100);

                    var cmd = new SqlCommand("appschema.usp_GetRecords", conn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();


                    using (var reader = cmd.ExecuteReader())
                    {

                        var RecordID = reader.GetOrdinal("SkivID");
                        var Title = reader.GetOrdinal("Skivtitel");
                        var Artist = reader.GetOrdinal("Artist");
                        var Playtime = reader.GetOrdinal("Speltid");
                        var Releasedate = reader.GetOrdinal("Releasedatum");
                        var Recordlabel = reader.GetOrdinal("Skivbolag");

                        while (reader.Read())
                        {

                            records.Add(new Record
                            {

                                RecordID = reader.GetInt32(RecordID),
                                Title = reader.GetString(Title),
                                Artist = reader.GetString(Artist),
                                Playtime = reader.GetString(Playtime),
                                Releasedate = reader.GetDateTime(Releasedate),
                                Recordlabel = reader.GetString(Recordlabel)


                            });
                        }

                    }

                    records.TrimExcess();

                    return records;


                }
                catch
                {


                    throw new ApplicationException("An error occured while getting customers from the database.");
                }
            }

        }

        #endregion

        /// <summary>
        /// GetRecordByID
        /// Hämtar info om en specifik skiva ur databasen m hjälp av dess skivID (RecordID).  
        /// </summary>
        /// <param name="RecordID"></param>
        /// <returns>Ett record-objekt innehållande info om skivan</returns>

        #region GetRecordByID

        public Record GetRecordByID(int RecordID)
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

        /// <summary>
        /// InsertRecord
        /// Skapar en ny post i tabellen Skiva.
        /// </summary>
        /// <param name="record"></param>

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

        /// <summary>
        /// UpdateRecord
        /// Uppdaterar information om en skiva i tabllen Skiva,
        /// med hjälp av dess skivID (RecordID, återfinns i egenskapen
        /// RecordID i referensen till Record-objektet)
        /// </summary>
        /// <param name="record"></param>

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