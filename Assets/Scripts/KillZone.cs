using UnityEngine;

public class KillZone : MonoBehaviour
{
    public Transform RespawnPoint;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            var controller = FindAnyObjectByType<LevelUIController>();
            controller.Kill();
            other.transform.position = RespawnPoint.position;
        }
    }
}
