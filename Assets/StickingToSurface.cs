using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickingToSurface : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Collider myCollider;
    [SerializeField] private FixedJoint fj;
    [SerializeField] private GameObject stickingFood;
    [SerializeField] private string foodTag = "food";

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == foodTag) 
        {
            GameObject food = (GameObject)Instantiate(stickingFood);
            
            food.transform.parent = collision.collider.attachedRigidbody.transform;
            fj = food.AddComponent<FixedJoint>();
            fj.connectedBody = collision.collider.GetComponent<Rigidbody>();

            Destroy(gameObject);
        }

    }
}
