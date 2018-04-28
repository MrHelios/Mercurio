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
	
	void FixedUpdate ()
    {        
        float velY = Input.GetAxis("Vertical");
        Vector2 v = GetComponent<Rigidbody2D>().velocity;

        if(Input.GetAxis("Fire1") > 0 || Input.GetKey(KeyCode.Alpha1))
        {            
            anim.SetBool(GetComponent<movimiento>().getNombreAnimacion(), false);
            anim.SetBool(GetComponent<agacharse>().getNombreAnimacion(), false);
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, v.y);

            if (Input.GetAxis("Fire1") > 0 && cd.tiempoCompletado())
            {
                GetComponent<atqbasico>().activar();
                anim.SetTrigger("atq_basico");
                cd.setCooldown(0.2f);
                cd.setUltimaVez(Time.time);
            }
            else if (Input.GetKey(KeyCode.Alpha1) && cd.tiempoCompletado())
            {                
                GetComponent<atqbomba>().activar();
                anim.SetTrigger("atq_bomba");
                cd.setCooldown(0.4f);
                cd.setUltimaVez(Time.time);
            }
        }
                
	}
}
