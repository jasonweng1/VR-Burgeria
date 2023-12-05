using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinX : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // I put a random number for the y value :P
        transform.Rotate(0, 137, 0 * Time.deltaTime);
    }
}
