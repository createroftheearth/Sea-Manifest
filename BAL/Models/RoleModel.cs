using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BAL.Models
{
    public class RoleModel
    {
        public byte iRoleId { get; set; }
        [MaxLength(50, ErrorMessage = "Role Name cannot exceed 50 characters.")]
        [Required(ErrorMessage = "Role Name is a required field.")]
        public string sRolename { get; set; }
    }

    public class RolePermissionModel
    {
        public byte iRoleId { get; set; }
        public List<PermissionModel> lstPermissionModel { get; set; }
    }

    public class PermissionModel
    {
        public int iPermissionId { get; set; }
        public string sPermissionName { get; set; }
        public string sPath { get; set; }
        public bool isChecked { get; set; }
        public bool bIsVisible { get; set; }
        public List<PermissionModel> childs { get; set; }

    }

    public class PermissionInputModel
    {
        public int iPermissionId { get; set; }
        public int? iParentId { get; set; }
        [MaxLength(50, ErrorMessage = "Permission Name cannot exceed 50 characters.")]
        [Required(ErrorMessage = "Permission Name is a required field.")]
        public string sPermissionName { get; set; }
        [MaxLength(200, ErrorMessage = "Path is a required field.")]
        [Required(ErrorMessage = "Path is a required field.")]
        public string sPath { get; set; }
        public byte iOrder { get; set; }
    }
}
