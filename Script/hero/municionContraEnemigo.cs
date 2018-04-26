using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class municionContraEnemigo : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag.Equals("Enemy"))
        {
            gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            gameObject.GetComponent<Animator>().SetTrigger("exp");
            gameObject.GetComponent<destruir>().enabled = true;

            collision.gameObject.GetComponent<enemigo>().perderVida();
        }        
    }

}
