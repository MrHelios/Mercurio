using UnityEngine;

public class teletransportar : MonoBehaviour
{
    public GameObject ubicacion;
    public GameObject camara;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.transform.position = ubicacion.transform.position;
            camara.SetActive(true);

            GameObject.Find("Camera").SetActive(false);
        }
    }


}
