using TMPro;
using UnityEditor;
using UnityEngine;

public class Flower : MonoBehaviour
{
    [SerializeField] private float capacity;
    [SerializeField] private Color petalColor;

    private Animator anim;
    private SpriteRenderer petalRender;
    private float fill;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        anim.speed = 0;
        petalRender = GetPetal().GetComponent<SpriteRenderer>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        petalRender.color = petalColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Water")
        {
            Grow(fill);
            fill++;
        }
    }

    private void Grow(float fill)
    {
        var amnt = fill / capacity;
        //petalRender.color = (petalColor * amnt) + new Color(0,0,0,1);
        anim.Play("Grow",0, amnt);
    }

    private GameObject GetPetal()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).tag == "Petal")
            {
                return transform.GetChild(i).gameObject;
            }
        }
        Debug.LogWarning(name + "cannot find tag 'Petal'");
        return null;
    }


}
