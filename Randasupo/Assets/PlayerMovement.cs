using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform[] boardSpaces; // すごろくのマスを格納する配列
    public float moveSpeed = 2.0f; // プレイヤーの移動速度

    private int currentPosition = 0;

    public void MovePlayer(int steps)
    {
        Debug.Log("MovePlayer called with steps: " + steps); // デバッグログ追加
        StartCoroutine(Move(steps));
    }

    IEnumerator Move(int steps)
    {
        int targetPosition = currentPosition + steps;
        targetPosition = Mathf.Clamp(targetPosition, 0, boardSpaces.Length - 1); // 範囲を制限
        Debug.Log("Moving from " + currentPosition + " to " + targetPosition); // デバッグログ追加

        while (currentPosition != targetPosition)
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = boardSpaces[currentPosition + 1].position;
            float journey = 0f;

            while (journey < 1f)
            {
                journey += Time.deltaTime * moveSpeed;
                transform.position = Vector3.Lerp(startPosition, endPosition, journey);

                // 位置制限を適用
                transform.position = new Vector3(transform.position.x, transform.position.y, 0);

                yield return null;
            }

            transform.position = endPosition;
            currentPosition++;
            yield return new WaitForSeconds(0.1f); // マス間の待機時間
        }
    }

    // リセットメソッドを追加
    public void ResetPlayer()
    {
        currentPosition = 0;
        transform.position = boardSpaces[0].position; // プレイヤーを最初のマスに戻す
        Debug.Log("Player position has been reset."); // デバッグログ追加
    }
}
