using UnityEngine;

public class BugPoint : MonoBehaviour
{
    public int pointValue = 5;
    private bool hasCollected = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasCollected)
        {
            hasCollected = true;

            if (GameManager.instance != null)
            {
                GameManager.instance.AddScore(pointValue);
            }
            else
            {
                Debug.LogWarning("GameManager.instance is null!");
            }

            // Destroy(gameObject); // opsional
        }
    }
}
