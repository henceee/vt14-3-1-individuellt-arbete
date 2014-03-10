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
        private DigitalRecordDAL _DigitalRecordDAL;
        private PhysicalRecordDAL _PhysicalRecordDAL;

        #endregion

        #region Egenskaper

        private RecordDAL RecordDAL
        {
            get { return _RecordDAL ?? (_RecordDAL = new RecordDAL()); }
        }

        private DigitalRecordDAL DigitalRecordDAL
        {
            get { return _DigitalRecordDAL ?? (_DigitalRecordDAL = new DigitalRecordDAL()); }
        }

        private PhysicalRecordDAL PhysicalRecordDAL
        {
            get { return _PhysicalRecordDAL ?? (_PhysicalRecordDAL = new PhysicalRecordDAL()); }
        }

        #endregion

        //OBS ATT PhysicalRecord och Digital Record endast har "CRU"-funktionalitet, på grund av RI
        //Eftersom relationen Skiva-Fysisk Skiva resp. Skiva-Digital Skiva har Cascade och det räcker att ta bort skivan.
        
        //På samma vis har Record bara CR D -funktionalitet, då när en fysisk eller digital skiva uppdateras, uppdateras även tabellen skiva.

        #region PhysicalRecord CRU(D) Metoder

        #region SavePhysicalRecord

        public void SavePhysicalRecord(Record record)
        {

            //OBS VÄNTA TILL SIST MED NEDANSTÅENDE:

            /*ICollection<ValidationResult> validationResults;
            if(!customer.Validate(out validationResults){
            
             var ex = new ValidationException("Objektet klarade inte valideringen.");
                ex.Data.Add("ValidationResults", validationResults);
                throw ex;
            }
             */

            //Om skivID är noll, så finns inte posten redan och då ska en ny post skapas.

            if (record.RecordID == 0)
            {
                PhysicalRecordDAL.InsertPhysicalRecord(record);

            }

                //Annars ska den befintliga posten uppdateras.

            else
            {
                PhysicalRecordDAL.UpdatePhysicalRecord(record);
            }

        }

        #endregion

        #endregion

        #region DigitalRecord CRU(D) Metoder

        #region GetDigitalRecord

        public DigitalRecord GetDigitalRecord(int PhysRecordID) {
        
            return DigitalRecordDAL.GetRecordByID(PhysRecordID);
        }


        #endregion

        #region GetDigitalRecordByRecordID

        public List<DigitalRecord> GetDigitalRecordByRecordID(int RecordID) {            

            return DigitalRecordDAL.GetDigitalRecordByRecordID(RecordID);
        
        }

        #endregion

        #region SaveDigitalRecord

        public void SaveDigitalRecord(Record record)
        {

            //OBS VÄNTA TILL SIST MED NEDANSTÅENDE:

            /*ICollection<ValidationResult> validationResults;
            if(!customer.Validate(out validationResults){
            
             var ex = new ValidationException("Objektet klarade inte valideringen.");
                ex.Data.Add("ValidationResults", validationResults);
                throw ex;
            }
             */

            //Om skivID är noll, så finns inte posten redan och då ska en ny post skapas.

            if (record.RecordID == 0)
            {
                DigitalRecordDAL.InsertDigitalRecord(record);

            }

                //Annars ska den befintliga posten uppdateras.

            else
            {
                DigitalRecordDAL.UpdateDigitalRecord(record);
            }

        }

        #endregion



        #endregion

        #region Record CR(U)D METODER

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

       

        #endregion
    }
}