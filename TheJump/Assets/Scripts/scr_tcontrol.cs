using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class scr_tcontrol : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(Random.Range(-20f, 20f), 2f, Random.Range(-50f, 0));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 100 * Time.deltaTime, 0);

        // Restart position when fell off the map
        if (gameObject.transform.position.y < -30f)
        {
            // Reset the position
            transform.position = new Vector3(Random.Range(-20f, 20f), 2f, Random.Range(-50f, 0));
        }
    }
}

