using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Records.Model.DAL
{
    public class DigitalRecordDAL:DALBase
    {
         /// <summary>
        /// InsertDigitalRecord
        /// Lägger in information om en skiva i tabellen "Fysisk Skiva"  
        /// m. hjälp av informationen ur referensen till ett DigitalRecord-obj.
        /// </summary>
        /// <param name="digrecord"></param>

       #region InsertDigitalRecord

        public void InsertDigitalRecord(DigitalRecord digrecord)
        {

            using (var conn = CreateConnection())
            {

                try
                {
                    

                    SqlCommand cmd = new SqlCommand("appschema.usp_InsertDigital", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                   
                    cmd.Parameters.Add("@Playtime", SqlDbType.VarChar, 6).Value = digrecord.DiscSize;
                    cmd.Parameters.Add("@RecordID", SqlDbType.Int).Value = digrecord.RecordID;

                    cmd.Parameters.Add("@DigRecordID", SqlDbType.Int).Direction = ParameterDirection.Output;


                    conn.Open();
                    cmd.ExecuteNonQuery();

                    digrecord.DigRecordID = (int)cmd.Parameters["@DigRecordID"].Value;


                }
                catch
                {

                    throw new ApplicationException("An error occured while getting customers from the database.");
                }
            }
        }

        #endregion


        /// <summary>
        /// UpdateDigitalRecord
        /// Uppdaterar info om en skiva i tabellen Digital Skiva, m. hjälp av
        /// informationen i referensen till ett DigitalRecord-obj.
        /// </summary>
        /// <param name="record"></param>

      #region UpdateDigitalRecord

        public void UpdateDigitalRecord(DigitalRecord digrecord)
        {

            using (var conn = CreateConnection())
            {

                try
                {                   

                    SqlCommand cmd = new SqlCommand("appschema.usp_UpdateDigitalRecord", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DigRecordID", SqlDbType.Int).Value = digrecord.DigRecordID;                   
                    cmd.Parameters.Add("@Playtime", SqlDbType.VarChar, 6).Value = digrecord.DiscSize;
                    cmd.Parameters.Add("@RecordID", SqlDbType.Int).Value = digrecord.RecordID;  
                   

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
      /// GetDigitalRecordByRecordID
      /// Hämtar ut en specifik skiva ur tabellen Digital Skiva, med hjälp av
      /// Skivid(RecordID)
      /// </summary>
      /// <param name="RecordID"></param>
      /// <returns>En lista med referens(er) till DigitalRecord obj. </returns>
      
      #region GetDigitalRecordByRecordID

        public DigitalRecord GetDigitalRecordByRecordID(int RecordID) {


            using (var conn = CreateConnection())
            {

                try
                {

                    SqlCommand cmd = new SqlCommand("appschema.usp_GetDigitalByRecordID", conn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@RecordID", RecordID);



                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {

                            var DigRecordIDIndex = reader.GetOrdinal("DigSkivID");
                            var DiscSizeIndex = reader.GetOrdinal("Storlek");
                            var RecordIDIndex = reader.GetOrdinal("SkivID");

                            return new DigitalRecord
                            {

                                DigRecordID = reader.GetInt32(DigRecordIDIndex),
                                DiscSize = reader.GetString(DiscSizeIndex),
                                RecordID = reader.GetInt32(RecordIDIndex)


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
        /// GetDigitalRecordByID
        /// Hämtar ut en specifik skiva ur tabellen Digital Skiva, med hjälp av
        /// DigSkivID (DigRecordID)
      /// </summary>
      /// <param name="DigRecordID"></param>
        /// <returns></returns>

        #region GetDigitalRecordByID

        public DigitalRecord GetDigitalRecordByID(int DigRecordID)
        {
           
            using (var conn = CreateConnection())
            {

                try
                {

                    SqlCommand cmd = new SqlCommand("appschema.usp_GetDigitalRecord", conn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@DigRecordID", DigRecordID);

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        if (reader.Read())
                        {

                            var DigRecordIDIndex = reader.GetOrdinal("DigSkivID");
                            var DiscSizeIndex = reader.GetOrdinal("Storlek");
                            var RecordIDIndex = reader.GetOrdinal("SkivID");

                            return new DigitalRecord
                            {

                                DigRecordID = reader.GetInt32(DigRecordIDIndex),
                                DiscSize = reader.GetString(DiscSizeIndex),
                                RecordID = reader.GetInt32(RecordIDIndex)
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


    }
}