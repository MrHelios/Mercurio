using UnityEngine;

public abstract class habilidad : MonoBehaviour
{
    protected Animator anim;
    protected cooldown cd;
    protected string estado_anim;

    public cooldown getCooldown()
    {
        return cd;
    }

    public string getNombreAnimacion()
    {
        return estado_anim;
    }

    public abstract void activar();

    public abstract void desactivar();

    protected abstract void efecto();
	
}
