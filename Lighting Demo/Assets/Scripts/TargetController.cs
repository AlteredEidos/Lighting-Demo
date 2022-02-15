using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    private SpriteRenderer color;
    private bool flashlight = false;
    public Color lit;
    public Color unLit;



    void Start()
    {
        color = GetComponent<SpriteRenderer>();
    }

    void Update()
    { 

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Flashlight")
        {
            color.color = lit;
            Debug.Log("Lit");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Flashlight")
        {
            color.color = unLit;
            Debug.Log("unLit");
        }
    }
}
