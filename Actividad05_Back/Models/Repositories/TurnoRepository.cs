using Actividad05_Back.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad05_Back.Models.Repositories
{
    public class TurnoRepository : ITurnosRepository
    { 

        private readonly turnos_db_2Context _context;

        public TurnoRepository(turnos_db_2Context context)
        {
            _context = context;
        }
        public bool Create(TTurno turno)
        {
            _context.Add(turno);
            return _context.SaveChanges()>0;
        }

        public bool Delete(int id, string motivo)
        {
            var TurnoCancelar = _context.TTurnos.Find(id);
            if (TurnoCancelar != null)
            {
                TurnoCancelar.FechaCancelacion = DateTime.Now;
                TurnoCancelar.MotivoCancelacion = motivo;
                _context.TTurnos.Update(TurnoCancelar);
                return _context.SaveChanges() > 0;
            }
            return false;
        }

        public TTurno? GetById(int id)
        {
            return _context.TTurnos.Find(id);
        }

        public List<TTurno> GetAll()
        {
            return _context.TTurnos.Where(x => x.FechaCancelacion ==null).ToList();
        }

        public bool Update(int id, TTurno turno)
        {
            var TurnoExis = _context.TTurnos.Find(id);
            if (TurnoExis == null) return false;
            TurnoExis.Fecha = turno.Fecha;
            TurnoExis.Hora = turno.Hora;
            if (!string.IsNullOrEmpty(turno.Cliente))
                TurnoExis.Cliente = turno.Cliente;
            _context.TTurnos.Update(TurnoExis);
            return _context.SaveChanges() > 0;
            
        }
    }
}
