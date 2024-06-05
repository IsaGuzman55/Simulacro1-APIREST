using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Simulacro1.Services;
using Simulacro1.Data;
using Simulacro1.Models;

namespace Simulacro1.Services
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly SimulacroBaseContext _context;

        public AuthorRepository(SimulacroBaseContext context){
            _context = context;
        }

        public IEnumerable<Author> GetAll(){
            return _context.Authors.ToList();
        }

        public async Task<IEnumerable<Author>> GetInactiveAuthorsAsync() {
            return await _context.Authors.Where(b => b.Status == "Inactivo").ToListAsync();
        }
    
        public Author GetById(int id){
            return _context.Authors.Find(id);
        }

        public void Add(Author author){
            author.Status = "Activo";
            _context.Authors.Add(author);
            _context.SaveChanges();
        }

        public void Update(Author author){
            _context.Authors.Update(author);
            _context.SaveChanges();
        }

        public void ChangeStatus(int id){
            var author = _context.Authors.Find(id);
            if(author != null){
                if(author.Status == "Activo"){
                    author.Status = "Inactivo";
                    _context.SaveChanges();
                }else{
                    author.Status = "Activo";
                    _context.SaveChanges();
                }
            }else {
                throw new Exception("El autor no se encontró");
            }

        }


    }
}