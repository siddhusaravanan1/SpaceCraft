using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    private Vector3 Min;
    private Vector3 Max;

    private float xAxis;
    private float yAxis;
    private float zAxis;

    int count = 0;

    private Vector3 randomPosition;

    public GameObject petrol;
    private void Start()
    {
        SetRanges();
    }
    private void Update()
    {
        xAxis = Random.Range(Min.x, Max.x);
        yAxis = Random.Range(Min.y, Max.y);
        zAxis = Random.Range(Min.z, Max.z);
        randomPosition = new Vector3(xAxis, yAxis, zAxis);
        InstantiateRandomObjects();
    }
    private void SetRanges()
    {
        Min = new Vector3(2, 4, 0);
        Max = new Vector3(200, 400, 600);
    }
    void InstantiateRandomObjects()
    {
        if(count<10)
        {
            Instantiate(petrol, randomPosition, Quaternion.identity);
            count += 1;
            StartCoroutine(CanSpawn());
        }
        if(count >= 70)
        {
            count = 70;
            StopAllCoroutines();
        }
    }
    IEnumerator CanSpawn()
    {

        yield return new WaitForSeconds(3f);
        count = 0;
    }

}
