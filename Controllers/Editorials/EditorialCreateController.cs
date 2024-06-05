using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Simulacro1.Data;
using Simulacro1.Models;
using Simulacro1.Services;

namespace Simulacro1.Controllers{

    public class EditorialCreateController : ControllerBase{ 
        private readonly IEditorialRepository _editorialRepository;

        public EditorialCreateController (IEditorialRepository editorialRepository){
            _editorialRepository = editorialRepository;
        }

        [HttpPost]
        [Route("api/editorial")]
        public IActionResult Create([FromBody] Editorial editorial){
            try{
                _editorialRepository.Add(editorial);
                return Ok("La editorial se creó correctamente");
            }
            catch (System.Exception)
            {   
                return BadRequest("la editorial no pudo crearse");
            }

        }
        


        
    }

}