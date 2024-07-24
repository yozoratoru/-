using UnityEngine;
using System.Collections; // Add this line

public class PlayerMovement : MonoBehaviour
{
    public Transform[] boardSpaces; // Array of board spaces
    private int currentSpace = 0;
    public float moveSpeed = 2f; // Adjust the speed as needed

    public void MovePlayer(int spaces)
    {
        StartCoroutine(Move(spaces));
    }

    private IEnumerator Move(int spaces)
    {
        int targetSpace = currentSpace + spaces;
        targetSpace = Mathf.Min(targetSpace, boardSpaces.Length - 1); // Ensure player doesn't go out of bounds

        while (currentSpace < targetSpace)
        {
            currentSpace++;
            Vector3 targetPosition = boardSpaces[currentSpace].position;
            while (transform.position != targetPosition)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
                yield return null;
            }
        }
    }
}
