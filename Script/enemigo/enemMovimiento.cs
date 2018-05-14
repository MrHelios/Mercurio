using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemMovimiento : MonoBehaviour
{
    private Vector2 velocidad;
    private Animator anim;
    private string mirada;

	void Start ()
    {
        mirada = "derecha";
        setMovimiento();
	}

    public void setMirada(string m)
    {
        mirada = m;
        setMovimiento();
    }

    public string getMirada()
    {
        return mirada;
    }

    public Vector2 getVelocidad()
    {
        return GetComponent<Rigidbody2D>().velocity;
    }

    public void setMovimiento()
    {
        if(mirada.Equals("derecha"))
        {            
            transform.localScale = new Vector3(-0.85f, 0.85f, 1);

            velocidad = new Vector2(2, 0);
            anim = GetComponent<Animator>();

            GetComponent<Rigidbody2D>().velocity = velocidad;
            setAnimMovimiento(true);
        }
        else
        {
            transform.localScale = new Vector3(0.85f, 0.85f, 1);

            velocidad = new Vector2(-2, 0);
            anim = GetComponent<Animator>();

            GetComponent<Rigidbody2D>().velocity = velocidad;
            setAnimMovimiento(true);
        }        
    }

    public void setAnimMovimiento(bool e)
    {
        anim.SetBool("movimiento", e);
    }

	
}
