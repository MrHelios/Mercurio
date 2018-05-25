using UnityEngine;

public class heroColision : MonoBehaviour
{
    public jefe vidaJefe; 
    private bool activo;

    void Start()
    {
        activo = true;    
    }

    public void activar()
    {
        activo = true;
    }

    public void desactivar()
    {
        activo = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player" && activo)
        {
            if(vidaJefe != null && vidaJefe.estaVivo())
                collision.gameObject.GetComponent<hero>().pierdeVida();
            else if(vidaJefe == null)
                collision.gameObject.GetComponent<hero>().pierdeVida();
        }        
    }

}
