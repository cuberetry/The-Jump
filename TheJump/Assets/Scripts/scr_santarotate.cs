using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_santarotate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // If timeScale is 0 then skip the checking process
        if (Time.timeScale == 0)
        {
            return;
        }

        if (Input.GetKey(KeyCode.A))
        {
            // Rotate the character left
            if (transform.rotation.eulerAngles.y != -90)
            {
                Quaternion rot = new Quaternion();
                rot.eulerAngles = new Vector3(-90, -90, 0);
                transform.rotation = rot;
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            // Rotate the character to the right
            if (transform.rotation.eulerAngles.y != 90)
            {
                Quaternion rot = new Quaternion();
                rot.eulerAngles = new Vector3(-90, 90, 0);
                transform.rotation = rot;
            }
        }
        if (Input.GetKey(KeyCode.W))
        {
            // Rotate the character forward
            if (transform.rotation.eulerAngles.y != 0)
            {
                Quaternion rot = new Quaternion();
                rot.eulerAngles = new Vector3(-90, 0, 0);
                transform.rotation = rot;
            }
        }
        if (Input.GetKey(KeyCode.S))
        {
            // Rotate the character backward
            if (transform.rotation.eulerAngles.y != 180)
            {
                Quaternion rot = new Quaternion();
                rot.eulerAngles = new Vector3(-90, 180, 0);
                transform.rotation = rot;
            }
        }
    }
}
