using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JugueteriadelCaribe.Models;

public partial class Juguete
{
    public int PkJuguete { get; set; }
    [Required(ErrorMessage = "El nombre es obligatorio")]
    public string? Nombre { get; set; }
    [Required(ErrorMessage = "El genero es obligatorio")]
    public string? Genero { get; set; }
    [Required(ErrorMessage = "El costo es obligatorio")]
    public string? Costo { get; set; }
    [Required(ErrorMessage = "La descripción es obligatoria")]
    public string? Descripcion { get; set; }
    [Required(ErrorMessage = "La fecha es obligatoria")]
    public DateTime? FechaIngreso { get; set; }
}
