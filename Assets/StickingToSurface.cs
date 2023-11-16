using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickingToSurface : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private MeshCollider myCollider;
    [SerializeField] private GameObject stickingFood;
    [SerializeField] private string foodTag = "food";

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == foodTag) 
        {
            rb.isKinematic = true;
            myCollider.isTrigger = true;

            GameObject food = (GameObject)Instantiate(stickingFood);
            food.transform.position = transform.position;
            food.transform.forward = transform.forward;

            if (collision.collider.attachedRigidbody != null)
            {
                food.transform.parent = collision.collider.attachedRigidbody.transform;
            }

            Destroy(gameObject);
        }

    }
}
