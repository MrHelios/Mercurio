﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class nuevaEscena : MonoBehaviour
{
    private string nombrePartida;
    public int scene;

    void Start()
    {
        nombrePartida = transform.parent.gameObject.name;    
    }

    public void loadScene()
    {
        SceneManager.LoadScene(scene);
    }

    public void loadSaveGame()
    {
        archivoPartidas ap = new archivoPartidas();

        GameObject go = new GameObject();
        go.name = "Config";
        go.AddComponent<conservarGameObject>();
        go.GetComponent<conservarGameObject>().setFile(nombrePartida);
        string n = go.GetComponent<conservarGameObject>().getFile();

        SceneManager.LoadScene(ap.cargar(n));
    }

    public void reiniciarPartida()
    {
        archivoPartidas ap = new archivoPartidas();
        ap.vaciarPartida(nombrePartida);
    }

}
