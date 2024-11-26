using UnityEngine;

public class GameController : MonoBehaviour
{
    public void RollDice()
    {
        // サイコロを振る（1〜6のランダムな数値）
        int diceRoll = Random.Range(1, 7);
        Debug.Log("サイコロの目: " + diceRoll);

        // プレイヤーを進める
        BoardManager.Instance.MovePlayer(diceRoll);
    }
}
