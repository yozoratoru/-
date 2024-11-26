using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public SaveData saveData;
    private string filePath;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        filePath = Application.persistentDataPath + "/SaveData.json";

        Load(); // 起動時にデータを読み込む
    }

    public void Save()
    {
        string json = JsonUtility.ToJson(saveData, true);
        File.WriteAllText(filePath, json);
        Debug.Log("データを保存しました: " + filePath);
    }

    public void Load()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            saveData = JsonUtility.FromJson<SaveData>(json);
            Debug.Log("データを読み込みました: " + filePath);
        }
        else
        {
            saveData = new SaveData(); // データがない場合は初期化
            Debug.Log("新しいデータを作成しました。");
        }
    }
}
