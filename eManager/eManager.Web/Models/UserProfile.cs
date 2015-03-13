using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace eManager.Web.Models
{
    //this UserProfile definition comes from AccountModels.cs, we just want more control of the membership in MVC4
     // we also delete the definition of UserContext in AccountModel.cs, and move the SQL server table of UserProfile to our Own
    // DepartmentDb.cs. see more details about this 
    // in scott allen's course: 
    //Building Applications with ASP.NET MVC4\7 Security and ASP.NET MVC4\5 Taking Control of Membership
    [Table("UserProfile")]
    public class UserProfile
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string UserName { get; set; }
    }
}