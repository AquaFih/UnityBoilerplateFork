using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject fish;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPosition = transform.position;
        currentPosition.x = fish.transform.position.x;
        currentPosition.y = fish.transform.position.y;
        transform.position = currentPosition;
    }
}
