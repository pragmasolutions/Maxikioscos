﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MaxiKioscos.Datos.Repositorio;
using MaxiKioscos.Entidades;
using MaxiKioscos.Web.Configuration;

namespace MaxiKioscos.Web.Models
{
    public class ExportacionDescargaModel
    {

        public List<SelectListItem> Tipos
        {
            get
            {
                return new List<SelectListItem>()
                           {
                               new SelectListItem(){ Text = "Para Kiosco", Value = "1"},
                               new SelectListItem(){ Text = "Completa", Value = "2"},
                               new SelectListItem(){ Text = "Parcial", Value = "3"}
                           };
            }
        }

        [Display(Name = "Tipo de Descarga")]
        public int DescargaTipo { get; set; }

        [Display(Name = "A partir de Nro de Secuencia")]
        [Range(1, Double.MaxValue, ErrorMessage = "La secuencia debe ser mayor a 0")]
        public int? Secuencia { get; set; }

        [UIHint("MaxiKiosco")]
        [Display(Name = "Para Kiosco")]
        public int? MaxiKioscoId { get; set; }

        [UIHint("Date")]
        [Display(Name = "Desde Fecha")]
        public DateTime? Fecha { get; set; }

        public string FileName { get; set; }

        internal List<Exportacion> ObtenerExportaciones()
        {
            var repo = new ExportacionRepository();
            var archivos = new List<Exportacion>();
            switch (DescargaTipo)
            {
                case 1: //Kiosco
                    var kioscoRepository = new MaxiKioscoRepository();
                    var kiosco = kioscoRepository.Obtener(this.MaxiKioscoId.GetValueOrDefault());
                    archivos = repo.ListadoPorCuenta(UsuarioActual.CuentaId, e => e.ExportacionArchivo)
                                            .Where(e => e.Secuencia > kiosco.UltimaSecuenciaExportacion.GetValueOrDefault()).ToList();
                    break;
                case 2: //Completa
                    archivos = repo.ListadoPorCuenta(UsuarioActual.CuentaId, e => e.ExportacionArchivo).ToList();
                    break;
                case 3: //Parcial (secuencia)
                    archivos = repo.ListadoPorCuenta(UsuarioActual.CuentaId, e => e.ExportacionArchivo)
                                                                .Where(e => e.Secuencia >= this.Secuencia).ToList();
                    break;
                case 4: //Fecha
                    var fecha = this.Fecha.GetValueOrDefault().AddDays(-1);
                    archivos = repo.ListadoPorCuenta(UsuarioActual.CuentaId, e => e.ExportacionArchivo)
                                                                .Where(e => e.Fecha > fecha).ToList();
                    break;
            }
            return archivos;
        }

        internal string GenerarNombreArchivo()
        {
            var nombre = string.Empty;
            switch (DescargaTipo)
            {
                case 1: //Kiosco
                    var kioscoRepository = new MaxiKioscoRepository();
                    var kiosco = kioscoRepository.Obtener(this.MaxiKioscoId.GetValueOrDefault());
                    nombre = String.Format("EXP-Kiosco-{0} {1}.zip", kiosco.Nombre, DateTime.Now.ToString("dd-MM-yyyy"));
                    break;
                case 2: //Completa
                    nombre = String.Format("EXP-Completa {0}.zip", DateTime.Now.ToString("dd-MM-yyyy"));
                    break;
                case 3: //Parcial (secuencia)
                    nombre = String.Format("EXP-Secuencia-{0} {1}.zip", this.Secuencia, DateTime.Now.ToString("dd-MM-yyyy"));
                    break;
                case 4: //Fecha
                    nombre = String.Format("EXP-Fecha-{0} {1}.zip", this.Fecha.GetValueOrDefault().ToString("dd-MM-yyyy"), 
                                                                    DateTime.Now.ToString("dd-MM-yyyy"));
                    break;
            }
            return nombre;
        }
    }
}