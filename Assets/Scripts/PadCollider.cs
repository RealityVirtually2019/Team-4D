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
        if (collision.collider.name == "Crate" || collision.collider.tag == "Crate")
        {
            Transform crate = collision.transform;
            Vector3 size = GetComponent<Collider>().bounds.size;
            if (!bottomLeft)
            {
                crate.parent = gameObject.transform;
                crate.position = new Vector3(-size.x / 2, 0, -size.z / 2);
            }
        }
    }


}
