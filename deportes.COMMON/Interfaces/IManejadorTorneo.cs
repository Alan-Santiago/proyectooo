using deportes.COMMON.Entidades;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace deportes.COMMON.Interfaces
{
    public interface IManejadorTorneo: IManejadorGenerico<Torneo>
    {
        int VerificarSiEsNumero(string text);
    }
}
