using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static void SaveData(SaveData data)
    {
        PlayerPrefs.SetString("SaveData", JsonUtility.ToJson(data));
        PlayerPrefs.Save();
        Debug.Log("Saving data");
    }

    public static SaveData LoadData()
    {
        if (PlayerPrefs.HasKey("SaveData"))
        {
            string json = PlayerPrefs.GetString("SaveData");
            return JsonUtility.FromJson<SaveData>(json);
        }
        else
        {
            Debug.LogWarning("Save data not found");
            return null;
        }
    }
}
