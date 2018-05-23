using UnityEngine;

public abstract class jefeFinalSecuencia : MonoBehaviour
{
    protected habilidad[] habilidades;

    protected void setHabilidad(int i, habilidad h)
    {
        habilidades[i] = h;
    }

    protected habilidad getHabilidad(int i)
    {
        return habilidades[i % habilidades.Length];
    }

}
