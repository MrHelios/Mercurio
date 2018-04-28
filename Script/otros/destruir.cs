using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destruir : MonoBehaviour
{
    private cooldown cd, muerte_sin_colision;
    private bool ahora;

    private void Start()
    {
        ahora = false;

        cd = new cooldown();
        cd.setCooldown(2f);
        cd.setUltimaVez(Time.time);

        muerte_sin_colision = new cooldown();
        muerte_sin_colision.setCooldown(4f);
        muerte_sin_colision.setUltimaVez(Time.time);
    }

    public void activar()
    {
        ahora = true;
    }

    private void FixedUpdate()
    {
        if (ahora && cd.tiempoCompletado())
            Destroy(gameObject);
        else if (muerte_sin_colision.tiempoCompletado())
            activar();
    }
}
