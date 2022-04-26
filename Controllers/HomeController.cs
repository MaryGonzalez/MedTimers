using MedTimers.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Collections.Generic;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Drawing;
using ClosedXML.Excel;
using System.Globalization;
using System.Linq;

namespace MedTimers.Controllers
{
    public class HomeController : Controller
    {


        public HomeController()
        {

        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string Username, Users objTemp)
        {

            try
            {
                int userID = MedTimersDB.GetLogIn(objTemp);
                if (userID != -1)
                {
                    Users loggedUser = MedTimersDB.GetUser(userID);

                    HttpContext.Session.SetString("loggerUser", userID.ToString());
                    HttpContext.Session.SetString("userType", loggedUser.UserTypeID.ToString());
                    HttpContext.Session.SetString("userName", loggedUser.User_FirstName.ToString() +" "+ loggedUser.User_LastName.ToString());
                    HttpContext.Session.SetString("userPassword", loggedUser.User_Password.ToString());
                    HttpContext.Session.SetString("User_LastLogin", loggedUser.User_LastLogin.ToString());

                    //ViewData.Add( = HttpContext.Session.GetString("userType");
                    //ViewBag.thisUser = HttpContext.Session.GetString("loggerUser");





                    switch (loggedUser.UserTypeID)
                    {
                        //Administrator
                        case 1:
                            return RedirectToAction("PatientData");
                       

                        //Nurse
                        case 2:
                            return RedirectToAction("PatientData");
                        

                        //Assessor
                        case 3:
                            return RedirectToAction("PatientData");
                        

                        //Sub Administrator
                        case 4:
                            return RedirectToAction("PatientData");
                        

                        //Front Desk
                        case 5:
                            return RedirectToAction("Lobby");
                            
                    }
                    
                    ViewBag.LoginError = "Username or Password does not exist";
                    return View();
                }
                else
                {
                    ViewBag.LoginError = "Username or Password does not exist";
                    return View();
                    
                }

            }
            catch (Exception e)
            {
                ViewBag.error = e.Message;
                ViewBag.userType = HttpContext.Session.GetString("userType");
                return View();
            }
        }



        //Index - Transfer for front desk
        public IActionResult Index()
        {            
            ViewBag.userType = HttpContext.Session.GetString("userType");
            return View(getNames());
        }

        //Index - Transfer for front desk
        //Get patient's first and last names
        public static List<AllEdit> getNames()
        {
            List<AllEdit> patients = new List<AllEdit>();
            patients = MedTimersDB.GetNames();
            return patients;
        }

        //Walk In for front desk 
        public IActionResult NewWalk()
        {            
            ViewBag.userType = HttpContext.Session.GetString("userType");
            return View();
        }


        //Walk In for front desk - Add new patient
        [HttpPost]
        public IActionResult NewWalk(AllEdit objModel)
        {

            try
            {
                if (MedTimersDB.AddPatientDetails(objModel))
                {
                    ViewBag.Message = "Patient has been successfully added.";
                    ModelState.Clear();
                    ViewBag.userType = HttpContext.Session.GetString("userType");
                    return RedirectToAction("Lobby", "Home");
                }
                ViewBag.userType = HttpContext.Session.GetString("userType");
                return View();

            }
            catch (Exception)
            {
                ViewBag.userType = HttpContext.Session.GetString("userType");
                return View();
            }
        }

        //Homepage for front desk 
        public IActionResult Lobby()
        {
            List<AllEdit> patients = new List<AllEdit>();
            patients = MedTimersDB.GetLobbyData();
            //ViewBag.userName = HttpContext.Session.GetString("userName");
            ViewBag.userType = HttpContext.Session.GetString("userType");
            ViewBag.userPassword = HttpContext.Session.GetString("userPassword");
            ViewBag.User_LastLogin = HttpContext.Session.GetString("User_LastLogin");
            ViewBag.loggerUser = HttpContext.Session.GetString("loggerUser");
            return View(patients);

        }

        public IActionResult UpdateLobbyTransfer(AllEdit objModel)
        {
            //AllEdit objTest = new AllEdit();
            bool objTest = MedTimersDB.UpdateLobbyTransfer(objModel);
            ViewBag.userType = HttpContext.Session.GetString("userType");
            return RedirectToAction("Index", "Home");

        }


        /*Create New Patient View*/
        public IActionResult CreateNewPatient()
        {
            ViewBag.userType = HttpContext.Session.GetString("userType");
            return View();
        }

        //Send new patient form to database
        [HttpPost]
        public IActionResult CreateNewPatient(AllEdit objModel)
        {

            try
            {
               if (ModelState.IsValid)
                {
                   

                    if (MedTimersDB.AddPatientDetails(objModel))
                    {                       
                        ModelState.Clear();
                        ViewBag.userType = HttpContext.Session.GetString("userType");
                        return RedirectToAction("PatientData", "Home");
                    }

                }

                ViewBag.userType = HttpContext.Session.GetString("userType");
                return View();

            }
            catch (Exception)
            {
                ViewBag.userType = HttpContext.Session.GetString("userType");
                return View();
            }
        }



        /*All patient data home page */
        public IActionResult PatientData()
        {
            List<AllEdit> patients = new List<AllEdit>();
            patients = MedTimersDB.GetHomepage();
            ViewBag.userName = HttpContext.Session.GetString("userName");
            ViewBag.userType = HttpContext.Session.GetString("userType");
            ViewBag.userPassword = HttpContext.Session.GetString("userPassword");
            ViewBag.User_LastLogin = HttpContext.Session.GetString("User_LastLogin");
            ViewBag.loggerUser = HttpContext.Session.GetString("loggerUser");

            return View(patients);

        }


        /***********************TRANSFER PAGES*******************************/

        public IActionResult Transfers()
        {
            List<AllEdit> patients = new List<AllEdit>();
            patients = MedTimersDB.GetTransfer();
            ViewBag.userType = HttpContext.Session.GetString("userType");
            return View(patients);
        }


        /*Edit transfer patient tracking & information page*/
        public IActionResult EditPatient(int PatientID)
        {
            AllEdit objTest = new AllEdit();
            objTest = MedTimersDB.GetPatientEdit(PatientID);

            //Create List for Reasons for multiselect
            List<String> trackReasons = new List<String>();
            trackReasons.Add("Anxiety/Depression");
            trackReasons.Add("Auditory");
            trackReasons.Add("CD");
            trackReasons.Add("Homicidal");
            trackReasons.Add("Information Only");
            trackReasons.Add("Residential Treatment");
            trackReasons.Add("Suicidal");
            trackReasons.Add("Visual");

            ViewBag.reasons = objTest.Track_Reason;
            ViewBag.allReasons = trackReasons;

            ///////////////////////////////////////////////////////

            //Create List for Pronouns for multiselect
            List<String> patientPronouns = new List<String>();
            patientPronouns.Add("She, Her, Hers");
            patientPronouns.Add("He, Him, His");
            patientPronouns.Add("They, Them, Theirs");
            patientPronouns.Add("No Pronoun");
            patientPronouns.Add("No Preference");
            patientPronouns.Add("Not Listed");

            ViewBag.pronouns = objTest.Patient_Pronouns;
            ViewBag.allPronouns = patientPronouns;

            //////////////////////////////////////////////////////

            //Create List for Genders for multiselect
            List<String> patientGenders = new List<String>();
            patientGenders.Add("Cisgender (non-trans) Man");
            patientGenders.Add("Cisgender (non-trans) Woman");
            patientGenders.Add("Gender Non-conforming");
            patientGenders.Add("Gender Varient");
            patientGenders.Add("GenderQueer");
            patientGenders.Add("Non-Binary");
            patientGenders.Add("Intersex");
            patientGenders.Add("Not Listed");
            patientGenders.Add("Transgender Man");
            patientGenders.Add("Transgender Woman");


            ViewBag.genders = objTest.Patient_Gender;
            ViewBag.allGenders = patientGenders;

            //////////////////////////////////////////////////////


            ViewBag.allNurses = objTest.AllNurses;
            ViewBag.nurseID = objTest.NurseID;

            ViewBag.allAssessors = objTest.AllAssessors;
            ViewBag.assessorID = objTest.AssessorID;

            ViewBag.allHospitals = objTest.AllHospitals;
            ViewBag.hospitalID = objTest.HospitalID;

            ViewBag.userType = HttpContext.Session.GetString("userType");
            return View(objTest);

        }

        public IActionResult UpdatePatient(AllEdit objModel)
        {
            bool objTest = MedTimersDB.UpdateAllPatient(objModel);
            ViewBag.userType = HttpContext.Session.GetString("userType");
            return RedirectToAction("PatientData", "Home");
        }




        public IActionResult DeletePatient(int PatientID)
        {
            try
            {
                bool deleteFlag = MedTimersDB.DeletePatient(PatientID);
                ViewBag.userType = HttpContext.Session.GetString("userType");
                return RedirectToAction("PatientData");
            }
            catch (Exception ex)
            {
                ViewBag.userType = HttpContext.Session.GetString("userType");
                return View();
            }
        }

        public IActionResult CreateNewHospital()
        {
            List<AllEdit> patients = new List<AllEdit>();
            patients = MedTimersDB.GetCurrentHospital();
            ViewBag.userType = HttpContext.Session.GetString("userType");
            return View(patients);
        }


        //Submit new account
        [HttpPost]
        public IActionResult CreateNewHospital(AllEdit objModel)
        {
            try
            {
                if (MedTimersDB.AddHospital(objModel))
                {
                    //ViewBag.Message = "Patient has been successfully added.";
                    ModelState.Clear();
                    ViewBag.userType = HttpContext.Session.GetString("userType");
                    return RedirectToAction("CreateNewHospital", "Home");
                }
                ViewBag.userType = HttpContext.Session.GetString("userType");
                return View();

            }
            catch (Exception)
            {
                ViewBag.userType = HttpContext.Session.GetString("userType");
                return View();
            }
        }




        /***********************CERT PAGES***********************************/
        public IActionResult Cert()
        {
            List<AllEdit> patients = new List<AllEdit>();
            patients = MedTimersDB.GetCert();
            ViewBag.userType = HttpContext.Session.GetString("userType");
            return View(patients);
        }


        /***********************ACCOUNTS PAGES***********************************/

        public IActionResult Accounts()
        {
            List<Users> patients = new List<Users>();
            patients = MedTimersDB.GetUsers();
            ViewBag.userType = HttpContext.Session.GetString("userType");
            return View(patients);
        }

        //Add New Account Form
        public IActionResult NewAccount()
        {
            ViewBag.userType = HttpContext.Session.GetString("userType");
            return View();
        }


        //Submit new account
        [HttpPost]
        public IActionResult NewAccount(Users objModel)
        {
            try
            {     
               if (MedTimersDB.AddUser(objModel))
               {
                 ModelState.Clear();
                 ViewBag.userType = HttpContext.Session.GetString("userType");
                 return RedirectToAction("Accounts", "Home");
               }
            ViewBag.userType = HttpContext.Session.GetString("userType");
            return View();

            }
            catch (Exception)
            {
                ViewBag.userType = HttpContext.Session.GetString("userType");
                return View();
            }
        }



        //Edit User Account
        public IActionResult EditAccount(int UserID)
        {
            Users objTest = new Users();
            objTest = MedTimersDB.GetUser(UserID);
            ViewBag.userType = HttpContext.Session.GetString("userType");
            return View(objTest);
        }


        //Update user account
        [HttpPost]
        public IActionResult EditAccount(int UserID, Users objTemp)
        {    
                        
            ViewBag.userType = HttpContext.Session.GetString("userType");
            try
            {
                bool updateFlag = MedTimersDB.UpdateUser(objTemp);
                ViewBag.userType = HttpContext.Session.GetString("userType");
                return RedirectToAction("Accounts");
            }
            catch (Exception)
            {
                ViewBag.userType = HttpContext.Session.GetString("userType");
                return View();
            }
        }



        public IActionResult ResetPassword(Users objModel)
        {
            //AllEdit objTest = new AllEdit();
            bool objTest = MedTimersDB.ResetPassword(objModel);
            ViewBag.userType = HttpContext.Session.GetString("userType");
            return RedirectToAction("Accounts", "Home");

        }


        //Admin update user password
        public IActionResult UpdatePassword(int UserID)
        {
            Users objTest = new Users();
            objTest = MedTimersDB.GetUser(UserID);           
            //ViewBag.userName = HttpContext.Session.GetString("userName");
            ViewBag.userType = HttpContext.Session.GetString("userType");
            //ViewBag.userPassword = HttpContext.Session.GetString("userPassword");
            //ViewBag.loggerUser = HttpContext.Session.GetString("loggerUser");
            return View(objTest);
        }


        //Admin update user password
        [HttpPost]
        public IActionResult UpdatePassword(int UserID, Users objTemp)
        {
            try
            {                 
                ViewBag.userType = HttpContext.Session.GetString("userType");
                //ViewBag.userName = HttpContext.Session.GetString("userName");
                //ViewBag.loggerUser = HttpContext.Session.GetString("loggerUser");

                bool updateFlag = MedTimersDB.UpdatePassword(objTemp);
                return RedirectToAction("Accounts");
              

            }
            catch (Exception)
            {
                //ViewBag.userName = HttpContext.Session.GetString("userName");
                ViewBag.userType = HttpContext.Session.GetString("userType");
                return View();
            }
        }



        //User update user password
        public IActionResult UpdatePasswordSelf(int UserID)
        {
            Users objTest = new Users();
            objTest = MedTimersDB.GetUser(UserID);
            ViewBag.userName = HttpContext.Session.GetString("userName");
            ViewBag.userType = HttpContext.Session.GetString("userType");
            ViewBag.userPassword = HttpContext.Session.GetString("userPassword");
            ViewBag.loggerUser = HttpContext.Session.GetString("loggerUser");

            return View(objTest);
        }


        //User update user password
        [HttpPost]
        public IActionResult UpdatePasswordSelf(int UserID, Users objTemp)
        {
            try
            {
                ViewBag.userName = HttpContext.Session.GetString("userName");
                ViewBag.userType = HttpContext.Session.GetString("userType");
                ViewBag.loggerUser = HttpContext.Session.GetString("loggerUser");
                               
                bool updateFlag = MedTimersDB.UpdatePassword(objTemp);              
                return RedirectToAction("Login");              

            }
            catch (Exception)
            {
                ViewBag.userName = HttpContext.Session.GetString("userName");
                ViewBag.userType = HttpContext.Session.GetString("userType");
                return View();
            } 
        }

        public IActionResult DeleteAccount(int UserID)
        {
            try
            {
                bool deleteFlag = MedTimersDB.DeleteUser(UserID);
                ViewBag.userType = HttpContext.Session.GetString("userType");
                return RedirectToAction("Accounts");
            }
            catch (Exception)
            {
                ViewBag.userType = HttpContext.Session.GetString("userType");
                return View();
            }
        }


        /*****************************REPORTS************************************/

        public IActionResult Reports()
        {
            ViewBag.userType = HttpContext.Session.GetString("userType");
            return View();
        }

        /************************Patient Lobby Forms*****************************/
        public IActionResult PatientForms()
        {
            return View();

        }

        //Export Lobby Data to Excel Spreadsheet
        public ActionResult ExportToExcelLobby()
        {

            DateTime date = new DateTime(2000, 01, 01, 12, 0, 0);


            List<AllEdit> patients = new List<AllEdit>();
            patients = MedTimersDB.GetEMTALA();

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Patients");
                var currentRow = 1;


                var range = worksheet.Range("A1:AA1");
                range.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                range.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                range.Style.Font.SetBold();
                range.Style.Alignment.SetWrapText();
                //range.Style.DateFormat.Format = ("MM dd YYYY hh:mm tt");
                range.Style.Font.FontSize = 12;
                worksheet.Columns(1, 27).AdjustToContents();

                //Column width
                //A:Arrival Time, B:Patient Name, I:MSE Assessment Start Time, P:Departure Time,
                //Q:Arrival To Disposition, J:Nurse L:Assessor, O:Time Patient Went Back To Unit
                worksheet.Columns("A,B,I,P,Q,J,L,O").Width = 20;

                //E:Reason
                worksheet.Column("E").Width = 25;

                //C:Age
                worksheet.Column("C").Width = 5;

                //H:Chief Complaint, N:Emergency Medical Condition, 
                worksheet.Columns("H,N").Width = 17;

                //M:Assessment Room #, R:Departure Time, S:Departure Mode
                worksheet.Columns("M,R, S").Width = 15;

                //D:Sex, F:Arrival Mode, G:Arrival Type
                worksheet.Columns("D,F,G").Width = 10;

                //K:Assessment Wait Time
                worksheet.Column("K").Width = 13;

                #region Header
                worksheet.Cell(currentRow, 1).Value = "Arrival Time";
                worksheet.Cell(currentRow, 2).Value = "Patient Name";
                worksheet.Cell(currentRow, 3).Value = "Age";
                worksheet.Cell(currentRow, 4).Value = "Sex";
                worksheet.Cell(currentRow, 5).Value = "Reason";
                worksheet.Cell(currentRow, 6).Value = "Arrival Mode";
                worksheet.Cell(currentRow, 7).Value = "Arrival Type";
                worksheet.Cell(currentRow, 8).Value = "Chief Complaint";
                worksheet.Cell(currentRow, 9).Value = "MSE Start Time";
                worksheet.Cell(currentRow, 10).Value = "Nurse";
                worksheet.Cell(currentRow, 11).Value = "Assessment Wait Time";
                worksheet.Cell(currentRow, 12).Value = "Assessor Name";
                worksheet.Cell(currentRow, 13).Value = "Assessment Room #";
                worksheet.Cell(currentRow, 14).Value = "Emergency Medical Condition";
                worksheet.Cell(currentRow, 15).Value = "Time Patient Went Back To Unit";
                worksheet.Cell(currentRow, 16).Value = "Departure Time";
                worksheet.Cell(currentRow, 17).Value = "Arrival To Disposition";
                worksheet.Cell(currentRow, 18).Value = "Disposition";
                worksheet.Cell(currentRow, 19).Value = "Departure Mode";


                #endregion

                #region Body
                foreach (var item in patients)
                {
                    currentRow++;

                    if (item.Track_InitialArrival != DateTime.MinValue && item.Track_InitialArrival != date)
                    {
                        worksheet.Cell(currentRow, 1).Value = item.Track_InitialArrival;
                        worksheet.Cell(currentRow, 1).Style.NumberFormat.Format = ("MM/dd/yyyy hh:mm AM/PM");
                    }

                    worksheet.Cell(currentRow, 2).Value = item.Patient_FirstName + " " + item.Patient_LastName;

                    if (item.Patient_DOB != DateTime.MinValue && item.Patient_Age != "102")
                    {
                        worksheet.Cell(currentRow, 3).Value = item.Patient_Age;
                    }

                    worksheet.Cell(currentRow, 4).Value = item.Patient_Sex;
                    worksheet.Cell(currentRow, 5).Value = item.Track_Reason;

                    if (item.Track_ArrivalMode != "Select")
                    {
                        worksheet.Cell(currentRow, 6).Value = item.Track_ArrivalMode;
                    }

                    worksheet.Cell(currentRow, 7).Value = item.Track_ArrivalType;

                    if (item.Track_ChiefComplaint != "Select")
                    {
                        worksheet.Cell(currentRow, 8).Value = item.Track_ChiefComplaint;
                    }

                    if (item.Track_MSEStart != DateTime.MinValue && item.Track_MSEStart != date)
                    {
                        worksheet.Cell(currentRow, 9).Value = item.Track_MSEStart;
                        worksheet.Cell(currentRow, 9).Style.NumberFormat.Format = ("MM/dd/yyyy hh:mm AM/PM");
                    }

                    worksheet.Cell(currentRow, 10).Value = item.Nurse_FirstName + " " + item.Nurse_LastName;

                    if (item.Patient_Wait != "0 Minutes")
                    {
                        worksheet.Cell(currentRow, 11).Value = item.Patient_Wait;
                    }

                    worksheet.Cell(currentRow, 12).Value = item.Assessor_FirstName + " " + item.Assessor_LastName;

                    if (item.Assessment_Room != "Selec")
                    {
                        worksheet.Cell(currentRow, 13).Value = item.Assessment_Room;
                    }

                    worksheet.Cell(currentRow, 14).Value = item.Track_EmergencyMedCondition;

                    if (item.Track_PatientWentToUnit != DateTime.MinValue && item.Track_PatientWentToUnit != date)
                    {
                        worksheet.Cell(currentRow, 15).Value = item.Track_PatientWentToUnit;
                        worksheet.Cell(currentRow, 15).Style.NumberFormat.Format = ("MM/dd/yyyy hh:mm AM/PM");
                    }

                    if (item.Track_DepartureTime != DateTime.MinValue && item.Track_DepartureTime != date)
                    {
                        worksheet.Cell(currentRow, 16).Value = item.Track_DepartureTime;
                        worksheet.Cell(currentRow, 16).Style.NumberFormat.Format = ("MM/dd/yyyy hh:mm AM/PM");
                    }

                    if (item.Track_DispositionArrival != DateTime.MinValue && item.Track_DispositionArrival != date)
                    {
                        worksheet.Cell(currentRow, 17).Value = item.Track_DispositionArrival;
                        worksheet.Cell(currentRow, 17).Style.NumberFormat.Format = ("MM/dd/yyyy hh:mm AM/PM");
                    }

                    if (item.Track_DispositionType != "Select")
                    {
                        worksheet.Cell(currentRow, 18).Value = item.Track_DispositionType;
                    }

                    if (item.Track_DepartureMode != "Select")
                    {
                        worksheet.Cell(currentRow, 19).Value = item.Track_DepartureMode;
                    }

                }
                #endregion


                using (var stream = new MemoryStream())
                {
                    string filename = "EMTALA_MedTimers_Data_" + DateTime.Now.ToString("MM/dd/yyyy") + ".xlsx";

                    workbook.SaveAs(stream);
                    var content = stream.ToArray();

                    return File(
                        content,
                          "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        filename
                        );
                }
            }
        }








        public ActionResult ExportToExcelALL()
        {

            DateTime date = new DateTime(2000, 01, 01, 12, 0, 0);
            DateTime dob = new DateTime(1920, 1, 1);

            List<AllEdit> patients = new List<AllEdit>();
            patients = MedTimersDB.GetAllDataExcel();

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Patients");
                var currentRow = 1;


                var range = worksheet.Range("A1:AN1");
                range.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                range.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                range.Style.Font.SetBold();
                range.Style.Alignment.SetWrapText();
                range.Style.Font.FontSize = 12;
                worksheet.Columns(1, 40).AdjustToContents();

                //Column width
                
                //A:Arrival Time, C:Preferred Name, F:Pronouns,  I:Guardian Relationship, P:SBAR Called, Q:Nurse, R:MSE Assessment Start Time,
                //S:MSE Assessment End Time, T:Assessment Wait Time, U:Assessment Start Time, V:Assessor X:Assessment End Time, Y:Emergency Medical Condition
                //AA:Arrival to Disposition, AB:Disposition Type, AC:Time Patient Went Back to Unit,  AD:Departure Mode, AE:Departure Time,
                //AG:Hospital Phone Number, AH:Hospital Extension Number, AI:Hospital Fax Number, AJ:Transfer Status, AK:Fax Received,
                //AL:Time Notified of Acceptance. AM:Follow Up Complete
                worksheet.Columns("A,C,F,I,P:V,X,Y,AA:AE,AG:AM").Width = 20;


                //B:Patient Name, G:Guardian Name, J:Reason
                worksheet.Columns("B, G, J").Width = 25;

                //D:Age, E:Sex, O:Triage,
                worksheet.Columns("D,E,O").Width = 10;

                //H:Guardian Phone Number N:Admission Type
                worksheet.Columns("H,N").Width = 17;
                
                //L:Arrival Type, M:Chief Complaint,  W:Assessment Room Number
                worksheet.Columns("L,M,W").Width = 15;
                
                //Z:Cert Status
                worksheet.Column("Z").Width = 10;
                
                //K:Arrival Mode
                worksheet.Column("K").Width = 13;

                //AF:Hospital Name
                worksheet.Column("AF").Width = 30;
                
                //AN:Comments
                worksheet.Column("AN").Width = 50;

                #region Header
                worksheet.Cell(currentRow, 1).Value = "Arrival Time";
                worksheet.Cell(currentRow, 2).Value = "Patient Name";
                worksheet.Cell(currentRow, 3).Value = "Preferred Name";
                worksheet.Cell(currentRow, 4).Value = "Age";
                worksheet.Cell(currentRow, 5).Value = "Sex";
                worksheet.Cell(currentRow, 6).Value = "Pronouns";
                worksheet.Cell(currentRow, 7).Value = "Guardian Name";
                worksheet.Cell(currentRow, 8).Value = "Guardian Phone Number";
                worksheet.Cell(currentRow, 9).Value = "Guardian Relationship";
                worksheet.Cell(currentRow, 10).Value = "Reason";
                worksheet.Cell(currentRow, 11).Value = "Arrival Mode";
                worksheet.Cell(currentRow, 12).Value = "Arrival Type";
                worksheet.Cell(currentRow, 13).Value = "Chief Complaint";
                worksheet.Cell(currentRow, 14).Value = "Admission Type";
                worksheet.Cell(currentRow, 15).Value = "Triage";
                worksheet.Cell(currentRow, 16).Value = "SBAR Called";
                worksheet.Cell(currentRow, 17).Value = "Nurse";
                worksheet.Cell(currentRow, 18).Value = "MSE Assessment Start Time";
                worksheet.Cell(currentRow, 19).Value = "MSE Assessment End Time";
                worksheet.Cell(currentRow, 20).Value = "Assessment Wait Time";
                worksheet.Cell(currentRow, 21).Value = "Assessment Start Time";
                worksheet.Cell(currentRow, 22).Value = "Assessor Name";
                worksheet.Cell(currentRow, 23).Value = "Assessment Room #";
                worksheet.Cell(currentRow, 24).Value = "Assessment End Time";
                worksheet.Cell(currentRow, 25).Value = "Emergency Medical Condition";
                worksheet.Cell(currentRow, 26).Value = "Cert Status";
                worksheet.Cell(currentRow, 27).Value = "Arrival To Disposition";
                worksheet.Cell(currentRow, 28).Value = "Disposition";
                worksheet.Cell(currentRow, 29).Value = "Time Patient Went Back To Unit";  
                worksheet.Cell(currentRow, 30).Value = "Departure Mode";
                worksheet.Cell(currentRow, 31).Value = "Departure Time";               
                worksheet.Cell(currentRow, 32).Value = "Hospital Name";
                worksheet.Cell(currentRow, 33).Value = "Hospital Phone Number";
                worksheet.Cell(currentRow, 34).Value = "Hospital Extension Number";
                worksheet.Cell(currentRow, 35).Value = "Hospital Fax Number";
                worksheet.Cell(currentRow, 36).Value = "Transfer Status";
                worksheet.Cell(currentRow, 37).Value = "Fax Received";
                worksheet.Cell(currentRow, 38).Value = "Time Notified of Acceptance";
                worksheet.Cell(currentRow, 39).Value = "Follow Up Complete";
                worksheet.Cell(currentRow, 40).Value = "Comments";


                #endregion

                #region Body
                foreach (var item in patients)
                {
                    currentRow++;

                    if (item.Track_InitialArrival != DateTime.MinValue && item.Track_InitialArrival != date)
                    {
                        worksheet.Cell(currentRow, 1).Value = item.Track_InitialArrival;
                        worksheet.Cell(currentRow, 1).Style.NumberFormat.Format = ("MM/dd/yyyy hh:mm AM/PM");
                    }

                    worksheet.Cell(currentRow, 2).Value = item.Patient_FirstName + " " + item.Patient_LastName;

                    worksheet.Cell(currentRow, 3).Value = item.Patient_PreferredName;

                    if (item.Patient_DOB != DateTime.MinValue && item.Patient_Age != "102")
                    {
                        worksheet.Cell(currentRow, 4).Value = item.Patient_Age;
                    }

                    worksheet.Cell(currentRow, 5).Value = item.Patient_Sex;

                    worksheet.Cell(currentRow, 6).Value = item.Patient_Pronouns;

                    worksheet.Cell(currentRow, 7).Value = item.Patient_GuardianName;
                    worksheet.Cell(currentRow, 8).Value = item.Patient_GuardianPhoneNumber;
                    if (item.Patient_GuardianRelationship != "Select")
                    {
                        worksheet.Cell(currentRow, 9).Value = item.Patient_GuardianRelationship;
                    }

                    worksheet.Cell(currentRow, 10).Value = item.Track_Reason;

                    if (item.Track_ArrivalMode != "Select")
                    {
                        worksheet.Cell(currentRow, 11).Value = item.Track_ArrivalMode;
                    }

                    worksheet.Cell(currentRow, 12).Value = item.Track_ArrivalType;

                    if (item.Track_ChiefComplaint != "Select")
                    {
                        worksheet.Cell(currentRow, 13).Value = item.Track_ChiefComplaint;
                    }

                    worksheet.Cell(currentRow, 14).Value = item.Track_AdmissionType;
                    worksheet.Cell(currentRow, 15).Value = item.Track_TriageLevel;


                    if (item.Track_SBARCall != DateTime.MinValue && item.Track_SBARCall != date)
                    {
                        worksheet.Cell(currentRow, 16).Value = item.Track_SBARCall;
                        worksheet.Cell(currentRow, 16).Style.NumberFormat.Format = ("MM/dd/yyyy hh:mm AM/PM");
                    }

                    worksheet.Cell(currentRow, 17).Value = item.Nurse_FirstName + " " + item.Nurse_LastName;

                    if (item.Track_MSEStart != DateTime.MinValue && item.Track_MSEStart != date)
                    {
                        worksheet.Cell(currentRow, 18).Value = item.Track_MSEStart;
                        worksheet.Cell(currentRow, 18).Style.NumberFormat.Format = ("MM/dd/yyyy hh:mm AM/PM");
                    }

                    if (item.Track_MSEEnd != DateTime.MinValue && item.Track_MSEEnd != date)
                    {
                        worksheet.Cell(currentRow, 19).Value = item.Track_MSEEnd;
                        worksheet.Cell(currentRow, 19).Style.NumberFormat.Format = ("MM/dd/yyyy hh:mm AM/PM");
                    }

                    if (item.Patient_Wait != "0 Minutes" && item.Patient_Wait != "* Minutes")
                    {
                        worksheet.Cell(currentRow, 20).Value = item.Patient_Wait;
                    }

                    if (item.Assessment_StartTime != DateTime.MinValue && item.Assessment_StartTime != date)
                    {
                        worksheet.Cell(currentRow, 21).Value = item.Assessment_StartTime;
                        worksheet.Cell(currentRow, 21).Style.NumberFormat.Format = ("MM/dd/yyyy hh:mm AM/PM");
                    }

                    worksheet.Cell(currentRow, 22).Value = item.Assessor_FirstName + " " + item.Assessor_LastName;

                    if (item.Assessment_Room != "Selec")
                    {
                        worksheet.Cell(currentRow, 23).Value = item.Assessment_Room;
                    }

                    if (item.Assessment_EndTime != DateTime.MinValue && item.Assessment_EndTime != date)
                    {
                        worksheet.Cell(currentRow, 24).Value = item.Assessment_EndTime;
                        worksheet.Cell(currentRow, 24).Style.NumberFormat.Format = ("MM/dd/yyyy hh:mm AM/PM");
                    }

                    worksheet.Cell(currentRow, 25).Value = item.Track_EmergencyMedCondition;
                    worksheet.Cell(currentRow, 26).Value = item.Track_CertStatus;


                    if (item.Track_DispositionArrival != DateTime.MinValue && item.Track_DispositionArrival != date)
                    {
                        worksheet.Cell(currentRow, 27).Value = item.Track_DispositionArrival;
                        worksheet.Cell(currentRow, 27).Style.NumberFormat.Format = ("MM/dd/yyyy hh:mm AM/PM");
                    }

                    if (item.Track_DispositionType != "Select")
                    {
                        worksheet.Cell(currentRow, 28).Value = item.Track_DispositionType;
                    }

                    if (item.Track_PatientWentToUnit != DateTime.MinValue && item.Track_PatientWentToUnit != date)
                    {
                        worksheet.Cell(currentRow, 29).Value = item.Track_PatientWentToUnit;
                        worksheet.Cell(currentRow, 29).Style.NumberFormat.Format = ("MM/dd/yyyy hh:mm AM/PM");
                    }

                    if (item.Track_DepartureMode != "Select")
                    {
                        worksheet.Cell(currentRow, 30).Value = item.Track_DepartureMode;
                    }

                    if (item.Track_DepartureTime != DateTime.MinValue && item.Track_DepartureTime != date)
                    {
                        worksheet.Cell(currentRow, 31).Value = item.Track_DepartureTime;
                        worksheet.Cell(currentRow, 31).Style.NumberFormat.Format = ("MM/dd/yyyy hh:mm AM/PM");
                    }

                   

                    if (item.Hosp_Name != "Select")
                    {
                        worksheet.Cell(currentRow, 32).Value = item.Hosp_Name;
                    }

                    worksheet.Cell(currentRow, 33).Value = item.HospitalPhoneNumber;
                    worksheet.Cell(currentRow, 34).Value = item.HospitalExtensionNumber;
                    worksheet.Cell(currentRow, 35).Value = item.HospitalFaxNumber;

                    if (item.Track_TransferStatus != "Select")
                    {
                        worksheet.Cell(currentRow, 36).Value = item.Track_TransferStatus;
                    }

                    if (item.Track_FaxReceived != DateTime.MinValue && item.Track_FaxReceived != date)
                    {
                        worksheet.Cell(currentRow, 37).Value = item.Track_FaxReceived;
                        worksheet.Cell(currentRow, 37).Style.NumberFormat.Format = ("MM/dd/yyyy hh:mm AM/PM");
                    }

                    if (item.Track_Notified != DateTime.MinValue && item.Track_Notified != date)
                    {
                        worksheet.Cell(currentRow, 38).Value = item.Track_Notified;
                        worksheet.Cell(currentRow, 38).Style.NumberFormat.Format = ("MM/dd/yyyy hh:mm AM/PM");
                    }

                    if (item.Track_FollowUp != DateTime.MinValue && item.Track_FollowUp != date)
                    {
                        worksheet.Cell(currentRow, 39).Value = item.Track_FollowUp;
                        worksheet.Cell(currentRow, 39).Style.NumberFormat.Format = ("MM/dd/yyyy hh:mm AM/PM");
                    }


                    worksheet.Cell(currentRow, 40).Value = item.Track_Comments;

                }
                #endregion


                using (var stream = new MemoryStream())
                {
                    string filename = "All_MedTimers_Data_" + DateTime.Now.ToString("MM/dd/yyyy") + ".xlsx";

                    workbook.SaveAs(stream);
                    var content = stream.ToArray();

                    return File(
                        content,
                          "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        filename
                        );
                }
            }
        }

















    }
}
