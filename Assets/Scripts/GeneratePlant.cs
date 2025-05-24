using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GeneratePlant : MonoBehaviour
{
    public enum typeOfPlant { Floor, Wall, Roof, Background};

    public typeOfPlant plantType;
    public int numberOfPlantsMin        = 2;
    public int numberOfPlantsMax        = 4;
    public List<Transform> seedSlots    = new List<Transform>();
    private string prefabFolderPath     = "Assets/Prefabs/StemPrefabs";
    private GameObject[] loadedPrefabs;

    void Start()
    {
        loadedPrefabs = Resources.LoadAll<GameObject>("StemPrefabs");
        GeneratePlants();
    }

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

    void SpawnFlowerStem(int plantsGenerated) // Spawns random Stem prefab at random seed slot with a random rotation and flip
    {
        Transform randomSeedSlot                                    = seedSlots[Random.Range(0, seedSlots.Count)];
        int randomIndex                                             = Random.Range(0, loadedPrefabs.Length);
        GameObject prefabToSpawn                                    = loadedPrefabs[randomIndex];
        GameObject stemPrefab                                       = Instantiate(prefabToSpawn, randomSeedSlot.position, Quaternion.identity);
        stemPrefab.transform.parent                                 = gameObject.transform;
        stemPrefab.name                                             = "stem_" + plantsGenerated;
        int randomRotation                                          = Random.Range(-30, 30);
        Transform stemSprite                                        = stemPrefab.transform.Find("Stem");
        SpriteRenderer stemSpriteRenderer                           = stemSprite.GetComponent<SpriteRenderer>();
        stemSpriteRenderer.flipX                                    = Random.Range(0, 2) == 0;
        stemPrefab.transform.Rotate(randomRotation, 0.0f, 0.0f, Space.World);

        seedSlots.Remove(randomSeedSlot);
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

    void GenerateFloorPlants()
    {
        bool moreThan1PrefabExist   = loadedPrefabs.Length > 0;
        int plantsGenerated         = 0;
        var numberOfPlants          = Random.Range(numberOfPlantsMin,numberOfPlantsMax);

        FixPlantNumberIfOutOfRange();

        if (!moreThan1PrefabExist)
        {
            Debug.LogWarning("No prefabs found in " + prefabFolderPath);
            return;
        }
        
        while (plantsGenerated < numberOfPlants)
        {
            SpawnFlowerStem(plantsGenerated);
            plantsGenerated             += 1;
        }
    }
    
}
