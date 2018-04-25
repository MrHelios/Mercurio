using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atqbomba : MonoBehaviour
{
    public GameObject disp;

    private int velocidad;
    private bool disparar;
    private float ultimaVez, cooldown;

    void Start()
    {
        disparar = false;
        ultimaVez = -99f;
        cooldown = 0.3f;
        velocidad = 200;
    }

    public void activar()
    {
        ultimaVez = Time.time;
        disparar = true;
    }

    private void crearAtq()
    {
        GameObject nuevo = Instantiate(disp);

        Vector3 v = disp.transform.parent.transform.position;
        string m = GetComponent<mov>().getMirada();        
        nuevo.transform.position = disp.transform.position;

        if (m.Equals("derecha"))
        {
            nuevo.GetComponent<Rigidbody2D>().AddForce(new Vector2(velocidad, velocidad));
        }
        else
        {
            nuevo.GetComponent<Rigidbody2D>().AddForce(new Vector2(-velocidad, velocidad));            
        }        
        nuevo.GetComponent<SpriteRenderer>().enabled = true;
        disparar = false;
    }

    private void FixedUpdate()
    {
        if (disparar && Time.time > ultimaVez + cooldown)
            crearAtq();
    }

}
