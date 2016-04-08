using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Web;
using MaxiKioscos.Datos.Interfaces;
using MaxiKioscos.Seguridad;
using MaxiKioscos.Services.Contracts;

namespace MaxiKioscos.Services
{
    public class MaxiKioscosService : BaseService, IMaxiKioscoService
    {
        private IAuthService AuthService { get; set; }

        public MaxiKioscosService(IMaxiKioscosUow uow, IAuthService authService)
        {
            Uow = uow;
            AuthService = authService;
        }

        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public LoginResponse Login(LoginRequest login)
        {
            if (AuthService.Login(login.UserName, login.Password, false))
            {
                var user = Uow.Usuarios.Obtener(login.UserName);
                return new LoginResponse
                       {
                           UserId = user.UsuarioId,
                           Nombre = user.NombreUsuario
                       };
            }

            return new LoginResponse
            {
                UserId = null,
                Error = "El usuario o en password es incorrecto."
            };
        }
        
        public void LogOff()
        {
            AuthService.LogOff();
        }
    }
}
