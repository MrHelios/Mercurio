using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento : MonoBehaviour
{
    private float vel;
    private Animator anim;    
    private string mirada;
    private cooldown cd, sin_apretar_tecla_mov;

    void Awake()
    {
        cd = new cooldown();
        cd.setUltimaVez(-99f);
        cd.setCooldown(0.2f);
    }

    void Start ()
    {
        anim = GetComponent<Animator>();        
        vel = 4f;        

        sin_apretar_tecla_mov = new cooldown();
        sin_apretar_tecla_mov.setUltimaVez(0);
        sin_apretar_tecla_mov.setCooldown(0.05f);
    }

    public cooldown getCooldown()
    {
        return cd;
    }

    public void activar()
    {
        anim.SetBool("movimiento", true);
    }

    public void desactivar()
    {
        anim.SetBool("movimiento", false);
    }
	
	void FixedUpdate ()
    {
        float velX = Input.GetAxis("Horizontal");        
        Vector2 v = GetComponent<Rigidbody2D>().velocity;
        
        if (Mathf.Abs(velX) > 0.1f && !anim.GetBool("agacharse") && cd.tiempoCompletado())
        {
            cd.setCooldown(0.2f);
            sin_apretar_tecla_mov.setUltimaVez(Time.time);
            GetComponent<Rigidbody2D>().velocity = new Vector2(velX * vel, v.y);

            if (velX > 0)
            {
                GetComponent<mov>().setMirada("derecha");
                GetComponent<Transform>().localScale = new Vector3(1, 1, 1);
            }
            else
            {
                GetComponent<mov>().setMirada("izquierda");
                GetComponent<Transform>().localScale = new Vector3(-1, 1, 1);
            }
            activar();
        }        
        else if(sin_apretar_tecla_mov.tiempoCompletado())
        {            
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, v.y);
            desactivar();
        }            
    }
}
