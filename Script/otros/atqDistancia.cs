using UnityEngine;

public abstract class atqDistancia : MonoBehaviour
{
    public GameObject disp;
    protected Animator anim;
    protected string nombre_anim;
    protected int velocidad;
    protected bool disparar;
    // cd: es un cooldown para ejecutar el efecto despues de la animacion.
    // hab_ejec: es un cooldown para ejecutar el poder cada cierto tiempo.
    protected cooldown cd, hab_ejec;

    public void activar()
    {
        anim.SetTrigger(nombre_anim);
        cd.setUltimaVez(Time.time);
        disparar = true;
    }

    public void desactivar()
    {
        disparar = false;
    }

    public cooldown getCooldown()
    {
        return hab_ejec;
    }

    public bool puedeActuar()
    {
        return disparar && cd.tiempoCompletado();
    }

    public abstract void efecto();

}
