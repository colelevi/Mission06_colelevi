using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission06_colelevi.Models
{
    public class ApplicationResponse
    {
        [Key]
        [Required]
        public int MovieId { get; set; } 
        [Required]
        public string Title { get; set; }
        [Required]
        public ushort Year { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public string Rating { get; set; }
        public bool Edited { get; set; }
        public string Lent { get; set; }
        [MaxLength(25)]
        public string Notes { get; set; }

        // Build Foreign Key Relationship
        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
