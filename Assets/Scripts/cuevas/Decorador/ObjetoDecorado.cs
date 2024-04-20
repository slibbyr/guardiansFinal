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

        // Cambia el nombre del m�todo para evitar la ambig�edad con el constructor
        public Jugador ObtenerJugador()
        {
            return cJugador;
        }
    }
}