using UnityEngine;

public class FlowerBehaviour : MonoBehaviour
{

    private bool flowerIsDry = true;
    public GameObject dryflower;
    public GameObject healthyflower;


    private void Start()
    {
        dryflower.SetActive(true);
        healthyflower.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Water"))
        {
            Destroy(collision.gameObject);
            dryflower.SetActive(false);
            healthyflower.SetActive(true);
            flowerIsDry = false;
        }
    }

}
