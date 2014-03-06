using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RecordCollection.Model.DAL
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


        #region DeleteRecord

        public void DeleteRecord(int RecordID)
        {
            RecordDAL.DeleteRecord(RecordID);
        }

        #endregion

        #region GetRecord

        public Record GetRecord(int RecordID) {

            return RecordDAL.GetRecordsByID(RecordID);
        }

        #endregion

        #region GetRecords

        public IEnumerable<Record> GetRecords() {

            return RecordDAL.GetRecords();

        }

        #endregion

        #region SaveRecord

        public void SaveRecord(Record record) {

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