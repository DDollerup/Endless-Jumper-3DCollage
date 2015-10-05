using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour
{
    public KeyCode jumpKey; // Hvilken knap vi bruger til at hoppe med.
    public float jumpForce; // Hvor meget 'force' vi skal bruge for at hoppe.
    public float moveSpeed; // Hvor hurtigt vi skal kunne bevæge os fra højre til venstre
    public bool isPlayerDead = false; // Er spilleren død?
    public bool grounded = false; // Er spilleren på en platform?

    public int score = 0; // Hvor mange points har spilleren fået?

    private Rigidbody myRigidbody;

    // Use this for initialization
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>(); // Finder referencen til Rigidybody som ligger
                                                 // på Player objektet
    }

    // Update is called once per frame
    void Update()
    {
        // Hop
        if (Input.GetKeyDown(jumpKey) && grounded == true) // Hvis der bliver trykket på HOP knappen
        {
            myRigidbody.AddForce(Vector3.up * jumpForce);
            grounded = false;
        }

        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        myRigidbody.AddForce(Vector3.right * horizontal * moveSpeed);
    }

    void OnCollisionEnter(Collision col)
    {
        GameObject other = col.gameObject;

        if (other.tag == "Ground")
        {
            grounded = true;
        }
    }
}
