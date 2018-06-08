using UnityEngine;

public class desaparicionColision : MonoBehaviour
{
    public heroColision hc;
    private bool estado;
    private cooldown cd;

    void Start()
    {
        cd = new cooldown();
        cd.setCooldown(2);
        cd.setUltimaVez(-99f);

        estado = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name.Contains("disp_basico"))
        {
            desactivar();
            GetComponent<jefe>().pierdeVida();
        }
    }

    private void activar()
    {
        estado = false;
        GetComponent<BoxCollider2D>().enabled = true;
        transform.parent.gameObject.GetComponent<movDireccionalHero>().activar();
        hc.activar();
    }

    private void desactivar()
    {
        estado = true;
        transform.parent.gameObject.GetComponent<movDireccionalHero>().desactivar();        
        GetComponent<BoxCollider2D>().enabled = false;
        hc.desactivar();
        cd.setUltimaVez(Time.time);
    }

    void FixedUpdate ()
    {
		if(estado && cd.tiempoCompletado())
        {
            activar();    
        }
	}
}
