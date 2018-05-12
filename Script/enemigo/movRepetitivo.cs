using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movRepetitivo : MonoBehaviour
{
    public Transform[] posicion;
    private string haciaDonde;
    private float error;
    private int vel;    

    void Start ()
    {
        vel = 3;
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        haciaDonde = "ida";        
        error = 0.1f;
	}

    private void direccion()
    {
        if (haciaDonde == "ida")
        {
            if (posicion[0].transform.position.y < posicion[1].transform.position.y)
                movimiento(vel);
            else
                movimiento(-vel);
        }
        else
        {
            if (posicion[1].transform.position.y > posicion[0].transform.position.y)
                movimiento(-vel);
            else
                movimiento(vel);
        }
    }

    private void movimiento(int v)
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, v);
    }

    public Vector2 getVelocidad()
    {
        return gameObject.GetComponent<Rigidbody2D>().velocity;
    }
	
	void FixedUpdate ()
    {        
        float valor;
        if(haciaDonde.Equals("ida") && gameObject.GetComponent<Rigidbody2D>().velocity != Vector2.zero)
        {
            valor = Vector3.SqrMagnitude(transform.position - posicion[1].transform.position);            
            if (error > valor)
            {                
                haciaDonde = "vuelta";
                direccion();
            }
        }
        else if(gameObject.GetComponent<Rigidbody2D>().velocity != Vector2.zero)
        {
            valor = Vector3.SqrMagnitude(transform.position - posicion[0].transform.position);
            if (error > valor)
            {                
                haciaDonde = "ida";
                direccion();
            }
        }
        else
        {
            direccion();
        }
	}
}
