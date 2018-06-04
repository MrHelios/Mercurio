using UnityEngine;

public class buhoCrearVida : habilidad
{
    public GameObject vida;
    private bool estado;

    private void Start()
    {
        activar();
    }

    public override void activar()
    {
        estado = true;
    }

    public override void desactivar()
    {
        estado = false;
    }

    protected override void efecto()
    {
        if (vida != null && estado)
        {
            vida.SetActive(true);
            vida.AddComponent<Rigidbody2D>();
            transform.parent.gameObject.GetComponent<destruir>().enabled = true;
            desactivar();
            GetComponent<SpriteRenderer>().enabled = false;
        }
        else if(estado)
            Debug.Log("Error: No se eligio vida.");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name.Contains("disp_basico"))
        {
            efecto();
        }
    }

}
