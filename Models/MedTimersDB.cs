using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Web.Mvc;

namespace MedTimers.Models
{
    public class MedTimersDB
    {

        //USER LOGIN
        public static int GetLogIn(Users objModel)
        {
            string connString = GetConnectionString();
            String sql = string.Empty;
            SqlConnection db = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            int rowsAffected = 0;

            try
            {


                using (db = new SqlConnection(connString))
                {
                    db.Open();
                    //Call Stored Procedure LogIn and pass in parameters
                    //Stored procedure will compare the username and password submitted to the data in the database
                    sql = "EXEC LogIn @Username, @User_Password";


                    using (cmd = new SqlCommand(sql, db))
                    {
                        cmd.Parameters.AddWithValue("@Username", objModel.Username);
                        cmd.Parameters.AddWithValue("@User_Password", objModel.User_Password);
                        using (dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                rowsAffected = Convert.ToInt32(dr["UserID"].ToString());
                            }
                        }

                    }
                    if (rowsAffected > 0)
                    {
                        //Call Last Login
                        UpdateLastLogin(objModel);
                        return rowsAffected;
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }


        //UPDATE LAST LOGIN
        public static bool UpdateLastLogin(Users objModel)
        {
            string connString = GetConnectionString();
            String sql = string.Empty;
            SqlConnection db = null;
            SqlCommand cmd = null;
            int rowsAffected = 0;

            DateTime LastLogin = DateTime.Now;

            try
            {
                using (db = new SqlConnection(connString))
                {
                    db.Open();
                    //Calls stored procedure and passing in parameters to compare to database values
                    sql = "EXEC UpdateLastLogin  @Username, @User_Password, @User_LastLogin";
                    using (cmd = new SqlCommand(sql, db))
                    {
                        //cmd.Parameters.AddWithValue("@UserID", objModel.UserID);
                        cmd.Parameters.AddWithValue("@Username", objModel.Username);
                        cmd.Parameters.AddWithValue("@User_Password", objModel.User_Password);
                        cmd.Parameters.AddWithValue("@User_LastLogin", LastLogin);

                        rowsAffected = cmd.ExecuteNonQuery();
                    }
                    if (rowsAffected >= 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }





        //ADDING A NEW PATIENT
        public static bool AddPatientDetails(AllEdit objModel)
        {
            string connString = GetConnectionString();
            //Call the stored procedure AddPatientDetails and pass in the parameters
            String sql = "Exec AddPatientDetails @Patient_FirstName,@Patient_LastName, @Patient_PreferredName, @Patient_Pronouns, @Patient_DOB, @Patient_Sex, @Patient_GuardianName, @Patient_GuardianPhoneNumber, @Patient_GuardianRelationship, @Track_Reason, @Track_ChiefComplaint, @Track_ArrivalType, @Track_InitialArrival,  @Track_ArrivalMode, @Track_AdmissionType, @Track_ReceivedReferral";

            SqlConnection db = null;
            SqlCommand cmd = null;
            int rowsAffected = 0;

            //Default datetime to replace null dates
            DateTime date = new DateTime(2000, 01, 01, 12, 0, 0);
            DateTime dob = new DateTime(1920, 01, 01);

            try
            {
                using (db = new SqlConnection(connString))
                {
                    db.Open();
                    using (cmd = new SqlCommand(sql, db))
                    {
                        cmd.Parameters.AddWithValue("@Patient_FirstName", objModel.Patient_FirstName);
                        cmd.Parameters.AddWithValue("@Patient_LastName", objModel.Patient_LastName);
                        cmd.Parameters.AddWithValue("@Patient_PreferredName", objModel.Patient_PreferredName ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Patient_Pronouns", objModel.Patient_Pronouns ?? (object)DBNull.Value);
                        //cmd.Parameters.AddWithValue("@Patient_Gender", objModel.Patient_Gender);


                        if (objModel.Patient_DOB != DateTime.MinValue && objModel.Patient_DOB != null && objModel.Patient_DOB != dob)
                        {
                            cmd.Parameters.AddWithValue("@Patient_DOB", objModel.Patient_DOB);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@Patient_DOB", dob);
                        }

                        cmd.Parameters.AddWithValue("@Patient_Sex", objModel.Patient_Sex ?? (object)DBNull.Value);
                        //cmd.Parameters.AddWithValue("@Patient_EmergencyContactName", objModel.Patient_EmergencyContactName);
                        //cmd.Parameters.AddWithValue("@Patient_EmergencyContactNumber", objModel.Patient_EmergencyContactNumber);
                        //cmd.Parameters.AddWithValue("@Patient_Ethnicity", objModel.Patient_Ethnicity);
                        //cmd.Parameters.AddWithValue("@Patient_Race", objModel.Patient_Race);
                        //cmd.Parameters.AddWithValue("@Patient_EmergencyContactRelationship", objModel.Patient_EmergencyContactRelationship);
                        cmd.Parameters.AddWithValue("@Patient_GuardianName", objModel.Patient_GuardianName ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Patient_GuardianPhoneNumber", objModel.Patient_GuardianPhoneNumber ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Patient_GuardianRelationship", objModel.Patient_GuardianRelationship ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Track_Reason", objModel.Track_Reason ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Track_ChiefComplaint", objModel.Track_ChiefComplaint ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Track_ArrivalType", objModel.Track_ArrivalType ?? (object)DBNull.Value);

                        //If the initial arrival time is not equal to minimum datetime, null, or equal to the default date, assign the datetime to the object
                        if (objModel.Track_InitialArrival != DateTime.MinValue && objModel.Track_InitialArrival != null && objModel.Track_InitialArrival != date)
                        {
                            cmd.Parameters.AddWithValue("@Track_InitialArrival", objModel.Track_InitialArrival);
                        }
                        //If the initial arrival time is equal to null or minimum date, set object to default date
                        else
                        {
                            cmd.Parameters.AddWithValue("@Track_InitialArrival", date);
                        }

                        cmd.Parameters.AddWithValue("@Track_ArrivalMode", objModel.Track_ArrivalMode ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Track_AdmissionType", objModel.Track_AdmissionType ?? (object)DBNull.Value);


                        //If the received referral time is not equal to minimum datetime, null, or equal to the default date, assign the datetime to the object
                        if (objModel.Track_ReceivedReferral != DateTime.MinValue && objModel.Track_ReceivedReferral != null && objModel.Track_ReceivedReferral != date)
                        {
                            cmd.Parameters.AddWithValue("@Track_ReceivedReferral", objModel.Track_ReceivedReferral);
                        }
                        //If the received referral time is equal to null or minimum date, set object to default date
                        else
                        {
                            cmd.Parameters.AddWithValue("@Track_ReceivedReferral", date);
                        }




                        rowsAffected = cmd.ExecuteNonQuery();
                    }
                    if (rowsAffected >= 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //NAME DROPDOWN LIST
        //Populates the name list on the Index (Lobby) page
        public static List<AllEdit> GetNames()
        {
            string connString = GetConnectionString();

            List<AllEdit> myList = new List<AllEdit>();

            //Calls stored procedure and pulls all the patients
            String sql = "EXEC GetNames";


            SqlConnection db = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            try
            {
                using (db = new SqlConnection(connString))
                {
                    db.Open();
                    using (cmd = new SqlCommand(sql, db))
                    {
                        using (dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                AllEdit objTmp = new AllEdit();
                                objTmp.PatientID = Convert.ToInt32(dr["PatientID"].ToString());
                                objTmp.Patient_FirstName = dr["Patient_FirstName"].ToString();
                                objTmp.Patient_LastName = dr["Patient_LastName"].ToString();
                                objTmp.Track_ArrivalType = dr["Track_ArrivalType"].ToString();
                                objTmp.Patient_Sex = dr["Patient_Sex"].ToString();

                                //Only grab patients if their initial arrival time is not null
                                if (!Convert.IsDBNull(dr["Track_InitialArrival"]))
                                {
                                    objTmp.Track_InitialArrival = Convert.ToDateTime(dr["Track_InitialArrival"].ToString());
                                }

                                myList.Add(objTmp);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return myList;
        }

        //NURSE DROPDOWN LIST
        //Populates the nurses list on the _PatientTrackingPartial page
        public static List<SelectListItem> GetNurses(int NurseID)
        {
            string connString = GetConnectionString();

            List<SelectListItem> myList = new List<SelectListItem>();

            //Calls the stored procedure to pull any Nurse account type 
            String sql = "EXEC AllNurses";


            SqlConnection db = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            //Add Default Selection if no nurse is selected from the dropdown
            SelectListItem defaultOne = new SelectListItem();
            defaultOne.Value = "None";
            defaultOne.Text = "Select";
            myList.Add(defaultOne);

            if (NurseID == 0)
            {
                defaultOne.Selected = true;
            }


            try
            {
                using (db = new SqlConnection(connString))
                {
                    db.Open();
                    using (cmd = new SqlCommand(sql, db))
                    {
                        using (dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                SelectListItem objTmp = new SelectListItem();
                                objTmp.Value = dr["NurseID"].ToString();
                                objTmp.Text = dr["Nurse_FirstName"].ToString() + " " + dr["Nurse_LastName"].ToString();

                                //Compare the nurseID value in the database to the nurse list
                                if (objTmp.Value == NurseID.ToString())
                                {
                                    objTmp.Selected = true;
                                }

                                myList.Add(objTmp);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }



            return myList;
        }





        //ASSESSOR DROPDOWN LIST
        //Populates the assessors list on the _PatientTrackingPartial and _PatientTransferPartial page
        public static List<SelectListItem> GetAssessors(int AssessorID)
        {
            string connString = GetConnectionString();

            List<SelectListItem> myList = new List<SelectListItem>();

            //Calls the stored procedure to pull any Assessor account type 
            String sql = "EXEC AllAssessors";


            SqlConnection db = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;


            //Add Default Selection if no assessor is selected from the dropdown
            SelectListItem defaultOne = new SelectListItem();
            defaultOne.Value = "None";
            defaultOne.Text = "Select";
            myList.Add(defaultOne);

            if (AssessorID == 0)
            {
                defaultOne.Selected = true;
            }

            try
            {
                using (db = new SqlConnection(connString))
                {
                    db.Open();
                    using (cmd = new SqlCommand(sql, db))
                    {
                        using (dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                SelectListItem objTmp = new SelectListItem();
                                objTmp.Value = dr["AssessorID"].ToString();
                                objTmp.Text = dr["Assessor_FirstName"].ToString() + " " + dr["Assessor_LastName"].ToString();

                                //Compare the assessorID value in the database to the assessor list
                                if (objTmp.Value == AssessorID.ToString())
                                {
                                    objTmp.Selected = true;
                                }



                                myList.Add(objTmp);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return myList;
        }




        //HOSPITAL DROPDOWN LIST
        //Populates the hospital list on the _PatientTransferPartial page
        public static List<SelectListItem> GetHospitals(int HospitalID)
        {
            string connString = GetConnectionString();

            List<SelectListItem> myList = new List<SelectListItem>();

            //Calls the stored procedure to pull all the hospitals
            String sql = "EXEC AllHospitals";


            SqlConnection db = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            //Add Default Selection if no hospital is selected from the dropdown
            SelectListItem defaultOne = new SelectListItem();
            defaultOne.Value = "1";
            defaultOne.Text = "Select";
            myList.Add(defaultOne);

            if (HospitalID == 0)
            {
                defaultOne.Selected = true;
            }

            try
            {
                using (db = new SqlConnection(connString))
                {
                    db.Open();
                    using (cmd = new SqlCommand(sql, db))
                    {
                        using (dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                SelectListItem objTmp = new SelectListItem();
                                objTmp.Value = dr["HospitalID"].ToString();
                                objTmp.Text = dr["Hosp_Name"].ToString();
                                if (objTmp.Value == HospitalID.ToString())
                                {
                                    objTmp.Selected = true;
                                }

                                myList.Add(objTmp);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return myList;
        }






        //GET LOBBY DATA
        public static List<AllEdit> GetLobbyData()
        {
            string connString = GetConnectionString();

            List<AllEdit> myList = new List<AllEdit>();

            //Calls stored procedure to pull all patients data
            String sql = "EXEC GetLobbyData";

            SqlConnection db = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            try
            {
                using (db = new SqlConnection(connString))
                {
                    db.Open();
                    using (cmd = new SqlCommand(sql, db))
                    {
                        using (dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                AllEdit objTmp = new AllEdit();
                                objTmp.Patient_FirstName = dr["Patient_FirstName"].ToString();
                                objTmp.Patient_LastName = dr["Patient_LastName"].ToString();
                                objTmp.Track_ArrivalType = dr["Track_ArrivalType"].ToString();
                                if (!Convert.IsDBNull(dr["Track_InitialArrival"]))
                                {
                                    objTmp.Track_InitialArrival = Convert.ToDateTime(dr["Track_InitialArrival"].ToString());
                                }


                                myList.Add(objTmp);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return myList;
        }






































        //LOBBY ARRIVAL TIME UPDATE
        //When a transfer patient has arrived to the hospital, the Track_Arrival time is updated
        public static bool UpdateLobbyTransfer(AllEdit objModel)
        {
            string connString = GetConnectionString();
            String sql = string.Empty;
            SqlConnection db = null;
            SqlCommand cmd = null;
            int rowsAffected = 0;

            try
            {
                using (db = new SqlConnection(connString))
                {
                    db.Open();

                    //Calls the UpdateLobbyTransfer stored procedure to update the initial arrival time using the patient id
                    sql = "EXEC UpdateLobbyTransfer @PatientID, @Track_InitialArrival";
                    using (cmd = new SqlCommand(sql, db))
                    {
                        cmd.Parameters.AddWithValue("@PatientID", objModel.PatientID);
                        cmd.Parameters.AddWithValue("@Track_InitialArrival", objModel.Track_InitialArrival);

                        rowsAffected = cmd.ExecuteNonQuery();
                    }
                    if (rowsAffected >= 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }



        //TRANSFER PAGE
        public static List<AllEdit> GetTransfer()
        {
            string connString = GetConnectionString();

            List<AllEdit> myList = new List<AllEdit>();

            //Calls the stored procedure to pull all transfer patient data
            String sql = "EXEC GetTransfer";

            SqlConnection db = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;


            try
            {
                using (db = new SqlConnection(connString))
                {
                    db.Open();
                    using (cmd = new SqlCommand(sql, db))
                    {
                        using (dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                AllEdit objTmp = new AllEdit();
                                objTmp.PatientID = Convert.ToInt32(dr["PatientID"].ToString());
                                if (!Convert.IsDBNull(dr["Track_ReceivedReferral"]))
                                {
                                    objTmp.Track_ReceivedReferral = Convert.ToDateTime(dr["Track_ReceivedReferral"].ToString());
                                }

                                objTmp.Patient_FirstName = dr["Patient_FirstName"].ToString();
                                objTmp.Patient_LastName = dr["Patient_LastName"].ToString();
                                objTmp.Patient_PreferredName = dr["Patient_PreferredName"].ToString();
                                objTmp.Patient_Gender = dr["Patient_Gender"].ToString();
                                objTmp.Patient_Pronouns = dr["Patient_Pronouns"].ToString();

                                objTmp.Patient_DOB = Convert.ToDateTime(dr["Patient_DOB"].ToString());
                                objTmp.Patient_Sex = dr["Patient_Sex"].ToString();
                                objTmp.Track_Reason = dr["Track_Reason"].ToString();

                                objTmp.Track_ArrivalMode = dr["Track_ArrivalMode"].ToString();
                                objTmp.Track_ArrivalType = dr["Track_ArrivalType"].ToString();
                                objTmp.Track_ChiefComplaint = dr["Track_ChiefComplaint"].ToString();
                                objTmp.Hosp_Name = dr["Hosp_Name"].ToString();
                                objTmp.HospitalPhoneNumber = dr["HospitalPhoneNumber"].ToString();
                                objTmp.HospitalExtensionNumber = dr["HospitalExtensionNumber"].ToString();
                                objTmp.HospitalFaxNumber = dr["HospitalFaxNumber"].ToString();

                                objTmp.Track_TransferStatus = dr["Track_TransferStatus"].ToString();
                                objTmp.Nurse_FirstName = dr["Nurse_FirstName"].ToString();
                                objTmp.Nurse_LastName = dr["Nurse_LastName"].ToString();
                                objTmp.Assessor_FirstName = dr["Assessor_FirstName"].ToString();
                                objTmp.Assessor_LastName = dr["Assessor_LastName"].ToString();

                                if (!Convert.IsDBNull(dr["Track_FaxReceived"]))
                                {
                                    objTmp.Track_FaxReceived = Convert.ToDateTime(dr["Track_FaxReceived"].ToString());
                                }

                                if (!Convert.IsDBNull(dr["Track_Notified"]))
                                {
                                    objTmp.Track_Notified = Convert.ToDateTime(dr["Track_Notified"].ToString());
                                }

                                if (!Convert.IsDBNull(dr["Track_FollowUp"]))
                                {
                                    objTmp.Track_FollowUp = Convert.ToDateTime(dr["Track_FollowUp"].ToString());
                                }

                                if (!Convert.IsDBNull(dr["Track_SBARCall"]))
                                {
                                    objTmp.Track_SBARCall = Convert.ToDateTime(dr["Track_SBARCall"].ToString());
                                }

                                if (!Convert.IsDBNull(dr["Track_InitialArrival"]))
                                {
                                    objTmp.Track_InitialArrival = Convert.ToDateTime(dr["Track_InitialArrival"].ToString());
                                }

                                objTmp.Track_CertStatus = dr["Track_CertStatus"].ToString();

                                objTmp.Track_AdmissionType = dr["Track_AdmissionType"].ToString();

                                myList.Add(objTmp);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return myList;
        }



        //CERT PAGE
        public static List<AllEdit> GetCert()
        {
            string connString = GetConnectionString();

            List<AllEdit> myList = new List<AllEdit>();

            //Calls stored procedure and pulls any patient data with a deferred cert status
            String sql = "EXEC GetCert";


            SqlConnection db = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            try
            {
                using (db = new SqlConnection(connString))
                {
                    db.Open();
                    using (cmd = new SqlCommand(sql, db))
                    {
                        using (dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                AllEdit objTmp = new AllEdit();

                                objTmp.PatientID = Convert.ToInt32(dr["PatientID"].ToString());
                                objTmp.Patient_FirstName = dr["Patient_FirstName"].ToString();
                                objTmp.Patient_LastName = dr["Patient_LastName"].ToString();
                                objTmp.Patient_PreferredName = dr["Patient_PreferredName"].ToString();
                                objTmp.Track_CertStatus = dr["Track_CertStatus"].ToString();
                                objTmp.Assessor_FirstName = dr["Assessor_FirstName"].ToString();
                                objTmp.Assessor_LastName = dr["Assessor_LastName"].ToString();

                                if (!Convert.IsDBNull(dr["Track_InitialArrival"]))
                                {
                                    objTmp.Track_InitialArrival = Convert.ToDateTime(dr["Track_InitialArrival"].ToString());
                                }


                                objTmp.Track_Reason = dr["Track_Reason"].ToString();

                                if (!Convert.IsDBNull(dr["Track_ReceivedReferral"]))
                                {
                                    objTmp.Track_ReceivedReferral = Convert.ToDateTime(dr["Track_ReceivedReferral"].ToString());
                                }

                                objTmp.Track_ArrivalType = dr["Track_ArrivalType"].ToString();

                                objTmp.Track_AdmissionType = dr["Track_AdmissionType"].ToString();

                                myList.Add(objTmp);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return myList;
        }



        //PatientData Page
        public static List<AllEdit> GetHomepage()
        {
            string connString = GetConnectionString();

            List<AllEdit> myList = new List<AllEdit>();

            //Calls stored procedure to pull any patient data that has an initial arrival time
            String sql = "EXEC GETHOMEPAGE";

            SqlConnection db = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;


            try
            {
                using (db = new SqlConnection(connString))
                {
                    db.Open();
                    using (cmd = new SqlCommand(sql, db))
                    {
                        using (dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                AllEdit objTmp = new AllEdit();

                                objTmp.PatientID = Convert.ToInt32(dr["PatientID"].ToString());

                                if (!Convert.IsDBNull(dr["Track_InitialArrival"]))
                                {
                                    objTmp.Track_InitialArrival = Convert.ToDateTime(dr["Track_InitialArrival"].ToString());
                                }

                                objTmp.Patient_FirstName = dr["Patient_FirstName"].ToString();
                                objTmp.Patient_LastName = dr["Patient_LastName"].ToString();
                                objTmp.Patient_PreferredName = dr["Patient_PreferredName"].ToString();
                                if (!Convert.IsDBNull(dr["Patient_DOB"]))
                                {
                                    objTmp.Patient_DOB = Convert.ToDateTime(dr["Patient_DOB"].ToString());
                                }
                                objTmp.Patient_Sex = dr["Patient_Sex"].ToString();
                                objTmp.Track_Reason = dr["Track_Reason"].ToString();

                                objTmp.Track_AdmissionType = dr["Track_AdmissionType"].ToString();

                                objTmp.Track_ArrivalMode = dr["Track_ArrivalMode"].ToString();
                                objTmp.Track_ArrivalType = dr["Track_ArrivalType"].ToString();
                                objTmp.Track_ChiefComplaint = dr["Track_ChiefComplaint"].ToString();

                                objTmp.Track_AdmissionType = dr["Track_AdmissionType"].ToString();
                                objTmp.Track_TriageLevel = dr["Track_TriageLevel"].ToString();



                                if (!Convert.IsDBNull(dr["Track_SBARCall"]))
                                {
                                    objTmp.Track_SBARCall = Convert.ToDateTime(dr["Track_SBARCall"].ToString());
                                }


                                if (!Convert.IsDBNull(dr["Track_MSEStart"]))
                                {
                                    objTmp.Track_MSEStart = Convert.ToDateTime(dr["Track_MSEStart"].ToString());
                                }


                                if (!Convert.IsDBNull(dr["Track_MSEEnd"]))
                                {
                                    objTmp.Track_MSEEnd = Convert.ToDateTime(dr["Track_MSEEnd"].ToString());
                                }


                                if (!Convert.IsDBNull(dr["Assessment_StartTime"]))
                                {
                                    objTmp.Assessment_StartTime = Convert.ToDateTime(dr["Assessment_StartTime"].ToString());
                                }


                                if (!Convert.IsDBNull(dr["Assessment_EndTime"]))
                                {
                                    objTmp.Assessment_EndTime = Convert.ToDateTime(dr["Assessment_EndTime"].ToString());
                                }

                                objTmp.Nurse_FirstName = dr["Nurse_FirstName"].ToString();
                                objTmp.Nurse_LastName = dr["Nurse_LastName"].ToString();

                                objTmp.Assessor_FirstName = dr["Assessor_FirstName"].ToString();
                                objTmp.Assessor_LastName = dr["Assessor_LastName"].ToString();



                                objTmp.Assessment_Room = dr["Assessment_Room"].ToString();
                                objTmp.Track_EmergencyMedCondition = dr["Track_EmergencyMedCondition"].ToString();
                                objTmp.Track_CertStatus = dr["Track_CertStatus"].ToString();


                                if (!Convert.IsDBNull(dr["Track_DispositionArrival"]))
                                {
                                    objTmp.Track_DispositionArrival = Convert.ToDateTime(dr["Track_DispositionArrival"].ToString());
                                }


                                objTmp.Track_DispositionType = dr["Track_DispositionType"].ToString();


                                if (!Convert.IsDBNull(dr["Track_PatientWentToUnit"]))
                                {
                                    objTmp.Track_PatientWentToUnit = Convert.ToDateTime(dr["Track_PatientWentToUnit"].ToString());
                                }

                                objTmp.Track_DepartureMode = dr["Track_DepartureMode"].ToString();


                                if (!Convert.IsDBNull(dr["Track_DepartureTime"]))
                                {
                                    objTmp.Track_DepartureTime = Convert.ToDateTime(dr["Track_DepartureTime"].ToString());
                                }


                                myList.Add(objTmp);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return myList;
        }


        //GET USER ACCOUNTS
        public static List<Users> GetUsers()
        {
            string connString = GetConnectionString();

            List<Users> myList = new List<Users>();

            //Calls stored procedure to pull all user accounts
            String sql = "EXEC GetUsers";

            SqlConnection db = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            try
            {
                using (db = new SqlConnection(connString))
                {
                    db.Open();
                    using (cmd = new SqlCommand(sql, db))
                    {
                        using (dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                Users objTmp = new Users();
                                objTmp.UserID = Convert.ToInt32(dr["UserID"].ToString());
                                objTmp.User_FirstName = dr["User_FirstName"].ToString();
                                objTmp.User_LastName = dr["User_LastName"].ToString();
                                objTmp.User_Email = dr["User_Email"].ToString();
                                objTmp.Username = dr["Username"].ToString();
                                objTmp.UserType = dr["UserType"].ToString();
                                objTmp.User_Password = dr["User_Password"].ToString();
                                //objTmp.UserTypeID = Convert.ToInt32(dr["UserTypeID"].ToString());
                                if (!Convert.IsDBNull(dr["User_LastLogin"]))
                                {
                                    objTmp.User_LastLogin = Convert.ToDateTime(dr["User_LastLogin"].ToString());
                                }

                                myList.Add(objTmp);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return myList;
        }



        //ADD NEW USER ACCOUNT
        public static bool AddUser(Users objModel)
        {
            string connString = GetConnectionString();

            //Calls stored procedure and passes in parameters
            String sql = "EXEC AddUser @User_FirstName, @User_LastName, @User_Email, @Username, @UserTypeID, @User_Password";
            SqlConnection db = null;
            SqlCommand cmd = null;
            int rowsAffected = 0;

            try
            {
                using (db = new SqlConnection(connString))
                {
                    db.Open();
                    using (cmd = new SqlCommand(sql, db))
                    {
                       
                            cmd.Parameters.AddWithValue("@User_FirstName", objModel.User_FirstName);
                            cmd.Parameters.AddWithValue("@User_LastName", objModel.User_LastName);
                            cmd.Parameters.AddWithValue("@User_Email", objModel.User_Email);
                            cmd.Parameters.AddWithValue("@Username", objModel.Username);
                            cmd.Parameters.AddWithValue("@UserTypeID", objModel.UserTypeID);
                            cmd.Parameters.AddWithValue("@User_Password", "Zc!p2h@T");

                        rowsAffected = cmd.ExecuteNonQuery();
                    }
                    if (rowsAffected >= 1)
                    {                      
                            return true;
                        
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }







        //EDIT USER ACCOUNT
        public static Users GetUser(int UserID)
        {
            string connString = GetConnectionString();

            //Calls stored procedure and passing in the userID
            String sql = "EXEC GetUserID '" + UserID.ToString() + "'";

            SqlConnection db = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            Users objTemp = null;

            try
            {
                using (db = new SqlConnection(connString))
                {
                    db.Open();
                    using (cmd = new SqlCommand(sql, db))
                    {
                        cmd.Parameters.AddWithValue("@UserID", UserID);
                        using (dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                objTemp = new Users();
                                objTemp.UserID = Convert.ToInt16(dr["UserID"].ToString());
                                objTemp.User_FirstName = dr["User_FirstName"].ToString();
                                objTemp.User_LastName = dr["User_LastName"].ToString();
                                objTemp.User_Email = dr["User_Email"].ToString();
                                objTemp.Username = dr["Username"].ToString();
                                objTemp.User_Password = dr["User_Password"].ToString();
                                //objTemp.UserType = dr["UserType"].ToString();

                                if (!Convert.IsDBNull(dr["User_LastLogin"]))
                                {
                                    objTemp.User_LastLogin = Convert.ToDateTime(dr["User_LastLogin"].ToString());
                                }
                                objTemp.UserTypeID = Convert.ToInt16(dr["UserTypeID"].ToString());

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return objTemp;
        }

        //UPDATE USER ACCOUNT
        public static bool UpdateUser(Users objModel)
        {
            string connString = GetConnectionString();
            String sql = string.Empty;
            SqlConnection db = null;
            SqlCommand cmd = null;
            int rowsAffected = 0;

            try
            {
                using (db = new SqlConnection(connString))
                {
                    db.Open();
                    sql = "EXEC UpdateUser @UserID, @User_FirstName, @User_LastName, @User_Email, @Username, @UserTypeID";
                    using (cmd = new SqlCommand(sql, db))
                    {
                        cmd.Parameters.AddWithValue("@UserID", objModel.UserID);
                        cmd.Parameters.AddWithValue("@User_FirstName", objModel.User_FirstName);
                        cmd.Parameters.AddWithValue("@User_LastName", objModel.User_LastName);
                        cmd.Parameters.AddWithValue("@User_Email", objModel.User_Email);
                        cmd.Parameters.AddWithValue("@Username", objModel.Username);
                        cmd.Parameters.AddWithValue("@UserTypeID", objModel.UserTypeID);

                        rowsAffected = cmd.ExecuteNonQuery();
                    }
                    if (rowsAffected >= 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        //Reset Password
        public static bool ResetPassword (Users objModel)
        {
            string connString = GetConnectionString();
            String sql = string.Empty;
            SqlConnection db = null;
            SqlCommand cmd = null;
            int rowsAffected = 0;
     

            try
            {
                using (db = new SqlConnection(connString))
                {
                    db.Open();

                    //Calls stored prodedure and passes in parameters
                    sql = "EXEC UserPasswordUpdate @UserID, @User_Password";

                    using (cmd = new SqlCommand(sql, db))
                    {
                        cmd.Parameters.AddWithValue("@UserID", objModel.UserID);
                        cmd.Parameters.AddWithValue("@User_Password", "Zc!p2h@T");


                        rowsAffected = cmd.ExecuteNonQuery();
                    }
                    if (rowsAffected >= 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }



        //UPDATE USER PASSWORD
        public static bool UpdatePassword(Users objModel)
        {
            string connString = GetConnectionString();
            String sql = string.Empty;
            SqlConnection db = null;
            SqlCommand cmd = null;
            int rowsAffected = 0;

            try
            {
                using (db = new SqlConnection(connString))
                {
                    db.Open();
                    //Calls stored procedure and passing in parameters to compare to database values
                    sql = "EXEC UserPasswordUpdate @UserID, @User_Password";
                    using (cmd = new SqlCommand(sql, db))
                    {
                        cmd.Parameters.AddWithValue("@UserID", objModel.UserID);
                        cmd.Parameters.AddWithValue("@User_Password", objModel.User_Password);

                        rowsAffected = cmd.ExecuteNonQuery();
                    }
                    if (rowsAffected >= 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }





        //DELETE USER ACCOUNT
        public static bool DeleteUser(int UserID)
        {
            string connString = GetConnectionString();
            String sql = string.Empty;
            SqlConnection db = null;
            SqlCommand cmd = null;
            int rowsAffected = 0;

            try
            {
                using (db = new SqlConnection(connString))
                {
                    db.Open();
                    //Calls stored procedure and passing in UserID parameter
                    sql = "EXEC DeleteUser @UserID";
                    using (cmd = new SqlCommand(sql, db))
                    {
                        cmd.Parameters.AddWithValue("@UserID", UserID);
                        rowsAffected = cmd.ExecuteNonQuery();
                    }
                    if (rowsAffected >= 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }






        //GET PATIENT DATA BASED ON PATIENTID
        public static AllEdit GetPatientEdit(int PatientID)
        {
            string connString = GetConnectionString();

            //Calls stored procedure and passing in the patientID parameter
            String sql = "EXEC TransferPatientID '" + PatientID.ToString() + "'";

            SqlConnection db = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            AllEdit objTemp = null;


            try
            {
                using (db = new SqlConnection(connString))
                {
                    db.Open();
                    using (cmd = new SqlCommand(sql, db))
                    {
                        cmd.Parameters.AddWithValue("@PatientID", PatientID);
                        using (dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                objTemp = new AllEdit();



                                objTemp.PatientID = Convert.ToInt32(dr["PatientID"].ToString());
                                objTemp.Patient_FirstName = dr["Patient_FirstName"].ToString();
                                objTemp.Patient_LastName = dr["Patient_LastName"].ToString();
                                objTemp.Patient_PreferredName = dr["Patient_PreferredName"].ToString();
                                objTemp.Patient_Gender = dr["Patient_Gender"].ToString();
                                objTemp.Patient_Pronouns = dr["Patient_Pronouns"].ToString();
                                objTemp.Patient_Sex = dr["Patient_Sex"].ToString();
                                objTemp.Patient_DOB = Convert.ToDateTime(dr["Patient_DOB"].ToString());

                                objTemp.Patient_Ethnicity = dr["Patient_Ethnicity"].ToString();
                                objTemp.Patient_Race = dr["Patient_Race"].ToString();
                                objTemp.Patient_EmergencyContactName = dr["Patient_EmergencyContactName"].ToString();
                                objTemp.Patient_EmergencyContactRelationship = dr["Patient_EmergencyContactRelationship"].ToString();
                                objTemp.Patient_EmergencyContactNumber = dr["Patient_EmergencyContactNumber"].ToString();

                                objTemp.Patient_GuardianName = dr["Patient_GuardianName"].ToString();
                                objTemp.Patient_GuardianPhoneNumber = dr["Patient_GuardianPhoneNumber"].ToString();
                                objTemp.Patient_GuardianRelationship = dr["Patient_GuardianRelationship"].ToString();

                                

                                objTemp.Track_AdmissionType = dr["Track_AdmissionType"].ToString();

                                if (!Convert.IsDBNull(dr["Track_InitialArrival"]))
                                {
                                    objTemp.Track_InitialArrival = Convert.ToDateTime(dr["Track_InitialArrival"].ToString());
                                }

                                objTemp.Track_Reason = dr["Track_Reason"].ToString();
                                objTemp.Track_ArrivalMode = dr["Track_ArrivalMode"].ToString();
                                objTemp.Track_ArrivalType = dr["Track_ArrivalType"].ToString();
                                objTemp.Track_ChiefComplaint = dr["Track_ChiefComplaint"].ToString();



                                if (!Convert.IsDBNull(dr["Track_TriageLevel"]))
                                {
                                    objTemp.Track_TriageLevel = dr["Track_TriageLevel"].ToString();
                                }


                                if (!Convert.IsDBNull(dr["Track_SBARCall"]))
                                {
                                    objTemp.Track_SBARCall = Convert.ToDateTime(dr["Track_SBARCall"].ToString());
                                }

                                if (!Convert.IsDBNull(dr["Track_MSEStart"]))
                                {
                                    objTemp.Track_MSEStart = Convert.ToDateTime(dr["Track_MSEStart"].ToString());
                                }

                                if (!Convert.IsDBNull(dr["Track_MSEEnd"]))
                                {
                                    objTemp.Track_MSEEnd = Convert.ToDateTime(dr["Track_MSEEnd"].ToString());
                                }

                                if (!Convert.IsDBNull(dr["Assessment_StartTime"]))
                                {
                                    objTemp.Assessment_StartTime = Convert.ToDateTime(dr["Assessment_StartTime"].ToString());
                                }

                                objTemp.Assessment_Room = dr["Assessment_Room"].ToString();

                                if (!Convert.IsDBNull(dr["Assessment_EndTime"]))
                                {
                                    objTemp.Assessment_EndTime = Convert.ToDateTime(dr["Assessment_EndTime"].ToString());
                                }


                                objTemp.Nurse_FirstName = dr["Nurse_FirstName"].ToString();
                                objTemp.Nurse_LastName = dr["Nurse_LastName"].ToString();
                                objTemp.Assessor_FirstName = dr["Assessor_FirstName"].ToString();
                                objTemp.Assessor_LastName = dr["Assessor_LastName"].ToString();

                                if (!Convert.IsDBNull(dr["NurseID"]))
                                {
                                    objTemp.NurseID = Convert.ToInt32(dr["NurseID"].ToString());
                                }

                                if (!Convert.IsDBNull(dr["AssessorID"]))
                                {
                                    objTemp.AssessorID = Convert.ToInt32(dr["AssessorID"].ToString());
                                }

                                if (!Convert.IsDBNull(dr["NurseID"]))
                                {
                                    objTemp.AllNurses = GetNurses(Convert.ToInt32(dr["NurseID"].ToString()));
                                }
                                else
                                {
                                    objTemp.AllNurses = GetNurses(0);
                                }

                                if (!Convert.IsDBNull(dr["AssessorID"]))
                                {
                                    objTemp.AllAssessors = GetAssessors(Convert.ToInt32(dr["AssessorID"].ToString()));
                                }
                                else
                                {
                                    objTemp.AllAssessors = GetAssessors(0);
                                }

                                objTemp.Track_EmergencyMedCondition = dr["Track_EmergencyMedCondition"].ToString();
                                objTemp.Track_CertStatus = dr["Track_CertStatus"].ToString();

                                if (!Convert.IsDBNull(dr["Track_DispositionArrival"]))
                                {
                                    objTemp.Track_DispositionArrival = Convert.ToDateTime(dr["Track_DispositionArrival"].ToString());
                                }

                                objTemp.Track_DispositionType = dr["Track_DispositionType"].ToString();

                                if (!Convert.IsDBNull(dr["Track_PatientWentToUnit"]))
                                {
                                    objTemp.Track_PatientWentToUnit = Convert.ToDateTime(dr["Track_PatientWentToUnit"].ToString());
                                }

                                objTemp.Track_DepartureMode = dr["Track_DepartureMode"].ToString();

                                if (!Convert.IsDBNull(dr["Track_DepartureTime"]))
                                {
                                    objTemp.Track_DepartureTime = Convert.ToDateTime(dr["Track_DepartureTime"].ToString());
                                }

                                objTemp.Track_Comments = dr["Track_Comments"].ToString();



                                if (!Convert.IsDBNull(dr["HospitalID"]))
                                {
                                    objTemp.HospitalID = Convert.ToInt32(dr["HospitalID"].ToString());
                                }


                                if (!Convert.IsDBNull(dr["HospitalID"]))
                                {
                                    objTemp.AllHospitals = GetHospitals(Convert.ToInt32(dr["HospitalID"].ToString()));
                                }
                                else
                                {
                                    objTemp.AllHospitals = GetHospitals(0);
                                }

                                if (!Convert.IsDBNull(dr["HospitalPhoneNumber"]))
                                {
                                    objTemp.HospitalPhoneNumber = dr["HospitalPhoneNumber"].ToString();
                                }

                                if (!Convert.IsDBNull(dr["HospitalExtensionNumber"]))
                                {
                                    objTemp.HospitalExtensionNumber = dr["HospitalExtensionNumber"].ToString();
                                }


                                if (!Convert.IsDBNull(dr["HospitalFaxNumber"]))
                                {
                                    objTemp.HospitalFaxNumber = dr["HospitalFaxNumber"].ToString();
                                }

                                if (!Convert.IsDBNull(dr["Track_TransferStatus"]))
                                {
                                    objTemp.Track_TransferStatus = dr["Track_TransferStatus"].ToString();
                                }

                                if (!Convert.IsDBNull(dr["Track_FaxReceived"]))
                                {
                                    objTemp.Track_FaxReceived = Convert.ToDateTime(dr["Track_FaxReceived"].ToString());
                                }


                                if (!Convert.IsDBNull(dr["Track_Notified"]))
                                {
                                    objTemp.Track_Notified = Convert.ToDateTime(dr["Track_Notified"].ToString());
                                }


                                if (!Convert.IsDBNull(dr["Track_FollowUp"]))
                                {
                                    objTemp.Track_FollowUp = Convert.ToDateTime(dr["Track_FollowUp"].ToString());
                                }

                                if (!Convert.IsDBNull(dr["Track_ReceivedReferral"]))
                                {
                                    objTemp.Track_ReceivedReferral = Convert.ToDateTime(dr["Track_ReceivedReferral"].ToString());
                                }

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return objTemp;
        }












        //UPDATE PATIENT DATA
        public static bool UpdateAllPatient(AllEdit objModel)
        {
            string connString = GetConnectionString();
            String sql = string.Empty;
            SqlConnection db = null;
            SqlCommand cmd = null;
            int rowsAffected = 0;

            //Default datetime
            DateTime date = new DateTime(2000, 01, 01, 12, 0, 0);
            DateTime dob = new DateTime(1920, 01, 01);

            try
            {
                using (db = new SqlConnection(connString))
                {
                    db.Open();

                    //Calls stored prodedure and passes in parameters
                    sql = "EXEC UpdateAllPatient @PatientID, @Patient_FirstName, @Patient_LastName, @Patient_PreferredName, @Patient_Sex, @Patient_Pronouns, @Patient_DOB, @Patient_GuardianName, @Patient_GuardianPhoneNumber, @Patient_GuardianRelationship, @Track_AdmissionType, @Track_InitialArrival, @Track_Reason, @Track_ArrivalMode, @Track_ArrivalType, @Track_ChiefComplaint, @Track_TriageLevel, @Track_SBARCall, @NurseID, @Track_MSEStart, @Track_MSEEnd, @Assessment_StartTime, @AssessorID, @Assessment_Room, @Assessment_EndTime, @Track_EmergencyMedCondition, @Track_CertStatus, @Track_DispositionArrival, @Track_DispositionType, @Track_PatientWentToUnit, @Track_DepartureMode, @Track_DepartureTime, @Track_Comments, @Track_ReceivedReferral, @HospitalID, @HospitalPhoneNumber, @HospitalExtensionNumber, @HospitalFaxNumber, @Track_TransferStatus, @Track_FaxReceived, @Track_Notified, @Track_FollowUp";

                    using (cmd = new SqlCommand(sql, db))
                    {
                        cmd.Parameters.AddWithValue("@PatientID", objModel.PatientID);
                        cmd.Parameters.AddWithValue("@Patient_FirstName", objModel.Patient_FirstName);
                        cmd.Parameters.AddWithValue("@Patient_LastName", objModel.Patient_LastName);
                        cmd.Parameters.AddWithValue("@Patient_PreferredName", objModel.Patient_PreferredName ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Patient_Sex", objModel.Patient_Sex ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Patient_Pronouns", objModel.Patient_Pronouns ?? (object)DBNull.Value);
                        //cmd.Parameters.AddWithValue("@Patient_Gender", objModel.Patient_Gender);
                        if (objModel.Patient_DOB != DateTime.MinValue && objModel.Patient_DOB != null && objModel.Patient_DOB != dob)
                        {
                            cmd.Parameters.AddWithValue("@Patient_DOB", objModel.Patient_DOB);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@Patient_DOB", dob);
                        }

                        //cmd.Parameters.AddWithValue("@Patient_Ethnicity", objModel.Patient_Ethnicity ?? (object)DBNull.Value);
                        //cmd.Parameters.AddWithValue("@Patient_Race", objModel.Patient_Race ?? (object)DBNull.Value);
                        //cmd.Parameters.AddWithValue("@Patient_EmergencyContactName", objModel.Patient_EmergencyContactName ?? (object)DBNull.Value);
                        //cmd.Parameters.AddWithValue("@Patient_EmergencyContactNumber", objModel.EmergencyContactNumber ?? (object)DBNull.Value);
                        //cmd.Parameters.AddWithValue("@Patient_EmergencyContactRelationship", objModel.Patient_EmergencyContactRelationship ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Patient_GuardianName", objModel.Patient_GuardianName ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Patient_GuardianPhoneNumber", objModel.Patient_GuardianPhoneNumber ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Patient_GuardianRelationship", objModel.Patient_GuardianRelationship ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Track_AdmissionType", objModel.Track_AdmissionType ?? (object)DBNull.Value);



                        //If the initial arrival time is not equal to minimum datetime, null, or equal to the default date, assign the datetime to the object
                        if (objModel.Track_InitialArrival != DateTime.MinValue && objModel.Track_InitialArrival != date && objModel.Track_InitialArrival != null)
                        {
                            cmd.Parameters.AddWithValue("@Track_InitialArrival", objModel.Track_InitialArrival);
                        }
                        //If the initial arrival time is equal to null or minimum date, set object to default date
                        else
                        {
                            cmd.Parameters.AddWithValue("@Track_InitialArrival", date);
                        }


                        cmd.Parameters.AddWithValue("@Track_Reason", objModel.Track_Reason ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Track_ArrivalMode", objModel.Track_ArrivalMode ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Track_ArrivalType", objModel.Track_ArrivalType ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Track_ChiefComplaint", objModel.Track_ChiefComplaint ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Track_TriageLevel", objModel.Track_TriageLevel ?? (object)DBNull.Value);

                        //If the SBar call time is not equal to minimum datetime, assign the datetime to the object
                        if (objModel.Track_SBARCall != DateTime.MinValue)
                        {
                            cmd.Parameters.AddWithValue("@Track_SBARCall", objModel.Track_SBARCall);
                        }
                        //If the SBar call time is equal to minimum date, set object to default date
                        else
                        {
                            cmd.Parameters.AddWithValue("@Track_SBARCall", date);
                        }



                        cmd.Parameters.AddWithValue("@NurseID", objModel.NurseID);


                        //If the MSE Start time is not equal to minimum datetime, assign the datetime to the object
                        if (objModel.Track_MSEStart != DateTime.MinValue)
                        {
                            cmd.Parameters.AddWithValue("@Track_MSEStart", objModel.Track_MSEStart);
                        }
                        //If the MSE Start time is equal to minimum date, set object to default date
                        else
                        {
                            cmd.Parameters.AddWithValue("@Track_MSEStart", date);
                        }


                        //If the MSE End time is not equal to minimum datetime, assign the datetime to the object
                        if (objModel.Track_MSEEnd != DateTime.MinValue)
                        {
                            cmd.Parameters.AddWithValue("@Track_MSEEnd", objModel.Track_MSEEnd);
                        }
                        //If the MSE End time is equal to minimum date, set object to default date
                        else
                        {
                            cmd.Parameters.AddWithValue("@Track_MSEEnd", date);
                        }

                        //If the assessment start time is not equal to minimum datetime, assign the datetime to the object
                        if (objModel.Assessment_StartTime != DateTime.MinValue)
                        {
                            cmd.Parameters.AddWithValue("@Assessment_StartTime", objModel.Assessment_StartTime);
                        }
                        //If the assessment start time is equal to minimum date, set object to default date
                        else
                        {
                            cmd.Parameters.AddWithValue("@Assessment_StartTime", date);
                        }

                        cmd.Parameters.AddWithValue("@AssessorID", objModel.AssessorID);



                        //If the assessment end time is not equal to minimum datetime, assign the datetime to the object
                        if (objModel.Assessment_EndTime != DateTime.MinValue)
                        {
                            cmd.Parameters.AddWithValue("@Assessment_EndTime", objModel.Assessment_EndTime);
                        }
                        //If the assessment end time is equal to minimum date, set object to default date
                        else
                        {
                            cmd.Parameters.AddWithValue("@Assessment_EndTime", date);
                        }



                        cmd.Parameters.AddWithValue("@Assessment_Room", objModel.Assessment_Room ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Track_EmergencyMedCondition", objModel.Track_EmergencyMedCondition ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Track_CertStatus", objModel.Track_CertStatus ?? (object)DBNull.Value);

                        //If the disposition arrival time is not equal to minimum datetime, assign the datetime to the object
                        if (objModel.Track_DispositionArrival != DateTime.MinValue)
                        {
                            cmd.Parameters.AddWithValue("@Track_DispositionArrival", objModel.Track_DispositionArrival);
                        }
                        //If the disposition arrival time is equal to minimum date, set object to default date
                        else
                        {
                            cmd.Parameters.AddWithValue("@Track_DispositionArrival", date);
                        }

                        cmd.Parameters.AddWithValue("@Track_DispositionType", objModel.Track_DispositionType ?? (object)DBNull.Value);


                        //If the patient went to unit time is not equal to minimum datetime, assign the datetime to the object
                        if (objModel.Track_PatientWentToUnit != DateTime.MinValue)
                        {
                            cmd.Parameters.AddWithValue("@Track_PatientWentToUnit", objModel.Track_PatientWentToUnit);
                        }
                        //If the patient went to unit time is equal to minimum date, set object to default date
                        else
                        {
                            cmd.Parameters.AddWithValue("@Track_PatientWentToUnit", date);
                        }

                        cmd.Parameters.AddWithValue("@Track_DepartureMode", objModel.Track_DepartureMode ?? (object)DBNull.Value);


                        //If the departure time is not equal to minimum datetime, assign the datetime to the object
                        if (objModel.Track_DepartureTime != DateTime.MinValue)
                        {
                            cmd.Parameters.AddWithValue("@Track_DepartureTime", objModel.Track_DepartureTime);
                        }
                        //If the departure time is equal to minimum date, set object to default date
                        else
                        {
                            cmd.Parameters.AddWithValue("@Track_DepartureTime", date);
                        }


                        cmd.Parameters.AddWithValue("@Track_Comments", objModel.Track_Comments ?? (object)DBNull.Value);



                        //If the received referral time is not equal to minimum datetime, null, or equal to the default date, assign the datetime to the object
                        if (objModel.Track_ReceivedReferral != DateTime.MinValue && objModel.Track_ReceivedReferral != date && objModel.Track_ReceivedReferral != null)
                        {
                            cmd.Parameters.AddWithValue("@Track_ReceivedReferral", objModel.Track_ReceivedReferral);
                        }
                        //If the received referral time is equal to minimum date, set object to default date
                        else
                        {
                            cmd.Parameters.AddWithValue("@Track_ReceivedReferral", date);
                        }

                        //If the hospitalID is not equal to 0 or 1, assign hospitalID to object 
                        if (objModel.HospitalID != 0 && objModel.HospitalID != 1)
                        {
                            cmd.Parameters.AddWithValue("@HospitalID", objModel.HospitalID);
                        }
                        //If the hospitalID is null or empty, assign it to default hospital 1
                        else
                        {
                            cmd.Parameters.AddWithValue("@HospitalID", 1);
                        }

                        cmd.Parameters.AddWithValue("@HospitalPhoneNumber", objModel.HospitalPhoneNumber ?? (object)DBNull.Value);

                        cmd.Parameters.AddWithValue("@HospitalExtensionNumber", objModel.HospitalExtensionNumber ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@HospitalFaxNumber", objModel.HospitalFaxNumber ?? (object)DBNull.Value);



                        cmd.Parameters.AddWithValue("@Track_TransferStatus", objModel.Track_TransferStatus ?? (object)DBNull.Value);



                        //If the fax recieved time is not equal to minimum datetime, assign the datetime to the object
                        if (objModel.Track_FaxReceived != DateTime.MinValue)
                        {
                            cmd.Parameters.AddWithValue("@Track_FaxReceived", objModel.Track_FaxReceived);
                        }
                        //If the fax recieved time is equal to minimum date, set object to default date
                        else
                        {
                            cmd.Parameters.AddWithValue("@Track_FaxReceived", date);
                        }


                        //If the time notified is not equal to minimum datetime, assign the datetime to the object
                        if (objModel.Track_Notified != DateTime.MinValue)
                        {
                            cmd.Parameters.AddWithValue("@Track_Notified", objModel.Track_Notified);
                        }
                        //If the time notified time is equal to minimum date, set object to default date
                        else
                        {
                            cmd.Parameters.AddWithValue("@Track_Notified", date);
                        }


                        //If the follow up time is not equal to minimum datetime, assign the datetime to the object
                        if (objModel.Track_FollowUp != DateTime.MinValue)
                        {
                            cmd.Parameters.AddWithValue("@Track_FollowUp", objModel.Track_FollowUp);
                        }
                        //If the follow up time is equal to minimum date, set object to default date
                        else
                        {
                            cmd.Parameters.AddWithValue("@Track_FollowUp", date);
                        }




                        rowsAffected = cmd.ExecuteNonQuery();
                    }
                    if (rowsAffected >= 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }


        //DELETE PATIENT
        public static bool DeletePatient(int PatientID)
        {
            string connString = GetConnectionString();
            String sql = string.Empty;
            SqlConnection db = null;
            SqlCommand cmd = null;
            int rowsAffected = 0;

            try
            {
                using (db = new SqlConnection(connString))
                {
                    db.Open();
                    sql = "EXEC DeletePatient @PatientID";
                    using (cmd = new SqlCommand(sql, db))
                    {
                        cmd.Parameters.AddWithValue("@PatientID", PatientID);
                        rowsAffected = cmd.ExecuteNonQuery();
                    }
                    if (rowsAffected >= 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }





        //EXCEL EMTALA LOG
        public static List<AllEdit> GetEMTALA()
        {

            string connString = GetConnectionString();

            List<AllEdit> myList = new List<AllEdit>();

            //Calls stored procedure
            String sql = "EXEC GetEMTALA";

            SqlConnection db = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            try
            {
                using (db = new SqlConnection(connString))
                {
                    db.Open();
                    using (cmd = new SqlCommand(sql, db))
                    {
                        using (dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                AllEdit objTmp = new AllEdit();


                                objTmp.Track_InitialArrival = Convert.ToDateTime(dr["Track_InitialArrival"].ToString());
                                objTmp.Patient_FirstName = dr["Patient_FirstName"].ToString();
                                objTmp.Patient_LastName = dr["Patient_LastName"].ToString();
                                objTmp.Patient_Age = dr["Patient_Age"].ToString();
                                objTmp.Patient_Sex = dr["Patient_Sex"].ToString();
                                objTmp.Track_Reason = dr["Track_Reason"].ToString();
                                objTmp.Track_ArrivalMode = dr["Track_ArrivalMode"].ToString();
                                objTmp.Track_ArrivalType = dr["Track_ArrivalType"].ToString();
                                objTmp.Track_ChiefComplaint = dr["Track_ChiefComplaint"].ToString();

                                if (!Convert.IsDBNull(dr["Track_MSEStart"]))
                                {
                                    objTmp.Track_MSEStart = Convert.ToDateTime(dr["Track_MSEStart"].ToString());
                                }

                                objTmp.Nurse_FirstName = dr["Nurse_FirstName"].ToString();
                                objTmp.Nurse_LastName = dr["Nurse_LastName"].ToString();
                                objTmp.Patient_Wait = dr["Patient_Wait"].ToString();
                                objTmp.Assessor_FirstName = dr["Assessor_FirstName"].ToString();
                                objTmp.Assessor_LastName = dr["Assessor_LastName"].ToString();
                                objTmp.Assessment_Room = dr["Assessment_Room"].ToString();
                                objTmp.Track_EmergencyMedCondition = dr["Track_EmergencyMedCondition"].ToString();

                                if (!Convert.IsDBNull(dr["Track_PatientWentToUnit"]))
                                {
                                    objTmp.Track_PatientWentToUnit = Convert.ToDateTime(dr["Track_PatientWentToUnit"].ToString());
                                }

                                if (!Convert.IsDBNull(dr["Track_DepartureTime"]))
                                {
                                    objTmp.Track_DepartureTime = Convert.ToDateTime(dr["Track_DepartureTime"].ToString());
                                }

                                if (!Convert.IsDBNull(dr["Track_DispositionArrival"]))
                                {
                                    objTmp.Track_DispositionArrival = Convert.ToDateTime(dr["Track_DispositionArrival"].ToString());
                                }

                                objTmp.Track_DispositionType = dr["Track_DispositionType"].ToString();
                                objTmp.Track_DepartureMode = dr["Track_DepartureMode"].ToString();

                                myList.Add(objTmp);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return myList;
        }





        //EXCEL EMTALA LOG
        public static List<AllEdit> GetAllDataExcel()
        {

            string connString = GetConnectionString();

            List<AllEdit> myList = new List<AllEdit>();

            //Calls stored procedure
            String sql = "EXEC GetALLDATA";

            SqlConnection db = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            try
            {
                using (db = new SqlConnection(connString))
                {
                    db.Open();
                    using (cmd = new SqlCommand(sql, db))
                    {
                        using (dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                AllEdit objTmp = new AllEdit();


                                objTmp.Track_InitialArrival = Convert.ToDateTime(dr["Track_InitialArrival"].ToString());
                                objTmp.Patient_FirstName = dr["Patient_FirstName"].ToString();
                                objTmp.Patient_LastName = dr["Patient_LastName"].ToString();
                                objTmp.Patient_PreferredName = dr["Patient_PreferredName"].ToString();
                                objTmp.Patient_Age = dr["Patient_Age"].ToString();
                                objTmp.Patient_Sex = dr["Patient_Sex"].ToString();
                                objTmp.Patient_Pronouns = dr["Patient_Pronouns"].ToString();
                                objTmp.Patient_GuardianName = dr["Patient_GuardianName"].ToString();
                                objTmp.Patient_GuardianPhoneNumber = dr["Patient_GuardianPhoneNumber"].ToString();
                                objTmp.Patient_GuardianRelationship = dr["Patient_GuardianRelationship"].ToString();
                                objTmp.Track_Reason = dr["Track_Reason"].ToString();
                                objTmp.Track_ArrivalMode = dr["Track_ArrivalMode"].ToString();
                                objTmp.Track_ArrivalType = dr["Track_ArrivalType"].ToString();
                                objTmp.Track_ChiefComplaint = dr["Track_ChiefComplaint"].ToString();
                                objTmp.Track_AdmissionType = dr["Track_AdmissionType"].ToString();
                                objTmp.Track_TriageLevel = dr["Track_TriageLevel"].ToString();

                                if (!Convert.IsDBNull(dr["Track_SBARCall"]))
                                {
                                    objTmp.Track_SBARCall = Convert.ToDateTime(dr["Track_SBARCall"].ToString());
                                }

                                objTmp.Nurse_FirstName = dr["Nurse_FirstName"].ToString();
                                objTmp.Nurse_LastName = dr["Nurse_LastName"].ToString();


                                if (!Convert.IsDBNull(dr["Track_MSEStart"]))
                                {
                                    objTmp.Track_MSEStart = Convert.ToDateTime(dr["Track_MSEStart"].ToString());
                                }

                                if (!Convert.IsDBNull(dr["Track_MSEEnd"]))
                                {
                                    objTmp.Track_MSEEnd = Convert.ToDateTime(dr["Track_MSEEnd"].ToString());
                                }


                                objTmp.Patient_Wait = dr["Patient_Wait"].ToString();


                                if (!Convert.IsDBNull(dr["Assessment_StartTime"]))
                                {
                                    objTmp.Assessment_StartTime = Convert.ToDateTime(dr["Assessment_StartTime"].ToString());
                                }

                                objTmp.Assessor_FirstName = dr["Assessor_FirstName"].ToString();
                                objTmp.Assessor_LastName = dr["Assessor_LastName"].ToString();
                                objTmp.Assessment_Room = dr["Assessment_Room"].ToString();

                                if (!Convert.IsDBNull(dr["Assessment_EndTime"]))
                                {
                                    objTmp.Assessment_EndTime = Convert.ToDateTime(dr["Assessment_EndTime"].ToString());
                                }

                                objTmp.Track_EmergencyMedCondition = dr["Track_EmergencyMedCondition"].ToString();

                                objTmp.Track_CertStatus = dr["Track_CertStatus"].ToString();

                                if (!Convert.IsDBNull(dr["Track_DispositionArrival"]))
                                {
                                    objTmp.Track_DispositionArrival = Convert.ToDateTime(dr["Track_DispositionArrival"].ToString());
                                }

                                objTmp.Track_DispositionType = dr["Track_DispositionType"].ToString();

                                if (!Convert.IsDBNull(dr["Track_PatientWentToUnit"]))
                                {
                                    objTmp.Track_PatientWentToUnit = Convert.ToDateTime(dr["Track_PatientWentToUnit"].ToString());
                                }

                                objTmp.Track_DepartureMode = dr["Track_DepartureMode"].ToString();

                                if (!Convert.IsDBNull(dr["Track_DepartureTime"]))
                                {
                                    objTmp.Track_DepartureTime = Convert.ToDateTime(dr["Track_DepartureTime"].ToString());
                                }

                                objTmp.Track_Comments = dr["Track_Comments"].ToString();
                                objTmp.Hosp_Name = dr["Hosp_Name"].ToString();
                                objTmp.HospitalPhoneNumber = dr["HospitalPhoneNumber"].ToString();
                                objTmp.HospitalExtensionNumber = dr["HospitalExtensionNumber"].ToString();
                                objTmp.HospitalFaxNumber = dr["HospitalFaxNumber"].ToString();
                                objTmp.Track_TransferStatus = dr["Track_TransferStatus"].ToString();

                                if (!Convert.IsDBNull(dr["Track_FaxReceived"]))
                                {
                                    objTmp.Track_FaxReceived = Convert.ToDateTime(dr["Track_FaxReceived"].ToString());
                                }

                                if (!Convert.IsDBNull(dr["Track_Notified"]))
                                {
                                    objTmp.Track_Notified = Convert.ToDateTime(dr["Track_Notified"].ToString());
                                }

                                if (!Convert.IsDBNull(dr["Track_FollowUp"]))
                                {
                                    objTmp.Track_FollowUp = Convert.ToDateTime(dr["Track_FollowUp"].ToString());
                                }


                                myList.Add(objTmp);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return myList;
        }

























        //DISPLAY ALL CURRENT HOSPITALS
        public static List<AllEdit> GetCurrentHospital()
        {
            string connString = GetConnectionString();

            List<AllEdit> myList = new List<AllEdit>();

            //Calls stored procedure to pull all user accounts
            String sql = "EXEC GetCurrentHospitals";

            SqlConnection db = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            try
            {
                using (db = new SqlConnection(connString))
                {
                    db.Open();
                    using (cmd = new SqlCommand(sql, db))
                    {
                        using (dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                AllEdit objTmp = new AllEdit();                           
                                objTmp.Hosp_Name = dr["Hosp_Name"].ToString();                             
                               
                                myList.Add(objTmp);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return myList;
        }




        //ADD NEW HOSPITAL
        public static bool AddHospital(AllEdit objModel)
        {
            string connString = GetConnectionString();

            //Calls stored procedure and passess in parameters
            String sql = "EXEC AddHospital @Hosp_Name, @Hosp_Street, @Hosp_City, @Hosp_State, @Hosp_ZipCode";
            SqlConnection db = null;
            SqlCommand cmd = null;
            int rowsAffected = 0;

            try
            {
                using (db = new SqlConnection(connString))
                {
                    db.Open();
                    using (cmd = new SqlCommand(sql, db))
                    {
                        cmd.Parameters.AddWithValue("@Hosp_Name", objModel.Hosp_Name);
                        cmd.Parameters.AddWithValue("@Hosp_Street", objModel.Hosp_Street);
                        cmd.Parameters.AddWithValue("@Hosp_City", objModel.Hosp_City);
                        cmd.Parameters.AddWithValue("@Hosp_State", objModel.Hosp_State);
                        cmd.Parameters.AddWithValue("@Hosp_ZipCode", objModel.Hosp_ZipCode);

                        rowsAffected = cmd.ExecuteNonQuery();
                    }
                    if (rowsAffected >= 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }










        private static string GetConnectionString()
        {
            string connectionString = String.Empty;

            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", false)
            .Build();

            connectionString = configuration.GetSection("connectionString").Value;
            return connectionString;
        }
    }
}
