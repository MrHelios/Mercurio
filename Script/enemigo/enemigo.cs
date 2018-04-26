using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemigo : MonoBehaviour
{
    private int vida;

	void Start ()
    {
        gameObject.tag = "Enemy";
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
	
}
