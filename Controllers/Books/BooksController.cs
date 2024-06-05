using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Simulacro1.Data;
using Simulacro1.Models;
using Simulacro1.Services;

namespace Simulacro1.Controllers{
    public class BooksController : ControllerBase {
        private readonly IBookRepository _bookRepository;

        public BooksController (IBookRepository bookRepository){
            _bookRepository = bookRepository;
        }

        [HttpGet]
        [Route("api/books")]
        public IActionResult GetBooks(){
            var books = _bookRepository.GetAll();
            if(!books.Any()){
                return Ok(new {Message = "No hay libros registrados"});
            }
            return Ok(books);
        }

        [HttpGet]
        [Route("api/books/inactives")]
        public async Task<IActionResult> GetInactiveBooks() {
            IEnumerable<Book> inactiveBooks = await _bookRepository.GetInactiveBooksAsync();
            if(!inactiveBooks.Any()){
                return Ok(new {Message = "No hay libros inactivos"});
            }
            return Ok(inactiveBooks);
        }

        [HttpGet]
        [Route("api/book/{id}")]
        public IActionResult Details(int id){
            var book = _bookRepository.GetById(id);
            if(book == null){
                return NotFound("Este libro no esta registrado");
            }
            return Ok(book);
        }


    }
}