using People.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace People.Interfaces
{
    public interface ICVPersonRepository
    {
        Task<bool> AgregarPersonAsync(CVPerson person);
        Task<List<CVPerson>> GetAllPersonAsync();
    }
}
