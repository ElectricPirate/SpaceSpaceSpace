using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    public float Rotation;
    public float MinSpeed, MaxSpeed;

    public GameObject AsteroidExplosion;
    public GameObject PlayerExplosion;

    public GameControllerScript GameController;

    void Start()
    {
        Rigidbody asteroid = GetComponent<Rigidbody>();
        asteroid.angularVelocity = Random.insideUnitSphere * Rotation;
        asteroid.velocity = Vector3.back * Random.Range(MinSpeed, MaxSpeed);

        GameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControllerScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "GameBoundary" || other.gameObject.tag == "Asteroid")
        {
            return;
        }

        if (other.gameObject.tag == "Player")
        {
            Instantiate(PlayerExplosion, other.gameObject.transform.position, Quaternion.identity);
        }
        else
        {
            GameController.IncreaseScore(10);
        }

        Instantiate(AsteroidExplosion, transform.position, Quaternion.identity);

        Destroy(other.gameObject);
        Destroy(gameObject);        
        
    }
}
