using System;
using System.Collections.Generic;
using System.Text;

namespace deportes.COMMON.Entidades
{
    public class CateDeportes: Base
    {
        public string NombreDeporte{ get; set; }
        public override string ToString()
        {
            return NombreDeporte;

        }

    }
}
