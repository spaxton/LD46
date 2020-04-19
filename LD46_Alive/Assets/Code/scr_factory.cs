using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_factory : MonoBehaviour
{
    public GameObject PolPrefab;
    public GameObject earf;
    int spawn_delay;
    bool pol_spawned = false;

    // Start is called before the first frame update
    void Start()
    {
        earf = GameObject.Find("Planet_controller");
        spawn_delay = Random.Range(2, 8);
        StartCoroutine(spawnCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        if (pol_spawned == true)
        {
            StartCoroutine(spawnCoroutine());
            pol_spawned = false;
        }
    }

    void spawnAirPol()
    {
        GameObject airPollution = Instantiate(PolPrefab, transform.position, new Quaternion(0, 0, 0, 0));
        airPollution.transform.parent = earf.transform;
    }

    IEnumerator spawnCoroutine()
    {
        yield return new WaitForSeconds(spawn_delay);
        spawnAirPol();
        pol_spawned = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ray"))
        {
            bool lasering = GameObject.Find("Space_station").GetComponent<scr_player>().laser_active;
            if (lasering == true)
            {
                Destroy(gameObject);
            }
        }

    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("ray"))
        {
            bool lasering = GameObject.Find("Space_station").GetComponent<scr_player>().laser_active;
            if (lasering == true)
            {
                Destroy(gameObject);
            }
        }

    }

}
