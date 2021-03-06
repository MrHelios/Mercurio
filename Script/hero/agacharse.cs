﻿using UnityEngine;

public class agacharse : habilidad
{    
    private float velY;
    private bool estaAgachado;
    private BoxCollider2D parado, agachado;

	void Start ()
    {
        parado = GameObject.Find("hero/cuerpo/parado").GetComponent<BoxCollider2D>();
        agachado = GameObject.Find("hero/cuerpo/agacharse").GetComponent<BoxCollider2D>();

        anim = GetComponent<Animator>();
        estaAgachado = false;
        estado_anim = "agacharse";

        cd = new cooldown();
        cd.setCooldown(0.2f);
        cd.setUltimaVez(-99f);
    }

    private void activarColliderParado()
    {
        parado.enabled = true;
        agachado.enabled = false;
    }

    private void activarColliderAgachado()
    {
        parado.enabled = false;
        agachado.enabled = true;
    }

    private bool chequearSiEstaSaltando()
    {
        if (GetComponent<mov2>() == null)
            return false;
        return GetComponent<mov2>().getEstaSaltando();
    }

    public bool getEstaAgachado()
    {
        return estaAgachado;
    }

    public override void activar()
    {
        estaAgachado = true;
        anim.SetBool(estado_anim, true);
        activarColliderAgachado();
    }

    public override void desactivar()
    {
        estaAgachado = false;
        anim.SetBool(estado_anim, false);
        activarColliderParado();
    }

    protected override void efecto()
    {
        float velY = Input.GetAxis("Vertical");

        if (velY < 0f && cd.tiempoCompletado() && !chequearSiEstaSaltando())
            activar();
        else
            desactivar();
    }

    void FixedUpdate ()
    {
        efecto();
    }
}
