using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

        // ミニゲームシーンへ移動
        StartMinigame();
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

    private void StartMinigame()
    {
        // サイコロの目をデータとして保存（後でミニゲームの動きに応用可能）
        DataManager.Instance.saveData.diceRollResult = currentResult;

        // ミニゲームシーンに移動
        SceneManager.LoadScene("3danntobi");
    }
}
