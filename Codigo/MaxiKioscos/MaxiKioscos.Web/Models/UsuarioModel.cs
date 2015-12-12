using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MaxiKioscos.Datos.Sync;
using MaxiKioscos.Entidades;
using MaxiKioscos.Web.Configuration;

namespace MaxiKioscos.Web.Models
{
    public class UsuarioModel
    {
        public Usuario Usuario { get; set; }

        [Display(Name = "Rol")]
        [Required(ErrorMessage = "Debe ingresar un rol para el usuario")]
        public int RoleId { get; set; }

        [Display(Name = "Rol")]
        public string RoleName
        {
            get
            {
                if (RoleId == 0)
                    return string.Empty;
                var repo = new UsuarioRepository();
                var rol = repo.RolesListado().FirstOrDefault(r => r.RoleId == RoleId);
                return rol.RoleName;
            }
        }

        private List<int> _proveedoresIds;
        [Display(Name = "Proveedores para ingreso de productos")]
        public List<int> ProveedoresIds
        {
            get
            {
                if (Usuario.UsuarioProveedores != null && Usuario.UsuarioProveedores.Any(p => !p.Eliminado))
                {
                    _proveedoresIds = Usuario.UsuarioProveedores.Where(p => !p.Eliminado).Select(p => p.ProveedorId).ToList();
                }
                return _proveedoresIds;
            }
            set { _proveedoresIds = value; }
        }

        public List<SelectListItem> Maxikioscos { get; set; }
        public List<SelectListItem> Roles { get; set; }
        public List<SelectListItem> Proveedores { get; set; }

        [Display(Name = "Proveedores para ingreso de productos")]
        public string ProveedoresDetalle
        {
            get
            {
                if (Proveedores == null || Proveedores.Count == 0 || ProveedoresIds == null || ProveedoresIds.Count == 0)
                    return string.Empty;
                var lista = string.Empty;
                for (int i = 0; i < Proveedores.Count; i++)
                {
                    var proveedor = Proveedores.ElementAt(i);
                    if (ProveedoresIds.Contains(int.Parse(proveedor.Value)))
                    {
                        lista += string.IsNullOrEmpty(lista) ? proveedor.Text : String.Format(", {0}", proveedor.Text);
                    }
                }
                return lista;
            }
        }

        public UsuarioModel()
        {
            Maxikioscos = UsuarioActual.MaxiKioscos.Where(m=>!m.Eliminado).Select(m => new SelectListItem()
                                                                    {
                                                                        Text = m.Nombre,
                                                                        Value = m.MaxiKioscoId.ToString()
                                                                    }).ToList();
        }
    }

    public class UsuarioConPasswordModel : UsuarioModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "La contraseña debe tener al menos 6 caracteres de largo.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar contraseña")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "La contraseña y la confirmación no coinciden.")]
        public string ConfirmPassword { get; set; }
    }

    public class UsuarioConPasswordOpcionalModel : UsuarioModel
    {
        [StringLength(100, ErrorMessage = "La contraseña debe tener al menos 6 caracteres de largo.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar contraseña")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "La contraseña y la confirmación no coinciden.")]
        public string ConfirmPassword { get; set; }
    }
}