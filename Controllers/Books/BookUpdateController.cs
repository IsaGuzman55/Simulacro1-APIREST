using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Simulacro1.Data;
using Simulacro1.Models;
using Simulacro1.Services;

namespace Simulacro1.Controllers{
    public class BookUpdateController : ControllerBase {
        private readonly IBookRepository _bookRepository;

        public BookUpdateController (IBookRepository bookRepository){
            _bookRepository = bookRepository;
        }

        [HttpPut]
        [Route("api/book/{id}/update")]
        public IActionResult UpdateBook([FromBody] Book book){
            try{
                _bookRepository.Update(book);
                return Ok("El libro se actualizó correctamente");
            }
            catch (System.Exception){
                return BadRequest("El libro no se actualizó");
            }
        }

        [HttpPut]
        [Route("api/book/{id}/changeStatus")]
        public IActionResult Status(int id){
            try{
                _bookRepository.ChangeStatus(id);
                return Ok("El libro cambio de estado correctamente");
            }
            catch (System.Exception ex){
                return NotFound(ex.Message);
            }
        }

    

    }
}