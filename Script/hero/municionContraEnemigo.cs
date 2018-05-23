using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class municionContraEnemigo : MonoBehaviour
{
    private bool utilizado;

    private void Start()
    {
        utilizado = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag.Equals("Enemy") && !utilizado)
        {
            bool cortar = false;
            for (int i = 0; i < collision.transform.childCount && !cortar; i++)
            {
                GameObject go = collision.transform.GetChild(i).gameObject;
                if (go.GetComponent<Renderer>() != null && go.GetComponent<Renderer>().isVisible)
                {
                    desarmar();
                    collision.gameObject.GetComponent<enemigo>().pierdeVida();
                    cortar = true;
                }
            }
        }
        else if(collision.transform.name.Equals("piso"))
        {
            desarmar();
        }
        
    }

    private void desarmar()
    {
        utilizado = true;

        gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 0f;
        gameObject.GetComponent<Animator>().SetTrigger("exp");
        gameObject.GetComponent<destruir>().activar();
    }

}
