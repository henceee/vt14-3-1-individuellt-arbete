using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Records.Model.DAL;

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
            

            using (var conn = CreateConnection())
            {

                try
                {
                    SqlCommand cmd = new SqlCommand("appschema.usp_DeleteRecord",conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@RecordID", SqlDbType.Int, 4).Value = RecordID;

                    conn.Open();
                    cmd.ExecuteNonQuery();


                }
                catch
                {


                    throw new ApplicationException("An error occured while getting customers from the database.");
                }
            }

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

                        var RecordIDIndex = reader.GetOrdinal("SkivID");
                        var TitleIndex = reader.GetOrdinal("Skivtitel");
                        var ArtistIndex = reader.GetOrdinal("Artist");
                        var PlaytimeIndex = reader.GetOrdinal("Speltid");
                        var ReleasedateIndex = reader.GetOrdinal("Releasedatum");
                        var RecordlabelIndex = reader.GetOrdinal("Skivbolag");
                        var RecordtypeIndex = reader.GetOrdinal("SkivtypID");

                        while (reader.Read())
                        {

                            records.Add(new Record
                            {

                                RecordID = reader.GetInt32(RecordIDIndex),
                                Title = reader.GetString(TitleIndex),
                                Artist = reader.GetString(ArtistIndex),
                                Playtime = reader.GetString(PlaytimeIndex),
                                Releasedate = reader.GetDateTime(ReleasedateIndex),
                                Recordlabel = reader.GetString(RecordlabelIndex),
                                RecordTypeID = reader.GetInt32(RecordtypeIndex)


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
            
            using (var conn = CreateConnection())
            {

                try
                {

                    SqlCommand cmd = new SqlCommand("appschema.usp_GetRecordByID", conn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@RecordID", RecordID);

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader()){

                        if (reader.Read()) {

                            var RecordIDIndex = reader.GetOrdinal("SkivID");
                            var TitleIndex = reader.GetOrdinal("Skivtitel");
                            var ArtistIndex = reader.GetOrdinal("Artist");
                            var PlaytimeIndex = reader.GetOrdinal("Speltid");
                            var ReleasedateIndex = reader.GetOrdinal("Releasedatum");
                            var RecordlabelIndex = reader.GetOrdinal("Skivbolag");
                            var RecordtypeIndex = reader.GetOrdinal("SkivtypID");

                            return new Record {

                                RecordID = reader.GetInt32(RecordIDIndex),
                                Title = reader.GetString(TitleIndex),
                                Artist = reader.GetString(ArtistIndex),
                                Playtime = reader.GetString(PlaytimeIndex),
                                Releasedate = reader.GetDateTime(ReleasedateIndex),
                                Recordlabel = reader.GetString(RecordlabelIndex),
                                RecordTypeID = reader.GetInt32(RecordtypeIndex)
                            };

                        }     
                        
                     }
                     
                    return null;

                }
                catch
                {


                    throw new ApplicationException("An error occured while getting customers from the database.");
                }
            }

        }

        #endregion

        /// <summary>
        /// InsertRecordTypeIDPhysical
        /// Används vid formulär för fysisk skiva. 
        /// TypID hårdkodas i SPROC med samma namn (appschema.usp_InsertRecordTypeIDDigital)
        /// så att TypID är 1, FYSISK. 
        /// </summary>
        /// <param name="record"></param>

        #region InsertRecordTypeIDPhysical

        public void InsertRecordTypeIDPhysical(Record record)
        {

            using (var conn = CreateConnection())
            {

                try
                {

                    SqlCommand cmd = new SqlCommand("appschema.usp_InsertRecordTypeIDPhyscial", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Title", SqlDbType.VarChar, 30).Value = record.Title;
                    cmd.Parameters.Add("@Artist", SqlDbType.VarChar, 20).Value = record.Artist;
                    cmd.Parameters.Add("@Playtime", SqlDbType.VarChar, 6).Value = record.Playtime;
                    cmd.Parameters.Add("@Releasedate", SqlDbType.Date).Value = record.Releasedate;

                    cmd.Parameters.Add("@RecordID", SqlDbType.Int).Direction = ParameterDirection.Output;



                    conn.Open();
                    cmd.ExecuteNonQuery();

                    record.RecordID = (int)cmd.Parameters["@ContactID"].Value;


                }
                catch
                {

                    throw new ApplicationException("An error occured while getting customers from the database.");
                }
            }
        }

        #endregion

        /// <summary>
        /// InsertRecordTypeIDDigital
        /// Används vid formulär för digital skiva.
        /// TypID hårdkodas i SPROC med samma namn (appschema.usp_InsertRecordTypeIDDigital)
        /// så att TypID är 1, FYSISK. 
        /// </summary>
        /// <param name="record"></param>

        #region InsertRecordTypeIDDigital

        public void InsertRecordTypeIDDigital(Record record)
        {

            using (var conn = CreateConnection())
            {

                try
                {

                    SqlCommand cmd = new SqlCommand("appschema.usp_InsertRecordTypeIDDigital", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Title", SqlDbType.VarChar, 30).Value = record.Title;
                    cmd.Parameters.Add("@Artist", SqlDbType.VarChar, 20).Value = record.Artist;
                    cmd.Parameters.Add("@Playtime", SqlDbType.VarChar, 6).Value = record.Playtime;
                    cmd.Parameters.Add("@Releasedate", SqlDbType.Date).Value = record.Releasedate;

                    cmd.Parameters.Add("@RecordID", SqlDbType.Int).Direction = ParameterDirection.Output;



                    conn.Open();
                    cmd.ExecuteNonQuery();

                    record.RecordID = (int)cmd.Parameters["@ContactID"].Value;


                }
                catch
                {

                    throw new ApplicationException("An error occured while getting customers from the database.");
                }
            }
        }

        #endregion

       /// <summary>
       /// UpdateRecord
       /// Uppdaterar info om en skiva i tabellen Skiva, m. hjälp av
       /// informationen i referensen till ett Record-obj.
       /// </summary>
       /// <param name="record"></param>

        #region UpdateRecord

        public void UpdateRecord(Record record)
        {

            using (var conn = CreateConnection())
            {

                try
                {

                    SqlCommand cmd = new SqlCommand("appschema.usp_UpdateRecord", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@RecordID", SqlDbType.Int).Value = record.RecordID;
                    cmd.Parameters.Add("@Title", SqlDbType.VarChar, 30).Value = record.Title;
                    cmd.Parameters.Add("@Artist", SqlDbType.VarChar, 20).Value = record.Artist;
                    cmd.Parameters.Add("@Playtime", SqlDbType.VarChar, 6).Value = record.Playtime;
                    cmd.Parameters.Add("@Releasedate", SqlDbType.Date).Value = record.Releasedate;
                                       
                    conn.Open();
                    cmd.ExecuteNonQuery();                    


                }
                catch
                {

                    throw new ApplicationException("An error occured while getting customers from the database.");
                }
            }
        }

        #endregion








    }  
}