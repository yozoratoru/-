using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public static BoardManager Instance;
    public Transform[] gameBoardSpaces; // マスの配列
    public GameObject player;           // プレイヤーオブジェクト

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
        if (position >= 0 && position < gameBoardSpaces.Length)
        {
            player.transform.position = gameBoardSpaces[position].position;
        }
        else
        {
            Debug.LogError("Invalid position: " + position);
        }
    }
}
