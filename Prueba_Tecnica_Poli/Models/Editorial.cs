﻿using System;
using System.Collections.Generic;

namespace Prueba_Tecnica_Poli.Models;

public partial class Editorial
{
    public int IdEditorial { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Libro> Libros { get; set; } = new List<Libro>();
}
