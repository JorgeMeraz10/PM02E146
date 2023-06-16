using System;
using System.Collections.Generic;
using System.Text;

namespace PM2E146.Models
{
    class Sitios
    {
       public int Id { get; set; }

       public string Latitud { get; set; }

       public string Longitud { get; set; }

       public string Descripcion { get; set; }

       public byte[] Imagen {get; set; }
    }
}
