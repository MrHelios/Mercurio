using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class municionContraEnemigo : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag.Equals("Enemy"))
        {
            desarmar();
            collision.gameObject.GetComponent<enemigo>().pierdeVida();
        }
        else if(collision.transform.name.Equals("piso"))
        {
            desarmar();
        }
    }

    private void desarmar()
    {
        gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 0f;
        gameObject.GetComponent<Animator>().SetTrigger("exp");
        gameObject.GetComponent<destruir>().activar();
    }

}
