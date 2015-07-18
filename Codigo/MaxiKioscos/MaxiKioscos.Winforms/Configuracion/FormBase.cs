using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;
using MaxiKioscos.Datos.Interfaces;
using MaxiKioscos.Datos.Repositorio;
using MaxiKioscos.Entidades;

namespace MaxiKioscos.Winforms
{
    /// <summary>
    /// The EF-dependent, generic repository for data access
    /// </summary>
    /// <typeparam name="T">Type of entity for this Repository.</typeparam>
    public class FormBase<T> : Form  where T : class , IEntity
    {
        public EFRepository<T> Repository { get; set; }
        public FormBase()
        {
            Repository = new EFRepository<T>();
        }
    }
}
