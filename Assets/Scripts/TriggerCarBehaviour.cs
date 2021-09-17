using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCarBehaviour : MonoBehaviour
{
    public GameObject car;
    public Transform spawnLocation;
    private void OnTriggerEnter(Collider other)
    {
        //when player enter trigger area spawn a car 
        if (other.gameObject.CompareTag("Player"))
            Instantiate(car, spawnLocation.position, spawnLocation.rotation);
    }
}
