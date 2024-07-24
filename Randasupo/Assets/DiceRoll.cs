using UnityEngine;
using UnityEngine.UI;

public class DiceRoll : MonoBehaviour
{
    public Text diceResultText;
    private int diceResult;
    public PlayerMovement playerMovement; // Reference to the PlayerMovement script

    public void RollDice()
    {
        diceResult = Random.Range(1, 7);
        diceResultText.text = "Roll: " + diceResult.ToString();
        playerMovement.MovePlayer(diceResult);
    }
}
