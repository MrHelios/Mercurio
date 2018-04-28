using UnityEngine;

public class atqbomba : atqDistancia
{    

    void Start()
    {
        anim = GetComponent<Animator>();
        nombre_anim = "atq_bomba";

        disparar = false;
        velocidad = 300;

        cd = new cooldown();
        cd.setUltimaVez(-99f);
        cd.setCooldown(0.3f);

        hab_ejec = new cooldown();
        hab_ejec.setUltimaVez(-99f);
        hab_ejec.setCooldown(1f);
    }    

    public override void efecto()
    {
        Vector3 v = disp.transform.parent.transform.position;
        string m = GetComponent<mov>().getMirada();

        GameObject nuevo = Instantiate(disp);
        nuevo.transform.position = disp.transform.position;
        nuevo.GetComponent<Collider2D>().enabled = true;
        nuevo.GetComponent<destruir>().enabled = true;

        if (m.Equals("derecha"))
        {
            nuevo.GetComponent<Rigidbody2D>().AddForce(new Vector2(velocidad, velocidad));
        }
        else
        {
            nuevo.GetComponent<Rigidbody2D>().AddForce(new Vector2(-velocidad, velocidad));            
        }

        nuevo.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
        desactivar();
        hab_ejec.setUltimaVez(Time.time);
    }

    private void FixedUpdate()
    {
        if(puedeActuar())
        {
            efecto();
        }        
    }

}
