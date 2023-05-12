using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prueba_Tecnica_Poli.Models;

public partial class Autor
{
    [DisplayName("Id")]
    public int IdAutor { get; set; }

    [Required(ErrorMessage = "{0} es obligatorio.")]
    public string Nombre { get; set; } = null!;

    [Required(ErrorMessage = "{0} es obligatorio.")]
    public string Apellido { get; set; } = null!;

    [Required(ErrorMessage = "{0} es obligatorio.")]
    [DisplayName("Tipo Documento")]
    public int IdTipoDocto { get; set; }

    [Required(ErrorMessage = "{0} es obligatorio.")]
    [DisplayName("No. Documento")]
    public int NumDocto { get; set; }

    [Required(ErrorMessage = "{0} es obligatorio.")]
    [DisplayName("Fecha Nacimiento")]
    [DataType(DataType.Date)]
    public DateTime FecNacimiento { get; set; }

    [DisplayName("Tipo Documento")]
    public virtual TipoDocto? IdTipoDoctoNavigation { get; set; } = null!;

    public virtual ICollection<Libro> Libros { get; set; } = new List<Libro>();

    public string NombreCompleto => $"{Nombre} {Apellido}";
}
