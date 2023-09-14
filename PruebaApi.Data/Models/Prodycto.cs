using System;
using System.Collections.Generic;

namespace PruebaApi.Data.Models;

public partial class Prodycto
{
    public int Idprodyctos { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public decimal Costo { get; set; }
}
