using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: Script should require a Rigidbody2D component
[RequireComponent(typeof(Rigidbody2D))]

public class Player : MonoBehaviour
{
    // TODO: Reference to Rigidbody2D component should have class scope.
    private Rigidbody2D rigidbody;

    // TODO: A float variable to control how high to jump / how much upwards
    // force to add.
    public float forceLeap = 10f;

    public bool isFalling = true;

    // Start is called before the first frame update
    void Start()
    {
        // TODO: Use GetComponent to get a reference to attached Rigidbody2D
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isFalling)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            { 
                GetComponent<Rigidbody2D>().AddForce(Vector3.up * forceLeap, ForceMode2D.Impulse);
            }
        }
        // TODO: On the frame the player presses down the space bar, add an instant upwards
        // force to the rigidbody.
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        print("On Collision Enter");
        if (other.gameObject.CompareTag("Ground"))
        {
            isFalling = false;
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isFalling = true;
        }
    }
}
