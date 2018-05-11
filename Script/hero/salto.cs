using UnityEngine;

public class salto : habilidad
{
    private bool puedeSaltar;
    private bool estaSaltando;
	
	void Start ()
    {
        estaSaltando = false;
        anim = GetComponent<Animator>();
        estado_anim = "en_aire";
        activar();
	}

    public bool getEstaSaltando()
    {
        return estaSaltando;
    }

    public override void activar()
    {
        puedeSaltar = true;
        estaSaltando = false;
        anim.SetBool(estado_anim, false);
    }

    public override void desactivar()
    {
        puedeSaltar = false;
        estaSaltando = true;
        anim.SetBool(estado_anim, true);
    }

    protected override void efecto()
    {
        if (Input.GetAxis("Fire3") > 0 && puedeSaltar && !GetComponent<agacharse>().getEstaAgachado())
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
