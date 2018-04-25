using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destruir : MonoBehaviour
{
    private cooldown cd;

    private void Start()
    {
        cd = new cooldown();
        cd.setCooldown(1f);
        cd.setUltimaVez(Time.time);
    }

    private void FixedUpdate()
    {
        if (cd.tiempoCompletado())
            Destroy(gameObject);
    }
}
