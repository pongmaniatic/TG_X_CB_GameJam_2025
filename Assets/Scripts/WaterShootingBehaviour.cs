using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class WaterShootingBehaviour : MonoBehaviour
{

    public GameObject centerObject;
    public GameObject aimCursor;
    public GameObject waterBullet;
    public float waterPreasure = 1f;


    public Camera mainCamera; 
    private bool hasWater;
    private Vector2 mousePos;
    private Vector2 aimPos;
    private Vector2 centerObjectPos;

    public float shootTimerMax = 0.1f;
    private float shootTimer = 0;
    private bool isShooting;

    private void Start()
    {
    }
    void Update()
    {
        UpdateCursor();



        if (shootTimer > 0)
        {
            shootTimer -= Time.deltaTime;
        }

        if (isShooting && waterBullet != null) SpawnWater();
           
        
    }

    private void SpawnWater()
    {
        if (shootTimer <= 0) 
        {
            var instantiatedWaterBullet = Instantiate(waterBullet, centerObject.transform.position, Quaternion.identity);
            var rigidBody2dWaterBullet = instantiatedWaterBullet.GetComponent<Rigidbody2D>();
            rigidBody2dWaterBullet.AddForce(aimPos * 200 * waterPreasure);
            shootTimer = shootTimerMax;
        }
    }

    private void UpdateCursor() // Update aim cursor position
    {
        Vector2 mousePos                = new Vector2(Mouse.current.position.x.value, Mouse.current.position.y.value);        // Get mouse postion 
        centerObjectPos                 = new Vector2(centerObject.transform.position.x, centerObject.transform.position.y); // Get center object world position
        mousePos                        = mainCamera.ScreenToWorldPoint(mousePos);                                          // Find mouse world position
        aimPos                          = mousePos - centerObjectPos;                                                      // Get mouse position in relation to center object
        aimPos.Normalize();                                                                                               // Normalize aim position
        aimCursor.transform.position    = centerObjectPos + aimPos;                                                      // Move aim cursor to center object
    }


    public void OnLook(InputAction.CallbackContext context)
    {
        Vector2 lookDelta = context.ReadValue<Vector2>();
    }

    public void StartShootingWater()
    {
        isShooting = true;
    }

    public void StopShootingWater()
    {
        isShooting = false;
    }

    public void ShootWater(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Performed:
                break;

            case InputActionPhase.Started:
                StartShootingWater();
                break;

            case InputActionPhase.Canceled:
                StopShootingWater();
                break;

        }
    }

}
