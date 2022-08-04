using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3.Models
{
    public class StudentModel
    {
        [Required]
        public string FirstName { get; set; } = "first";
        [Required]
        public string LastName { get; set; } = "last";
        [Required]
        public int Age { get; set; } = 1241;
        [Required]
        public string? Description { get; set; } = "desc";
    }
}
