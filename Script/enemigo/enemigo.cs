using UnityEngine;

public class enemigo : MonoBehaviour
{
    private vida vidaEnemigo;

	void Start ()
    {
        gameObject.tag = "Enemy";
        vidaEnemigo = new vida(1);
	}
	
    public vida getVida()
    {
        return vidaEnemigo;
    }

    public void pierdeVida()
    {
        vidaEnemigo.pierdeVida();
        if(vidaEnemigo.estaMuerto())
        {
            gameObject.SetActive(false);
        }
    }

    public void revivir()
    {
        vidaEnemigo.restaurar_maxima_vida();
    }

    public void muerte()
    {
        vidaEnemigo.muerte();
    }

}
