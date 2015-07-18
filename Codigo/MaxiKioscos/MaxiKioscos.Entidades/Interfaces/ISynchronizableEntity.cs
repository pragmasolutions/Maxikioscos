using System;

namespace MaxiKioscos.Entidades
{
    public interface ISynchronizableEntity
    {
        bool Desincronizado { get; set; }
    }
}
