﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JF11c : jefeFinalSecuencia
{
    private cooldown cd;
    private bool activar, empezo;
    private float tiempo;
    private int cooldown;

    public GameObject[] enem;

    void Start()
    {
        activar = false;
        empezo = false;

        cooldown = 5;

        cd = new cooldown();
        cd.setCooldown(cooldown);
        cd.setUltimaVez(-99f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !empezo)
        {
            activarZona();
        }
    }

    private void activarZona()
    {
        activar = true;
        empezo = true;
        tiempo = Time.time + 20f;
        GameObject.Find("Camaras/Camera").GetComponent<camaraTrackHorizontal>().enabled = false;
    }

    private void desactivarZona()
    {
        activar = false;
        Destroy(gameObject);
        GameObject.Find("Camaras/Camera").GetComponent<camaraTrackHorizontal>().enabled = true;
    }

    public void efecto()
    {
        for (int i = 0; i < enem.Length; i++)
        {
            GameObject nuevo = Instantiate(enem[i]);
            nuevo.SetActive(true);
            nuevo.AddComponent<destruir>();
        }
    }

    void FixedUpdate()
    {
        if (cd.tiempoCompletado() && activar)
        {
            efecto();

            if (cooldown > 2)
                cooldown -= 1;
            cd.setCooldown(cooldown);
            cd.setUltimaVez(Time.time);
        }
        else if (activar && Time.time > tiempo)
        {
            desactivarZona();
        }
    }
}
