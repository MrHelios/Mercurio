using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nuevaEscena : MonoBehaviour
{
    public int scene;

    public void loadScene()
    {
        SceneManager.LoadScene(scene);
    }

}
