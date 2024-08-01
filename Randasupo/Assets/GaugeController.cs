using UnityEngine;

public class GameController : MonoBehaviour
{
    public PlayerMovement playerMovement; // SampleScene内のPlayerMovement

    void Start()
    {
        ResetPlayerPrefs(); // スコアのリセットを行う

        if (playerMovement == null)
        {
            Debug.LogWarning("PlayerMovement is not assigned!");
        }
        else
        {
            playerMovement.ResetPlayer(); // ゲーム開始時にプレイヤーの位置をリセット
            int savedSteps = PlayerPrefs.GetInt("TotalScore", 0); // 保存されたスコアを取得
            playerMovement.MovePlayer(savedSteps); // スコアに基づいてプレイヤーを移動
        }
    }

    void ResetPlayerPrefs()
    {
        PlayerPrefs.SetInt("TotalScore", 0); // スコアをリセット
        PlayerPrefs.Save(); // リセット内容を保存
        Debug.Log("PlayerPrefs (TotalScore) has been reset."); // デバッグログ追加
    }
}
