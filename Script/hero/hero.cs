using UnityEngine;

public class hero : MonoBehaviour
{
    private int vida_max;

    private vida vidaHero;
    private cooldown invulnerabilidad_por_golpe;
    private controladorVidaUI ui_vida;

    void Start()
    {
        vida_max = 1;
        gameObject.tag = "Player";
        vidaHero = new vida(vida_max);       

        invulnerabilidad_por_golpe = new cooldown();
        invulnerabilidad_por_golpe.setCooldown(2f);
        invulnerabilidad_por_golpe.setUltimaVez(-99f);

        ui_vida = GameObject.Find("Canvas").gameObject.GetComponent<controladorVidaUI>();
        armarVidaUI();
    }

    private void armarVidaUI()
    {
        ui_vida.armar(vida_max);
    }

    private void efectosMuerte()
    {
        habilidad[] h = GetComponents<habilidad>();
        for (int i = 0; h.Length > i; i++)
            h[i].enabled = false;

        atqDistancia[] a = GetComponents<atqDistancia>();
        for (int i = 0; a.Length > i; i++)
            a[i].enabled = false;

        GetComponent<mov>().animacionMuerte();
        GameObject.Find("Canvas").gameObject.GetComponent<reiniciarEscena>().enabled = true;
    }

    public vida getVida()
    {
        return vidaHero;
    }

    public void pierdeVida()
    {
        if(invulnerabilidad_por_golpe.tiempoCompletado())
        {
            vidaHero.pierdeVida();
            if (vidaHero.estaMuerto())
            {
                muerte();
            }
            invulnerabilidad_por_golpe.setUltimaVez(Time.time);
            ui_vida.perderVida(vidaHero.getVidaAct());
        }
    }

    public void restaurar_vida_max()
    {
        vidaHero.restaurar_maxima_vida();
    }

    public void muerte()
    {
        vidaHero.muerte();
        efectosMuerte();
    }

}
