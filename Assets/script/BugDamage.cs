using UnityEngine;

public class BugDamage : MonoBehaviour
{
    public int damageAmount = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && GameManager.instance != null)
        {
            GameManager.instance.TakeDamage(damageAmount);
        }
    }
}
