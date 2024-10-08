using Actividad05_Back.Models.Entities;
using Actividad05_Back.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Actividad05_Back.Services
{
    public class TurnoServicio : ITurnoServicio
    {

        private readonly ITurnosRepository _repository;

        public TurnoServicio(ITurnosRepository repository)
        {
            _repository = repository;
        }


        public bool Delete(int id, string motivo)
        {
            return _repository.Delete(id,motivo);
        }

        public TTurno? Get(int id)
        {
            return _repository.GetById(id);
        }

        public List<TTurno> GetAll()
        {
            return _repository.GetAll();
        }

        public bool Update(int id, TTurno turno)
        {
            if ( ValidarActualizacion(id, turno))
                return  _repository.Update(id, turno);
            return false;
        }



        public bool Create(TTurno turno)
        {
            foreach (var detalle in turno.TDetallesTurnos)
            {
                if (!ValidarServicio(detalle))
                {
                    return false;
                }
            }

            if ( ValidarFecha(turno.Fecha, turno.Hora))
            {
                //Truncar la longitud de fecha a varchar(10)
                turno.Fecha = turno.Fecha?.Substring(0, Math.Min(turno.Fecha.Length, 10));
                return  _repository.Create(turno);
            }

            return false;
        }

        public bool Validar(TTurno? turno, int id)
        {
            var isMatch = Regex.IsMatch(id.ToString(), @"^\d+$");
            var aux = false;
            if (id != null && isMatch)
            {
                aux = true;
            }
            return aux;
        }

        public bool ValidarActualizacion(int id, TTurno turno)
        {
            var lst =  _repository.GetById(id);
            var horaActual = TimeSpan.Parse(lst.Hora);
            var horaNueva = TimeSpan.Parse(turno.Hora);
            var fechaActual = Convert.ToDateTime(lst.Fecha);
            var fechaNueva = Convert.ToDateTime(turno.Fecha);
            return fechaActual > fechaNueva || (fechaNueva == fechaActual && horaNueva < horaActual);
        }

        //Deberá controlar que la fecha de reserva no supere los 45 días a la fecha actual.
        public bool ValidarFecha(string fecha, string? hora)
        {
            if (fecha == null || hora == null) return false;

            var fec = Convert.ToDateTime(fecha);
            var hs = TimeSpan.Parse(hora);

            var fechaMaxima = DateTime.Today.AddDays(45);
            if (fec > fechaMaxima) return false;


            //solo es posible registrar el turno si para la fecha y hora seleccionadas no existe un registro previamente cargado.
            var lst =  _repository.GetAll();
            var existe = lst.FirstOrDefault(x =>
            {
                var fechaTurno = Convert.ToDateTime(x.Fecha);
                var horaTurno = TimeSpan.Parse(x.Hora);

                return fechaTurno.Date == fec.Date && horaTurno == hs;
            });
            return existe == null;
        }
        public  bool ValidarServicio(TDetallesTurno detalle)
        {
            var lst =  _repository.GetAll();
            var existeServicio = lst.Any(x => x.TDetallesTurnos.Any(e => e.IdServicio == detalle.IdServicio));
            return existeServicio;
        }


    }
}
