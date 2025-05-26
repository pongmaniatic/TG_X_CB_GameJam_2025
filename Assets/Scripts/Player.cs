using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    protected Rigidbody2D rb;
    protected Vector2 moveInput;

    protected void Start()
    {
        if (!(rb = GetComponent<Rigidbody2D>())) { Debug.LogError("player must contain a 2d rigidbodly"); }
    }

    //this is called externally when receiving move input
    public void OnMove(InputAction.CallbackContext ctx)
    {
        moveInput = ctx.ReadValue<Vector2>();
    }
}
