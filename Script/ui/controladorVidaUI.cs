using UnityEngine;
using UnityEngine.UI;

public class controladorVidaUI : MonoBehaviour
{
    private string direccion;
    private GameObject panelvida;
    private int[] rojo, celeste;
	
	void Awake ()
    {
        direccion = "Canvas/Vida/Panel";
        panelvida = GameObject.Find(direccion);

        //rojo = [255,25,0];
        rojo = new int[3];
        rojo[0] = 255;
        rojo[1] = 0;
        rojo[2] = 0;

        //celeste = [0,223,255];
        celeste = new int[3];
        celeste[0] = 0;
        celeste[1] = 223;
        celeste[2] = 255;
    }

    void Start()
    {
        pintarRojo();    
    }

    public void pintarCeleste()
    {
        for(int i=0; i<panelvida.transform.childCount; i++)
        {
            panelvida.transform.GetChild(i).GetComponent<Image>().color = new Color(celeste[0], celeste[1], celeste[2]);
        }
    }

    public void pintarRojo()
    {
        for (int i = 0; i < panelvida.transform.childCount; i++)
        {
            panelvida.transform.GetChild(i).GetComponent<Image>().color = new Color(rojo[0], rojo[1], rojo[2]);
        }
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
