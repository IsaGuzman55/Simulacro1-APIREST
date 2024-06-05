using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Simulacro1.Data;
using Simulacro1.Models;
using Simulacro1.Services;

namespace Simulacro1.Controllers{
    public class AuthorsUpdateController : ControllerBase{
        private readonly IAuthorRepository _authorRepository;

        public AuthorsUpdateController(IAuthorRepository authorRepository){
            _authorRepository = authorRepository;
        }

        [HttpPut]
        [Route("api/author/{id}/update")]
        public IActionResult Update([FromBody] Author author){
            try
            {
                _authorRepository.Update(author);
                return Ok("El autor se actualizó correctamente");

            }
            catch (System.Exception)
            {   
                return BadRequest("El autor no se actualizó");
            }
        }

        
        [HttpPut]
        [Route("api/author/{id}/changeStatus")]
        public IActionResult Status(int id){
            try{
                _authorRepository.ChangeStatus(id);
                return Ok("El autor cambio de estado correctamente");
            }
            catch (System.Exception ex){
                return NotFound(ex.Message);
            }
        }

        
    }
}