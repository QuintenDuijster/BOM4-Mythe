using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class SimpleMovement : MonoBehaviour
{
    public float speed = 3.0F;

    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();

        // Move left/right
        Vector3 right = transform.TransformDirection(Vector3.right);
        float curSpeedX = speed * Input.GetAxis("Horizontal");

        // Move forward/backward
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        float curSpeedZ = speed * Input.GetAxis("Vertical");

        // Combine the movement directions
        Vector3 movement = (right * curSpeedX) + (forward * curSpeedZ);

        // Apply the movement
        controller.SimpleMove(movement);
    }
}
