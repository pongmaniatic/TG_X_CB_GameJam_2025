using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private float groundDist = 0.06f;

    protected Rigidbody2D rb;
    protected Collider2D col;
    protected Vector2 moveInput;

    protected void Start()
    {
        if (!(rb = GetComponent<Rigidbody2D>())) { Debug.LogError("player must contain a 2d rigidbodly"); }
        if(!(col = GetComponent<Collider2D>())) { Debug.LogError("player must contain a collider"); }
    }

    private RaycastHit2D GetGround()
    {
        var distance = groundDist;
        var size = col.bounds.size;//new Vector2(col.bounds.size.x, 0.01f);
        var center = col.bounds.center;//new Vector2(col.bounds.center.x, col.bounds.min.y - size.y);
        var angle = 0f;
        var direction = Vector2.down;
        var layer = LayerMask.GetMask("Surface");

        return Physics2D.BoxCast(center, size, angle, direction, distance, layer);
    }

    protected bool IsGrounded()
    {
        return GetGround();
    }

    //this is called externally when receiving move input
    public void OnMove(InputAction.CallbackContext ctx)
    {
        moveInput = ctx.ReadValue<Vector2>();
    }
}
