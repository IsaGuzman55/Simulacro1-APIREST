using Microsoft.AspNetCore.Mvc;
using Simulacro1.Models;
using Simulacro1.Services;
using Simulacro1.Utils;
using System;
using System.Threading.Tasks;

namespace Simulacro1.Controllers{
    public class BookCreateController : ControllerBase {
        private readonly IBookRepository _bookRepository;

        public BookCreateController (IBookRepository bookRepository){
            _bookRepository = bookRepository;
        }

        /* [HttpPost]
        [Route("api/book")]
        public IActionResult Create([FromBody] Book book){
            try{
                _bookRepository.Add(book);
                return Ok("El autor se creó correctamente");
            }
            catch (System.Exception)
            {   
                return BadRequest("El autor no pudo crearse");
            }

        } */

        [HttpPost]
        [Route("api/book")]
        public async Task<IActionResult> Create([FromBody] Book book)
        {
            var respuesta = await _bookRepository.CreateOrCheckAsync(book, book.AuthorId, book.EditorialId);
            if(!respuesta.Any()){
                return Ok(new {Message = "No se pudó crear el libro"});
            }
            return Ok(respuesta);
        }

    }
}