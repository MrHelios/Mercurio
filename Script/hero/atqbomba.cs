using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atqbomba : MonoBehaviour
{
    public GameObject disp;
    private int velocidad;
    private bool disparar;
    private cooldown cd;    

    void Start()
    {
        disparar = false;
        velocidad = 200;
        cd = new cooldown();
        cd.setUltimaVez(-99f);
        cd.setCooldown(0.3f);        
    }

    public void activar()
    {
        cd.setUltimaVez(Time.time);
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
        if (disparar && cd.tiempoCompletado())
            crearAtq();
    }

}
