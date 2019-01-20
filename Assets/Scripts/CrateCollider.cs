using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateCollider : MonoBehaviour
{
    public bool isColliding = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnCollisionEnter(Collision col)
    {
        isColliding = true;
    }


    void OnCollisionExit()
    {
        isColliding = false;
    }
}
