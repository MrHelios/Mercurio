using UnityEngine;
using UnityEngine.UI;

public class controladorVidaUI : MonoBehaviour
{
    private string direccion;
    private GameObject panelvida;
	
	void Start ()
    {
        direccion = "Canvas/Vida/Panel";
        panelvida = GameObject.Find(direccion);
	}

    public void armar(int v)
    {
        GameObject go = panelvida.transform.GetChild(0).gameObject;
        for(int i=1; i<v; i++)
        {
            GameObject nuevo = Instantiate(go);
            nuevo.transform.SetParent(panelvida.gameObject.transform);
            nuevo.transform.position = new Vector2(go.transform.position.x + 30*i, go.transform.position.y);
        }
    }

    public void ganarVida(int i)
    {
        
        panelvida.transform.GetChild(i).GetComponent<Image>().enabled = true;
    }

    public void perderVida(int i)
    {
        if (i >= 0)
            panelvida.transform.GetChild(i).GetComponent<Image>().enabled = false;
    }
    
}
