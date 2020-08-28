using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BAL.Models
{
    public class UserModel
    {
        public int iUserId { get; set; }
        [MaxLength(50, ErrorMessage = "Username cannot exceed 50 characters.")]
        [Required(ErrorMessage = "Username is a required field.")]
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Username can only contain alphabets and number without any white spaces.")]
        public string sUsername { get; set; }
        [Required(ErrorMessage = "Password is a required field.")]
        [MaxLength(12, ErrorMessage = "Password cannot exceed 12 characters.")]
        public string sPassword { get; set; }
        [Required(ErrorMessage = "Role is a required field.")]
        public byte iRoleId { get; set; }
        [Required(ErrorMessage = "First Name is a required field.")]
        [MaxLength(100, ErrorMessage = "First Name cannot exceed 100 characters.")]
        public string sFirstName { get; set; }
        [Required(ErrorMessage = "Last Name is a required field.")]
        [MaxLength(100, ErrorMessage = "Last Name cannot exceed 100 characters.")]
        public string sLastName { get; set; }
        [Required(ErrorMessage = "Email is a required field.")]
        [EmailAddress(ErrorMessage = "Please enter valid email address.")]
        public string sEmailID { get; set; }
        [MaxLength(10, ErrorMessage = "Phone Number cannot exceed 10 characters.")]
        [Phone(ErrorMessage = "Please enter valid phone")]
        public string sPhoneNo { get; set; }
        public string sRoleName { get; set; }
    }

}
