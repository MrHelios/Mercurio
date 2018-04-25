using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cooldown
{
    private float ultimaVezUsado, cd;

    public bool tiempoCompletado()
    {
        return Time.time > ultimaVezUsado + cd;
    }

    public void setUltimaVez(float f)
    {
        ultimaVezUsado = f;
    }

    public void setCooldown(float f)
    {
        cd = f;
    }    
}
