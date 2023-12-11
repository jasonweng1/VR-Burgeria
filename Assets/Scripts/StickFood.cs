using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class StickFood : MonoBehaviour
{
    [SerializeField] private string foodTag = "food";
    [SerializeField] private FixedJoint fj;
    [SerializeField] private Rigidbody targetFood;
    private bool dropped = false;

    private IEnumerator OnCollisionEnter(Collision collision)
    {
        if (dropped && collision.gameObject.CompareTag(foodTag))
        {
            transform.parent = collision.collider.attachedRigidbody.transform;
            targetFood = collision.collider.GetComponent<Rigidbody>();
            yield return new WaitForSeconds(0.3f);
            fj = gameObject.AddComponent<FixedJoint>();
            fj.connectedBody = targetFood;
            dropped = false;

            gameObject.GetComponent<XRGrabInteractable>().enabled = false;
        }

        if (dropped && !collision.gameObject.CompareTag(foodTag))
        {
            dropped = false;
        }
    }

    public void EnableDropped()
    {
        dropped = true;
    }
}
