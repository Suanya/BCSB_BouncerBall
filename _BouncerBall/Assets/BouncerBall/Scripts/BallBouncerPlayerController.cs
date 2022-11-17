using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBouncerPlayerController : MonoBehaviour
{
    // Declaration
    public float speed = 5.0f;
    public float powerUpStrength = 15.0f;
    private Rigidbody playerRb;
    private GameObject focalPoint;
    public bool hasPowerUp = false;
    public GameObject powerUpIndicator;

    public AudioSource powerUpSound;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
    }

    // Update is called once per frame
    void Update()
    {
        // Library Delcaration
        float forwardInput = Input.GetAxis("Vertical");

        // Calling for Action
        playerRb.AddForce(focalPoint.transform.forward * forwardInput * speed);

        // show PowerUpIndicator
        powerUpIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("PowerUp"))
        {
            hasPowerUp = true;
            powerUpIndicator.gameObject.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerUpCountdownRoutine());
            Debug.Log("has PowerUp");
            powerUpSound.Play();     
        }
    }

    // set timer powerDown
    IEnumerator PowerUpCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerUp = false;
        powerUpIndicator.gameObject.SetActive(false);
        Debug.Log("noPower");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        { 
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;

            enemyRigidbody.AddForce(awayFromPlayer * powerUpStrength * 10, ForceMode.Impulse);

            Debug.Log("collided with:" + collision.gameObject.name + "with PowerUp set to" + hasPowerUp);       
        }
    }
}
