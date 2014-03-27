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
        /// InsertPhysicalRecord
        /// Lägger in information om en skiva i tabellen "Fysisk Skiva"  
        /// m. hjälp av informationen ur referensen till ett PhysicalRecord-obj.           
       /// </summary>
       /// <param name="physrecord"></param>

      #region InsertPhysicalRecord

        public void InsertPhysicalRecord(PhysicalRecord physrecord)
        {
            using (var conn = CreateConnection())
            {

                try
                {
                    SqlCommand cmd = new SqlCommand("appschema.usp_InsertPhysical", conn);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@Priceatpurchase", SqlDbType.Decimal).Value = physrecord.PriceAtPurchase;
                    cmd.Parameters.Add("@Dateofpurchase", SqlDbType.Date).Value = physrecord.DateofPurchase;
                    cmd.Parameters.Add("@RecordID", SqlDbType.Int).Value = physrecord.RecordID;                                     
                    
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
        /// UpdatePhysicalRecord
        /// Uppdaterar info om en skiva i tabellen Fysisk Skiva, m. hjälp av
        /// informationen i referensen till ett PhysicalRecord-obj.
      /// </summary>
      /// <param name="physrecord"></param>
  
      #region UpdatePhysicalRecord

        public void UpdatePhysicalRecord(PhysicalRecord physrecord)
        {
            using (var conn = CreateConnection())
            {

                try
                {

                    SqlCommand cmd = new SqlCommand("appschema.usp_UpdatePhysicalRecord", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    
                    
                    cmd.Parameters.Add("@Priceatpurchase", SqlDbType.Decimal).Value = physrecord.PriceAtPurchase;
                    cmd.Parameters.Add("@Dateofpurchase", SqlDbType.Date).Value = physrecord.DateofPurchase;
                    cmd.Parameters.Add("@RecordID", SqlDbType.Int).Value = physrecord.RecordID;                  
                    
                    conn.Open();
                    cmd.ExecuteNonQuery();


                }
                catch
                {

                    throw new ApplicationException("An error occured while getting records from the database.");
                }
            }

        }

        #endregion

        /// <summary>
        /// GetPhysicalRecordByRecordID
        /// Hämtar ut en specifik skiva ur tabellen Fysisk Skiva, med hjälp av
        /// Skivid(RecordID)
        /// </summary>   
        /// <param name="RecordID"></param>
        /// <returns>En referens till PhysicalRecord obj. </returns>

      #region GetPhysicalRecordByRecordID

        public PhysicalRecord GetPhysicalRecordByRecordID(int RecordID)
        {

            using (var conn = CreateConnection())
            {

                try
                {

                    SqlCommand cmd = new SqlCommand("appschema.usp_GetPhysicalByRecordID", conn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@RecordID", RecordID);


                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            
                            var PriceAtPurchaseIndex = reader.GetOrdinal("Inköpspris");
                            var DateofPurchaseIndex = reader.GetOrdinal("Inköpsdatum");
                            var RecordIDIndex = reader.GetOrdinal("SkivID");


                            return new PhysicalRecord
                             {
                                 
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