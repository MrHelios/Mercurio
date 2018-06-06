using UnityEngine;

public class heroColision : MonoBehaviour
{
    public jefe vidaJefe; 
    private bool activo;
    private GameObject hero;

    void Start()
    {
        buscarHero();
        activar();
    }

    private void buscarHero()
    {
        hero = GameObject.Find("hero");
        if (hero == null)
            Debug.Log("No hay hero.");
    }

    public void activar()
    {
        activo = true;
    }

    public void desactivar()
    {
        activo = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player" && activo && hero != null)
        {
            if(vidaJefe != null && vidaJefe.estaVivo())
                hero.GetComponent<hero>().pierdeVida();
            else if(vidaJefe == null)
                hero.GetComponent<hero>().pierdeVida();
        }        
    }

}
