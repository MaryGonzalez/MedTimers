using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MedTimers.Models
{
    public class AllEdit
    {
        ///////////////////////////////////////////////////
        //////////////////////PATIENT/////////////////////
        /////////////////////////////////////////////////

        public int PatientID { get; set; }       
        
        [MaxLength(30)]
        [Required(ErrorMessage = "*First name is required")]
        public string Patient_FirstName { get; set; }


        [MaxLength(30)]
        //[Required(ErrorMessage = "*Preferred name is required")]
        public string? Patient_PreferredName { get; set; }
            
       
        [MaxLength(30)]
        [Required(ErrorMessage = "*Last name is required")]
        public string Patient_LastName { get; set; }


        public string fullName
        {
            get
            {
                return Patient_FirstName + " " + Patient_LastName;
            }
        }
        public string fullPreferredName
        {
            get
            {
                return Patient_FirstName + " " + Patient_LastName + " (" + Patient_PreferredName + ")";
            }
        }

        public string lobbyName
        {
            get
            {
                return Patient_LastName + ", " + Patient_FirstName;
            }
        }

        public List<SelectListItem> AllNames { get; set; }

        public string Patient_Pronouns { get; set; }

        public string Patient_Gender { get; set; }


        //Calculated Patient Age for EMTALA Log
        public string Patient_Age { get; set; }

        public DateTime? Patient_DOB { get; set; }

        public int Age
        {
            get
            {
                DateTime? d1 = DateTime.Now;
                DateTime? d2 = Patient_DOB;
                int d3 = (int)(d1 - d2).GetValueOrDefault().TotalDays;
                int age = d3 / 365;
                return age;
            }
        }

        public string Patient_Sex { get; set; }
        public string Patient_Street { get; set; }
        public string Patient_City { get; set; }
        public string Patient_ZipCode { get; set; }
        public string Patient_State { get; set; }
        public string Patient_Country { get; set; }
        public string PatientAddress
        {
            get
            {
                return Patient_Street + ", " + Patient_City + " " + Patient_State + " " + Patient_ZipCode + ", " + Patient_Country;
            }
        }

        public string Patient_ContactNumber { get; set; }
        public string PatientNumber
        {
            get
            {


                if (string.IsNullOrEmpty(Patient_ContactNumber)) return string.Empty;
                Patient_ContactNumber = new System.Text.RegularExpressions.Regex(@"\D")
                    .Replace(Patient_ContactNumber, string.Empty);
                Patient_ContactNumber = Patient_ContactNumber.TrimStart('1');
                if (Patient_ContactNumber.Length == 7)
                    return Convert.ToInt64(Patient_ContactNumber).ToString("###-####");
                if (Patient_ContactNumber.Length == 10)
                    return Convert.ToInt64(Patient_ContactNumber).ToString("(###) ###-####");
                if (Patient_ContactNumber.Length > 10)
                    return Convert.ToInt64(Patient_ContactNumber)
                        .ToString("(###) ###-#### " + new String('#', (Patient_ContactNumber.Length - 10)));
                return Patient_ContactNumber;
            }

        }

        public string? Patient_Email { get; set; }    
        public string Patient_Ethnicity { get; set; }      
        public string Patient_Race { get; set; } 
        public string Patient_EmergencyContactName { get; set; }      
        public string Patient_EmergencyContactNumber { get; set; }
        public string EmergencyContactNumber
        {
            get
            {


                if (string.IsNullOrEmpty(Patient_EmergencyContactNumber)) return string.Empty;
                Patient_EmergencyContactNumber = new System.Text.RegularExpressions.Regex(@"\D")
                    .Replace(Patient_EmergencyContactNumber, string.Empty);
                Patient_EmergencyContactNumber = Patient_EmergencyContactNumber.TrimStart('1');
                if (Patient_EmergencyContactNumber.Length == 7)
                    return Convert.ToInt64(Patient_EmergencyContactNumber).ToString("###-####");
                if (Patient_EmergencyContactNumber.Length == 10)
                    return Convert.ToInt64(Patient_EmergencyContactNumber).ToString("(###) ###-####");
                if (Patient_EmergencyContactNumber.Length > 10)
                    return Convert.ToInt64(Patient_EmergencyContactNumber)
                        .ToString("(###) ###-#### " + new String('#', (Patient_EmergencyContactNumber.Length - 10)));
                return Patient_EmergencyContactNumber;
            }

        }

        public string Patient_EmergencyContactRelationship { get; set; }
        public string? Patient_Photo { get; set; }


        [MaxLength(100)]
        public string? Patient_GuardianName { get; set; }
        public string? Patient_GuardianPhoneNumber { get; set; }
        public string GuardianPhoneNumber
        {
            get
            {


                if (string.IsNullOrEmpty(Patient_GuardianPhoneNumber)) return string.Empty;
                Patient_GuardianPhoneNumber = new System.Text.RegularExpressions.Regex(@"\D")
                    .Replace(Patient_GuardianPhoneNumber, string.Empty);
                Patient_GuardianPhoneNumber = Patient_GuardianPhoneNumber.TrimStart('1');
                if (Patient_GuardianPhoneNumber.Length == 7)
                    return Convert.ToInt64(Patient_GuardianPhoneNumber).ToString("###-####");
                if (Patient_GuardianPhoneNumber.Length == 10)
                    return Convert.ToInt64(Patient_GuardianPhoneNumber).ToString("(###) ###-####");
                if (Patient_GuardianPhoneNumber.Length > 10)
                    return Convert.ToInt64(Patient_GuardianPhoneNumber)
                        .ToString("(###) ###-#### " + new String('#', (Patient_GuardianPhoneNumber.Length - 10)));
                return Patient_GuardianPhoneNumber;
            }

        }

        public string? Patient_GuardianRelationship { get; set; }



        ///////////////////////////////////////////////////
        //////////////////////TRACKING////////////////////
        /////////////////////////////////////////////////

             
        public string Track_AdmissionType { get; set; }
           
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy hh:mm tt}")]
        public DateTime? Track_InitialArrival { get; set; }

        [Required(ErrorMessage = "*Reason is required")]
        public string Track_Reason { get; set; }              
       
        public string Track_ArrivalMode { get; set; }

        [Required(ErrorMessage = "*Arrival type is required")]
        [Display(Name = "Track_ArrivalType")]
        public string Track_ArrivalType { get; set; }

        [Required(ErrorMessage = "*Chief complaint is required")]
        public string Track_ChiefComplaint { get; set; }

        public List<SelectListItem> AllAssessors { get; set; }
        public int AssessorID { get; set; }
        public string Assessor_FirstName { get; set; }
        public string Assessor_LastName { get; set; }

        public string fullAssessor
        {
            get
            {
                return Assessor_FirstName + " " + Assessor_LastName;
            }
        }

        public List<SelectListItem> AllNurses { get; set; }
        public int NurseID { get; set; }
        public string Nurse_FirstName { get; set; }
        public string Nurse_LastName { get; set; }
        public string fullNurse
        {
            get
            {
                return Nurse_FirstName + " " + Nurse_LastName;
            }
        }

        public string Track_TriageLevel { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy hh:mm tt}")]
        public DateTime Track_SBARCall { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy hh:mm tt}")]
        public DateTime Track_MSEStart { get; set; }


        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy hh:mm tt}")]
        public DateTime Track_MSEEnd { get; set; }

        public string AssessmentWaitTime
        {
            get
            {
                //Assessment Start != null
                DateTime date = new DateTime(2000, 01, 01, 12, 0, 0);
                if (Assessment_StartTime != DateTime.MinValue && Track_MSEEnd != DateTime.MinValue && Assessment_StartTime != date && Track_MSEEnd != date)
                {
                    TimeSpan span = Assessment_StartTime - Track_MSEEnd;
                    String totalTime = String.Format("{0}hr {1}m", span.Hours, span.Minutes);

                    return totalTime;
                }

                else if (Track_MSEEnd != DateTime.MinValue)
                {
                    TimeSpan span = DateTime.Now - Track_MSEEnd;
                    String totalTime = String.Format("{0}hr {1}m", span.Hours, span.Minutes);

                    return totalTime;
                }


                return " ";
            }
        }



        //Calculated Wait Time for EMTALA Log
        public string Patient_Wait { get; set; }


        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy hh:mm tt}")]
        public DateTime Assessment_StartTime { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy hh:mm tt}")]
        public DateTime Assessment_EndTime { get; set; }

        public string Assessment_Room { get; set; }
        public string Track_EmergencyMedCondition { get; set; }
        public string Track_CertStatus { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy hh:mm tt}")]
        public DateTime Track_DispositionArrival { get; set; }

        public string Track_DispositionType { get; set; }


        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy hh:mm tt}")]
        public DateTime Track_PatientWentToUnit { get; set; }

        public string Track_DepartureMode { get; set; }


        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy hh:mm tt}")]
        public DateTime Track_DepartureTime { get; set; }

        [MaxLength(250)]
        public string Track_Comments { get; set; }
        public int UserTypeID { get; set; }
        public bool Patient_EmergencyBool { get; set; }


        ///////////////////////////////////////////////////
        //////////////////////TRANSFER////////////////////
        /////////////////////////////////////////////////
        
       
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy hh:mm tt}")]
        public DateTime? Track_ReceivedReferral { get; set; }

        public string Track_TransferStatus { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy hh:mm tt}")]
        public DateTime Track_FaxReceived { get; set; }


        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy hh:mm tt}")]
        public DateTime Track_Notified { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy hh:mm tt}")]
        public DateTime Track_FollowUp { get; set; }


        ///////////////////////////////////////////////////
        //////////////////////HOSPITAL////////////////////
        /////////////////////////////////////////////////

        public int HospitalID { get; set; }

        [MaxLength(200)]
        public string Hosp_Name { get; set; }

        public List<SelectListItem> AllHospitals { get; set; }


        public string HospitalExtensionNumber { get; set; }
        public string HospitalPhoneNumber { get; set; }
        public string ExtensionNumber { get; set; }
        public string HospitalFaxNumber { get; set; }        

        [MaxLength(100)]
        public string Hosp_Street { get; set; }
        
        public string Hosp_State { get; set; }


        [MaxLength(50)]        
        public string Hosp_City { get; set; }

        [MaxLength(5)]
        public string Hosp_ZipCode { get; set; }

        ///////////////////////////////////////////////////
        //////////////////////CERT////////////////////////
        /////////////////////////////////////////////////
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy hh:mm tt}")]
        public DateTime Track_CertInitial { get; set; }

    }
}
