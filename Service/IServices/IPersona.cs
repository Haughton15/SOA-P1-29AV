using Domain.Entities;
using Domain.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IServices
{
    public interface IPersona
    {
        List<Persona> ObtenerLista();
        List<EmpleadoVM> GetEmpleados();
        Empleado RegisterEmpleado(PostEmpleadoRequest request);
        ActivoEmpleadoVM? GetPerson(int  id);
    }
}
