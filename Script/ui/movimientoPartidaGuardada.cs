using UnityEngine;
using UnityEngine.UI;

public class movimientoPartidaGuardada : MonoBehaviour
{
    public GameObject act, desac;

    private int posicion, max;
    private float cooldown, ultimaVezUsado;
    private cooldown cd;

    void Start()
    {
        posicion = 0;
        max = transform.childCount;

        activar();

        cd = GameObject.Find("Canvas").GetComponent<cooldownGlobal>().cd;

        if (act == null || desac == null)
            Debug.Log("Los gameobject activos o/y desactivos son nulos.");
    }

    private void desactivar()
    {
        for (int i = 0; i < transform.childCount; i++)
            gameObject.transform.GetChild(i).GetComponent<Image>().enabled = false;
    }

    private void activar()
    {
        gameObject.transform.GetChild(posicion).GetComponent<Image>().enabled = true;
    }

    private void efectoEmpezar()
    {
        transform.GetChild(posicion).gameObject.transform.GetChild(0).gameObject.GetComponent<Button>().onClick.Invoke();
        cd.setUltimaVez(Time.time);
    }

    private void reiniciarPartida()
    {
        Debug.Log("Partida reiniciada.");
        transform.GetChild(posicion).gameObject.transform.GetChild(1).gameObject.GetComponent<Button>().onClick.Invoke();
        cd.setUltimaVez(Time.time);
    }

    private void cerrarPartida()
    {
        act.SetActive(true);
        desac.SetActive(false);
    }

    void FixedUpdate()
    {
        float v = Input.GetAxis("Vertical");
        if (Mathf.Abs(v) > 0 && cd.tiempoCompletado())
        {
            if (v < 0f)
            {
                desactivar();

                posicion++;
                if (posicion == max)
                    posicion = 0;

                activar();
            }
            else
            {
                desactivar();

                posicion--;
                if (posicion == -1)
                    posicion = max - 1;

                activar();
            }
            cd.setUltimaVez(Time.time);
        }


        if (Input.GetAxis("Cancel") > 0 && cd.tiempoCompletado())
            efectoEmpezar();
        else if (Input.GetAxis("Fire2") > 0 && cd.tiempoCompletado())
            reiniciarPartida();
        else if (Input.GetAxis("Fire3") > 0 && cd.tiempoCompletado())
            cerrarPartida();
    }

}
