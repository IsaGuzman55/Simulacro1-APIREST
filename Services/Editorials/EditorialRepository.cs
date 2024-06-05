using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Simulacro1.Data;
using Simulacro1.Models;

namespace Simulacro1.Services
{
    public class EditorialRepository : IEditorialRepository
    {
        private readonly SimulacroBaseContext _context;

        public EditorialRepository(SimulacroBaseContext context){
            _context = context;
        }

        public IEnumerable<Editorial> GetAll(){
            return _context.Editorials.ToList();
        }

        public async Task<IEnumerable<Editorial>> GetInactiveEditorialsAsync() {
            return await _context.Editorials.Where(b => b.Status == "Inactivo").ToListAsync();
        }

    
        public Editorial GetById(int id){
            return _context.Editorials.Find(id);
        }

        public void Add(Editorial editorial){
            editorial.Status = "Activo";
            _context.Editorials.Add(editorial);
            _context.SaveChanges();
        }

        public void Update(Editorial Editorial){
            _context.Editorials.Update(Editorial);
            _context.SaveChanges();
        }

        public void ChangeStatus(int id){
            var editorial = _context.Editorials.Find(id);
            if(editorial != null){
                if(editorial.Status == "Activo"){
                    editorial.Status = "Inactivo";
                    _context.SaveChanges();
                }else{
                    editorial.Status = "Activo";
                    _context.SaveChanges();
                }
            }else {
                throw new Exception("La editorial no se encontró");
            }
        }

        
    }

}