using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Practica_MVC.Models.ViewModels
{
    public class UsuarioVM
    {

        [Required]
        [StringLength(50,ErrorMessage ="Cantidad de caracteres incorrecta debe ser  Min 5 Max 50",MinimumLength = 5)]
        [Display(Name="Nombre")]
        public string Name { get; set; }
       
        [Required]
        [StringLength(50, ErrorMessage = "Cantidad de caracteres incorrecta debe ser  Min 5 Max 50", MinimumLength = 5)]
        [Display(Name = "Apellido")]
        public string Apellido { get; set; }
        
        [Required]
        [EmailAddress]
        [Display(Name = "Correo")]
        public string Correo { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmar Contraseña")]
        [Compare("Password",ErrorMessage = "Las contraseñas no son iguales")]
        public string Repassword { get; set; }



    }

    public class EditUsuarioVM
    {

        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Cantidad de caracteres incorrecta debe ser  Min 5 Max 50", MinimumLength = 5)]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Cantidad de caracteres incorrecta debe ser  Min 5 Max 50", MinimumLength = 5)]
        [Display(Name = "Apellido")]
        public string Apellido { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Correo")]
        public string Correo { get; set; }

         
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar Contraseña")]
        [Compare("Password", ErrorMessage = "Las contraseñas no son iguales")]
        public string Repassword { get; set; }



    }
}