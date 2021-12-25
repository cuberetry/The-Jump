using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_outofbound : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y < -30f)
        {
            // Reset the position
            Destroy(gameObject);
        }
    }
}
