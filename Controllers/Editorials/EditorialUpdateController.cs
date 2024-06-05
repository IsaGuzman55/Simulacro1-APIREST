using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Simulacro1.Data;
using Simulacro1.Models;
using Simulacro1.Services;

namespace Simulacro1.Controllers{

    public class EditorialUpdateController : ControllerBase{ 
        private readonly IEditorialRepository _editorialRepository;

        public EditorialUpdateController (IEditorialRepository editorialRepository){
            _editorialRepository = editorialRepository;
        }

        [HttpPut]
        [Route("api/editorial/{id}/update")]
        public IActionResult Update([FromBody] Editorial editorial){
            try
            {
                _editorialRepository.Update(editorial);
                return Ok("La editorial se actualizó correctamente");

            }
            catch (System.Exception)
            {   
                return BadRequest("La editorial no se actualizó");
            }
        }
        
        [HttpPut]
        [Route("api/editorial/{id}/changeStatus")]
        public IActionResult Status(int id){
            try{
                _editorialRepository.ChangeStatus(id);
                return Ok("La editorial cambio de estado correctamente");
            }
            catch (System.Exception ex){
                return NotFound(ex.Message);
            }
        }

    }

}