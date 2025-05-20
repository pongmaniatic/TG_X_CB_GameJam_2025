using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] bool move;

    public Vector2 getMove()
    {
        if (move)
        {
            return InputSystem.actions.FindAction("move").ReadValue<Vector2>();
        }

        return new Vector2(0,0);
    }
}
