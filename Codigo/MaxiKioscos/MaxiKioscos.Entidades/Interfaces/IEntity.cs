using System;

namespace MaxiKioscos.Entidades
{
    public interface IEntity
    {
        DateTime? FechaUltimaModificacion { get; set; }
        bool Eliminado { get; set; }
        bool Desincronizado { get; set; }
    }
}
