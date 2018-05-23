using UnityEngine;

public class invisibilidad : habilidad
{
    private bool activo;

	void Awake ()
    {
        activo = false;
	}    

    public override void activar()
    {
        activo = true;
        efecto();
    }

    public override void desactivar()
    {
        activo = false;
        efecto();
    }

    protected override void efecto()
    {
        GetComponent<Animator>().enabled = !activo;
        GetComponent<Collider2D>().enabled = !activo;
        for(int i=0; i<transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<SpriteRenderer>().enabled = !activo;
        }
    }
    
}
