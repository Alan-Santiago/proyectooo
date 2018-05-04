using deportes.COMMON.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace deportes.COMMON.Graficos
{
    public class GraficaInfo
    {
        public GraficaInfo()
        {
            Puntos = new List<Graficas>();
        }
        public List<Graficas> Puntos { get; set; }

        public List<Graficas> GeneradorDatos (List<lisTorneo> listatorneo, double limiteInferior, double limiteSuperior, double incremento)
        {
            Puntos = new List<Graficas>();
            double contador = 1;
            foreach (var item in listatorneo)
            {
                Puntos.Add(new Graficas (contador++, item.Puntos));
            }
            return Puntos;
        }
    }
}

