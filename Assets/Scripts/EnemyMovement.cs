using UnityEngine;
using UnityEngine.UIElements;

public class EnemyMovement : MonoBehaviour
{
    public float enemySpeed;
    public float distance = 2.5F;
    private float startX;

    void Start()
    {
        startX = transform.position.x;
    }

    void Update()
    {
        // Mathf.PingPong moves smoothly between 0 and the max distance
        float newX = startX + Mathf.PingPong(Time.time * enemySpeed, distance) - (distance / 2f);
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }
}
