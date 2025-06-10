using System;
using System.ComponentModel.DataAnnotations;

namespace CoffeeShop.Models
{
    public class Contact
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter your name")]
        [StringLength(30, ErrorMessage = "Name cannot exceed 30 characters.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Please enter your email")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your message")]
        public string Message { get; set; }

        public DateTime SentAt { get; set; } = DateTime.Now;
    }
}
