using UnityEngine;
using System.Collections;

public class WaterDropBehaviour : MonoBehaviour
{

    public GameObject splashSprite;
    public Vector3 targetScale      = new Vector3(0.05f, 0.05f, 0.05f); // Final scale
    public float scaleDuration      = 0.1f; // Time in seconds before destruction
    private bool splashing          = false;


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Debug.Log("------------");
            Debug.Log(collision);
            if (!splashing)
            {
                StartCoroutine(WaterSplash());
            }
        }
    }


    IEnumerator WaterSplash()
    {
        splashSprite.SetActive(true);

        splashing                                           = true;
        Vector3 initialScale                                = new Vector3(0.03f, 0.03f, 0.03f);//splashSprite.transform.localScale;
        float timeElapsed                                   = 0f;
        gameObject.GetComponent<Rigidbody2D>().simulated    = false;
        gameObject.GetComponent<SpriteRenderer>().enabled   = false;

        while (timeElapsed < scaleDuration)
        {
            splashSprite.transform.localScale = Vector3.Lerp(initialScale, targetScale, timeElapsed / scaleDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        while (timeElapsed < scaleDuration*2)
        {
            splashSprite.transform.localScale = Vector3.Lerp(targetScale, initialScale, timeElapsed / scaleDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        Destroy(gameObject);
    }

}
