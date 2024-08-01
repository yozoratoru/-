using UnityEngine;
using UnityEngine.UI;

public class ProgressBarManager : MonoBehaviour
{
    public Image progressBar; // プログレスバーの参照
    public float fillAmount; // プログレスバーの値

    void Start()
    {
        UpdateProgressBar();
    }

    public void UpdateProgressBar()
    {
        progressBar.fillAmount = fillAmount;
    }
}
