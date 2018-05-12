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
        haciaDonde = "ida";
        movimiento(vel);
        error = 0.1f;
	}

    private void movimiento(int v)
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, v);
    }
	
	void FixedUpdate ()
    {        
        float valor;
        if(haciaDonde.Equals("ida") && gameObject.GetComponent<Rigidbody2D>().velocity != Vector2.zero)
        {
            valor = Vector3.SqrMagnitude(transform.position - posicion[1].transform.position);            
            if (error > valor)
            {
                movimiento(-vel);
                haciaDonde = "vuelta";
            }
        }
        else if(gameObject.GetComponent<Rigidbody2D>().velocity != Vector2.zero)
        {
            valor = Vector3.SqrMagnitude(transform.position - posicion[0].transform.position);
            if (error > valor)
            {
                movimiento(vel);
                haciaDonde = "ida";
            }
        }
        else
        {
            if (haciaDonde == "ida")
                movimiento(vel);
            else
                movimiento(-vel);
        }
	}
}
