using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour
{
    private Transform playerTransform;
    private Collider myCollider;

    // Use this for initialization
    void Start()
    {
        gameObject.tag = "Ground";
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        myCollider = GetComponentInChildren<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        // Hvis spillerens position er højere end platformens position, deaktivere vi platformens trigger
        // Derved, bliver platform en fysisk entitet i verden, og spilleren kan hoppe på den.
        if (playerTransform.position.y > transform.position.y)
        {
            myCollider.isTrigger = false;
        }
        else
        {
            myCollider.isTrigger = true;
        }
    }

    //void OnTriggerExit(Collider col)
    //{
    //    GameObject other = col.gameObject;
    //    if (other.tag == "Player")
    //    {
    //        Collider myCollider = GetComponent<Collider>();
    //        myCollider.isTrigger = false;
    //    }
    //}
}
