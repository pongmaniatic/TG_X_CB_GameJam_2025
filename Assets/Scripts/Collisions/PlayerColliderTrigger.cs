using UnityEngine;

public class PlayerColliderTrigger : MonoBehaviour
{
    
    public CollisionManager.ColliderSide colliderSide;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            CollisionManager.Instance.downColliderIsGrounded = true;
            CollisionManager.Instance.CollisionHasOccured(other, colliderSide);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {

            CollisionManager.Instance.downColliderIsGrounded = false;
        }
    }
}
        
