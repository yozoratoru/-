using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Transform playerTransform;

    private void Start()
    {
        playerTransform = this.transform;
    }

    public void MoveToPosition(Vector3 targetPosition)
    {
        playerTransform.position = targetPosition;
    }
}
