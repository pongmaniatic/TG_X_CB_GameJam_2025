using UnityEngine;

public class FlowerColorUntility : MonoBehaviour
{

    public Color dryStemColor;
    public Color healthyPlantColor;
    public Color dryFlowerColor;
    public Color healthyFlowerColor1;
    public Color healthyFlowerColor2;
    public Color healthyFlowerColor3;
    public Color healthyFlowerColor4;
    public Color healthyFlowerColor5;


    //void PaintStems(Color color)
    //{
    //    foreach (GameObject stem in flowerStems)
    //    {
    //        stem.transform.Find("Stem").GetComponent<SpriteRenderer>().color = color;
    //    }
    //}

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

    //void PaintHealthyFlower()
    //{
    //    foreach (GameObject stem in flowerStems)
    //    {

    //        int randomIndex = Random.Range(0, 5);
    //        switch (randomIndex)
    //        {
    //            case 0:
    //                stem.transform.Find("Stem").Find("Flower").GetComponent<SpriteRenderer>().color = HealthyFlowerColor1;
    //                break;
    //            case 1:
    //                stem.transform.Find("Stem").Find("Flower").GetComponent<SpriteRenderer>().color = HealthyFlowerColor2;
    //                break;
    //            case 2:
    //                stem.transform.Find("Stem").Find("Flower").GetComponent<SpriteRenderer>().color = HealthyFlowerColor3;
    //                break;
    //            case 3:
    //                stem.transform.Find("Stem").Find("Flower").GetComponent<SpriteRenderer>().color = HealthyFlowerColor4;
    //                break;
    //            case 4:
    //                stem.transform.Find("Stem").Find("Flower").GetComponent<SpriteRenderer>().color = HealthyFlowerColor5;
    //                break;
    //            default:
    //                stem.transform.Find("Stem").Find("Flower").GetComponent<SpriteRenderer>().color = HealthyFlowerColor2;
    //                break;
    //        }


    //    }
    //}

}
