using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public static Player main;

    private float groundDist = 0.06f;
    private float collisionPadding = 0.06f;

    protected Rigidbody2D rb;
    protected Collider2D col;
    protected Vector2 moveInput;
    protected GameObject rig;
    protected Animator anim;

    [SerializeField] protected bool debugMode;

    private void Awake()
    {
        if(!main) main = this;
    }

    protected void Start()
    {
        if (!(rb = GetComponent<Rigidbody2D>())) Debug.LogError("player must contain a 2d rigidbodly");
        if(!(col = GetComponent<Collider2D>())) Debug.LogError("player must contain a collider");
        //if (!(anim = GetComponent<Animator>())) Debug.LogError("player must contain an animator");
        rig = GameObject.FindGameObjectWithTag("PlayerRig");
        anim = rig.GetComponent<Animator>();
    }

    private RaycastHit2D GetGround()
    {
        var pos1 = new Vector2(col.bounds.min.x + collisionPadding, col.bounds.min.y - groundDist);
        var pos2 = new Vector2(col.bounds.max.x - collisionPadding, col.bounds.min.y - groundDist);
        RaycastHit2D hit = Physics2D.Linecast(pos1, pos2);

        if(debugMode)
        {
            var color = hit ? Color.green : Color.red;
            Debug.DrawLine(pos1, pos2, color);
        }

        return hit;
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
