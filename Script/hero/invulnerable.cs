using UnityEngine;

public class invulnerable : habilidad
{
    private int cant;    
    private bool estado;
	
	void Start ()
    {
        estado = true;        
        cant = 0;
	}

    protected override void efecto()
    {
        if(estado)
        {
            cant++;
            if (cant == 2)
            {
                GetComponent<hero>().activarInvulnerable();
                cant = 0;
            }
        }
    }

    public void aumentarCantidad()
    {
        efecto();
    }

    public override void activar()
    {
        estado = true;
    }

    public override void desactivar()
    {
        estado = false;
    }


}
