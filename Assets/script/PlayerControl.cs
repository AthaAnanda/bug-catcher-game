using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerControl : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 720f;

    private Rigidbody rb;
    private Vector3 moveDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // biar nggak miring/meluncur
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        Vector3 input = new Vector3(moveX, 0f, moveZ);
        if (input.magnitude > 0.1f)
        {
            moveDirection = input.normalized;

            // Rotasi ke arah gerakan
            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
        else
        {
            // Jika tidak ada input, set gerakan ke nol
            moveDirection = Vector3.zero;
        }
    }

    void FixedUpdate()
    {
        if (moveDirection != Vector3.zero)
        {
            rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.fixedDeltaTime);
        }
    }
}
