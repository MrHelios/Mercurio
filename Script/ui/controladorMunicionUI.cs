using UnityEngine;
using UnityEngine.UI;

public class controladorMunicionUI : MonoBehaviour
{
    private GameObject texto_ui;

    private void Start()
    {
        texto_ui = GameObject.Find("Canvas/Municion/Panel/Text");
        if (texto_ui == null)
            Debug.Log("No hay Texto para las municiones");
    }

    public void cambiarTexto(int i)
    {
        texto_ui.GetComponent<Text>().text = "" + i;
    }	
	
}
