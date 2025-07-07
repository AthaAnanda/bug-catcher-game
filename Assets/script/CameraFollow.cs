using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Target Settings")]
    public Transform target;               // Objek yang diikuti (biasanya Player)
    public Vector3 offset = new Vector3(0f, 7f, -9f); // Posisi relatif kamera terhadap player
    public float smoothSpeed = 10f;        // Kehalusan transisi posisi kamera
    public float lookSmoothSpeed = 10f;    // Kehalusan rotasi kamera

    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        if (target == null) return;

        // Posisi ideal kamera mengikuti arah rotasi target (agar selalu di belakang)
        Vector3 desiredPosition = target.position + target.TransformDirection(offset);

        // Lerp posisi kamera agar halus
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, 1f / smoothSpeed);

        // Kamera menghadap ke player dengan transisi rotasi halus
        Quaternion desiredRotation = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, lookSmoothSpeed * Time.deltaTime);
    }
}
