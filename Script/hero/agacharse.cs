using UnityEngine;

public class agacharse : habilidad
{    
    private float velY;    

	void Start ()
    {
        anim = GetComponent<Animator>();
        estado_anim = "agacharse";

        cd = new cooldown();
        cd.setCooldown(0.2f);
        cd.setUltimaVez(-99f);
	}

    public override void activar()
    {
        anim.SetBool(estado_anim, true);        
    }

    public override void desactivar()
    {
        anim.SetBool(estado_anim, false);        
    }

    protected override void efecto()
    {
        float velY = Input.GetAxis("Vertical");

        if (velY < 0f && cd.tiempoCompletado())
            activar();
        else
            desactivar();
    }

    void FixedUpdate ()
    {
        efecto();
    }
}
