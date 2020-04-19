using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_pollution : MonoBehaviour
{
    public GameObject PolPrefab;
    private Vector3 target = new Vector3(0.0f, 0.0f, 0.0f);
    bool orbiting = true;

    // Start is called before the first frame update
    void Start()
    {
        Kys();
    }

    // Update is called once per frame
    void Update()
    {
        if (orbiting == true)
        {
            orbit();
        }
        else
        {
            sucked();
        }
    }

    void Kys()
    {
        Destroy(gameObject, 30);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ray"))
        {
            bool suckage = GameObject.Find("Space_station").GetComponent<scr_player>().suck_active;
            bool lasering = GameObject.Find("Space_station").GetComponent<scr_player>().laser_active;
            if (suckage == true)
            {
                orbiting = false;
            }
            if (lasering == true)
            {
                GameObject airPollution = Instantiate(PolPrefab, transform.position, new Quaternion(0, 0, 0, 0));
                airPollution.transform.parent = GameObject.Find("Planet_controller").transform;
            }
        }
        if (other.gameObject.CompareTag("station"))
        {
            Destroy(gameObject);
        }

    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("ray"))
        {
            bool suckage = GameObject.Find("Space_station").GetComponent<scr_player>().suck_active;
            if (suckage == true)
            {
                orbiting = false;
            }
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("ray"))
        {
            orbiting = true;
        }
    }

    void orbit()
    {
        // Spin the object around the world origin at 10 degrees/second.
        transform.RotateAround(target, new Vector3(1, 0, 0), 10 * Time.deltaTime);
    }

    void sucked()
    {
        float step = 1.0f * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, 0.686f, -0.471f), step);
    }
}
