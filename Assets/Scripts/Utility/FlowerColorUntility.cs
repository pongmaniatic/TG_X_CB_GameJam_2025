using System.Collections.Generic;
using UnityEngine;

public class FlowerColorUntility : MonoBehaviour
{

    public Color dryStemColor;
    public Color dryFlowerColor;
    public Color healthyStemColor;
    public Color healthyFlowerColor1;
    public Color healthyFlowerColor2;
    public Color healthyFlowerColor3;
    public Color healthyFlowerColor4;
    public Color healthyFlowerColor5;


    public void PaintDryFlower(Transform flower)
    {
        SpriteRenderer renderer = flower.GetComponent<SpriteRenderer>();
        renderer.color = dryFlowerColor;
    }
    public void PaintDryStem(Transform stem)
    {
        SpriteRenderer renderer = stem.GetComponent<SpriteRenderer>();
        renderer.color = dryStemColor;
    }

    List<GameObject> GetListOfChildrenOfName(GameObject parent, string childName)
    {
        List<GameObject> matchingChildren   = new List<GameObject>();
        Transform[] allChildren             = parent.GetComponentsInChildren<Transform>();

        foreach (Transform child in allChildren)
        {
            if (child.gameObject.name == childName)
            {
                matchingChildren.Add(child.gameObject);
            }
        }
        return matchingChildren;
    }

    public void PaintHealthyFlower(GameObject plantPrefab)
    {
        // Gerome and Patty
        List<GameObject> stemPrefabs    = GetListOfChildrenOfName(plantPrefab, "StemPrefab");
        List<GameObject> flowers        = GetListOfChildrenOfName(plantPrefab, "Flower");
        List<GameObject> stems          = GetListOfChildrenOfName(plantPrefab, "Stem");

        foreach (GameObject flowerObject in flowers)
        {
            SpriteRenderer flowerSpriteRenderer = flowerObject.GetComponent<SpriteRenderer>();
            int randomIndex = Random.Range(0, 5);
            switch (randomIndex)
            {
                case 0:
                    flowerSpriteRenderer.color = healthyFlowerColor1;
                    break;
                case 1:
                    flowerSpriteRenderer.color = healthyFlowerColor2;
                    break;
                case 2:
                    flowerSpriteRenderer.color = healthyFlowerColor3;
                    break;
                case 3:
                    flowerSpriteRenderer.color = healthyFlowerColor4;
                    break;
                case 4:
                    flowerSpriteRenderer.color = healthyFlowerColor5;
                    break;
                default:
                    flowerSpriteRenderer.color = healthyFlowerColor2;
                    break;
            }
        }

        foreach (GameObject stemObject in stems)
        {

            SpriteRenderer stemSpriteRenderer   = stemObject.GetComponent<SpriteRenderer>();
            stemSpriteRenderer.color            = healthyStemColor;
        }    
    }

}
