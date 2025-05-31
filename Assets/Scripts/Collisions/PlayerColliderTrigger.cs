using UnityEngine;

public class PlayerColliderTrigger : MonoBehaviour
{
    
    public CollisionManager.ColliderSide colliderSide;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            CollisionManager.Instance.PlayerTriggerHasEntered(other, colliderSide);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            CollisionManager.Instance.downColliderIsGrounded = false;
            CollisionManager.Instance.PlayerTriggerHasExited(other, colliderSide);
        }
    }
}
        
