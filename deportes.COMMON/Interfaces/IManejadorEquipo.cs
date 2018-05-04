using deportes.COMMON.Entidades;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace deportes.COMMON.Interfaces
{
   public  interface IManejadorEquipo:IManejadorGenerico<Equipo>
    {
        IEnumerable BuscarEquipos(string pal);
        int ContadorDeBuscarEquipo(string pal);

        int Aleatorios(string pal);
    }
}
