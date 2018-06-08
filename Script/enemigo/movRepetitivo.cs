using UnityEngine;

public class movRepetitivo : MonoBehaviour
{
    private Transform[] posicion;
    private string haciaDonde;
    private float error;
    private int vel;
    private bool movimientoY;

    private void Awake()
    {
        posicion = new Transform[2];

        posicion[0] = GameObject.Find(transform.parent.name + "/puntos/a").transform;
        posicion[1] = GameObject.Find(transform.parent.name + "/puntos/b").transform;
    }

    void Start ()
    {
        vel = 3;
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        haciaDonde = "ida";
        error = 0.1f;

        calcularQueTipoMovimiento();
	}

    private void calcularQueTipoMovimiento()
    {        
        if (Mathf.Abs(posicion[0].transform.position.y - posicion[1].transform.position.y) > error)
            movimientoY = true;
        else
            movimientoY = false;
    }

    private void direccion()
    {
        if(movimientoY)
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
        else
        {
            if (haciaDonde == "ida")
            {
                if (posicion[0].transform.position.x < posicion[1].transform.position.x)
                    movimiento(vel);
                else
                    movimiento(-vel);
            }
            else
            {
                if (posicion[1].transform.position.x > posicion[0].transform.position.x)
                    movimiento(-vel);
                else
                    movimiento(vel);
            }
        }
        
    }

    private void movimiento(int v)
    {
        if(movimientoY)
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, v);
        else
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(v, 0);
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
