using UnityEngine;
using UnityEngine.Events;

public class FlowerBehaviour : MonoBehaviour
{

    private bool flowerIsDry    = true;
    public UnityEvent makePlantHealthy;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Water"))
        {
            Destroy(collision.gameObject);
            makePlantHealthy.Invoke();
        }
    }

}
