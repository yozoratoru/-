using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MinigameController : MonoBehaviour
{
    public Slider gaugeSlider; // スライダー
    public Text scoreText;     // スコア表示
    private float gaugeSpeed = 1f; // ゲージの増加速度
    private int score = 0;     // 合計スコア
    private int buttonPressCount = 0; // ボタンを押した回数（最大3回）
    private bool isGameRunning = true; // ミニゲーム中かどうか

    private void Start()
    {
        gaugeSlider.value = 0;
        scoreText.text = "Score: 0";
    }

    private void Update()
    {
        if (!isGameRunning) return;

        // ゲージを増加させる
        gaugeSlider.value += gaugeSpeed * Time.deltaTime;

        // ゲージが最大になったらリセット
        if (gaugeSlider.value >= 1f)
        {
            gaugeSlider.value = 0f;
        }

        // 左クリックでゲージを押す
        if (Input.GetMouseButtonDown(0)) // 左クリック
        {
            OnPressGauge();
        }
    }

    private void OnPressGauge()
    {
        buttonPressCount++;
        float gaugeValue = gaugeSlider.value;

        // 判定
        if (gaugeValue >= 0.9f)
        {
            score += 3;
        }
        else if (gaugeValue >= 0.5f)
        {
            score += 2;
        }
        else if (gaugeValue >= 0.3f)
        {
            score += 1;
        }

        // スコア表示を更新
        scoreText.text = "Score: " + score;

        // 3回押したら終了
        if (buttonPressCount >= 3)
        {
            EndMinigame();
        }
    }

    private void EndMinigame()
    {
        isGameRunning = false;

        if (DataManager.Instance == null || DataManager.Instance.scoreData == null)
        {
            Debug.LogError("DataManager or scoreData is null.");
            return;
        }

        // スコアを保存
        DataManager.Instance.scoreData.totalScore += score;
        DataManager.Instance.SaveData(); // スコアを JSON に保存

        Debug.Log("Total Score saved: " + DataManager.Instance.scoreData.totalScore);

        // すごろく画面に戻る
        SceneManager.LoadScene("Samplescene");
    }
}
