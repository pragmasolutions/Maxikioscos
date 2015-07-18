using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using Util.Controles;

namespace Util
{
    public class Validacion
    {
        public static bool Validar(ErrorProvider provider, List<object> controles)
        {
            var valido = true;
            foreach (var control in controles)
            {
                switch (control.GetType().ToString())
                {
                    case "System.Windows.Forms.TextBox":
                        if (string.IsNullOrEmpty(((TextBox)control).Text))
                        {
                            provider.SetError((TextBox)control, "Debe completar el campo.");
                            provider.SetIconPadding((TextBox)control, 2);
                            valido = false;
                        }
                        break;
                    case "Util.Controles.ucTexto":
                        var ucTexto = (ucTexto)control;
                        if (!ucTexto.Valido())
                        {
                            provider.SetError(ucTexto, ucTexto.ErrorMessage);
                            provider.SetIconPadding(ucTexto, 2);
                            valido = false;
                        }
                        break;
                    case "Util.Controles.ucSoloNumero":
                        var ucSoloNumero = (ucSoloNumero)control;
                        if (!ucSoloNumero.Valido())
                        {

                            provider.SetError(ucSoloNumero, ucSoloNumero.ErrorMessage);
                            provider.SetIconPadding(ucSoloNumero, 2);
                            valido = false;
                        }
                        break;
                    case "Util.Controles.ucDinero":
                        var ucDinero = (ucDinero)control;
                        if (!ucDinero.Valido())
                        {
                            provider.SetError(ucDinero, ucDinero.ErrorMessage);
                            provider.SetIconPadding(ucDinero, 2);
                            valido = false;
                        }
                        break;
                    case "Util.Controles.ucDropDownList":
                        var ucDropDownList = (ucDropDownList)control;
                        if (!ucDropDownList.Valido())
                        {
                            provider.SetError(ucDropDownList, ucDropDownList.ErrorMessage);
                            provider.SetIconPadding(ucDropDownList, 2);
                            valido = false;
                        }
                        break;
                    case "Telerik.WinControls.UI.RadDropDownList":
                        var ucDropDown = (RadDropDownList)control;

                        if ((int)ucDropDown.SelectedValue == 0)
                        {
                            provider.SetError(ucDropDown, "Debe seleccionar un elemento");
                            provider.SetIconPadding(ucDropDown, 2);
                            valido = false;
                        }
                        break;
                    case "Util.Controles.ucPassword":
                        var ucPassowrd = (ucPassword)control;
                        if (!ucPassowrd.Valido())
                        {
                            provider.SetError(ucPassowrd, ucPassowrd.ErrorMessage);
                            provider.SetIconPadding(ucPassowrd, 2);
                            valido = false;
                        }
                        break;
                }

                
            }
            return valido;
        }

        public static bool ValidarCantidad(ErrorProvider provider, decimal cantidadoriginal, decimal? cantidadnueva ,object control )
        {
            var valido = true;
            if (cantidadoriginal < cantidadnueva)
            {
                provider.SetError((ucSoloNumero)control, "Cantidad mayor a la disponible en stock.");
                valido = false;
            }
                
            return valido;
        }
    }
}
