using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaxiKioscos.Datos.Sync;
using MaxiKioscos.Entidades;
using Util;

namespace MaxiKioscos.Winforms.Productos.Modulos
{
    public partial class IngresarPrecioCosto : Form
    {
        public decimal Precio { get; set; }
        public decimal? Costo { get; set; }

        public IngresarPrecioCosto(string producto, decimal precio, decimal? costo, string proveedorNombre)
        {
            InitializeComponent();
            txtCostoConIVA.Valor = costo;
            txtCostoSinIVA.Valor = costo / 1.21m;
            txtPrecioConIVA.Valor = precio;
            txtPrecioSinIVA.Valor = precio / 1.21m;
            if (costo != 0)
            {
                txtPorcentajeGanancia.Valor = ((precio - costo) / costo) * 100m;
            }
            txtProducto.Texto = producto;
            lblProveedor.Text = proveedorNombre;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            errorProvider1.Dispose();

            var valido = Validacion.Validar(errorProvider1, new List<object> 
                                                    { 
                                                        txtPrecioConIVA,
                                                        txtPrecioSinIVA,
                                                        txtCostoConIVA,
                                                        txtCostoSinIVA
                                                    });
            if (valido)
            {
                Precio = txtPrecioConIVA.Valor.GetValueOrDefault();
                Costo = txtCostoConIVA.Valor;
            }
            else
            {
                DialogResult = DialogResult.None;
            }
        }

        private void IngresarPrecioCosto_Shown(object sender, EventArgs e)
        {
            txtCostoConIVA.Select();
        }

        private void IngresarPrecioCosto_Load(object sender, EventArgs e)
        {
            txtPrecioConIVA.FocusOnTextbox();
        }

        private void txtCostoSinIVA_Cambio()
        {
            var costoSinIva = txtCostoSinIVA.Valor;
            var costoConIva = costoSinIva * 1.21m;
            if (txtCostoConIVA.Valor.GetValueOrDefault() == 0 || (Math.Abs(txtCostoConIVA.Valor.GetValueOrDefault() - costoConIva.GetValueOrDefault()) > 0.3m))
            {
                txtCostoConIVA.Valor = costoConIva;
                if (costoConIva.GetValueOrDefault() != 0)
                {
                    var porcentaje = ((txtPrecioConIVA.Valor - costoConIva) / costoConIva) * 100m;
                    txtPorcentajeGanancia.Valor = porcentaje;
                }
            }
        }

        private void txtCostoConIVA_Cambio()
        {
            var costoConIva = txtCostoConIVA.Valor;
            var costoSinIva = costoConIva / 1.21m;
            if (txtCostoSinIVA.Valor.GetValueOrDefault() == 0 || (Math.Abs(txtCostoSinIVA.Valor.GetValueOrDefault() - costoSinIva.GetValueOrDefault()) > 0.3m))
            {
                txtCostoSinIVA.Valor = costoSinIva;
                if (costoConIva.GetValueOrDefault() != 0)
                {
                    var porcentaje = ((txtPrecioConIVA.Valor - costoConIva) / costoConIva) * 100m;
                    txtPorcentajeGanancia.Valor = porcentaje;
                }
                
            }
        }

        private void txtPorcentajeGanancia_Cambio()
        {
            var costoConIva = txtCostoConIVA.Valor;
            var nuevoPrecio = (txtPorcentajeGanancia.Valor * costoConIva) / 100 + costoConIva;

            if (Math.Abs(nuevoPrecio.GetValueOrDefault() - txtPrecioConIVA.Valor.GetValueOrDefault()) > 0.15m)
            {
                txtPrecioConIVA.Valor = nuevoPrecio;
                txtPrecioSinIVA.Valor = nuevoPrecio / 1.21m;
            }
        }

        private void txtPrecioSinIVA_Cambio()
        {
            var precioSinIva = txtPrecioSinIVA.Valor;
            var precioConIva = precioSinIva * 1.21m;
            if (Math.Abs(txtPrecioConIVA.Valor.GetValueOrDefault() - precioConIva.GetValueOrDefault()) > 0.3m)
            {
                txtPrecioConIVA.Valor = precioConIva;
                if (txtCostoConIVA.Valor.GetValueOrDefault() > 0)
                {
                    var porcentaje = ((precioConIva - txtCostoConIVA.Valor) / txtCostoConIVA.Valor) * 100m;
                    txtPorcentajeGanancia.Valor = porcentaje;
                }
            }
        }

        private void txtPrecioConIVA_Cambio()
        {
            var precioConIva = txtPrecioConIVA.Valor;
            var precioSinIva = precioConIva / 1.21m;
            if (Math.Abs(txtPrecioSinIVA.Valor.GetValueOrDefault() - precioSinIva.GetValueOrDefault()) > 0.3m)
            {
                txtPrecioSinIVA.Valor = precioSinIva;
                if (txtCostoConIVA.Valor.GetValueOrDefault() > 0)
                {
                    var porcentaje = ((precioConIva - txtCostoConIVA.Valor) / txtCostoConIVA.Valor) * 100m;
                    txtPorcentajeGanancia.Valor = porcentaje;
                }
            }
        }
    }
}
