using UnityEngine;

public class desactivarImpactoConHero : MonoBehaviour
{
    private bool usado;

    private void Start()
    {
        usado = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && !usado)
        {
            usado = true;
            desactivar();
        }
    }

    private void desactivar()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<destruir>().activar();
        GameObject.Find("hero").GetComponent<municionArcana>().aumentarCarga();
        Destroy(this);
    }

}
