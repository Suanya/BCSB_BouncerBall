using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBouncerEnemy : MonoBehaviour
{
    // internal readonly int Length;
    
    public float speed;
    private Rigidbody enemyRb;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;

        enemyRb.AddForce(lookDirection * speed);

        // destroy enemy if it falls down the cliff
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
}
