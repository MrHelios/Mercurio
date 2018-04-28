using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class agacharse : MonoBehaviour
{
    private Animator anim;
    private cooldown cd;
    private bool estaAgachado;
    private float velY;
    private string animacion;

	void Start ()
    {
        anim = GetComponent<Animator>();
        animacion = "agacharse";

        estaAgachado = false;

        cd = new cooldown();
        cd.setCooldown(0.2f);
        cd.setUltimaVez(-99f);
	}
	
	void FixedUpdate ()
    {
        float velY = Input.GetAxis("Vertical");

        if (velY < 0f && cd.tiempoCompletado())
        {
            anim.SetBool(animacion, true);
            estaAgachado = true;
        }
        else
        {
            anim.SetBool(animacion, false);
            estaAgachado = false;
        }
    }
}
