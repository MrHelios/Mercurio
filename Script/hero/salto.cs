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

    private bool chequearSiEstaAgachado()
    {
        if (GetComponent<mov2>() == null)
            return false;
        return GetComponent<mov2>().getEstaAgachado();
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

    public void desactivarPuedeSaltar()
    {
        puedeSaltar = false;
    }

    public override void desactivar()
    {        
        puedeSaltar = false;
        estaSaltando = true;
        anim.SetBool(estado_anim, true);
    }

    protected override void efecto()
    {
        if (Input.GetAxis("Fire3") > 0 && puedeSaltar && !chequearSiEstaAgachado())
        {
            Vector2 v = GetComponent<Rigidbody2D>().velocity;
            GetComponent<Rigidbody2D>().velocity = new Vector2(v.x, 0);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 250));
            desactivar();            
        }
    }

    void FixedUpdate ()
    {
        efecto();	
	}
}
