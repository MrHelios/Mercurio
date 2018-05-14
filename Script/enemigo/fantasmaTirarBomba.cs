using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fantasmaTirarBomba : MonoBehaviour
{
    public GameObject bomba;    
    private cooldown cd;

	void Start ()
    {
        cd = new cooldown();
        cd.setCooldown(2f);
        cd.setUltimaVez(0f);
	}

    private void efecto()
    {
        GameObject nuevo = Instantiate(bomba);

        nuevo.transform.position = transform.position;
        nuevo.SetActive(true);
        nuevo.GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<enemMovimiento>().getVelocidad().x, 0);
        nuevo.GetComponent<Rigidbody2D>().gravityScale = 2;
        nuevo.GetComponent<destruir>().enabled = true;

        cd.setUltimaVez(Time.time);
    }
	
	void FixedUpdate ()
    {
        if (cd.tiempoCompletado())
            efecto();
	}
}
