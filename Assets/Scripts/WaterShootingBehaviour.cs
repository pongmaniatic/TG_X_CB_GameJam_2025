using UnityEngine;

public class WaterShootingBehaviour : MonoBehaviour
{

    public GameObject centerObject;
    public GameObject WaterBullet;
    private bool currentlyShooting;
    private bool hasWater;


    void Start()
    {
        
    }


    public void ShootWater()
    {
        Debug.Log("hey, I am clicking");
        Destroy(centerObject);
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
