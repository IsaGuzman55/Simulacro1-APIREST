using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Simulacro1.Data;
using Simulacro1.Models;
using Simulacro1.Services;

namespace Simulacro1.Controllers{

    public class EditorialsController : ControllerBase{ 
        private readonly IEditorialRepository _editorialRepository;

        public EditorialsController (IEditorialRepository editorialRepository){
            _editorialRepository = editorialRepository;
        }

        [HttpGet]
        [Route("api/editorials")]
        public IActionResult GetEditorials(){
            var editorials = _editorialRepository.GetAll();
            if(!editorials.Any()){
                return Ok(new {Message = "No hay editoriales registrados"});
            }
            return Ok(editorials);
        }

        [HttpGet]
        [Route("api/editorials/inactives")]
        public async Task<IActionResult> GetInactiveEditorials() {
            IEnumerable<Editorial> inactiveEditorials = await _editorialRepository.GetInactiveEditorialsAsync();
            if(!inactiveEditorials.Any()){
                return Ok(new {Message = "No hay editoriales inactivos"});
            }
            return Ok(inactiveEditorials);
        }

        [HttpGet]
        [Route("api/editorial/{id}")]
        public IActionResult Details(int id){
            var editorial = _editorialRepository.GetById(id);
            if(editorial == null){
                return NotFound("Esta editorial no esta registrada");
            }
            return Ok(editorial);
        }
    }

}