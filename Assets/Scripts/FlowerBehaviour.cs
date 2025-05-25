using UnityEngine;
using UnityEngine.Events;

public class FlowerBehaviour : MonoBehaviour
{

    public UnityEvent makePlantHealthy;

    private bool flowerIsDry    = true;
    private GameObject uilityScripts;
    private FlowerColorUntility flowerColorUntility;


    void Start()
    {
        uilityScripts       = GameObject.Find("UtilityScripts");
        flowerColorUntility = uilityScripts.GetComponent<FlowerColorUntility>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (flowerIsDry)
        {
            if (collision.gameObject.CompareTag("Water"))
            {
                Destroy(collision.gameObject);
                flowerColorUntility.PaintHealthyFlower(gameObject);
                flowerIsDry = false;
            }
        }
    }

}
