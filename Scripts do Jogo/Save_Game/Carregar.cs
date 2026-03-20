using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class Carregar
{
    public static SaveGame Load()
    {
        string path = Application.persistentDataPath + "/labbitJogoSalvo.save";

        if (!File.Exists(path))
            return null;

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(path, FileMode.Open);

        SaveGame save = (SaveGame)bf.Deserialize(file);
        file.Close();

        return save;
    }
}

