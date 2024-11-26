using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DiceController : MonoBehaviour
{
    public Sprite[] diceSprites; // サイコロの目のスプライト（1〜6）
    public Image diceImage;      // サイコロを表示するUIイメージ
    private bool isRolling = false; // サイコロが回転中かどうか
    private int currentResult;   // 出目
    private Coroutine rollCoroutine;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 左クリックで操作
        {
            if (!isRolling)
            {
                StartRolling();
            }
            else
            {
                StopRolling();
            }
        }
    }

    private void StartRolling()
    {
        isRolling = true;
        rollCoroutine = StartCoroutine(RollDiceAnimation());
    }

    private void StopRolling()
    {
        if (rollCoroutine != null)
        {
            StopCoroutine(rollCoroutine);
        }
        isRolling = false;

        // 出目を決定（1〜6のランダム）
        currentResult = Random.Range(1, 7);
        diceImage.sprite = diceSprites[currentResult - 1]; // 対応するスプライトを設定
        Debug.Log("サイコロの目: " + currentResult);

        // プレイヤーを進める
        if (BoardManager.Instance != null)
        {
            BoardManager.Instance.MovePlayer(currentResult);
        }
        else
        {
            Debug.LogError("BoardManager.Instance is null.");
        }
    }

    private IEnumerator RollDiceAnimation()
    {
        while (true)
        {
            int randomIndex = Random.Range(0, diceSprites.Length);
            diceImage.sprite = diceSprites[randomIndex];
            yield return new WaitForSeconds(0.1f);
        }
    }
}
