using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickFood : MonoBehaviour
{
    [SerializeField] private GameObject stickingFood;
    [SerializeField] private string foodTag = "food";
    private FixedJoint fj;
    private bool dropped = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (dropped && collision.gameObject.tag == foodTag)
        {
            GameObject food = Instantiate(stickingFood);
            
            food.transform.parent = collision.collider.attachedRigidbody.transform;
            fj = food.AddComponent<FixedJoint>();
            fj.connectedBody = collision.collider.GetComponent<Rigidbody>();

            Destroy(gameObject);
        }

        if (dropped && collision.gameObject.tag != foodTag)
        {
            dropped = false;
        }
    }

    public void EnableDropped()
    {
        dropped = true;
    }
}
