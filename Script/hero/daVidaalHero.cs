using UnityEngine;

public class daVidaalHero : habilidad
{
    private bool activado;

    private void Start()
    {
        activar();
    }

    public override void activar()
    {
        activado = true;
    }

    public override void desactivar()
    {
        activado = false;
    }

    protected override void efecto()
    {
        GameObject.Find("hero").GetComponent<hero>().ganaVida();
        GetComponent<SpriteRenderer>().enabled = false;
        activado = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && activado)
        {
            efecto();
        }
    }

}
