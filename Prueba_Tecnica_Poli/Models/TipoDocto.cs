using System;
using System.Collections.Generic;

namespace Prueba_Tecnica_Poli.Models;

public partial class TipoDocto
{
    public int IdTipoDocto { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Autor> Autors { get; set; } = new List<Autor>();
}
