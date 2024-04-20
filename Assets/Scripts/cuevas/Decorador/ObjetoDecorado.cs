using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Componente;

namespace decorador
{
    public abstract class ObjetoDecorado : Jugador
    {
        protected Jugador cJugador;

        // El nombre del constructor no debe ser el mismo que el de la clase
        public ObjetoDecorado(Jugador jugador)
        {
            this.cJugador = jugador;
        }

        // Cambia el nombre del método para evitar la ambigüedad con el constructor
        public Jugador ObtenerJugador()
        {
            return cJugador;
        }
    }
}