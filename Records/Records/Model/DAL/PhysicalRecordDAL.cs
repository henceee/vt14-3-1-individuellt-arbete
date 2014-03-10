using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Records.Model.DAL
{
    public class PhysicalRecordDAL:DALBase
    {
        /// <summary>
        /// UpdatePhysicalRecord
        /// Uppdaterar information om en skiva i tabllen "Skiva" samt "Fysisk Skiva",
        /// med hjälp av dess skivID (RecordID, återfinns i egenskapen
        /// RecordID i referensen till Record-objektet)
        /// </summary>
        /// <param name="record"></param>

      #region InsertPhysicalRecord

        public void InsertPhysicalRecord(Record record)
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

        
      #region UpdatePhysicalRecord

        public void UpdatePhysicalRecord(Record record)
        {
            throw new NotImplementedException();

            //using (var conn = CreateConnection())
            //{

            //    try
            //    {
            //        //TODO: IMPLEMENTERA PhysicalRecordDAL - UpdateRecord()


            //    }
            //    catch
            //    {


            //        throw new ApplicationException();
            //    }
            //}

        }

        #endregion

      #region GetPhysicalRecordByRecordID

        public List<PhysicalRecord> GetPhysicalRecordByRecordID(int RecordID)
        {


            using (var conn = CreateConnection())
            {

                try
                {

                    SqlCommand cmd = new SqlCommand("appschema.usp_GetPhysicalByRecordID", conn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@RecordID", RecordID);

                    List<PhysicalRecord> PhysicalRecords = new List<PhysicalRecord>(10);

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                       
                        var PhysRecordIDIndex = reader.GetOrdinal("FysSkivID");
                        var PriceAtPurchaseIndex = reader.GetOrdinal("Inköpspris");
                        var DateofPurchaseIndex = reader.GetOrdinal("Inköpsdatum");
                        var RecordIDIndex = reader.GetOrdinal("SkivID");
                      

                        while (reader.Read())
                        {
                            PhysicalRecords.Add(new PhysicalRecord
                            {
                                PhysRecordID = reader.GetInt32(PhysRecordIDIndex),
                                PriceAtPurchase = reader.GetDecimal(PriceAtPurchaseIndex),
                                DateofPurchase = reader.GetDateTime(DateofPurchaseIndex),
                                RecordID = reader.GetInt32(RecordIDIndex)


                            });

                        }

                    }

                    PhysicalRecords.TrimExcess();

                    return PhysicalRecords;

                }
                catch
                {


                    throw new ApplicationException("An error occured while getting customers from the database.");
                }


            }
        }

        #endregion

      #region GetRecordByID

        public PhysicalRecord GetRecordByID(int RecordID)
        {
                      
            using (var conn = CreateConnection())
            {

                try
                {

                    SqlCommand cmd = new SqlCommand("appschema.usp_GetPhysicalRecord", conn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@PhysRecordID", RecordID);

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        if (reader.Read())
                        {

                            var PhysRecordIDIndex = reader.GetOrdinal("FysSkivID");
                            var PriceAtPurchaseIndex = reader.GetOrdinal("Inköpspris");
                            var DateofPurchaseIndex = reader.GetOrdinal("Inköpsdatum");
                            var RecordIDIndex = reader.GetOrdinal("SkivID");

                            return new PhysicalRecord
                            {
                                PhysRecordID = reader.GetInt32(PhysRecordIDIndex),
                                PriceAtPurchase = reader.GetDecimal(PriceAtPurchaseIndex),
                                DateofPurchase = reader.GetDateTime(DateofPurchaseIndex),
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