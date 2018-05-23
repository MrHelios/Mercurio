using UnityEngine;

public class movDiagonal : habilidad
{
    public GameObject punto;
    private string direccion;
    private string altura;    

    private float tiempo;
    private float velX, velY;

    private bool activado;

	void Start ()
    {
        activado = true;

        tiempo = 1f;
        cd = new cooldown();
        cd.setCooldown(tiempo);
        cd.setUltimaVez(-99f);

        direccion = getDireccion();

        altura = "abajo";

        velX = 5f;
        velY = 2;
	}

    private string getDireccion()
    {
        if (punto.transform.position.x > transform.position.x)
            return "derecha";
        else
            return "izquierda";
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
        if(direccion == "derecha")
        {
            if(altura == "abajo")
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(velX, velY);
                transform.localScale = new Vector3(-1, 1, 1);
                altura = "arriba";
            }
            else
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(velX, -velY);
                transform.localScale = new Vector3(-1, 1, 1);
                altura = "abajo";
            }
        }
        else
        {
            if (altura == "abajo")
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(-velX, velY);
                transform.localScale = new Vector3(1, 1, 1);
                altura = "arriba";
            }
            else
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(-velX, -velY);
                transform.localScale = new Vector3(1, 1, 1);
                altura = "abajo";
            }
        }
        cd.setUltimaVez(Time.time);
    }
	
	void FixedUpdate ()
    {
        if (cd.tiempoCompletado() && activado)
            efecto();
	}
}
