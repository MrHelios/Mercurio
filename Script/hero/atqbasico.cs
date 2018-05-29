using UnityEngine;

public class atqbasico : atqDistancia
{
    void Start()
    {
        anim = GetComponent<Animator>();
        nombre_anim = "atq_basico";

        disparar = false;
        velocidad = 20;

        cd = new cooldown();
        cd.setUltimaVez(-99f);
        cd.setCooldown(0.2f);

        hab_ejec = new cooldown();
        hab_ejec.setUltimaVez(-99f);
        hab_ejec.setCooldown(0.5f);

        seleccionarProyectil();
    }

    private void seleccionarProyectil()
    {
        GameObject proy = GameObject.Find("hero/proyectiles/disp_basico");
        if (proy != null)
            disp = proy;
        else
            Debug.Log("No ha sido seleccionado el proyectil para atqbasico.");
    }

    private bool estaAgachado()
    {
        return GetComponent<agacharse>().getEstaAgachado();
    }

    public override void efecto()
    {
        if(disp != null)
        {
            GameObject nuevo = Instantiate(disp);
            if (estaAgachado())
            {
                Vector3 v = new Vector3(disp.transform.position.x, disp.transform.position.y-0.5f, disp.transform.position.z);
                nuevo.transform.position = v;
            }                
            else
                nuevo.transform.position = disp.transform.position;
            nuevo.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
            nuevo.AddComponent<Rigidbody2D>();
            nuevo.GetComponent<Rigidbody2D>().gravityScale = 0;
            nuevo.GetComponent<Collider2D>().enabled = true;
            nuevo.GetComponent<destruir>().enabled = true;

            string m = GetComponent<mov2>().getMirada();
            if (m  != null && m.Equals("derecha"))
                nuevo.GetComponent<Rigidbody2D>().velocity = new Vector2(velocidad, 0);
            else
                nuevo.GetComponent<Rigidbody2D>().velocity = new Vector2(-velocidad, 0);

            desactivar();
        }        
    }

    private void FixedUpdate()
    {
        if (puedeActuar())
        {
            efecto();
        }
    }

}
