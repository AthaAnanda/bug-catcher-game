using UnityEngine;

public class BugHurtPlayer : MonoBehaviour
{
    public int damageAmount = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.TakeDamage(damageAmount);
        }
    }
}
