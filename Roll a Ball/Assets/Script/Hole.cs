using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum TagName { 
    BlueBall,
    RedBall,
    GreenBall
}


public class Hole : MonoBehaviour
{
    [SerializeField]
    private TagName tagName;
    private bool ballIn = false;
    public bool Ballin {
        get { return ballIn; }
    }
    

    private void OnTriggerEnter(Collider other)
    {
        ballIn = true;
    }

    private void OnTriggerStay(Collider other)
    {
        Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();

        Vector3 driction = (transform.position - other.transform.position).normalized;
        if (other.gameObject.tag == tagName.ToString())
        {
            rb.velocity *= 0.9f;
            rb.AddForce(driction * rb.mass * 20f);
        }
        else { 
            rb.AddForce(-driction * rb.mass * 80f);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        ballIn = false;
    }
}
