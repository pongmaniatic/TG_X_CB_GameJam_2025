using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : Player
{
    [SerializeField] private float jumpSpeed;

    private void Update()
    {
        if(debugMode)
        {
            if(debugMode)
            {
                IsGrounded();
            }
        }
    }

    private void Jump(Vector2 dir, float jumpSpeed)
    {
        rb.linearVelocityY = 0f;
        rb.AddForce(dir * jumpSpeed * 50f);
    }

    public void onJump(InputAction.CallbackContext ctx)
    {
        Debug.Log(IsGrounded());
        if(IsGrounded())
        {
            Jump(Vector2.up, jumpSpeed);
        }
    }
}
