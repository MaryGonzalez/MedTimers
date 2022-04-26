using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MedTimers.Models
{
    public class Users
    {
        public int UserID { get; set; }

        [MaxLength(30)]
        [Required(ErrorMessage = "*First name is required")]
        public string User_FirstName { get; set; }

        [MaxLength(30)]
        [Required(ErrorMessage = "*Last name is required")]
        public string User_LastName { get; set; }

        public string fullName
        {
            get
            {
                return User_FirstName + " " + User_LastName;
            }
        }

        public string passwordModal
        {
            get
            {
                return "Update Password: " + User_FirstName + " " + User_LastName;
            }
        }

        [MaxLength(50)]
        [Required(ErrorMessage = "*Email is required")]
        public string User_Email { get; set; }

        [MaxLength(30)]
        [Required(ErrorMessage = "*Username is required")]
        public string Username { get; set; }

        public string UserType { get; set; }
        public IEnumerable<SelectListItem> Types { get; set; }

        [Required(ErrorMessage = "*Account type is required")]
        public int UserTypeID { get; set; }  
        
        [Required]
        [MaxLength(30)]
        public string User_Password { get; set; }       

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy hh:mm tt}")]
        public DateTime User_LastLogin { get; set; }

        public bool User_Status { get; set; }

    }
}
