using cakeslice;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadCollider : MonoBehaviour
{
    // If an object is occupying this space
    private bool bottomLeft;
    private bool bottomRight;
    private bool topLeft;
    private bool topRight;

    // Start is called before the first frame update
    void Start()
    {
        bottomLeft = bottomRight = topLeft = topRight = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.collider.name);
        if (collision.collider.name == "Crate" || collision.collider.tag == "Crate")
        {
            Transform crate = collision.transform;
            Vector3 size = GetComponent<Collider>().bounds.size;
            Debug.Log(size.x);
            GazeAttacher.Instance.DetachOutline();
            if (!bottomLeft)
            {
                crate.parent = gameObject.transform;
                crate.position = new Vector3(-size.x / 2, 0, -size.z / 2);
                crate.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                bottomLeft = true;
            }
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.name == "Crate" || collider.tag == "Crate")
        {
            Transform crate = collider.transform;
            Vector3 size = GetComponent<Collider>().bounds.size;
            GazeAttacher.Instance.DetachOutline();

            // Move the crate to the pad's parent
            crate.parent = gameObject.transform;
            // Set rotation opposite to that of the pad
            crate.localRotation = Quaternion.Euler(new Vector3(90f, 0f, 0f));
            // Prevent the crate from moving
            crate.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            // Turn off gaze outline
            crate.GetChild(0).GetComponent<Outline>().enabled = false;
            if (!bottomLeft)
            {
                crate.localPosition = new Vector3(-1f, 0f, -0.5f);
                crate.name = "Crate Bottom Left";
                bottomLeft = true;
            }
            else if (!bottomRight)
            {
                crate.localPosition = new Vector3(-1f, size.z / 2, -0.5f);
                crate.name = "Crate Bottom Right";
                bottomRight = true;
            }
            else if (!topLeft)
            {
                crate.localPosition = new Vector3(0.5f, 0f, -0.5f);
                crate.name = "Crate Top Left";
                topLeft = true;
            }
            else if (!topRight)
            {
                crate.localPosition = new Vector3(0.5f, size.z / 2, -0.5f);
                crate.name = "Crate Top Right";
                topRight = true;
            }
        }
    }


}
