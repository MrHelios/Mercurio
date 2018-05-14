using UnityEngine;
using UnityEngine.SceneManagement;

public class reiniciarEscena : MonoBehaviour
{
    private int scene;
    private cooldown cd;
	
	void Start ()
    {
        cd = new cooldown();
        cd.setCooldown(2f);
        cd.setUltimaVez(Time.time);

        scene = SceneManager.GetActiveScene().buildIndex;
	}

    public void setEscena(int i)
    {
        scene = i;
    }

    private void loadScene()
    {
        SceneManager.LoadScene(scene);
    }

    void Update ()
    {
        if (cd.tiempoCompletado())
            loadScene();
	}
}
