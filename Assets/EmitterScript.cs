using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmitterScript : MonoBehaviour
{
    public GameObject Asteroid;
    public float MinDealy, MaxDelay;
    private float NextLaunch;

    void Update()
    {
        if (Time.time > NextLaunch)
        {
            var xPos = Random.Range(-transform.localScale.x / 2, transform.localScale.x / 2);
            var yPos = transform.position.y;
            var zPos = transform.position.z;

            Instantiate(Asteroid, new Vector3(xPos, yPos, zPos), Quaternion.identity);
            NextLaunch = Time.time + Random.Range(MinDealy, MaxDelay);
        }

    }
}
