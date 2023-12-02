using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickSauce : MonoBehaviour
{
    [SerializeField] private GameObject stickingFood;
    [SerializeField] private string foodTag = "food";
    private FixedJoint fj;
    public bool dropped = true;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("yippeeee");
        if (dropped && collision.gameObject.tag == foodTag)
        {
            GameObject food = Instantiate(stickingFood);

            food.transform.parent = collision.collider.attachedRigidbody.transform;
            fj = food.AddComponent<FixedJoint>();
            fj.connectedBody = collision.collider.GetComponent<Rigidbody>();

            Destroy(gameObject);
        }

        if (dropped && collision.gameObject.tag != "bottle" && collision.gameObject.tag != foodTag)
        {
            dropped = false;
            Debug.Log("touch not food, rip");
        }
    }
}
