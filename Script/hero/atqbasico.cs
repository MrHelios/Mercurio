using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atqbasico : MonoBehaviour
{
    public GameObject disp;
    private int velocidad;
    private bool disparar;
    private cooldown cd;

    void Start()
    {
        disparar = false;
        velocidad = 20;
        cd = new cooldown();
        cd.setUltimaVez(-99f);
        cd.setCooldown(0.2f);
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
        nuevo.transform.position = new Vector3(v.x, v.y-1, v.z);
        nuevo.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
        nuevo.GetComponent<Collider2D>().enabled = true;
        string m = GetComponent<mov>().getMirada();
        if(m.Equals("derecha"))
            nuevo.GetComponent<Rigidbody2D>().velocity = new Vector2(velocidad, 0);
        else
            nuevo.GetComponent<Rigidbody2D>().velocity = new Vector2(-velocidad, 0);

        disparar = false;
    }

    private void FixedUpdate()
    {
        if (disparar && cd.tiempoCompletado())
            crearAtq();
    }

}
