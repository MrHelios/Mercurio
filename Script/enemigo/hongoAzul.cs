using UnityEngine;

public class hongoAzul : MonoBehaviour
{
    private Animator anim;
    private GameObject hero;
    private bool cortado;
    
    void Start ()
    {
        hero = GameObject.Find("hero");
        anim = GetComponent<Animator>();
        cortado = false;
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name.Contains("disp_basico") && !cortado && transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().isVisible)
        {
            anim.SetTrigger("corte");
            cortado = true;
            agregarPuntoDeInvulnerable();
            eliminar();
        }
    }

    private void agregarPuntoDeInvulnerable()
    {
        hero.GetComponent<invulnerable>().aumentarCantidad();
    }

    private void eliminar()
    {
        gameObject.AddComponent<destruir>();
        Destroy(GetComponent<Collider2D>());
        Destroy(this);
    }

}
