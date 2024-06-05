using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Simulacro1.Data;
using Simulacro1.Models;
using Simulacro1.Services;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Simulacro1.Models{
    public class Author{
        public int Id {get; set;}

        [Required]
        public string Name {get; set;}

        [Required]
        public string LastName {get; set;}

        [Required]
        public string Email {get; set;}

        [Required]
        public string Nacionality {get; set;}


        public string? Status {get; set;}

        [JsonIgnore]
        public List<Book>? Books { get; set; }

        /* [ForeignKey("DocumentType")] */

    }
}