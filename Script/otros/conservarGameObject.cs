using UnityEngine;

public class conservarGameObject : MonoBehaviour
{
    protected static bool creado = false;
    protected string file;

    void Awake()
    {
        if (!creado)
        {
            DontDestroyOnLoad(gameObject.transform);
            creado = true;
        }
        else
            Destroy(this.gameObject);
    }


    public void setFile(string s)
    {
        file = s;
    }

    public string getFile()
    {
        return file;
    }
}
