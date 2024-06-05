using System.ComponentModel.DataAnnotations;
using System;

namespace Simulacro1.Models{
    public class Book{
        public int Id {get; set;}

        [Required]
        public string Title {get; set;}

        [Required]
        public int Pages {get; set;}

        [Required]
        public string Language {get; set;}

        [Required]
        public DateOnly PublicationDate {get; set;}

        [Required]
        public string Description {get; set;}

        public string? Status {get; set;}


        [Required]
        public int AuthorId {get; set;}
        public Author Author { get; set; }

        
        [Required]
        public int EditorialId {get; set;}
        public Editorial Editorial { get; set; }


    }
}