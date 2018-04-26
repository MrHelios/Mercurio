using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invocarEnem : MonoBehaviour
{
    public GameObject enem;
    private cooldown cd;

	void Start ()
    {
        cd = new cooldown();
        cd.setUltimaVez(-99f);
        cd.setCooldown(30f);
	}	

	void FixedUpdate ()
    {

        if (cd.tiempoCompletado() && !enem.activeSelf)
        {
            cd.setUltimaVez(Time.time);
            enem.SetActive(true);
            enem.GetComponent<enemigo>().revivir();
        }
		
	}
}
