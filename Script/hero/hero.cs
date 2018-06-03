using UnityEngine;

public class hero : MonoBehaviour
{
    private int vida_max;

    private vida vidaHero;
    private cooldown invulnerabilidad_por_golpe;
    private controladorVidaUI ui_vida;
    private bool invulnerable;

    private GameObject escenario;

    private void Awake()
    {
        ubicarHeroe();

        vida_max = 4;
        gameObject.tag = "Player";
        vidaHero = new vida(vida_max);

        invulnerable = false;
    }

    private void ubicarHeroe()
    {
        escenario = GameObject.Find("escenario");
        if (escenario != null)
        {
            escenario.SetActive(true);
            GameObject respawn = GameObject.Find("escenario/respawn");
            if (respawn != null)
                transform.position = respawn.transform.position;
            else
                transform.position = escenario.transform.position;
        }
        else
        {
            transform.position = Vector3.zero;
        }
    }

    private void revisarCanvas()
    {
        if (GameObject.Find("Canvas") != null)
        {
            ui_vida = GameObject.Find("Canvas").gameObject.GetComponent<controladorVidaUI>();
            armarVidaUI();
        }
    }

    void Start()
    {
        revisarCanvas();

        invulnerabilidad_por_golpe = new cooldown();
        invulnerabilidad_por_golpe.setCooldown(2f);
        invulnerabilidad_por_golpe.setUltimaVez(-99f);        
    }

    private void armarVidaUI()
    {
        ui_vida.armar(vida_max);
    }

    private void reiniciarEscenaUI()
    {
        if(GameObject.Find("Canvas") != null)
            GameObject.Find("Canvas").gameObject.GetComponent<reiniciarEscena>().enabled = true;
    }

    private void efectosMuerte()
    {
        GetComponent<mov2>().enabled = false;

        habilidad[] h = GetComponents<habilidad>();
        for (int i = 0; h.Length > i; i++)
            h[i].enabled = false;

        atqDistancia[] a = GetComponents<atqDistancia>();
        for (int i = 0; a.Length > i; i++)
            a[i].enabled = false;

        Vector2 v = GetComponent<Rigidbody2D>().velocity;
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, v.y);

        GetComponent<mov2>().animacionMuerte();
        reiniciarEscenaUI();
    }

    public vida getVida()
    {
        return vidaHero;
    }

    public void pierdeVida()
    {
        if(invulnerabilidad_por_golpe.tiempoCompletado() && !invulnerable)
        {
            vidaHero.pierdeVida();
            if (vidaHero.estaMuerto())
            {
                muerte();
            }
            invulnerabilidad_por_golpe.setUltimaVez(Time.time);
            ui_vida.perderVida(vidaHero.getVidaAct());
        }
        else if(invulnerable)
        {
            invulnerabilidad_por_golpe.setUltimaVez(Time.time);
            desactivarInvulnerable();
        }
    }

    public void ganaVida()
    {
        vidaHero.ganaVida();
        ui_vida.ganarVida(vidaHero.getVidaAct() - 1);
    }

    public void activarInvulnerable()
    {
        invulnerable = true;
        ui_vida.pintarCeleste();
    }

    public void desactivarInvulnerable()
    {
        invulnerable = false;
        ui_vida.pintarRojo();
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
