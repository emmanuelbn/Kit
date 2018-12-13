using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Profilz.Models
{
    [Table("Users")]
    public class User : Model 
    {
        
       // public int Id { get; set; }

        
        [Required(ErrorMessage ="nom non valideuser")]
        [DisplayName("quel nom ?")]
        public string Username { get; set; }

        [Required(ErrorMessage = "EMail invalide user")]
        [DisplayName("quel Email ?")]
        [StringLength(64)]
        [EmailAddress(ErrorMessage ="jaid it invalide")]
        public string Email { get; set; }

        [Required(ErrorMessage = "password trop court user")]
        [DisplayName("quel password ?")]
        [MinLength(8)]        
        [PasswordPropertyText]
        public string Password { get; set; }

      

        [NotMapped]
        [HiddenInput(DisplayValue = false)]
        public bool IsAuthenticated { get; set; } = false;

        public User()
        { }
        public override void UpdateFrom(Model source)
        {
            if (source is User user && user.Id == Id)
            {
                this.Username = user.Username;
                this.Email = user.Email;
                this.Password = user.Password;
            }
        }
        public void Copy(User user)
        {
            this.Username = user.Username;
            this.Email = user.Email;
            this.Password = user.Password;
                
        }
    }
}