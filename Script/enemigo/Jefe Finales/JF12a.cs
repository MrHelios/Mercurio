using UnityEngine;

public class JF12a : MonoBehaviour
{
    private cooldown cd;    
    private float tiempo;
    private int cooldown, posicion;

    public GameObject[] enem;
    public GameObject[] objetos;

    void Start()
    {
        posicion = 0;
        cooldown = 5;

        cd = new cooldown();
        cd.setCooldown(cooldown);
        cd.setUltimaVez(-99f);

        activarZona();
    }    

    private void activarZona()
    {
        tiempo = Time.time + 20f;        
    }

    private void desactivarZona()
    {
        for(int i=0; i<objetos.Length; i++)
        {
            objetos[i].SetActive(true);
        }
        Destroy(gameObject);
    }

    public void efecto()
    {        
        GameObject nuevo = Instantiate(enem[posicion % enem.Length]);
        nuevo.SetActive(true);
        nuevo.AddComponent<destruir>();

        posicion++;
    }

    void FixedUpdate()
    {
        if (cd.tiempoCompletado())
        {
            efecto();
            cd.setUltimaVez(Time.time);
        }
        else if (Time.time > tiempo)
        {
            desactivarZona();
        }
    }
}
