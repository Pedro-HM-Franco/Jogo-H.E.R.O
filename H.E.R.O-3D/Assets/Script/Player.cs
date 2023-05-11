using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float forceMultiplier = 3f;
    public float maximumVelocity = 3f;
    private float jumpForce = 10f;
    public GameObject bombPrefab;
    public float initialLife = 100f;
    private float currentLife;

    public void IncreaseLife(float amount) {
    currentLife += amount;
     }

    // Start is called before the first frame update
    void Start()
    {
        currentLife = initialLife;
    }

    // Update is called once per frame
    void Update()
    {
        var horizontalInput = Input.GetAxis("Horizontal");
        var verticalInput = Input.GetAxis("Vertical");
        if (GetComponent<Rigidbody>().velocity.magnitude <= maximumVelocity)
        {   
        GetComponent<Rigidbody>().AddForce(new Vector3(horizontalInput * forceMultiplier, 0, 0));
        }
        if (Input.GetKeyDown(KeyCode.Space)) {
         GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
         }

        /*if (Input.GetKeyDown(KeyCode.B)) {
        // Clone the bomb object and position it at the player's location
        GameObject newBomb = Instantiate(bombPrefab, transform.position, transform.rotation);
    
        // Destroy the bomb after a set amount of time
        Destroy(newBomb, destroyTime);
        }*/

    
    }
}
