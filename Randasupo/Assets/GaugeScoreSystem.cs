using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GaugeScoreSystem : MonoBehaviour
{
    public Slider gaugeSlider; // ゲージのスライダー
    public Text scoreText; // スコアを表示するためのUIテキスト

    public int totalScore = 0;
    private int attempts = 0;
    private const int maxAttempts = 3;
    private bool isIncreasing = true;
    private bool isStopped = false;

    void Start()
    {
        ResetGauge();
    }

    void Update()
    {
        if (attempts < maxAttempts)
        {
            if (Input.GetKeyDown(KeyCode.Space) && !isStopped)
            {
                StopGaugeAndCalculateScore();
            }

            if (!isStopped)
            {
                MoveGauge();
            }
        }
        else
        {
            if (scoreText != null)
            {
                scoreText.text = "Total Score: " + totalScore; // 最終スコアを表示
            }
            else
            {
                Debug.LogWarning("scoreText is not assigned!");
            }
            Invoke("SaveScoreAndChangeScene", 1.0f); // スコア保存とシーン移動を遅延実行
        }
    }

    void MoveGauge()
    {
        if (isIncreasing)
        {
            gaugeSlider.value += Time.deltaTime * 0.5f;
            if (gaugeSlider.value >= gaugeSlider.maxValue)
            {
                isIncreasing = false;
            }
        }
        else
        {
            gaugeSlider.value -= Time.deltaTime * 0.5f;
            if (gaugeSlider.value <= gaugeSlider.minValue)
            {
                isIncreasing = true;
            }
        }
    }

    void StopGaugeAndCalculateScore()
    {
        isStopped = true;
        float gaugeValue = gaugeSlider.value;
        int score = 0;

        if (gaugeValue > 0.9f)
        {
            score = 4;
            Debug.Log("Perfect! Score: " + score);
        }
        else if (gaugeValue > 0.6f)
        {
            score = 2;
            Debug.Log("Great! Score: " + score);
        }
        else if (gaugeValue > 0.3f)
        {
            score = 1;
            Debug.Log("Good! Score: " + score);
        }
        else
        {
            Debug.Log("Miss! Score: " + score);
        }

        totalScore += score;
        attempts++;

        if (attempts < maxAttempts)
        {
            Invoke("ResetGauge", 1.0f);
        }
    }

    void ResetGauge()
    {
        gaugeSlider.value = 0f;
        isIncreasing = true;
        isStopped = false;
    }

    void SaveScoreAndChangeScene()
    {
        PlayerPrefs.SetInt("TotalScore", totalScore); // スコアを保存
        PlayerPrefs.Save(); // データを保存
        SceneManager.LoadScene("SampleScene"); // SampleSceneに移動
    }
}
