using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemMovimiento : MonoBehaviour
{
    private Vector2 velocidad;
    private Animator anim;

	void Start ()
    {
        velocidad = new Vector2(-2, 0);
        anim = GetComponent<Animator>();

        GetComponent<Rigidbody2D>().velocity = velocidad;
        setAnimMovimiento(true);
	}

    public void setAnimMovimiento(bool e)
    {
        anim.SetBool("movimiento", e);
    }

	
}
