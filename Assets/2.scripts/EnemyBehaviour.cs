using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public bool enable = false;
    void Start()
    {
        enable = true;
    }
    void Update()
    {
        if(enable)
        {
            StartCoroutine(Disable());
        }
        else if(!enable)
        {
            StartCoroutine(Enable());
        }
    }
    IEnumerator Disable()
    {
        yield return new WaitForSeconds(5f);
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        Debug.Log("Disable");
        enable = false;
    }
    IEnumerator Enable()
    {
        yield return new WaitForSeconds(5f);
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<BoxCollider2D>().enabled = true;
        Debug.Log("Enable");
        enable = true;
    }
}
