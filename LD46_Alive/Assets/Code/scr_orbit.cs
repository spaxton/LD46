using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_orbit : MonoBehaviour
{

    private Vector3 target = new Vector3(0.0f, 0.0f, 0.0f);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Spin the object around the world origin at 10 degrees/second.
        transform.RotateAround(target, new Vector3(0, 0, 1), 50 * Time.deltaTime);
    }
}
