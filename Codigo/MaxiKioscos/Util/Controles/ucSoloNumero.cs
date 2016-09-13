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
    public partial class ucSoloNumero : UserControl
    {
        public ucSoloNumero()
        {
            InitializeComponent();
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

        public delegate void TeclaApretadaEventHandler(Keys tecla);
        private TeclaApretadaEventHandler TeclaApretadaEvent;

        public event TeclaApretadaEventHandler TeclaApretada
        {
            add
            {
                TeclaApretadaEvent = (TeclaApretadaEventHandler)System.Delegate.Combine(TeclaApretadaEvent, value);
            }
            remove
            {
                TeclaApretadaEvent = (TeclaApretadaEventHandler)System.Delegate.Remove(TeclaApretadaEvent, value);
            }
        }

        private string MsjError = "";
        private int Min = 0;
        private int Max = 32767;
        private bool Obligatorio = true;
        bool CambioTexto = false;
        private string separadores = ".,";

        public string Valor
        {
            get
            {
                return TextBox1.Text.Trim();
            }
            set
            {
                if (AceptaDecimales)
                {
                    TextBox1.Text = value;
                }
                else
                {
                    TextBox1.Text = value.Split('.')[0];
                }
            }
        }

        public decimal? ValorDecimal
        {
            get
            {
                if (string.IsNullOrEmpty(TextBox1.Text))
                    return null;
                return Convert.ToDecimal(TextBox1.Text.Trim().Replace(".", ","));
            }
            set
            {
                if (value == null)
                    TextBox1.Text = string.Empty;
                else
                    TextBox1.Text = value.GetValueOrDefault().ToString("N2").Replace(".", "").Replace(",", ".");
            }
        }

        public int? ValorEntero
        {
            get
            {
                if (string.IsNullOrEmpty(TextBox1.Text))
                    return null;
                int val;
                if (int.TryParse(TextBox1.Text.Trim().Replace(".00", ""), out val))
                {
                    return val;
                }
                return null;
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
                return Min;
            }
            set
            {
                Min = value;
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

        private bool _aceptaDecimales = false;
        public bool AceptaDecimales
        {
            get { return _aceptaDecimales; }
            set { _aceptaDecimales = value; }
        }

        public string CaracteresPermitidos { get; set; }

        public decimal? MinimoValor { get; set; }
        public decimal? MaximoValor { get; set; }

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
            TextBox1.Select();

        }

        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && (TextBox1.Text.Length >= Min | TextBox1.Text.Length <= Max))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                var aceptaNegativos = MinimoValor != null && MinimoValor < 0;
                var desdeElPrincipio = string.IsNullOrEmpty(TextBox1.Text) || TextBox1.SelectedText.Count() == TextBox1.Text.Count();

                if (AceptaDecimales)
                {
                    if (!desdeElPrincipio)
                    {
                        var contieneComa = TextBox1.Text.ToList().Any(ch => separadores.Contains(ch));
                        if ((e.KeyChar == char.Parse(",") || e.KeyChar == char.Parse(".")) && !contieneComa)
                        {
                            e.Handled = false;
                        }
                        else
                        {
                            e.Handled = true;
                        }
                    }
                    else if (e.KeyChar == char.Parse("."))
                    {
                        e.Handled = true;
                        TextBox1.Text = "0.";
                        TextBox1.Select(TextBox1.Text.Length, 0);
                    }
                    else
                    {
                        e.Handled = !(aceptaNegativos && e.KeyChar == char.Parse("-"));
                    }
                    //else
                    //{
                    //    e.Handled = true;
                    //}
                }
                else
                {
                    if (desdeElPrincipio)
                    {
                        e.Handled = !(aceptaNegativos && e.KeyChar == char.Parse("-"));
                    }
                }
                
            }
        }

        private void TextBox1_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TextBox1.Text) && separadores.Any(s => s.ToString() == TextBox1.Text.Last().ToString()))
            {
                TextBox1.Text = TextBox1.Text.Remove(TextBox1.Text.Count() - 1, 1);
            }
            if (Min != 0)
            {
                if ((TextBox1.Text.Length < Min) && CambioTexto)
                {

                    MessageBox.Show(string.Format("La cantidad de dígitos debe ser mayor a {0}", Min), "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Focus();
                }
            }
            if (CambioEvent != null)
                CambioEvent();
        }

        public void Reiniciar()
        {
            TextBox1.Text = null;
        }

        public bool Valido()
        {
            if (TextBox1.Text.Trim() == "") //Or TextBox.Text.Trim = 0 Then
            {
                ErrorMessage = "Este campo es requerido";
                return false;
            }
            else
            {
                decimal result = default(decimal);
                var parsed = decimal.TryParse(TextBox1.Text.Trim(), out result);
                if (!parsed)
                {
                    ErrorMessage = "El número ingresado no es válido";
                    return false;
                }

                if ((MinimoValor != null && MinimoValor > result) || (MaximoValor != null && MaximoValor < result))
                {
                    ErrorMessage = "El número ingresado se encuentra fuera del rango de valores permitido";
                    return false;
                }
            }
            return true;
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            CambioTexto = true;
        }

        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (TeclaApretadaEvent != null)
            {
                TeclaApretadaEvent(e.KeyCode);
            }
        }
    }
}
