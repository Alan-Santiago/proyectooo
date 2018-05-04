using System;
using System.Collections.Generic;
using System.Text;

namespace deportes.COMMON.Entidades
{
    public class Torneo: Base
    {
        public  string fechaDeJuego { get; set; }
        public string Deporte { get; set; }
        public string EquipoA { get; set; }
        public int MarcadorA { get; set; }
        public string EquipoB { get; set; }
        public int MarcadorB { get; set; }
    }
}
