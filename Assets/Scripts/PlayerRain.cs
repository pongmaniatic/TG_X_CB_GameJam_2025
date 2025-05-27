using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class PlayerRain : Player
{
    [SerializeField] private float glide = 1f;
    [SerializeField] private ParticleSystem rain;

    private float rainInput;

    void Update()
    {
        Glide(glide * rainInput);
    }

    private void Glide(float amnt)
    {
        Debug.Log(rb.linearVelocity.y);
            
        rb.gravityScale = rb.linearVelocity.y >= 0 ? 1 : 1 / Mathf.Max(amnt, 1f);
    }

   

   

    public void OnRain(InputAction.CallbackContext ctx)
    {
        rainInput = ctx.ReadValue<float>();
        if (rainInput == 0)
        {
            rain.Stop();
        }
        else
        {
            rain.Play();
        }
    }
}
