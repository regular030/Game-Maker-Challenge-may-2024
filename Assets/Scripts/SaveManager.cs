using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveManager : MonoBehaviour
{
    public static void SaveData(SaveData data)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = UnityEngine.Application.persistentDataPath + "/save.dat";
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static SaveData LoadData()
    {
        string path = UnityEngine.Application.persistentDataPath + "/save.dat";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SaveData data = formatter.Deserialize(stream) as SaveData;
            stream.Close();
            return data;
        }
        else
        {
            UnityEngine.Debug.LogWarning("Save file not found in " + path);
            return null;
        }
    }
}
