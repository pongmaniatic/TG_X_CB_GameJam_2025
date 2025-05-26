using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float maxSpeed;
    [SerializeField] private float accelerationSpeed;
    [SerializeField] private float decelerationSpeed;

    private bool grounded;
    private Vector2 moveInput;


    private Rigidbody2D rb;
    private BoxCollider2D col;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(!(rb = GetComponent<Rigidbody2D>())) { Debug.LogError("player must contain a 2d rigidbodly"); }
        if (!(col = GetComponent<BoxCollider2D>())) { Debug.LogError("player must contain a box colider"); }
    }

    //physics update
    void FixedUpdate()
    {
        Move(Vector2.right * moveInput.x, accelerationSpeed, decelerationSpeed, maxSpeed);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void Move(Vector2 direction, float acceleration, float deceleration, float maxSpeed)
    { 
        //set defaul target velocity to move in direciton
        var targetVelocity = new Vector2(
                direction.x == 0 ? rb.linearVelocity.x : direction.x * maxSpeed,
                direction.y == 0 ? rb.linearVelocity.y : direction.y * maxSpeed
            );

        var speed = acceleration;

        //set stop target velocity
        if (direction.magnitude == 0 || maxSpeed == 0)
        {
            targetVelocity = new Vector2(
                Physics.gravity.x != 0 ? rb.linearVelocity.x : 0,
                Physics.gravity.y != 0 ? rb.linearVelocity.y : 0
            );

            speed = deceleration;
        }

        rb.linearVelocity = Vector2.Lerp(rb.linearVelocity, targetVelocity, speed * 0.01f);
    }

    //this is called externally when receiving move input
    public void OnMove(InputAction.CallbackContext ctx)
    {
        moveInput = ctx.ReadValue<Vector2>();
    }
}