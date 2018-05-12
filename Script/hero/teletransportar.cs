using UnityEngine;

public class teletransportar : MonoBehaviour
{
    public GameObject ubicacion;
    public GameObject camara;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            camara.SetActive(true);
            cambiarCamaras();
            cambiarMundo(collision);
        }
    }

    private void cambiarMundo(Collider2D collision)
    {        
        if (ubicacion.transform.parent.name != "escenario" && !ubicacion.transform.parent.gameObject.activeSelf)
        {
            ubicacion.transform.parent.gameObject.SetActive(true);
        }
        else if(ubicacion.transform.parent.name == "escenario")
        {            
            if (GameObject.Find("esc_secret_1") != null)
                GameObject.Find("esc_secret_1").SetActive(false);
            if (GameObject.Find("esc_secret_2") != null)
                GameObject.Find("esc_secret_2").SetActive(false);
        }

        collision.transform.position = ubicacion.transform.position;
    }

    private void cambiarCamaras()
    {
        GameObject go = GameObject.Find("Camaras");
        for (int i = 0; go.transform.childCount > i; i++)
            if(camara != go.transform.GetChild(i).gameObject)
                go.transform.GetChild(i).gameObject.SetActive(false);
    }


}
