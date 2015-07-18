using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Util
{
    public interface IValidationControl
    {
        bool Validar(ErrorProvider provider);
    }
}
