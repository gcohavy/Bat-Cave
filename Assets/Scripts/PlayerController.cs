using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float upForce = 500;
    private float sideStep = 1;
    Rigidbody playerRb;

    void Start()
    {
        playerRb = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        MovePlayer();
    }

    void OnCollisionEnter(Collision collision)
    {

    }

    void MovePlayer()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            playerRb.AddForce(Vector3.up * upForce);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Translate(new Vector3(-sideStep, 0, 0));
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Translate(new Vector3(sideStep, 0, 0));
        }
    }
}
