using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    public int pointValue = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.AddScore(pointValue);
            Destroy(gameObject);
        }
    }
}