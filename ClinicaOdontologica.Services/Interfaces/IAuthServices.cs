using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaOdontologica.Services.Interfaces
{
    public interface IAuthServices
    {
        Task<bool> Login(string correo, string password);

        Task<bool> Register(
            string nombre,
            string apellido,
            string correo,
            string nombreUsuario,
            string password);

    }
}
