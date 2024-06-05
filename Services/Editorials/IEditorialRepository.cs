using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Simulacro1.Models; 

namespace Simulacro1.Services
{
    public interface IEditorialRepository
    {
        IEnumerable<Editorial> GetAll();
        Task<IEnumerable<Editorial>> GetInactiveEditorialsAsync();
        Editorial GetById(int id);
        void Add(Editorial editorial);
        void Update(Editorial editorial);
        void ChangeStatus(int id);
    
    }
}