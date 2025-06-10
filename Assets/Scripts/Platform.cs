using UnityEngine;

public class Platform : MonoBehaviour
{
    private Collider2D col;
    private Collider2D playerCol;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnValidate()
    {
        if (transform.rotation.eulerAngles != Vector3.zero) Debug.LogWarning("WARNING: '" + gameObject.name + "' collisions may not work properly if rotation is not 0");
    }

    void Start()
    {
        if (!(col = GetComponent<Collider2D>())) Debug.LogError("Platform \"" + gameObject.name + "\" must contain at least 1 2D collider");
        playerCol = Player.main.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckUpdateCollisions();
    }

    private void CheckUpdateCollisions()
    {
        col.isTrigger = playerCol.bounds.min.y < transform.position.y;//col.bounds.max.y;
    }
}
