using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SauceBottle : MonoBehaviour
{
    public Transform sauceSpawnPoint;
    public GameObject saucePrefab;
    public float sauceSpeed = 10;

    void Update() { 
        if (Input.GetKeyDown(KeyCode.Space)) {
            GameObject sauce = Instantiate(saucePrefab, sauceSpawnPoint.position, sauceSpawnPoint.rotation);
            sauce.GetComponent<Rigidbody>().velocity = sauceSpawnPoint.forward * sauceSpeed;
        }
    }
}
