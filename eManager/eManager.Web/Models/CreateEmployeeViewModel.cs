using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eManager.Web.Models
{
    /*decouple the objects that you use to save information into the database,
     * decouple those objects from the objects that you used to receive information 
     * from a user, so that you have these objects view models that will only contain 
     * properties for the information that you expect from the user, 
     * that way no one can sneak in anything on you.*/
    public class CreateEmployeeViewModel
    {
        /*The other nice thing I can do with the view model is 
         * I can mark it up with presentation concerns. For instance,
         * I can add metadata, I've been talking about how the HTML 
         * helpers look at metadata on an object. What's metadata? 
         * Well, it's typically attributes, attributes by default.*/
        [HiddenInput(DisplayValue=false)]
        /**For instance, I can tell the MVC runtime that DepartmentId should be HiddenInput, 
         * it's not something that the user needs to edit, 
         * but it does need to be embedded in the form in an input type equals hidden.*/
        public int DepartmentId { get; set; }
        /* There's also validation attributes. So I can say that the name is a 
         * required field. MVC runtime will automatically do 
         * validation to make sure that was populated. 
         * You can also do range validations and regular 
         * expression matching for your validation.*/
        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyy}", ApplyFormatInEditMode = true)]
        public DateTime HireDate { get; set; }
    }
}