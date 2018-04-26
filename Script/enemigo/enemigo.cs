using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemigo : MonoBehaviour
{
    private int vida, vida_max;

	void Start ()
    {
        gameObject.tag = "Enemy";
        vida_max = 1; 
        vida = 1;
	}

    public void perderVida()
    {
        vida--;
        if(vida == 0)
        {            
            gameObject.SetActive(false);
        }
    }

    public void revivir()
    {
        vida = vida_max;
    }
	
}
