using UnityEngine;

public class detectarPiso : MonoBehaviour
{    

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.name.Equals("piso"))
        {
            if (transform.parent.GetComponent<salto>() != null)
                transform.parent.GetComponent<salto>().activar();
            else
                Debug.Log("No esta la componente salto");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.name.Equals("piso"))
        {
            if (transform.parent.GetComponent<salto>() != null)
                transform.parent.GetComponent<salto>().desactivarPuedeSaltar();
        }
    }

}
