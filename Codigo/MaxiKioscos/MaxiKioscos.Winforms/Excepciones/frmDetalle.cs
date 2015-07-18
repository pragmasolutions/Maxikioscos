using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaxiKioscos.Winforms.Clases;
using MaxiKioscos.Entidades;
using MaxiKioscos.Datos.Repositorio;
using MaxiKioscos.Winforms.Configuracion;
using Util;

namespace MaxiKioscos.Winforms.Excepciones
{
    public partial class frmDetalle : Form
    {
        private int id = 0;
        public frmDetalle()
        {
            InitializeComponent();
        }

        public frmDetalle(int Id,string operacion)
        {
            InitializeComponent();
            id = Id;

            Operacion = operacion;
            if (operacion == "Eliminar")
            {
                lblTitulo.Text = "Eliminar Excepción";
                this.Text = "Eliminar Excepción";
                btnCancelar.Visible = true;
                btnAceptar.Text = "Aceptar";
            }
            else
            {
                lblTitulo.Text = "Detalle de Excepción";
                this.Text = "Detalle de Excepción";
                btnCancelar.Visible = false; 
                btnAceptar.Location = new Point(231, 416);
            }
        }

        private EFRepository<Excepcion> _repository;
        public EFRepository<Excepcion> Repository
        {
            get { return _repository ?? (_repository = new EFRepository<Excepcion>()); }
        }


        #region "Propiedades"
        public string Operacion { get; set; }

        public string Fecha 
        {
            get { return txtFecha.Texto; }
            set { txtFecha.Texto = value; }
        }

        public string Descripcion 
        {
            get { return txtDescripcion.Text; }
            set { txtDescripcion.Text = value; }
        }

        public string Importe
        {
            get { return txtImporte.Texto; }
            set { txtImporte.Texto = value; }
        }
        #endregion

        private void frmDetalle_Load(object sender, EventArgs e)
        {
            CargarControles();
        }

        private void CargarControles()
        {
            var excepcion = Repository.Obtener(id);

            Fecha = excepcion.FechaCarga.ToShortDateString();
            Descripcion = excepcion.Descripcion;
            Importe = "$" + excepcion.Importe.ToString("N2");
         }

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = false;
        }

        private void frmDetalle_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case (Keys.Escape):
                    this.Close();
                    break;
            }
        }

       

    }
}
