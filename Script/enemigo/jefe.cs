using UnityEngine;

public class jefe : enemigo
{
    public destruir removerJefe;
    public GameObject[] objeto;

	void Start ()
    {
        transform.tag = "Enemy";
        vidaEnemigo = new vida(3);
	}

    public new void pierdeVida()
    {        
        vidaEnemigo.pierdeVida();
        if (vidaEnemigo.estaMuerto())
        {
            //gameObject.SetActive(false);
            efectoMuerte();
            if(removerJefe != null)
            {
                if(GetComponent<desaparicionColision>() != null)
                    GetComponent<desaparicionColision>().enabled = false;
                if(transform.parent.gameObject.GetComponent<habilidad>() != null)
                    transform.parent.gameObject.GetComponent<habilidad>().enabled = false;
                /*
                removerJefe.enabled = true;
                removerJefe.activar();
                */
            }
        }
    }

    private void efectoMuerte()
    {
        transform.parent.gameObject.GetComponent<Animator>().SetTrigger("muerte");

        for (int i = 0; i < objeto.Length; i++)
            if (objeto[i] != null)
                objeto[i].SetActive(true);
    }    
	
}
