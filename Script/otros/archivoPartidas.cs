using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class archivoPartidas
{
    public void guardar(string nombre, int scene)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(Application.persistentDataPath + nombre, FileMode.Create);

        PlayerData data = new PlayerData(scene);

        bf.Serialize(stream, data);
        stream.Close();
    }
    
    public int cargar(string nombre)
    {
        if (File.Exists(Application.persistentDataPath + nombre))
        {
            Debug.Log(Application.persistentDataPath);
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(Application.persistentDataPath + nombre, FileMode.Open);

            PlayerData data = bf.Deserialize(stream) as PlayerData;

            stream.Close();
            return data.getScene();
        }
        else
            return 1;
    }

    public void vaciarPartida(string nombre)
    {
        guardar(nombre, 1);
    }
}

[Serializable]
public class PlayerData
{    
    private int scene;

    public PlayerData(int s)
    {
        scene = s;
    }

    public int getScene()
    {
        return scene;
    }

}
