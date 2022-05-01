using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    Vector3 movement;
    Quaternion newRotation;
    Rigidbody playerRigidbody;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Move(h, v);
        Turning(h, v);
    }

    public void Move(float h, float v)
    {
        movement.Set(h, 0f, v);
        movement = movement.normalized * movementSpeed * Time.deltaTime;
        playerRigidbody.MovePosition(transform.position + movement);
    }

    public void Turning(float h, float v)
    {
        if (h != 0 || v != 0)
            newRotation = Quaternion.LookRotation(movement);
        else
            newRotation = Quaternion.LookRotation(transform.forward + movement);

        playerRigidbody.MoveRotation(newRotation);
    }
}