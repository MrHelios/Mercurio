using UnityEngine;
using UnityEngine.SceneManagement;

public class teletransportar : MonoBehaviour
{
    public GameObject ubicacion, escenario;
    public GameObject camara;
    public int scene;
    public bool sinClick;
    
    private bool cambiarEscena;
    private GameObject hero;

    private void Start()
    {
        hero = GameObject.Find("hero");

        if (scene == 0)
            cambiarEscena = false;
        else
            cambiarEscena = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {            
            GetComponent<SpriteRenderer>().enabled = true;
            if(sinClick)
            {
                camara.SetActive(true);
                cambiarCamaras();
                cambiarMundo(collision);
            }
            else if(Input.GetAxis("Fire1") > 0)
            {
                camara.SetActive(true);
                cambiarCamaras();
                cambiarMundo(collision);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    private void cambiarMundo(Collider2D collision)
    {
        if(!cambiarEscena)
        {
            if (ubicacion.transform.parent.name != "escenario" && !ubicacion.transform.parent.gameObject.activeSelf)
            {                
                ubicacion.transform.parent.gameObject.SetActive(true);
            }
            else if (ubicacion.transform.parent.name == "escenario")
            {                
                if (GameObject.Find("esc_secret_1") != null)
                    GameObject.Find("esc_secret_1").SetActive(false);
                if (GameObject.Find("esc_secret_2") != null)
                    GameObject.Find("esc_secret_2").SetActive(false);
            }

            hero.transform.position = ubicacion.transform.position;
        }
        else
        {
            SceneManager.LoadScene(scene);
        }
    }

    private void cambiarCamaras()
    {
        GameObject go = GameObject.Find("Camaras");
        for (int i = 0; go.transform.childCount > i; i++)
            if(camara != go.transform.GetChild(i).gameObject)
                go.transform.GetChild(i).gameObject.SetActive(false);
    }

}
