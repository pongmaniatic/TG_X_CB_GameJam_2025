using UnityEngine;
using UnityEngine.Events;
using System.Collections;

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
                flowerIsDry = false;
                Destroy(collision.gameObject);
                StartCoroutine(FlowerTranformFromDryToHealthy());
            }
        }
    }


    IEnumerator FlowerTranformFromDryToHealthy()
    {
        float timeElapsed       = 0f;
        Vector3 initialScale    = new Vector3(2, 1, 1);//splashSprite.transform.localScale;
        Vector3 targetScale     = new Vector3(0.01f, 0.01f, 0.01f); // Final scale
        float scaleDuration     = 0.3f; // Time in seconds before destruction


        while (timeElapsed < scaleDuration)
        {

            gameObject.transform.localScale = Vector3.Lerp(initialScale, targetScale, timeElapsed / scaleDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        flowerColorUntility.PaintHealthyFlower(gameObject);
        timeElapsed = 0f;

        while (timeElapsed < scaleDuration)
        {
            Debug.Log(timeElapsed);
            gameObject.transform.localScale = Vector3.Lerp(targetScale, initialScale, timeElapsed / scaleDuration );
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        //gameObject.transform.localScale = targetScale;

    }

}
