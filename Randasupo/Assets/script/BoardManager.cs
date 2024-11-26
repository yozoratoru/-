using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public static BoardManager Instance;
    public List<GameBoardSpace> gameBoardSpaces;
    public Transform player;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // 保存された位置にプレイヤーを復元
        int savedPosition = DataManager.Instance.saveData.playerPosition;
        if (savedPosition >= 0 && savedPosition < gameBoardSpaces.Count)
        {
            player.position = gameBoardSpaces[savedPosition].spaceTransform.position;
            Debug.Log("プレイヤーの位置を復元しました: " + savedPosition);
        }
    }

    public void MovePlayer(int diceRoll)
    {
        if (gameBoardSpaces == null || gameBoardSpaces.Count == 0)
        {
            Debug.LogError("GameBoardSpaces is not set. Please assign spaces in the Inspector.");
            return;
        }

        int playerPosition = DataManager.Instance.saveData.playerPosition;
        playerPosition += diceRoll;

        if (playerPosition >= gameBoardSpaces.Count)
        {
            playerPosition = gameBoardSpaces.Count - 1; // 最後のマスでストップ
        }

        // プレイヤーを移動
        Transform targetSpace = gameBoardSpaces[playerPosition].spaceTransform;
        player.position = targetSpace.position;

        // 現在位置を保存
        DataManager.Instance.saveData.playerPosition = playerPosition;
        DataManager.Instance.Save();

        Debug.Log("Player moved to space " + playerPosition);
    }
}
