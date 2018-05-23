using UnityEngine;

public class bombaPlanta : habilidad
{
    public GameObject bomba;    
    private bool estaEnZona;
    private bool activado;

    void Start()
    {
        activado = true;

        estaEnZona = false;

        cd = new cooldown();
        cd.setCooldown(2f);
        cd.setUltimaVez(0f);

        anim = GetComponent<Animator>();
        estado_anim = "terminar";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && !estaEnZona)
        {
            estaEnZona = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" && estaEnZona)
        {
            estaEnZona = false;
        }
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
        GameObject nuevo = Instantiate(bomba);

        nuevo.transform.position = transform.position;
        nuevo.SetActive(true);
        nuevo.GetComponent<Rigidbody2D>().gravityScale = 2;
        nuevo.GetComponent<destruir>().enabled = true;

        cd.setUltimaVez(Time.time);
        anim.SetTrigger(estado_anim);
    }

    void FixedUpdate()
    {
        if (cd.tiempoCompletado() && estaEnZona && activado)
            efecto();
    }
}
