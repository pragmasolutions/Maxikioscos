using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MaxiKioscos.Entidades
{
    [MetadataType(typeof(UsuarioMetadata))]
    public partial class Usuario : IEntity
    {
        public string ProveedoresIdsListado
        {
            get
            {
                if (UsuarioProveedores == null || UsuarioProveedores.Count == 0)
                    return null;
                var lista = string.Empty;
                for (int i = 0; i < UsuarioProveedores.Count; i++)
                {
                    var proveedor = this.UsuarioProveedores.ElementAt(i);
                    lista += (i == 0) ? proveedor.ProveedorId.ToString() : String.Format(",{0}", proveedor.ProveedorId);
                }
                return lista;
            }
        }

        public Role Rol
        {
            get
            {
                return this.Roles.FirstOrDefault();
            }
        }

        public string NombreCompleto
        {
            get { return String.Format("{0}, {1}", Apellido, Nombre); }
        }

        public bool TienePermiso(string permiso)
        {
            return this.Rol.PermisoRoles.Where(x => !x.Eliminado).Select(x => x.Permiso.Nombre).Any(x => x.Equals(permiso));
        }
    }

    public class UsuarioMetadata
    {
        [DisplayName("Nombre de Usuario")]
        [Required(ErrorMessage = "Debe ingresar un nombre de usuario")]
        public string NombreUsuario { get; set; }

        [DisplayName("Apellido")]
        [Required(ErrorMessage = "Debe ingresar un apellido")]
        public string Apellido { get; set; }

        [DisplayName("Nombre")]
        [Required(ErrorMessage = "Debe ingresar un nombre")]
        public string Nombre { get; set; }
    }
}
