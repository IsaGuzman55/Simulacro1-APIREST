using Simulacro1.Models;
using Simulacro1.Utils;

namespace Simulacro1.Services
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetAll();
        Task<IEnumerable<Book>> GetInactiveBooksAsync();
        Book GetById(int id);
        /* void Add(Book book); */
        void Update(Book book);
        void ChangeStatus(int id);

        /* ENVIAR CORREO CUANDO SE CREA UN LIBRO */
        Task<string> CreateOrCheckAsync(Book book, int IdAuthor, int IdEditorial);
    
    }
}