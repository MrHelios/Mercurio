using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mov : MonoBehaviour
{
    private float vel;
    private Animator anim;
    private bool agacharse;
    private float ultimaVez, cooldown;
    private string mirada;
	
	void Start ()
    {
        anim = GetComponent<Animator>();
        agacharse = false;
        vel = 4f;
        ultimaVez = -99f;
        cooldown = 0.35f;
        mirada = "derecha";
	}

    public string getMirada()
    {
        return mirada;
    }
	
	void FixedUpdate ()
    {
        float velX = Input.GetAxis("Horizontal");
        float velY = Input.GetAxis("Vertical");
        Vector2 v = GetComponent<Rigidbody2D>().velocity;

        if (Input.GetAxis("Fire1") > 0 && Time.time > ultimaVez + cooldown)
        {
            anim.SetBool("movimiento", false);
            anim.SetBool("agacharse", false);
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, v.y);
            GetComponent<atqbasico>().activar();
            anim.SetTrigger("atq_basico");
            ultimaVez = Time.time + cooldown;
        }
        else if (Input.GetKey(KeyCode.Alpha1) && Time.time > ultimaVez + cooldown)
        {
            anim.SetBool("movimiento", false);
            anim.SetBool("agacharse", false);
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, v.y);
            GetComponent<atqbomba>().activar();
            anim.SetTrigger("atq_bomba");
            ultimaVez = Time.time + cooldown;
        }
        else
        {
            if (Mathf.Abs(velX) > 0.1f && !agacharse && Time.time > ultimaVez + cooldown)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(velX * vel, v.y);
                if (velX > 0)
                {
                    GetComponent<Transform>().localScale = new Vector3(1, 1, 1);
                    mirada = "derecha";
                }
                else
                {
                    GetComponent<Transform>().localScale = new Vector3(-1, 1, 1);
                    mirada = "izquierda";
                }
                anim.SetBool("movimiento", true);
            }
            else
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, v.y);
                anim.SetBool("movimiento", false);

                if (velY < 0f && Time.time > ultimaVez + cooldown)
                {
                    anim.SetBool("agacharse", true);
                    agacharse = true;
                }
                else
                {
                    anim.SetBool("agacharse", false);
                    agacharse = false;
                }
            }
        }        
	}
}
