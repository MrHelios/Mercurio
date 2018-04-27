using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mov : MonoBehaviour
{
    private float vel;
    private Animator anim;
    private bool agacharse;
    private string mirada;
    private cooldown cd, sin_apretar_tecla_mov;
	
	void Start ()
    {
        anim = GetComponent<Animator>();
        agacharse = false;
        vel = 4f;
        mirada = "derecha";

        cd = new cooldown();
        cd.setUltimaVez(-99f);
        cd.setCooldown(0.2f);

        sin_apretar_tecla_mov = new cooldown();
        sin_apretar_tecla_mov.setUltimaVez(0);
        sin_apretar_tecla_mov.setCooldown(0.05f);
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

        if (Input.GetAxis("Fire1") > 0 && cd.tiempoCompletado())
        {
            anim.SetBool("movimiento", false);
            anim.SetBool("agacharse", false);
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, v.y);
            GetComponent<atqbasico>().activar();
            anim.SetTrigger("atq_basico");
            cd.setUltimaVez(Time.time);
        }
        else if (Input.GetKey(KeyCode.Alpha1) && cd.tiempoCompletado())
        {
            anim.SetBool("movimiento", false);
            anim.SetBool("agacharse", false);
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, v.y);
            GetComponent<atqbomba>().activar();
            anim.SetTrigger("atq_bomba");
            cd.setUltimaVez(Time.time);
        }
        else
        {
            if (Mathf.Abs(velX) > 0.1f && !agacharse && cd.tiempoCompletado())
            {
                sin_apretar_tecla_mov.setUltimaVez(Time.time);
                GetComponent<Rigidbody2D>().velocity = new Vector2(velX * vel, v.y);
                if (velX > 0)
                {                    
                    mirada = "derecha";                    
                    GetComponent<Transform>().localScale = new Vector3(1, 1, 1);
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
                if(sin_apretar_tecla_mov.tiempoCompletado())
                {
                    GetComponent<Rigidbody2D>().velocity = new Vector2(0, v.y);
                    anim.SetBool("movimiento", false);
                }

                if (velY < 0f && cd.tiempoCompletado())
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
