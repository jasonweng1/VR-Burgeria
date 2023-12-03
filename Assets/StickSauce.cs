using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickSauce : MonoBehaviour
{
    [SerializeField] private string foodTag = "food";
    [SerializeField] private FixedJoint fj;
    [SerializeField] private Rigidbody targetFood;
    public bool dropped = true;

    private IEnumerator OnCollisionEnter(Collision collision)
    {
        if (dropped && collision.gameObject.CompareTag(foodTag))
        {
            dropped = false;
            transform.parent = collision.collider.attachedRigidbody.transform;
            targetFood = collision.collider.GetComponent<Rigidbody>();
            yield return new WaitForSeconds(0.3f);
            fj = gameObject.AddComponent<FixedJoint>();
            fj.connectedBody = targetFood;
        }

        if (dropped && !collision.gameObject.CompareTag("bottle") && !collision.gameObject.CompareTag(foodTag))
        {
            dropped = false;
        }
    }
}
