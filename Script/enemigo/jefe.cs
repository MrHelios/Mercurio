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
            gameObject.SetActive(false);
            efectoMuerte();
            if(removerJefe != null)
            {
                removerJefe.enabled = true;
                removerJefe.activar();
            }
        }
    }

    private void efectoMuerte()
    {        
        for (int i = 0; i < objeto.Length; i++)
            if (objeto[i] != null)
                objeto[i].SetActive(true);
    }    
	
}
