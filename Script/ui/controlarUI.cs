using UnityEngine;

public class controlarUI : MonoBehaviour
{
    public GameObject activar;
    public GameObject desactivar;
	
	void Start ()
    {
        if (activar == null)
            Debug.Log("No hay nada para activar en el controlador.");

        if (desactivar == null)
            Debug.Log("No hay nada para activar en el controlador.");
    }

    public void activarUI()
    {
        activar.SetActive(true);
    }

    public void desactivarUI()
    {
        desactivar.SetActive(false);
    }

    public void efecto()
    {
        activarUI();
        desactivarUI();
    }

}
