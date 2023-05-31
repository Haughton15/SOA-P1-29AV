using Domain.Entities;
using Domain.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IServices
{
    public interface IActivoEmpleado
    {
        ActivoEmpleado CreateActivoEmpleado(PostActivoEmpleado request);

        bool DeleteActivoEmpleado(int id);
        ActivoEmpleado GetActivoEmpleado(int id);

        ActivoEmpleado PatchActivoEmpleado(int id,  PatchActivoEmpleado request);
    }
}
