using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace cuevas
{
public class niveles : MonoBehaviour{
    salaI salas;

    public niveles(salaI piso){
        salas = piso;
    }

    public void CambiarPiso(GameObject player,int nivel,List<GameObject>pisos){
        salas.CambiarPiso(player,nivel,pisos);
    }


    }
}