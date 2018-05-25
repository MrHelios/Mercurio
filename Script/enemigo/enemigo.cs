using UnityEngine;

public class enemigo : MonoBehaviour
{
    protected vida vidaEnemigo;

    void Awake()
    {
        gameObject.tag = "Enemy";
        vidaEnemigo = new vida(1);
        if(gameObject.transform.parent.GetComponent<crearEnemigo>() != null)
            gameObject.SetActive(false);
    }

    void Start ()
    {
        
	}    

    public bool estaVivo()
    {
        return vidaEnemigo.getVidaAct() > 0;
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
