using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Simulacro1.Data;
using Simulacro1.Models;
using Simulacro1.Utils;

namespace Simulacro1.Services
{
    public class BookRepository : IBookRepository
    {
        private readonly SimulacroBaseContext _context;

        public BookRepository(SimulacroBaseContext context){
            _context = context;
        }

        public IEnumerable<Book> GetAll(){
            return _context.Books.Include(b => b.Author).Include(b => b.Editorial).ToList();
        }

        public async Task<IEnumerable<Book>> GetInactiveBooksAsync() {
            return await _context.Books.Include(b => b.Author).Include(b => b.Editorial).Where(b => b.Status == "Inactivo").ToListAsync();
        }

        public Book GetById(int id){
            return _context.Books.Find(id);
        }

       /*  public void Add(Book book){
            book.Status = "Activo";
            _context.Books.Add(book);
            _context.SaveChanges();
        } */

        public void Update(Book book){
            _context.Books.Update(book);
            _context.SaveChanges();
        }

        public void ChangeStatus(int id){
            var book = _context.Books.Find(id);
        
            if (book != null) {
                if(book.Status == "Activo"){
                    book.Status = "Inactivo";
                    _context.SaveChanges();
                    
                }else{
                    book.Status = "Activo";
                    _context.SaveChanges();
                }
                
            }else {
                throw new Exception("El libro no se encontró");
            }
        }

        public async Task<string> CreateOrCheckAsync(Book book, int IdAuthor, int IdEditorial)
        {
            try{
                var libroRepetido = await _context.Books.FirstOrDefaultAsync(b => b.Title == book.Title);
                if(libroRepetido == null){
                    /* Se busca al autor del libro (userEmail) */
                    var autorEncontrado = await _context.Authors.FirstOrDefaultAsync(a => a.Id == book.AuthorId);

                    /* Se busca el nombre de la editorial (editorialName) */
                    var editorialEncontrada = await _context.Editorials.FirstOrDefaultAsync(e => e.Id == book.EditorialId);

                    /* Poner el estado del libro a activo, crear el libro y guardar los cambios */
                    book.Status = "Activo";
                    _context.Books.Add(book);
                    _context.SaveChangesAsync();

                    /* MAIL */
                    // Se instancia un objeto de la clase 'MailersendUtils'
                    var sendEmail = new MailController();
                    // Se utiliza el método .EnviarCorreo(), se envía como parámetro el email del paciente y la fecha de la cita
                    sendEmail.EnviarCorreo(autorEncontrado.Email, book.Title, editorialEncontrada.Name);
                    return "El libro se creo correctamente";

                }else{
                   throw new Exception("El libro ingresado ya esta registrado");
                }

            }catch(Exception ex){
                return "Ocurrió un error";
            }

        }



    }
}