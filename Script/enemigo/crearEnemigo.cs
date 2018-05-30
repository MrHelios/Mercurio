using UnityEngine;

public class crearEnemigo : MonoBehaviour
{
    private bool crear;
    private cooldown cd;

    private void Start()
    {
        crear = true;

        cd = new cooldown();
        cd.setCooldown(2f);
        cd.setUltimaVez(-99f);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player" && cd.tiempoCompletado())
        {
            if (GetComponent<destruir>() != null)
            {
                GetComponent<destruir>().enabled = true;
                activar();
            }
            else
                activar();
            cd.setUltimaVez(Time.time);
        }
    }

    private void activar()
    {
        for (int i = 0; i < transform.childCount; i++)
        {            
            GameObject nuevo = Instantiate(transform.GetChild(i).gameObject);
            if (nuevo != null)
                nuevo.SetActive(true);
            else
                Debug.Log("No se puede activar la nueva instancia " + nuevo.name);
        }
    }

}
