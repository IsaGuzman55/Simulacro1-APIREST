using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Simulacro1.Data;
using Simulacro1.Models;
using Simulacro1.Services;

namespace Simulacro1.Controllers{
    public class AuthorsController : ControllerBase{
        private readonly IAuthorRepository _authorRepository;

        public AuthorsController(IAuthorRepository authorRepository){
            _authorRepository = authorRepository;
        }

        [HttpGet]
        [Route("api/authors")]
        public IActionResult GetAuthors(){
            var authors = _authorRepository.GetAll();
            if(!authors.Any()){
                return Ok(new {Message = "No hay autores registrados"});
            }
            return Ok(authors);
        }

        [HttpGet]
        [Route("api/authors/inactives")]
        public async Task<IActionResult> GetInactiveAuthors() {
            IEnumerable<Author> inactiveAuthors = await _authorRepository.GetInactiveAuthorsAsync();
            if(!inactiveAuthors.Any()){
                return Ok(new {Message = "No hay autores inactivos"});
            }
            return Ok(inactiveAuthors);
        }

        [HttpGet]
        [Route("api/author/{id}")]
        public IActionResult Details(int id){
            var author = _authorRepository.GetById(id);
            if(author == null){
                return NotFound("Este autor no existe");
            }
            return Ok(author);
        }

    }
}