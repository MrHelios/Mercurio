using UnityEngine;

public class JF11b : jefeFinalSecuencia
{
    private int contar;
    private cooldown cd;

    private int posicion;
    public GameObject puntos;
	
	void Start ()
    {
        contar = 0;

        posicion = 0;
        cambiarPosicion();

        habilidades = new habilidad[2];
        setHabilidad(0, GetComponent<fantasmaTirarBomba>());
        setHabilidad(1, GetComponent<invisibilidad>());

        getHabilidad(contar).activar();

        cd = new cooldown();
        cd.setCooldown(5f);
        cd.setUltimaVez(Time.time);
    }

    private void cambiarPosicion()
    {
        transform.position = puntos.transform.GetChild(posicion % puntos.transform.childCount).transform.position;
        posicion++;
    }
	
	void FixedUpdate ()
    {
	    if(cd.tiempoCompletado())
        {
            getHabilidad(contar).desactivar();
            if (contar % 2 != 0)
                cambiarPosicion();

            contar++;
            getHabilidad(contar).activar();

            cd.setUltimaVez(Time.time);
        }	
	}
}
