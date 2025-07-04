﻿using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models
{
    public class RegisterViewModel
    {
        public required string UserName { get; set; }
        public required string FullName { get; set; }

        [DataType(DataType.EmailAddress)]
        public required string Email { get; set; }
        
        [DataType(DataType.Password)]
        public required string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="Password do not match")]
        public required string ConfirmPassword { get; set; }



    }
}
