using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace cuevas
{
    public class cambioCueva : MonoBehaviour
    {
        private int nivel;
        public List<GameObject> pisos;
        public GameObject jugador;
        private salaI sala;

        void Start(){
            nivel = 1;
        }
        void OnTriggerEnter2D(Collider2D other){
                if(other.CompareTag("Player")){
                    if(this.CompareTag("tienda")){
                        sala = new tienda();
                    
                    }else{
                        sala = new planta();
                    }
                    niveles zona  = new niveles(sala);
                    nivel++;
                    zona.CambiarPiso(jugador,nivel,pisos);
                }
           }

    }
}
