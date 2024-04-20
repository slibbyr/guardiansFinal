using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using decorador;

namespace decorador_concreto
{
    public class Pocion : ObjetoDecorado
    {
        private int gMyVel = 15;

        public Pocion(Componente.Jugador pJugador) : base(pJugador)
        {
            // Llamamos al constructor de la clase base con el jugador pasado como par�metro
        }

        public override int GetVelocidad()
        {
            return cJugador.GetVelocidad() + gMyVel;
        }

        public override string GetNombre()
        {
            return cJugador.GetNombre() + " ha tomado una poci�n";
        }

        public override string GetTipo()
        {
            return "velocidad m�xima";
        }
    }
}