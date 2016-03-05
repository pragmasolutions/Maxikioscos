using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using MaxiKioscos.Datos;
using MaxiKioscos.Datos.Helpers;
using MaxiKioscos.Datos.Interfaces;
using MaxiKioscos.Email;
using MaxiKioscos.Email.Models;
using MaxiKioscos.Entidades;
using MaxiKioscos.Negocio;
using MaxiKioscos.Services.Contracts;

namespace MaxiKioscos.Services
{
    public class MaxiKioscoService : BaseService, IMaxiKioscoService
    {
        public MaxiKioscoService(IMaxiKioscosUow uow)
        {
            Uow = uow;
        }

        public IList<KioscoApiResponse> GetMaxiKioscos()
        {
            try
            {
                var maxiKioscosList = Uow.MaxiKioscos.Listado().Select(m => new KioscoApiResponse
                                                                            {
                                                                                Identifier = m.Identifier,
                                                                                MachineName = m.NombreMaquina
                                                                            }).ToList();



                return maxiKioscosList;
            }
            catch (Exception)
            {
                return null;
            }
            
        }
    }
}
