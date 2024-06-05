using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Simulacro1.Data;
using Simulacro1.Models;
using Simulacro1.Services;

namespace Simulacro1.Controllers{
    public class AuthorsCreateController : ControllerBase{
        private readonly IAuthorRepository _authorRepository;

        public AuthorsCreateController(IAuthorRepository authorRepository){
            _authorRepository = authorRepository;
        }

        [HttpPost]
        [Route("api/author")]
        public IActionResult Create([FromBody] Author author){
            try{
                _authorRepository.Add(author);
                return Ok("El autor se creó correctamente");
            }
            catch (System.Exception)
            {   
                return BadRequest("El autor no pudo crearse");
            }

        }

        
    }
}