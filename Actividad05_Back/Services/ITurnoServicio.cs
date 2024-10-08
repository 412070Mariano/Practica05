using Actividad05_Back.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad05_Back.Services
{
    public interface ITurnoServicio
    {

        List<TTurno> GetAll();
        TTurno? Get(int id);

        bool Create(TTurno turno);
        bool Update(int id, TTurno turno);
        bool Delete(int id, string motivo);


    }
}
