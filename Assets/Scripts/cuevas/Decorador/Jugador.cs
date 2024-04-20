using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Componente
{
    public abstract class Jugador
    {
        public abstract int GetVelocidad();
        public abstract string GetNombre();
        public abstract string GetTipo();

        private int velocidad;

        
    }
}
