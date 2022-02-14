using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    private SpriteRenderer color;
    public Color lit;
    public Color unLit;



    void Start()
    {
        color = GetComponent<SpriteRenderer>();
    }

    void Update()
    {       
            color.color = unLit;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Flashlight")
        {
            color.color = lit;
            Debug.Log("Lit");
        }
        else if (collision.tag == "Flashlight")
        {
            color.color = unLit;
        }
    }
}
