using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Records.Model.DAL
{
    public class Service
    {

        #region fält

        private RecordDAL _RecordDAL;

        #endregion

        #region Egenskaper

        private RecordDAL RecordDAL
        {
            get { return _RecordDAL ?? (_RecordDAL = new RecordDAL()); }
        }

        #endregion


        #region Record CRUD METODER

        /// <summary>
        /// DeleteRecord
        /// Tar bort en specifik skiva ur databasen.  
        /// Anropar DeleteRecord i RecordDAL och skickar med RecordID
        /// </summary>
        /// <returns>Skiva som tas bort</returns>      
        /// <param name="RecordID"></param>       

        #region DeleteRecord

        public void DeleteRecord(int RecordID)
        {
            RecordDAL.DeleteRecord(RecordID);
        }

        #endregion

        /// <summary>
        /// GetRecord
        /// Hämtar info om en specifik skiva ur databasen.  
        /// Anropar GetRecordByID i RecordDAL och skickar med RecordID
        /// </summary>
        /// <returns>Record-objekt innehållande information om skivan</returns>
        /// <param name="RecordID"></param>


        #region GetRecord

        public Record GetRecord(int RecordID)
        {

            return RecordDAL.GetRecordByID(RecordID);
        }

        #endregion

        /// <summary>
        /// GetRecords
        /// Hämtar ut alla skivor ur databasen.        
        /// Anropar GetRecords i RecordDAL.
        /// </summary>
        /// <returns>En samling med referenser till Record-objekt</returns>

        #region GetRecords

        public IEnumerable<Record> GetRecords()
        {

            return RecordDAL.GetRecords();

        }

        #endregion

        /// <summary>
        /// SaveRecord
        /// Sparar en skiva.        
        /// Om RecordID är noll => ny skiva => Anropar InsertRecord i RecordDAL, skickar med en referens till ett Record-obj.
        /// Annars => uppdatera skiva => Anropar UpdateRecord i RecordDAL, skickar med en referens till ett Record-obj.
        /// </summary>
        /// <returns>En referens till ett Record-objekt (skivan som ska sparas).</returns>
        /// <param name="record"></param>
        /// <summary>

        #region SaveRecord

        public void SaveRecord(Record record)
        {

            //OBS VÄNTA TILL SIST MED NEDANSTÅENDE:

            /*ICollection<ValidationResult> validationResults;
            if(!customer.Validate(out validationResults){
            
             var ex = new ValidationException("Objektet klarade inte valideringen.");
                ex.Data.Add("ValidationResults", validationResults);
                throw ex;
            }
             */

            if (record.RecordID == 0)
            {

                RecordDAL.InsertRecord(record);

            }
            else
            {
                RecordDAL.UpdateRecord(record);
            }

        }

        #endregion

        #endregion
    }
}