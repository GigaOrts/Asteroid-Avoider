using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerHealth player))
        {
            player.Crash();
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
