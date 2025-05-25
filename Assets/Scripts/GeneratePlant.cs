using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class GeneratePlant : MonoBehaviour
{
    public enum typeOfPlant { Floor, Wall, Roof, Background};

    public typeOfPlant plantType;
    public int numberOfPlantsMin                = 2;
    public int numberOfPlantsMax                = 4;
    public List<Transform> seedSlots            = new List<Transform>();

    private List<GameObject> flowerStems        = new List<GameObject>();
    private GameObject[] loadedStemPrefabs;
    private GameObject[] loadedFlowerPrefabs;
    private GameObject uilityScripts;
    private FlowerColorUntility flowerColorUntility;


    void Start()
    {
        loadedStemPrefabs   = Resources.LoadAll<GameObject>("StemPrefabs");
        loadedFlowerPrefabs = Resources.LoadAll<GameObject>("FlowerPrefab");
        uilityScripts       = GameObject.Find("UtilityScripts");
        flowerColorUntility = uilityScripts.GetComponent<FlowerColorUntility>();
        GeneratePlants();
    }

    private void FixPlantNumberIfOutOfRange()
    {
        bool tooFewPlants           = numberOfPlantsMin < 1;
        bool tooManyPlants          = numberOfPlantsMax > seedSlots.Count;
        bool minIsGreaterThanMax    = numberOfPlantsMin > numberOfPlantsMax;
        if (tooFewPlants)
        {
            Debug.LogWarning("can not generate less than 1 flower, it has been set to 1 instead");
            numberOfPlantsMin = 1;
        }
        if (tooManyPlants)
        {
            Debug.LogWarning("can not generate more than the amount of seedslots, it has been set to " + seedSlots.Count + " instead");
            numberOfPlantsMax = seedSlots.Count;
        }
        if (minIsGreaterThanMax)
        {
            Debug.LogWarning("Min is greater than Max, it has been set to numbers that work instead");
            numberOfPlantsMin = 1;
            numberOfPlantsMax = seedSlots.Count;
        }
    }

    //----------[ Spawning Related Functions ]----------//
    void GeneratePlants()
    {
        switch (plantType)
        {
            case typeOfPlant.Floor:
                GenerateFloorPlants();
                break;
            case typeOfPlant.Wall:
                break;
            case typeOfPlant.Roof:
                break;
            case typeOfPlant.Background:
                break;
            default:
                break;
        }
    }

    void GenerateFloorPlants()
    {
        bool moreThan1StemPrefabExist       = loadedStemPrefabs.Length > 0;
        bool moreThan1FlowerPrefabExist     = loadedFlowerPrefabs.Length > 0;
        int plantsGenerated                 = 0;
        var numberOfPlants                  = Random.Range(numberOfPlantsMin,numberOfPlantsMax);

        FixPlantNumberIfOutOfRange();

        if (!moreThan1StemPrefabExist || !moreThan1FlowerPrefabExist) return;
        
        
        while (plantsGenerated < numberOfPlants)
        {
            SpawnFlowerStem(plantsGenerated);
            SpawnFlowerInStem();
            plantsGenerated             += 1;
        }

        foreach (GameObject stemPrefab in flowerStems)
        {
            Transform stem                  = stemPrefab.transform.Find("Stem");
            Transform flower                = stem.transform.Find("Flower");

            if (flowerColorUntility != null)
            {
                flowerColorUntility.PaintDryStem(stem);
                flowerColorUntility.PaintDryFlower(flower);
            }

        }
    }
   
    void SpawnFlowerStem(int plantsGenerated) // Spawns random Stem prefab at random seed slot with a random rotation and flip
    {
        // Get Random Seed Slot and instantiate a random stem in it
        Transform randomSeedSlot            = seedSlots[Random.Range(0, seedSlots.Count)];
        int randomIndex                     = Random.Range(0, loadedStemPrefabs.Length);
        GameObject prefabToSpawn            = loadedStemPrefabs[randomIndex];
        GameObject stemPrefab               = Instantiate(prefabToSpawn, randomSeedSlot.position, Quaternion.identity);

        // Set Stem Parent, name, rotation and flip
        stemPrefab.transform.parent         = gameObject.transform;
        stemPrefab.name                     = "StemPrefab";
        int randomRotation                  = Random.Range(-30, 30);
        Transform stemSprite                = stemPrefab.transform.Find("Stem");
        SpriteRenderer stemSpriteRenderer   = stemSprite.GetComponent<SpriteRenderer>();
        stemSpriteRenderer.flipX            = Random.Range(0, 2) == 0;
        stemPrefab.transform.Rotate(randomRotation, 0.0f, 0.0f, Space.World);

        // Add stem to list for future reference and remove seed slot from list to avoid using the same seed slot
        flowerStems.Add(stemPrefab);
        seedSlots.Remove(randomSeedSlot);
    }

    void SpawnFlowerInStem() // Spawns random Flower prefab flower slot with a random rotation
    {
        foreach (GameObject stemPrefab in flowerStems)
        {
            // Check if flower already exists
            Transform stem                  = stemPrefab.transform.Find("Stem");
            bool flowerExists               = stem.transform.Find("Flower");
            if (flowerExists) continue;

            // Get Flower slot position, and instantiate a flower prefab in that position
            var flowerSlot                  = stemPrefab.transform.Find("Flower_Slot");
            int randomIndex                 = Random.Range(0, loadedFlowerPrefabs.Length);
            GameObject prefabToSpawn        = loadedFlowerPrefabs[randomIndex];
            GameObject flowerPrefab         = Instantiate(prefabToSpawn, flowerSlot.position, Quaternion.identity);

            // Set Flower to be child of stem, change its name and rotation
            flowerPrefab.transform.parent   = stem.transform;
            flowerPrefab.name               = "Flower";
            int randomRotation              = Random.Range(-15, 15);
            flowerPrefab.transform.Rotate(0.0f, 0.0f, randomRotation, Space.World);
        }
    }
}
