using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Util.Controles
{
    public partial class ucProcentaje : UserControl
    {
        public ucProcentaje()
        {
            InitializeComponent();
            TextBox1.GotFocus += TextBox1OnGotFocus;
            TextBox1.LostFocus += TextBox1OnLostFocus;
        }

        private void TextBox1OnLostFocus(object sender, EventArgs eventArgs)
        {
            if (!string.IsNullOrEmpty(TextBox1.Text))
            {
                decimal value;

                var texto = TextBox1.Text.Replace("%", "").Replace(".", ",");
                var result = decimal.TryParse(texto, out value);
                if (result)
                    TextBox1.Text = String.Format("{0}%", value.ToString("N2"));
                else
                    TextBox1.Text = "";

            }
        }

        private void TextBox1OnGotFocus(object sender, EventArgs eventArgs)
        {
            if (!string.IsNullOrEmpty(TextBox1.Text))
            {
                //Saco el formato currency
                TextBox1.Text = TextBox1.Text.Replace("%", "").Replace(".", "");
                TextBox1.SelectAll();
            }
        }

        public delegate void CambioEventHandler();
        private CambioEventHandler CambioEvent;

        public event CambioEventHandler Cambio
        {
            add
            {
                CambioEvent = (CambioEventHandler)System.Delegate.Combine(CambioEvent, value);
            }
            remove
            {
                CambioEvent = (CambioEventHandler)System.Delegate.Remove(CambioEvent, value);
            }
        }
        private string MsjError = "";
        private int MinLengh;
        private decimal minValue;
        private decimal maxValue = decimal.MaxValue;
        private bool Obligatorio = true;
        private string separador = ",.";

        public decimal? Valor
        {
            get
            {
                if (string.IsNullOrEmpty(TextBox1.Text))
                    return null;
                var text = TextBox1.Text.Replace("%", "").Replace(".", "");
                decimal value;
                var result = decimal.TryParse(text, out value);
                if (!result)
                    return null;
                return value;
            }
            set
            {
                if (value != null)
                    TextBox1.Text = String.Format("{0}%", value.GetValueOrDefault().ToString("N2"));
                else
                    TextBox1.Text = string.Empty;
            }
        }

        public int TextboxTabIndex
        {
            get
            {
                return TextBox1.TabIndex;
            }
            set
            {
                TextBox1.TabIndex = value;
            }
        }

        public bool EsObligatorio
        {
            get
            {
                return Obligatorio;
            }
            set
            {
                Obligatorio = value;
            }
        }
        public int LongMin
        {
            get
            {
                return MinLengh;
            }
            set
            {
                MinLengh = value;
            }
        }

        public int LongMax
        {
            get
            {
                return TextBox1.MaxLength;
            }
            set
            {
                TextBox1.MaxLength = value;

            }
        }
        public decimal MinValue
        {
            get
            {
                return minValue;
            }
            set
            {
                minValue = value;
            }
        }

        public decimal MaxValue
        {
            get
            {
                return maxValue;
            }
            set
            {
                maxValue = value;

            }
        }

        public bool ReadOnly
        {
            get { return TextBox1.ReadOnly; }
            set { TextBox1.ReadOnly = value; }
        }

        
        public bool Disabled
        {
            get { return !TextBox1.Enabled; }
            set { TextBox1.Enabled = !value; }
        }

        public string ErrorMessage
        {
            get
            {
                return MsjError;
            }
            set
            {
                MsjError = value;
            }
        }

        public HorizontalAlignment PosicionText
        {
            get
            {
                return TextBox1.TextAlign;
            }
            set
            {
                TextBox1.TextAlign = value;
            }
        }

        new public void Focus()
        {
            TextBox1.Focus();
//            TextBox1.Select();

        }

        public void Reiniciar()
        {
            TextBox1.Text = null;
        }

        /// <summary>
        /// Esta funcion verifica que sea valido los datso del control
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public bool Valido()
        {
            if (TextBox1.Text.Trim() == "" && Obligatorio) //Or TextBox.Text.Trim = 0 Then
            {
                ErrorMessage = "Este campo es requerido";
                return false;
            }
            decimal result;
            var isDecimal = decimal.TryParse(TextBox1.Text.Trim().Replace("%",""), out result);
            if (!isDecimal)
            {
                ErrorMessage = "El importe ingresado es inválido";
                return false;
            }
            if (result < minValue)
            {
                ErrorMessage = String.Format("El porcentaje ingresado debe ser mayor al {0}%", minValue.ToString("N2"));
                return false;
            }
            if (result > maxValue)
            {
                ErrorMessage = String.Format("El porcentaje ingresado debe ser menor al {0}%", maxValue.ToString("N2"));
                return false;
            }
            return true;
        }

        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            int dig = (TextBox1.Text + e.KeyChar).Length;
            int a = default(int);
            int esDecimal = default(int);
            int NumDecimales = default(int);
            bool esDec = default(bool);

            // se verifica si es un digito o un punto
            if (char.IsDigit(e.KeyChar) || separador.Contains(e.KeyChar) || e.KeyChar != 8)
            {
                e.Handled = false;
                // se verifica que el primer digito ingresado no sea un punto al seleccionar
                if (TextBox1.SelectedText != "")
                {
                    if (separador.Contains(e.KeyChar))
                    {
                        e.Handled = true;
                    }
                }
                if (dig == 1 && separador.Contains(e.KeyChar))
                {
                    e.Handled = true;
                }
                //aqui se hace la verificacion cuando es seleccionado el valor del texto
                //y no sea considerado como la adicion de un digito mas al valor ya contenido en el textbox
                if (TextBox1.SelectedText == "")
                {
                    // aqui se hace el for para controlar que el numero sea de dos digitos - contadose a partir del punto decimal.
                    for (a = 0; a <= dig - 1; a++)
                    {
                        string car = (TextBox1.Text + e.KeyChar);
                        if (separador.Contains(car.Substring(a, 1)))
                        {
                            esDecimal++;
                            esDec = true;
                        }
                        if (esDec == true)
                        {
                            NumDecimales++;
                        }
                        // aqui se controla los digitos a partir del punto numdecimales = 4 si es de dos decimales
                        if (NumDecimales >= 4 | esDecimal >= 2)
                        {
                            e.Handled = true;
                        }
                    }
                }
            }
            else if (char.IsControl(e.KeyChar) || e.KeyChar == 8)
            {
                e.Handled = false;
                
            }
            else
            {
                e.Handled = true;
            }
            
        }

        private void TextBox1_Leave(object sender, EventArgs e)
        {
            if (CambioEvent != null)
                CambioEvent();
        }


        public void FocusOnTextbox()
        {
            TextBox1.Focus();
        }
    }
}
