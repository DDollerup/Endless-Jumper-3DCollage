using UnityEngine;
using System.Collections;

public class CameraBehaviour : MonoBehaviour
{
    public Transform playerTrans;
    public Vector3 offset;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (playerTrans)
        {
            float playerYPosition = playerTrans.position.y;
            transform.position = Vector3.Lerp(transform.position, new Vector3(0 + offset.x, playerYPosition + offset.y, 0 + offset.z), 0.2f);
        }
    }
}
