using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Simulacro1.Services;
using Simulacro1.Data;
using Simulacro1.Models;

namespace Simulacro1.Services
{
    public interface IAuthorRepository
    {
        IEnumerable<Author> GetAll();
        Task<IEnumerable<Author>> GetInactiveAuthorsAsync();
        Author GetById(int id);
        void Add(Author author);
        void Update(Author author);
        void ChangeStatus(int id);
    

    }
}