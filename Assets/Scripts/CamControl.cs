using Unity.VisualScripting;
using UnityEngine;

public class CamControl : MonoBehaviour
{
    [SerializeField] private float camSpeed;
    [SerializeField] private float playerDistance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!PlayerInRange(playerDistance))
        {
            FollowPlayer(camSpeed * Time.deltaTime);
        }
    }

    private bool PlayerInRange(float range)
    {
        return Mathf.Abs(transform.position.y - Player.main.transform.position.y) <= range;
    }

    private void FollowPlayer(float speed)
    {
        var targetpos = Vector2.Lerp(transform.position, Player.main.transform.position, speed);
        transform.position = new Vector3(transform.position.x, targetpos.y, transform.position.z);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green; //PlayerInRange(playerDistance) ? Color.green : Color.red;
        Gizmos.DrawWireSphere(transform.position, playerDistance);
    }
}
