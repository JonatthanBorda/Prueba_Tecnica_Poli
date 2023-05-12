using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Prueba_Tecnica_Poli.Models;

public partial class Libro
{
    [DisplayName("Id")]
    public int IdLibro { get; set; }

    [Required(ErrorMessage = "{0} es obligatorio.")]
    public string Titulo { get; set; } = null!;

    [Required(ErrorMessage = "{0} es obligatorio.")]
    [DisplayName("Editorial")]
    public int IdEditorial { get; set; }

    [Required(ErrorMessage = "{0} es obligatorio.")]
    [DisplayName("No. Páginas")]
    public int NumPaginas { get; set; }

    [Required(ErrorMessage = "{0} es obligatorio.")]
    [DisplayName("Fecha Publicación")]
    [DataType(DataType.Date)]
    public DateTime FecPublicacion { get; set; }

    [Required(ErrorMessage = "{0} es obligatorio.")]
    [DisplayName("Autor")]
    public int IdAutor { get; set; }

    [DisplayName("Autor")]
    public virtual Autor? IdAutorNavigation { get; set; } = null!;

    [DisplayName("Editorial")]
    public virtual Editorial? IdEditorialNavigation { get; set; } = null!;
}
