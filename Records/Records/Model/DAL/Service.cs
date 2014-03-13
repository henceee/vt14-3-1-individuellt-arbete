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
        

        #region PhysicalRecord CRU(D) Metoder

        
        

        /// <summary>
        /// GetPhysicalRecordByRecordID
        /// Hämtar info om en specifik skiva ur databasen.  
        /// Anropar GetPhysicalRecordByRecordID i PhysicalRecordDAL och skickar med RecordID
        /// </summary>
        /// <param name="RecordID"></param>
        /// <returns>En lista med referens(er) till PhysicalRecord-obj.</returns>

        #region GetPhysicalRecordByRecordID

        public PhysicalRecord GetPhysicalRecordByRecordID(int RecordID)
        {

            return PhysicalRecordDAL.GetPhysicalRecordByRecordID(RecordID);

        }

        #endregion

       
        /// <summary>   
        /// SavePhysicalRecord
        /// Sparar en skiva m. hjälp av en referens till ett PhysicalRecord-obj.        
        /// </summary>
        /// <param name="record"></param>

        #region SavePhysicalRecord

        public void SavePhysicalRecord(PhysicalRecord record)
        {
         

            /*ICollection<ValidationResult> validationResults;
            if(!customer.Validate(out validationResults){
            
             var ex = new ValidationException("Objektet klarade inte valideringen.");
                ex.Data.Add("ValidationResults", validationResults);
                throw ex;
            }
             */

            
        
                PhysicalRecordDAL.InsertPhysicalRecord(record);

          

        }

        #endregion

        #region UpdatePhysicalRecord

        public void UpdatePhysicalRecord(PhysicalRecord physrecord) {

            

            /*ICollection<ValidationResult> validationResults;
            if(!customer.Validate(out validationResults){
            
             var ex = new ValidationException("Objektet klarade inte valideringen.");
                ex.Data.Add("ValidationResults", validationResults);
                throw ex;
            }
             */

            PhysicalRecordDAL.UpdatePhysicalRecord(physrecord);
        
        }

        #endregion

        #endregion

        #region DigitalRecord CRU(D) Metoder

        /// <summary>
        /// GetDigitalRecord
        /// Hämtar info om en specifik skiva ur databasen.  
        /// Anropar GetDigitalRecordByID i DigitalRecordDAL och skickar med DigRecordID
        /// </summary>
        /// <returns>DigitalRecord-objekt innehållande information om skivan</returns>
        /// <param name="RecordID"></param>

     

        /// <summary>
        /// GetDigitalRecordByRecordID
        /// Hämtar info om en specifik skiva ur databasen.  
        /// Anropar GetDigitalRecordByRecordID i DigitalRecordDAL och skickar med RecordID
        /// </summary>
        /// <param name="RecordID"></param>
        /// <returns>En lista med referens(er) till DigitalRecord-obj.</returns>

        #region GetDigitalRecordByRecordID

        public DigitalRecord GetDigitalRecordByRecordID(int RecordID) {            

            return DigitalRecordDAL.GetDigitalRecordByRecordID(RecordID);
        
        }

        #endregion

        /// <summary>       
        /// SaveDigitalRecord
        /// Sparar en skiva m. hjälp av en referens till ett DigitalRecord-obj.        
        /// </summary>
        /// <param name="digrecord"></param>
        /// 
              

        #region SaveDigitalRecord

        public void SaveDigitalRecord(DigitalRecord digrecord)
        {
            
            //OBS VÄNTA TILL SIST MED NEDANSTÅENDE:

            /*ICollection<ValidationResult> validationResults;
            if(!customer.Validate(out validationResults){
            
             var ex = new ValidationException("Objektet klarade inte valideringen.");
                ex.Data.Add("ValidationResults", validationResults);
                throw ex;
            }
             */

            
                DigitalRecordDAL.InsertDigitalRecord(digrecord);

          
        }

        #endregion

        /// <summary>
        /// UpdateDigitalRecord
        /// Uppdaterar en skiva m. hjälp av en referens till ett DigitalRecord-obj.      
        /// </summary>
        /// <param name="digrecord"></param>

        #region UpdateDigitalRecord

        public void UpdateDigitalRecord(DigitalRecord digrecord)
        {

            //OBS VÄNTA TILL SIST MED NEDANSTÅENDE:

            /*ICollection<ValidationResult> validationResults;
            if(!customer.Validate(out validationResults){
            
             var ex = new ValidationException("Objektet klarade inte valideringen.");
                ex.Data.Add("ValidationResults", validationResults);
                throw ex;
            }
             */

            DigitalRecordDAL.UpdateDigitalRecord(digrecord);
        }

        #endregion


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
        /// Sparar en skiva m. hjälp av en referens till ett Record-obj.
        /// </summary>
        /// <param name="record"></param>

        #region SaveRecord

        public void SaveRecord(Record record) {

            //VÄNTA TILL SIST MED DETTA!!

            //ICollection<ValidationResult> ValidationResults;

            //if (!contact.Validate(out ValidationResults))
            //{

            //    var ex = new ValidationException("Objektet klarade inte valideringen");
            //    ex.Data.Add("ValidationResults", ValidationResults);
            //    throw ex;
            //}

            
            if (record.RecordID == 0)
            {
                //Är RecordTypeID (skivtypID) 1 så är det en FYSISK skiva...

                if (record.RecordTypeID == 1)
                {
                    RecordDAL.InsertRecordTypeIDPhysical(record);
                }

                //Är RecordTypeID (skivtypID) 1 så är det en DIGITAL skiva...

                else if (record.RecordTypeID == 2)
                {
                    RecordDAL.InsertRecordTypeIDDigital(record);
                }

                //RecordType får bara va antingen fysisk eller digital, så annars kastas ett undantag!

                else {

                    throw new ApplicationException();
                }
                
            }
            else
            {

                RecordDAL.UpdateRecord(record);
            }
        }

        #endregion


        /// <summary>
        /// UpdateRecord
        /// Uppdaterar en skiva m. hjälp av en referens till ett DigitalRecord-obj.      
        /// </summary>
        /// <param name="digrecord"></param>

        #region UpdateRecord

        //public void UpdateRecord(DigitalRecord digrecord)
        //{

        //    //OBS VÄNTA TILL SIST MED NEDANSTÅENDE:

        //    /*ICollection<ValidationResult> validationResults;
        //    if(!customer.Validate(out validationResults){
            
        //     var ex = new ValidationException("Objektet klarade inte valideringen.");
        //        ex.Data.Add("ValidationResults", validationResults);
        //        throw ex;
        //    }
        //     */

        //    DigitalRecordDAL.UpdateDigitalRecord(digrecord);
        //}

        #endregion

        #endregion

    }
}