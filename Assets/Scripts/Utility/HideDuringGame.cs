using UnityEngine;

public class HideDuringGame : MonoBehaviour
{
    public bool hideDuringGame = true;
    void Start()
    {
        gameObject.SetActive(!hideDuringGame);
    }
}
