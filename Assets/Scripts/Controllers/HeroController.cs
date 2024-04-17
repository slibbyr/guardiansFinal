using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class HeroController : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        // Movimiento básico usando las teclas de dirección
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f) * speed * Time.deltaTime;
        transform.Translate(movement);
    }
}