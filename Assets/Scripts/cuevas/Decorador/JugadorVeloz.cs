using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Componente;

namespace componente_Concreto
{
    public class JugadorVeloz : Componente.Jugador
    {
        private string nombre;

        public JugadorVeloz(string nombre)
        {
            this.nombre = nombre;
        }

        public override int GetVelocidad()
        {
            return 5;
        }

        public override string GetNombre()
        {
            return nombre;
        }

        public override string GetTipo()
        {
            return "corriendo";
        }
    }
}