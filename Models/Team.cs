using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication15.Models
{
    public class Team
    {
        public int Id {  get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(50)]
        public string FullName { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(50)]
        public string Position { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(50)]
        public string Description { get; set; }

        public string? ImgUrl { get; set; }

        [NotMapped]
        public IFormFile PhotoFile { get; set; }
    }
}
