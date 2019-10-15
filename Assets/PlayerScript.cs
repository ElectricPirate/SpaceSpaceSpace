using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float Speed;
    public float Tilt;
    public float XMin, XMax, ZMin, ZMax;
    public Rigidbody Player = new Rigidbody();
    public GameObject LazerShot;
    public Transform LazerGun;

    public float ShotDelay;
    private float NextShot;

    public float SuperShotDelay;
    private float NextSuperShot;

    public GameObject AsteroidExplosion;
    
    void Start()
    {
        Player = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
#if UNITY_STANDALONE
        var moveHorizontal = Input.GetAxis("Horizontal");
        var moveVertical = Input.GetAxis("Vertical");        

        Player.velocity = new Vector3(moveHorizontal, 0, moveVertical) * Speed;

        Player.rotation = Quaternion.Euler(Player.velocity.z * Tilt, 0, -Player.velocity.x * Tilt);

        var xPosition = Mathf.Clamp(Player.position.x, XMin,XMax);
        var zPosition = Mathf.Clamp(Player.position.z, ZMin, ZMax);

        Player.position = new Vector3(xPosition, 0, zPosition);

#endif

#if UNITY_ANDROID

        Player.velocity = new Vector3(-Input.acceleration.y * 10, 0, Input.acceleration.x * 10);
        Player.velocity.Normalize();
        Player.rotation = Quaternion.Euler(Player.velocity.z * Tilt, 0, -Player.velocity.x * Tilt);

        var xPosition = Mathf.Clamp(Player.position.x, XMin, XMax);
        var zPosition = Mathf.Clamp(Player.position.z, ZMin, ZMax);

        Player.position = new Vector3(xPosition, 0, zPosition);

#endif
        if (Time.time > NextShot && Input.GetButton("Fire1"))
        {
            Instantiate(LazerShot, LazerGun.position, Quaternion.identity);
            NextShot = Time.time + ShotDelay;
        }

        if (Time.time > NextSuperShot && Input.GetButton("Fire2"))
        {
            GameObject[] asteroids = GameObject.FindGameObjectsWithTag("Asteroid");
            foreach(GameObject aster in asteroids)
            {
                Instantiate(AsteroidExplosion, aster.transform.position, Quaternion.identity);
                Destroy(aster);
            }            

        }
    }
}
