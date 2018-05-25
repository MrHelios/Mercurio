using UnityEngine;

public class movDireccionalHero : habilidad
{    
    private bool activado;
    private int velx;

    void Start()
    {
        anim = GetComponent<Animator>();
        estado_anim = "movimiento";

        velx = 3;

        cd = new cooldown();
        cd.setCooldown(1f);
        cd.setUltimaVez(-99f);

        activar();
    }

    public void setVelocidad(int v)
    {
        velx = v;
    }

    protected override void efecto()
    {        
        GameObject hero = GameObject.Find("hero");
        if (transform.position.x < hero.transform.position.x)
        {
            
            transform.localScale = new Vector3(-2,2,1);
            GetComponent<Rigidbody2D>().velocity = new Vector2(velx, 0);
        }
        else
        {
            transform.localScale = new Vector3(2, 2, 1);
            GetComponent<Rigidbody2D>().velocity = new Vector2(-velx, 0);
        }
        cd.setUltimaVez(Time.time);
    }

    public override void activar()
    {
        activado = true;
        anim.SetBool(estado_anim, true);
        efecto();
    }

    public override void desactivar()
    {
        activado = false;
        anim.SetBool(estado_anim, false);
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);        
    }

    void FixedUpdate()
    {
        if (activado && cd.tiempoCompletado())
            efecto();
    }
}
