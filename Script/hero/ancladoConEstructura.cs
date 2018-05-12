using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ancladoConEstructura : MonoBehaviour
{

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log(collision.gameObject.GetComponent<Rigidbody2D>().velocity);
            Vector2 v = collision.gameObject.GetComponent<Rigidbody2D>().velocity;
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(v.x, GetComponent<movRepetitivo>().getVelocidad().y);
        }
    }
}
