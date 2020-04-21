using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_rot : MonoBehaviour
{
    [SerializeField] float rotSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.Rotate(0, rotSpeed, 0, Space.Self);
    }
}
