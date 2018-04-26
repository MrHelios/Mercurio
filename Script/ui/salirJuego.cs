using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class salirJuego : MonoBehaviour
{

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

}
