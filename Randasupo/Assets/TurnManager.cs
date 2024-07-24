using UnityEngine;
using UnityEngine.UI;

public class TurnManager : MonoBehaviour
{
    public Text turnText;
    private int currentPlayer = 1;
    private int totalPlayers = 2; // Adjust based on your game

    public void EndTurn()
    {
        currentPlayer = (currentPlayer % totalPlayers) + 1;
        turnText.text = "Player " + currentPlayer + "'s Turn";
    }
}
