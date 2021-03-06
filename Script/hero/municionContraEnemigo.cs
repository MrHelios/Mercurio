﻿using UnityEngine;

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
            if(gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().isVisible)
            {
                desarmar();
                if (collision.gameObject.GetComponent<jefe>() != null)
                    collision.gameObject.GetComponent<jefe>().pierdeVida();
                else
                    collision.gameObject.GetComponent<enemigo>().pierdeVida();
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
