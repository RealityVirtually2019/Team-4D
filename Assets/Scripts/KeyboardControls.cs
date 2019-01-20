using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardControls : MonoBehaviour
{
    [SerializeField]
    readonly int arrowKeySpeed = 3;

    [SerializeField]
    readonly int mouseSpeed = 3;

    private float yaw = 0.0f;
    private float pitch = 0.0f;
    private bool toggleMouseOff;

    // Start is called before the first frame update
    void Start()
    {
        toggleMouseOff = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow)) transform.Translate(new Vector3(0, 0, 1) * Time.deltaTime * arrowKeySpeed);
        if (Input.GetKey(KeyCode.W)) transform.Translate(new Vector3(0, 0, 1) * Time.deltaTime * arrowKeySpeed);
        if (Input.GetKey(KeyCode.DownArrow)) transform.Translate(new Vector3(0, 0, -1) * Time.deltaTime * arrowKeySpeed);
        if (Input.GetKey(KeyCode.S)) transform.Translate(new Vector3(0, 0, -1) * Time.deltaTime * arrowKeySpeed);
        if (Input.GetKey(KeyCode.LeftArrow)) transform.Translate(new Vector3(-1, 0, 0) * Time.deltaTime * arrowKeySpeed);
        if (Input.GetKey(KeyCode.A)) transform.Translate(new Vector3(-1, 0, 0) * Time.deltaTime * arrowKeySpeed);
        if (Input.GetKey(KeyCode.RightArrow)) transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime * arrowKeySpeed);
        if (Input.GetKey(KeyCode.D)) transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime * arrowKeySpeed);

        if (Input.GetKey(KeyCode.Space)) toggleMouseOff = !toggleMouseOff;

        if (toggleMouseOff)
        {
            return;
        }

        yaw += mouseSpeed * Input.GetAxis("Mouse X");
        pitch -= mouseSpeed * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }
}
