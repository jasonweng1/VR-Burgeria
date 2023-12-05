using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickFood : MonoBehaviour
{
    [SerializeField] private string foodTag = "food";
    [SerializeField] private FixedJoint fj;
    [SerializeField] private Rigidbody targetFood;
    private bool dropped = false;

    private IEnumerator OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision");
        if (dropped && collision.gameObject.CompareTag(foodTag))
        {
            Debug.Log("Stick");
            transform.parent = collision.collider.attachedRigidbody.transform;
            targetFood = collision.collider.GetComponent<Rigidbody>();
            yield return new WaitForSeconds(0.3f);
            fj = gameObject.AddComponent<FixedJoint>();
            fj.connectedBody = targetFood;
            dropped = false;
        }

        if (dropped && !collision.gameObject.CompareTag(foodTag))
        {
            Debug.Log("No Stick");
            dropped = false;
        }
    }

    public void EnableDropped()
    {
        dropped = true;
    }
}
