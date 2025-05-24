using System.Collections.Generic;
using UnityEngine;

public class GeneratePlant : MonoBehaviour
{
    public enum typeOfPlant { Floor, Wall, Roof, Background};

    public typeOfPlant plantType;
    public int numberOfPlants           = 1;
    public List<Transform> seedSlots    = new List<Transform>();
    public string prefabFolderPath = "Assets/Art/Sprites/Flowers/Stems"; // Replace with your folder name





    void Start()
    {
        GeneratePlants();
    }

    void GeneratePlants()
    {



        switch (plantType)
        {
            case typeOfPlant.Floor:
                GenerateFloorPlant();
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

    void GenerateFloorPlant()
    {
        if (numberOfPlants < 1)
        {
            Debug.LogWarning("can not generate less than 1 flower");
        }
        else 
        {
            Debug.Log("got here");
            GameObject[] loadedPrefabs = Resources.LoadAll<GameObject>(prefabFolderPath);
            Debug.Log("loadedPrefabs" + loadedPrefabs);
            foreach (GameObject prefab in loadedPrefabs)
            {
                Debug.Log("Loaded prefab: " + prefab.name);
            }

            /*
            Debug.LogWarning("prefabs: " + prefabs);
            if (prefabs.Length > 0)
            {


                Debug.LogWarning("succsess: ");


                var plantsGenerated = 0;
                while (plantsGenerated < numberOfPlants)
                {
                    var randomSeedSlot = seedSlots[Random.Range(0, seedSlots.Count)];

                    int randomIndex = Random.Range(0, prefabs.Length);
                    GameObject prefabToSpawn = prefabs[randomIndex];
                    var stemPrefab = Instantiate(prefabToSpawn, transform.position, Quaternion.identity);

                    seedSlots.Remove(randomSeedSlot);
                }


            }
            else
            {
                Debug.LogWarning("No prefabs found in " + prefabFolderPath);
            }
            */


        }



    }


}
