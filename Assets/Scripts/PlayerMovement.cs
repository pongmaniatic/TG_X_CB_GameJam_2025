using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using static CollisionManager;

public class PlayerMovement : Player
{
    [SerializeField] private float maxSpeed;
    [SerializeField] private float accelerationSpeed;
    [SerializeField] private float decelerationSpeed;

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

    //private void OnEnable()
    //{
    //    CollisionManager.Instance.onc += OnCollision;
    //}

    //private void OnDisable()
    //{
    //    CollisionManager.Instance.onCollision -= OnCollision;
    //}

    //private void OnCollision(Collider2D collision, ColliderSide side)
    //{
    //    Debug.Log("Wohoo");
    //}

}