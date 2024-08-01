using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public Transform[] squares; // マスを格納する配列
    public float moveSpeed = 5f; // 移動速度
    private int currentSquareIndex = 0;

    void Start()
    {
        if (squares.Length > 0)
        {
            transform.position = squares[currentSquareIndex].position; // 初期位置を設定
        }
    }

    public void MoveToSquare(int score)
    {
        int targetIndex = currentSquareIndex + score; // スコアに基づいてターゲットマスを計算

        if (targetIndex < squares.Length)
        {
            StartCoroutine(MoveToTarget(squares[targetIndex].position));
            currentSquareIndex = targetIndex; // 現在のマスのインデックスを更新
        }
        else
        {
            Debug.LogWarning("Target index out of bounds!");
        }
    }

    private IEnumerator MoveToTarget(Vector3 targetPosition)
    {
        while (Vector3.Distance(transform.position, targetPosition) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPosition;
    }
}
