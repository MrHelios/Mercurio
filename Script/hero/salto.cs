using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class salto : MonoBehaviour
{
    private bool puedeSaltar;
    private Animator anim;
	
	void Start ()
    {
        anim = GetComponent<Animator>();
        activar();
	}

    public void activar()
    {
        puedeSaltar = true;
        anim.SetBool("en_aire", false);
    }	
	
	void FixedUpdate ()
    {
        if(Input.GetAxis("Submit") > 0 && puedeSaltar)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0,250));
            puedeSaltar = false;
            anim.SetBool("en_aire", true);
        }
		
	}
}
