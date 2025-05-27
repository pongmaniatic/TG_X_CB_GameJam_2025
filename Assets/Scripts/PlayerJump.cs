using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : Player
{
    [SerializeField] private float jumpSpeed;

    private void Jump(Vector2 dir, float jumpSpeed)
    {
        rb.AddForce(dir * jumpSpeed * 50f);
    }

    public void onJump(InputAction.CallbackContext ctx)
    {
        if(IsGrounded())
        {
            Jump(Vector2.up, jumpSpeed);
        }
    }
}
