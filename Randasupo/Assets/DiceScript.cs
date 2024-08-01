using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DiceScript : MonoBehaviour
{
    public Sprite[] diceImages; // サイコロの画像を格納する配列
    public Image diceImage; // サイコロのUI Imageコンポーネント
    public PlayerMovement playerMovement; // プレイヤーの移動スクリプトへの参照

    private bool isRolling = false;

    void Start()
    {
        diceImage.sprite = diceImages[0]; // 初期画像を1に設定
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!isRolling)
            {
                StartCoroutine(RollDice());
            }
        }
    }

    IEnumerator RollDice()
    {
        isRolling = true;

        float rollDuration = Random.Range(0.5f, 1.5f); // ランダムな時間
        float elapsed = 0f;

        while (elapsed < rollDuration)
        {
            diceImage.sprite = diceImages[Random.Range(0, diceImages.Length)];
            elapsed += Time.deltaTime;
            yield return null;
        }

        int result = Random.Range(1, 7); // サイコロの目をランダムに決定
        diceImage.sprite = diceImages[result - 1]; // 最終的な画像を設定

        isRolling = false;
        Debug.Log("サイコロの出目: " + result);

        // 1秒待機してからシーンを切り替え
        yield return new WaitForSeconds(1f);

        if (result == 1 || result == 3 || result == 5)
        {
            SceneManager.LoadScene("3danntobi"); // Scene2に移動
        }
        else if (result == 2 || result == 4 || result == 6)
        {
            SceneManager.LoadScene("3danntobi"); // Scene3に移動
        }
    }
}
