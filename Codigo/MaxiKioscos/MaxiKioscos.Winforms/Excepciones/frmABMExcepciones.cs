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
using MaxiKioscos.Datos.Sync;
using MaxiKioscos.Winforms.Configuracion;
using Util;

namespace MaxiKioscos.Winforms.Excepciones
{
    public partial class frmABMExcepciones : Form
    {
        private int excepcionId = 0;
        private int cierreCajaId = 0;

        public Excepcion Excepcion { get; set; }

        private EFRepository<Excepcion> _repository;
        public EFRepository<Excepcion> Repository
        {
            get { return _repository ?? (_repository = new EFRepository<Excepcion>()); }
        }


        public frmABMExcepciones(int CierreCajaId)
        {
            InitializeComponent();
            cierreCajaId = CierreCajaId;
            this.Text = "Agregar Excepción";
            this.Text = "Agregar Excepción";
            txtDescripcion.Select();
        }
        public frmABMExcepciones(int CierreCajaId, int ExcepcionId)
        {
            InitializeComponent();
            cierreCajaId = CierreCajaId;
            excepcionId= ExcepcionId;
            CargarExcepcion();
            lblTitulo.Text = "Editar Excepción";
            this.Text = "Editar Excepción";
            txtDescripcion.Select();
        }

        #region  BarraHerramientas

        private void CrearBH()
        {
            //bh.CrearItemBarraEspecifica("Aceptar", MaxiKioscos.Winforms.Properties.Resources.ok, Aceptar);
            //bh.CrearItemBarraEspecifica("Cerrar", MaxiKioscos.Winforms.Properties.Resources.Cerrar, Cerrar);
        }

        private void Cerrar(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Aceptar(object sender, EventArgs e)
        {
            errorProvider1.Dispose();
            var valido = Validacion.Validar(errorProvider1, new List<object>
                                                               {
                                                                   txtDescripcion,
                                                                   txtImporte
                                                               });
            if (valido)
            {
                if (excepcionId == 0)
                {
                    Excepcion= new Excepcion();
                    CargarExcepcion();
                    Repository.Agregar(Excepcion);
                }
                else
                {
                    CargarExcepcion();
                    Repository.Modificar(Excepcion);
                }
                try
                {
                    Repository.Commit();
                    Mensajes.Guardar(true);
                }
                catch (Exception)
                {
                    Mensajes.Guardar(false);
                }
            }
        }
        #endregion

        #region "Propiedades"


        public string Operacion { get; set; }

        public DateTime Fecha
            {
                get { return dtpFecha.Fecha; }
                set { dtpFecha.Fecha= value; }
            }

            public string Descripcion
            {
                get { return txtDescripcion.Text; }
                set { txtDescripcion.Text = value; }
            }

            public decimal Importe
            {
                get { return txtImporte.Valor.GetValueOrDefault(); }
                set { txtImporte.Valor = value; }
            }
        #endregion

        private void frmABMExcepciones_Load(object sender, EventArgs e)
        {
            txtDescripcion.Focus();
        }

    private void CargarExcepcion()
        {
            Excepcion = Repository.Obtener(excepcionId);

            Fecha = Excepcion.FechaCarga;
            Descripcion = Excepcion.Descripcion;
            Importe = Excepcion.Importe;
        }

       

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            errorProvider1.Dispose();

            var valido = Validacion.Validar(errorProvider1, new List<object>
                                                  {
                                                      txtImporte,
                                                      txtDescripcion,
                                                      dtpFecha
                                                  });
            if (valido)
            {


                if (Excepcion != null)
                {
                    Excepcion.FechaCarga = Fecha;
                    Excepcion.Importe = Importe;
                    Excepcion.Descripcion = Descripcion;

                    Repository.Modificar(Excepcion);
                    Repository.Commit();
                }
                else
                {
                    var excepcion = new Excepcion()
                        {
                            //CierreCajaId = UsuarioActual.CierreCajaIdActual,
                            CierreCajaId= cierreCajaId,
                            Identifier = Guid.NewGuid(),
                            Descripcion = Descripcion,
                            Importe = Importe,
                            FechaCarga = Fecha

                          };
                        Repository.Agregar(excepcion);
                        Repository.Commit();
                }
            }
            else
            {
                this.DialogResult = DialogResult.None;
            }
        }

       

        private void frmABMExcepciones_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case (Keys.Enter):

                    if (txtDescripcion.Focused == false){
                        btnAceptar_Click(null, null);
                        this.DialogResult = DialogResult.OK;
                    }
                    break;
                    
                case (Keys.Escape):
                    Cerrar(null, null);
                    break;
            }
        }

        private void frmABMExcepciones_Shown(object sender, EventArgs e)
        {
            dtpFecha.Select();
        }

      
        
    }
}
