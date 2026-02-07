using UnityEngine;
using UnityEngine.InputSystem; // 1. Add this namespace

public class PaddleMovement : MonoBehaviour
{
    public float moveSpeed = 8f;

    void Update()
    {
        
        float horizontalInput = 0f;

        
        if (Keyboard.current != null)
        {
            if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
            {
                horizontalInput = -1f;
            }
            else if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
            {
                horizontalInput = 1f;
            }
        }

        transform.Translate(horizontalInput * moveSpeed * Time.deltaTime, 0, 0);
    }
}