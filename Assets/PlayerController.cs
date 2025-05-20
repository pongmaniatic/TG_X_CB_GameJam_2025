using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    [SerializeField] private float lifetimeMultiplier;

    [SerializeField] private ParticleSystem ps;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = InputSystem.actions.FindAction("move").ReadValue<Vector2>();
        if (moveInput.magnitude != 0)
        {
            transform.position += new Vector3(moveInput.x, moveInput.y, 0) * Time.deltaTime * moveSpeed;
        }
        else
        {

        }
    }
}
