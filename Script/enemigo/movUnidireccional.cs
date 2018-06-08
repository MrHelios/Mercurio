using UnityEngine;

public class movUnidireccional : habilidad
{
    private GameObject punto;
    private bool activado;
    private int velx;

    private void Awake()
    {
        punto = GameObject.Find(transform.parent.name + "/puntos/a");
        if (punto == null)
            Debug.Log("No se ha seleccionado hacia donde debe moverse " + transform.parent.name);
    }

    void Start ()
    {
        activado = true;

        anim = GetComponent<Animator>();
        estado_anim = "movimiento";

        velx = 3;

        efecto();
	}

    public void setVelocidad(int v)
    {
        velx = v;
    }

    protected override void efecto()
    {        
        anim.SetBool(estado_anim, true);
        if(punto != null)
        {
            if (transform.position.x < punto.transform.position.x)
            {
                Vector3 s = transform.localScale;
                transform.localScale = new Vector3((-1) * s.x, s.y, s.z);
                GetComponent<Rigidbody2D>().velocity = new Vector2(velx, 0);
            }
            else
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(-velx, 0);
            }
        }
        else
        {
            GameObject hero = GameObject.Find("hero");
            if (transform.position.x < hero.transform.position.x)
            {
                Vector3 s = transform.localScale;
                transform.localScale = new Vector3((-1) * s.x, s.y, s.z);
                GetComponent<Rigidbody2D>().velocity = new Vector2(velx, 0);
            }
            else
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(-velx, 0);
            }
        }
    }

    public override void activar()
    {
        activado = true;
        efecto();
    }

    public override void desactivar()
    {
        activado = false;
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        GetComponent<BoxCollider2D>().enabled = false;
    }
    
}
