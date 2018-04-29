using UnityEngine;

public class mov : MonoBehaviour
{
    private Animator anim;
    private string mirada;
    private cooldown cd;
	
	void Start ()
    {
        anim = GetComponent<Animator>();
        cd = GetComponent<movimiento>().getCooldown();
        mirada = "derecha";
    }

    public void setMirada(string m)
    {
        mirada = m;
    }

    public string getMirada()
    {
        return mirada;
    }

    public void animacionMuerte()
    {
        anim.SetBool(GetComponent<movimiento>().getNombreAnimacion(), false);
        anim.SetBool(GetComponent<agacharse>().getNombreAnimacion(), false);
        anim.SetTrigger("muerte");
    }
	
	void FixedUpdate ()
    {
        Vector2 v = GetComponent<Rigidbody2D>().velocity;

        if(Input.GetAxis("Fire1") > 0 || Input.GetKey(KeyCode.Alpha1))
        {            
            anim.SetBool(GetComponent<movimiento>().getNombreAnimacion(), false);
            anim.SetBool(GetComponent<agacharse>().getNombreAnimacion(), false);
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, v.y);

            if (Input.GetAxis("Fire1") > 0 && cd.tiempoCompletado() && GetComponent<atqbasico>().getCooldown().tiempoCompletado())
            {
                GetComponent<atqbasico>().activar();
                GetComponent<atqbasico>().getCooldown().setUltimaVez(Time.time);
                
                cd.setCooldown(0.2f);
                cd.setUltimaVez(Time.time);
            }
            else if (Input.GetKey(KeyCode.Alpha1) && cd.tiempoCompletado() && GetComponent<atqbomba>().getCooldown().tiempoCompletado())
            {                
                GetComponent<atqbomba>().activar();
                GetComponent<atqbomba>().getCooldown().setUltimaVez(Time.time);

                cd.setCooldown(0.4f);
                cd.setUltimaVez(Time.time);
            }
        }
                
	}
}
