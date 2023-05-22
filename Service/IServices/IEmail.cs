using Domain.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IServices
{
    public interface IEmail
    {
        String SedMasiveMail(PostEmailRequest request);
    }
}
