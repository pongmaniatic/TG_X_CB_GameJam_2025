using UnityEngine;
using System;

public class CollisionManager : MonoBehaviour // Singelton Pattern
{
    public static CollisionManager Instance { get; private set; }

    public enum ColliderSide { Left, Right, Up, Down };

    public event Action<Collider2D> onDownCollision;

    public event Action<Collider2D> onUpCollision;

    public event Action<Collider2D> onLeftCollision;

    public event Action<Collider2D> onRightCollision;

    public bool downColliderIsGrounded  = false;
    public bool upColliderIsGrounded    = false;
    public bool leftColliderIsGrounded  = false;
    public bool rightColliderIsGrounded = false;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); 
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void PlayerTriggerHasEntered(Collider2D collision, ColliderSide side)
    {
        switch (side)
        {
            case ColliderSide.Left:
                onLeftCollision?.Invoke(collision); // Call all subscribers of this delegate, in this case when a collider is hit
                break;
            case ColliderSide.Right:
                onRightCollision?.Invoke(collision);
                break;
            case ColliderSide.Up:
                onUpCollision?.Invoke(collision);
                break;
            case ColliderSide.Down:
                onDownCollision?.Invoke(collision);
                break;
            default:
                break;
        }
    }

    public void PlayerTriggerHasExited(Collider2D collision, ColliderSide side)
    {
        switch (side)
        {
            case ColliderSide.Left:
                onLeftCollision?.Invoke(collision); // Call all subscribers of this delegate, in this case when a collider is hit
                break;
            case ColliderSide.Right:
                onRightCollision?.Invoke(collision);
                break;
            case ColliderSide.Up:
                onUpCollision?.Invoke(collision);
                break;
            case ColliderSide.Down:
                onDownCollision?.Invoke(collision);
                break;
            default:
                break;
        }
    }

}
