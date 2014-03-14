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

                   
                    cmd.Parameters.Add("@DiscSize", SqlDbType.VarChar, 6).Value = digrecord.DiscSize;
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

                    cmd.Parameters.Add("@Discsize", SqlDbType.VarChar, 6).Value = digrecord.DiscSize;
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

                            
                            var DiscSizeIndex = reader.GetOrdinal("Storlek");
                            var RecordIDIndex = reader.GetOrdinal("SkivID");

                            return new DigitalRecord
                            {

                                
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