using UnityEngine;

public class hero : MonoBehaviour
{
    private vida vidaHero;

    void Start()
    {
        gameObject.tag = "Player";
        vidaHero = new vida(4);
    }

    public vida getVida()
    {
        return vidaHero;
    }

    public void pierdeVida()
    {
        vidaHero.pierdeVida();
        if (vidaHero.estaMuerto())
        {
            Debug.Log("El heroe ha muerto.");
        }
    }

    public void restaurar_vida_max()
    {
        vidaHero.restaurar_maxima_vida();
    }

    public void muerte()
    {
        vidaHero.muerte();
    }

}
