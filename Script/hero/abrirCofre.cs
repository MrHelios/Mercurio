using UnityEngine;

public class abrirCofre : MonoBehaviour
{
    private bool estado;

    void Start()
    {
        estado = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && Input.GetAxis("Fire4") > 0 && !estado)
        {
            estado = true;
            transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;
            transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().enabled = true;
            GetComponent<destruir>().enabled = true;
        }
    }

}