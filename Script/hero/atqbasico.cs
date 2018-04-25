using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atqbasico : MonoBehaviour
{
    public GameObject disp;
    private int velocidad;
    private bool disparar;
    private float ultimaVez, cooldown;

    void Start()
    {
        disparar = false;
        ultimaVez = -99f;
        cooldown = 0.2f;
        velocidad = 20;
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
        if (disparar && Time.time > ultimaVez + cooldown)
            crearAtq();
    }

}
