using UnityEngine;

public class salto : habilidad
{
    private bool puedeSaltar;    
	
	void Start ()
    {
        anim = GetComponent<Animator>();
        estado_anim = "en_aire";
        activar();
	}

    public override void activar()
    {
        puedeSaltar = true;
        anim.SetBool(estado_anim, false);
    }

    public override void desactivar()
    {
        puedeSaltar = false;
        anim.SetBool(estado_anim, true);
    }

    protected override void efecto()
    {
        if (Input.GetAxis("Fire3") > 0 && puedeSaltar)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 250));
            desactivar();            
        }
    }

    void FixedUpdate ()
    {
        efecto();	
	}
}
