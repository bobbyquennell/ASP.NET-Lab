using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eManager.Web.Models
{
    /*decouple the objects that you use to save information into the database,
     * decouple those objects from the objects that you used to receive information 
     * from a user, so that you have these objects view models that will only contain 
     * properties for the information that you expect from the user, 
     * that way no one can sneak in anything on you.*/
    public class CreateEmloyeeViewModel
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public DateTime HireDate { get; set; }
    }
}