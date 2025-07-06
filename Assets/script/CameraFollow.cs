using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;        // Objek yang diikuti (player)
    public Vector3 offset = new Vector3(0, 5, -6);  // Jarak kamera dari player
    public float smoothSpeed = 5f;

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;

        transform.LookAt(target); // Kamera menghadap ke player
    }
}
