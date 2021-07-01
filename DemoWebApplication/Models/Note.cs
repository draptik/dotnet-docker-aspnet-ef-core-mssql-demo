using System;
using System.ComponentModel.DataAnnotations;

namespace DemoWebApplication.Models
{
    public class Note
    {
        [Key]
        public int Id { get; set; }
        
        public string Summary { get; set; }
    }
}