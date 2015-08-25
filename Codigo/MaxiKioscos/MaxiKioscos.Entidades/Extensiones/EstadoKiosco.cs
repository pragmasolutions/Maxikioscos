using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maxikioscos.Comun.Helpers;

namespace MaxiKioscos.Entidades
{
    public partial class EstadoKiosco
    {
        public bool EstaConectado
        {
            get
            {
                if (UltimaConexion == null)
                    return false;

                var differece = DateHelper.DifferenceInMinutes(DateTime.Now, UltimaConexion.GetValueOrDefault());
                return differece < 2;
            }
        }
    }
}
