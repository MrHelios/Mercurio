using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class habilidadVerOpciones : MonoBehaviour
{
    private GameObject config;
    private bool estado;
    private cooldown cd;    
	
	void Start ()
    {
        config = GameObject.Find("Canvas/Opciones").transform.GetChild(0).gameObject;
        estado = false;
        cd = new cooldown();
        cd.setUltimaVez(-99f);
        cd.setCooldown(0.25f);        
	}

    public void cambiarEstado()
    {
        estado = !estado;
        config.SetActive(estado);
        cd.setUltimaVez(Time.time);
    }
	
	void FixedUpdate ()
    {
        if (cd.tiempoCompletado() && Input.GetAxis("Cancel") > 0)
            cambiarEstado();
	}
}
