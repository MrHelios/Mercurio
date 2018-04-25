using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectarPiso : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.name.Equals("piso"))
        {
            transform.parent.GetComponent<salto>().activar();
        }
    }

}
