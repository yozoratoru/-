using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public SaveData saveData;    // すごろくのセーブデータ
    public ScoreData scoreData;  // スコアデータ

    private void Awake()
    {
        // Singleton パターン
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // シーンをまたいでも破棄しない
        }
        else
        {
            Destroy(gameObject);
        }

        // データの読み込み
        LoadData();
    }

    // データの読み込み
    public void LoadData()
    {
        // すごろくのセーブデータの読み込み
        string savePath = Application.dataPath + "/saveData.json";  // Application.dataPath に変更
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            saveData = JsonUtility.FromJson<SaveData>(json);
        }
        else
        {
            saveData = new SaveData(); // ファイルがない場合、新しいデータを作成
        }

        // スコアデータの読み込み
        string scorePath = Application.dataPath + "/scoreData.json";  // Application.dataPath に変更
        if (File.Exists(scorePath))
        {
            string json = File.ReadAllText(scorePath);
            scoreData = JsonUtility.FromJson<ScoreData>(json);
        }
        else
        {
            scoreData = new ScoreData(); // ファイルがない場合、新しいデータを作成
        }
    }

    // データの保存
    public void SaveData()
    {
        // すごろくのセーブデータを保存
        string savePath = Application.dataPath + "/saveData.json";  // Application.dataPath に変更
        string saveJson = JsonUtility.ToJson(saveData);
        File.WriteAllText(savePath, saveJson);

        // スコアデータを保存
        string scorePath = Application.dataPath + "/scoreData.json";  // Application.dataPath に変更
        string scoreJson = JsonUtility.ToJson(scoreData);
        File.WriteAllText(scorePath, scoreJson);
    }
}
