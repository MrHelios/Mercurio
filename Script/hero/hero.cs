using UnityEngine;

public class hero : MonoBehaviour
{
    private vida vidaHero;
    private cooldown invulnerabilidad_por_golpe;

    void Start()
    {
        gameObject.tag = "Player";
        vidaHero = new vida(4);

        invulnerabilidad_por_golpe = new cooldown();
        invulnerabilidad_por_golpe.setCooldown(2f);
        invulnerabilidad_por_golpe.setUltimaVez(-99f);
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
                Debug.Log("El heroe ha muerto.");
            }
            invulnerabilidad_por_golpe.setUltimaVez(Time.time);            
        }        
    }

    public void restaurar_vida_max()
    {
        vidaHero.restaurar_maxima_vida();
    }

    public void muerte()
    {
        vidaHero.muerte();
    }

}
