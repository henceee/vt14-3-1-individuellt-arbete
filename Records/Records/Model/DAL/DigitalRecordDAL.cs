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
        /// Lägger in information om en skiva i tabellerna "Skiva" samt "Fysisk Skiva",
        /// med hjälp av dess skivID (RecordID, återfinns i egenskapen
        /// RecordID i referensen till Record-objektet)
        /// </summary>
        /// <param name="record"></param>

       #region InsertDigitalRecord

        public void InsertDigitalRecord(Record record)
        {
            throw new NotImplementedException();

            //using (var conn = CreateConnection())
            //{

            //    try
            //    {
            //        SqlCommand cmd = new SqlCommand("", conn);

            //        cmd.CommandType = CommandType.StoredProcedure;

            //        cmd.add("



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
        /// Uppdaterar information om en skiva i tabllen Skiva och Digital Skiva,
        /// med hjälp av dess skivID (RecordID, återfinns i egenskapen
        /// RecordID i referensen till Record-objektet)
        /// </summary>
        /// <param name="record"></param>

      #region UpdateDigitalRecord

        public void UpdateDigitalRecord(Record record)
        {
            //TODO: Implementera DigitalRecordDAL - UpdateDigitalRecord

            throw new NotImplementedException();

            //using (var conn = CreateConnection())
            //{

            //    try
            //    {
            //        SqlCommand cmd = new SqlCommand("Person.uspUpdateContact", conn);
            //        cmd.CommandType = CommandType.StoredProcedure;


            //        //cmd.Parameters.Add("@FirstName", SqlDbType.VarChar, 50).Value = contact.FirstName;
            //        //cmd.Parameters.Add("@LastName", SqlDbType.VarChar, 50).Value = contact.LastName;
            //        //cmd.Parameters.Add("@EmailAddress", SqlDbType.VarChar, 50).Value = contact.EmailAddress;
            //        //cmd.Parameters.Add("@ContactID", SqlDbType.Int, 4).Value = contact.ContactID;

            //        conn.Open();
            //        cmd.ExecuteNonQuery();

            //    }
            //    catch
            //    {

            ////        throw new ApplicationException("An error occured while getting customers from the database.");
            ////    }
            //}

        }

        #endregion

      #region GetDigitalRecordByRecordID

        public List<DigitalRecord> GetDigitalRecordByRecordID(int RecordID) {


            using (var conn = CreateConnection())
            {

                try
                {

                    SqlCommand cmd = new SqlCommand("appschema.usp_GetDigitalByRecordID", conn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@RecordID", RecordID);

                    List<DigitalRecord> digitalRecords = new List<DigitalRecord>(10);

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {


                        var DigRecordIDIndex = reader.GetOrdinal("DigSkivID");
                        var DiscSizeIndex = reader.GetOrdinal("Storlek");
                        var RecordIDIndex = reader.GetOrdinal("SkivID");


                        while (reader.Read())
                        {
                            digitalRecords.Add(new DigitalRecord { 
                            
                            DigRecordID = reader.GetInt32(DigRecordIDIndex),
                            DiscSize = reader.GetString(DiscSizeIndex),
                            RecordID = reader.GetInt32(RecordIDIndex)
                            
                            });

                        }

                    }

                    digitalRecords.TrimExcess();

                    return digitalRecords;

                }
                catch
                {


                    throw new ApplicationException("An error occured while getting customers from the database.");
                }

                
            }
        }

        #endregion

      #region GetRecordByID

        public DigitalRecord GetRecordByID(int DigRecordID)
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