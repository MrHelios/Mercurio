using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class atqDistancia : MonoBehaviour
{
    public GameObject disp;
    protected int velocidad;
    protected bool disparar;
    protected cooldown cd;    

    public void activar()
    {
        cd.setUltimaVez(Time.time);
        disparar = true;
    }

    protected void puedeActuar()
    {
        if (disparar && cd.tiempoCompletado())
            efecto();
    }

    protected abstract void efecto();

}
