using System;
using UnityEngine;

public class movUnidireccional : habilidad
{
    public GameObject punto;
    private bool activado;
    private int velx;

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
        if(transform.position.x < punto.transform.position.x)
        {
            Vector3 s = transform.localScale;
            transform.localScale = new Vector3((-1) * s.x, s.y, s.z);
            GetComponent<Rigidbody2D>().velocity = new Vector2(velx,0);
        }
        else
        {            
            GetComponent<Rigidbody2D>().velocity = new Vector2(-velx, 0);
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
    
}
