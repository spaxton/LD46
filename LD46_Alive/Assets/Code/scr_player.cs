using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_player : MonoBehaviour
{
    public bool suck_active = false;
    public bool laser_active = false;
    public bool beam_active = false;

    GameObject ray;

    // Start is called before the first frame update
    void Start()
    {
        ray = this.gameObject.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        getInput();
        setRay();
    }

    void getInput()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            suck_active = true;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            laser_active = true;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            beam_active = true;
        }
        if (Input.GetKeyUp(KeyCode.Q))
        {
            suck_active = false;
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            laser_active = false;
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            beam_active = false;
        }
    }

    void setRay()
    {
        var ray_color = ray.GetComponent<Renderer>();
        if (suck_active == true)
        {
            ray_color.material.SetColor("_Color", Color.white);
        }
        if (laser_active == true)
        {
            ray_color.material.SetColor("_Color", Color.red);
        }
        if (beam_active == true)
        {
            ray_color.material.SetColor("_Color", Color.cyan);
        }
        if ((suck_active == false) && (laser_active == false) && (beam_active == false))
        {
            ray_color.material.SetColor("_Color", Color.magenta);
        }
    }

    void fireSuck()
    {

    }

    void fireLaser()
    {

    }

    void fireBeam()
    {

    }
}
