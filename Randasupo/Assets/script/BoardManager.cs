using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public static BoardManager Instance; // シングルトンインスタンス
    public GameObject player;            // プレイヤーオブジェクト
    public Transform[] gameBoardSpaces;  // すごろくのマスの配列

    private void Awake()
    {
        // シングルトンインスタンスの設定
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
        // プレイヤーの位置をロード
        int savedPosition = DataManager.Instance.saveData.playerPosition;

        if (savedPosition >= 0 && savedPosition < gameBoardSpaces.Length)
        {
            MovePlayerTo(savedPosition); // 保存された位置に移動
        }
        else
        {
            Debug.LogError("Invalid saved position: " + savedPosition);
        }
    }

    public void MovePlayerTo(int position)
    {
        // プレイヤーを指定された位置に移動
        if (position >= 0 && position < gameBoardSpaces.Length)
        {
            player.transform.position = gameBoardSpaces[position].position;
        }
        else
        {
            Debug.LogError("Invalid position: " + position);
        }
    }

    // プレイヤーを指定されたマス分移動
    public void MovePlayer(int spaces)
    {
        int currentPosition = Mathf.Clamp((int)player.transform.position.x, 0, gameBoardSpaces.Length - 1);
        int newPosition = currentPosition + spaces;

        if (newPosition >= gameBoardSpaces.Length)
        {
            newPosition = gameBoardSpaces.Length - 1; // 最大の位置に制限
        }

        player.transform.position = gameBoardSpaces[newPosition].position; // プレイヤーを指定されたマスに移動
        Debug.Log("Player moved to position: " + newPosition);
    }
}

