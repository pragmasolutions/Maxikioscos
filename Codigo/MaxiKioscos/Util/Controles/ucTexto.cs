﻿using System;
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
    public partial class ucTexto : UserControl
    {
        public ucTexto()
        {
            InvalidateChar = null;
            CaracteresValidos = null;
            InitializeComponent();
        }

        private string MsjError = "";
        private int Min;
        private int Max = 32767;
        private bool Obligatorio = true;
        private string AtributoReferente;

        public string InvalidateChar { get; set; }

        public string CaracteresValidos { get; set; }

        /// <summary>
        /// Esto hace referencia al atributo o etiqueta ej. Domicilio -> Referencia
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public string Referencia
        {
            get
            {
                return AtributoReferente;
            }
            set
            {
                AtributoReferente = value;
            }
        }

        public CharacterCasing CharCasing
        {
            get
            {
                return TextBox.CharacterCasing;
            }
            set
            {
                TextBox.CharacterCasing = value;
            }
        }

        public int Alto
        {
            get
            {
                return this.Height;
            }
            set
            {
                this.Height = value;
            }
        }

        public int Ancho
        {
            get
            {
                return this.Width;
            }
            set
            {
                this.Width = value;
            }
        }

        public bool MultiLineas
        {
            get
            {
                return TextBox.Multiline;
            }
            set
            {
                TextBox.Multiline = value;
            }
        }

        public ScrollBars BarraScroll
        {
            get
            {
                return TextBox.ScrollBars;
            }
            set
            {
                TextBox.ScrollBars = value;
            }
        }

        public string Valor
        {
            get
            {
                return TextBox.Text;
            }
            set
            {
                TextBox.Text = value;
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
                return Max;
            }
            set
            {
                Max = value;
            }
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

        public bool Disabled
        {
            get { return !TextBox.Enabled; }
            set { TextBox.Enabled = !value; }
        }

        new public void Focus()
        {
            TextBox.Focus();
            TextBox.Select();
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (TextBox.Text.Length >= Min | TextBox.Text.Length <= Max)
            {
                if (!string.IsNullOrEmpty(CaracteresValidos))
                {
                    e.Handled = !CaracteresValidos.Contains(e.KeyChar.ToString());
                    return;
                }
                if (InvalidateChar != null)
                {
                    if (InvalidateChar.Contains(e.KeyChar.ToString()))
                    {
                        e.Handled = true;
                    }
                }
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void TextBox_Leave(object sender, EventArgs e)
        {
            if (Min != 0)
            {
                if (TextBox.Text.Length < Min)
                {
                    MessageBox.Show(string.Format("La cantidad de caractéres debe ser mayor a {0}", Min));
                    Focus();
                }
            }
        }

        public void Reiniciar()
        {
            TextBox.Text = null;
        }

        /// <summary>
        /// Esta funcion verifica que sea valido los datso del control
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public bool Valido()
        {
            if (string.IsNullOrEmpty(TextBox.Text))
            {
                ErrorMessage = "Este campo es requerido";
                return false;
            }
            return true;
        }

    }
}
