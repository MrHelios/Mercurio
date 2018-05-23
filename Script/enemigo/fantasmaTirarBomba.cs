using UnityEngine;

public class fantasmaTirarBomba : habilidad
{
    public GameObject bomba;
    private bool activo;

    void Awake()
    {
        activo = true;
    }

    void Start ()
    {
        cd = new cooldown();
        cd.setCooldown(2f);
        cd.setUltimaVez(-99f);
	}

    protected override void efecto()
    {
        GameObject nuevo = Instantiate(bomba);

        nuevo.transform.position = transform.position;
        nuevo.SetActive(true);
        if (GetComponent<enemMovimiento>() != null)
            nuevo.GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<enemMovimiento>().getVelocidad().x, 0);
        else
            nuevo.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        nuevo.GetComponent<Rigidbody2D>().gravityScale = 2;
        nuevo.GetComponent<destruir>().enabled = true;

        cd.setUltimaVez(Time.time);
    }

    public override void activar()
    {
        activo = true;
    }

    public override void desactivar()
    {
        activo = false;
    }

    void FixedUpdate ()
    {
        if (cd.tiempoCompletado() && activo)
            efecto();
	}
}
