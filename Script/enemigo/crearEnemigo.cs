using UnityEngine;

public class crearEnemigo : MonoBehaviour
{
    private bool crear;    

    private void Start()
    {
        crear = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && crear)
        {            
            if (GetComponent<destruir>() != null)
            {
                GetComponent<destruir>().enabled = true;
                for(int i=0; i<transform.childCount; i++)
                {
                    transform.GetChild(i).gameObject.SetActive(true);
                }
            }
            else
                Debug.Log(transform.name + ": No tiene la componente destruir.");
            crear = false;
        }
    }

}
