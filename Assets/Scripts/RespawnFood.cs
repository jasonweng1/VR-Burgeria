using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnFood : MonoBehaviour
{
    [SerializeField] private string foodTag = "food";
    [SerializeField] private GameObject respawnedFood;
    private int pause = 0;

    private IEnumerator OnTriggerExit(Collider other)
    {

        if (other.gameObject.CompareTag(foodTag) && pause == 0)
        {
            pause = 1;
            yield return new WaitForSeconds(0.5f);
            Instantiate(respawnedFood, transform.position, respawnedFood.GetComponent<Transform>().rotation);
            pause = 0;
        }
    }
}
