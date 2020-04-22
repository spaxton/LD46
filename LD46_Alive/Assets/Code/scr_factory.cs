using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_factory : MonoBehaviour
{
    public GameObject PolPrefab;
    GameObject earf;
    int spawn_delay;
    bool pol_spawned = false;
    [SerializeField] GameObject IcePrefab;
    bool freezed = false;
    bool invulnerable = false;

    // Start is called before the first frame update
    void Start()
    {
        earf = GameObject.Find("Planet_controller");
        spawn_delay = Random.Range(2, 8);
        StartCoroutine("spawnCoroutine");
    }

    // Update is called once per frame
    void Update()
    {
        if ((pol_spawned == true) && (freezed == false))
        {
            StartCoroutine("spawnCoroutine");
            pol_spawned = false;
        }
    }

    void spawnAirPol()
    {
        GameObject airPollution = Instantiate(PolPrefab, transform.position, transform.rotation);
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
        evalRay(other);

    }

    void OnTriggerStay(Collider other)
    {
        evalRay(other);
    }

    void evalRay(Collider other)
    {
        if (other.gameObject.CompareTag("ray"))
        {
            bool lasering = GameObject.Find("Space_station").GetComponent<scr_player>().laser_active;
            bool freezing = GameObject.Find("Space_station").GetComponent<scr_player>().beam_active;
            if (lasering == true)
            {
                if ((freezed == false) && (invulnerable == false))
                {
                    Destroy(gameObject);
                }
                else
                {
                    thawed();
                }
            }
            if ((freezing == true) && (freezed == false))
            {
                frozen();
            }
        }
    }

    void frozen()
    {
        StopCoroutine("spawnCoroutine");
        freezed = true;
        GameObject elsa = Instantiate(IcePrefab, transform.position, transform.rotation);
        elsa.transform.parent = transform;
        StartCoroutine("iceCoroutine");
    }

    IEnumerator iceCoroutine()
    {
        yield return new WaitForSeconds(10);
        Destroy(this.gameObject.transform.GetChild(0).gameObject); // let it go
        freezed = false;
        StartCoroutine("spawnCoroutine");
    }

    void thawed()
    {
        StopCoroutine("iceCoroutine");
        if (this.gameObject.transform.childCount != 0)
        {
            Destroy(this.gameObject.transform.GetChild(0).gameObject); // let it go
        }
        freezed = false;
        invulnerable = true;
        StartCoroutine("spawnCoroutine");
        StartCoroutine("invCoroutine");
    }

    IEnumerator invCoroutine()
    {
        yield return new WaitForSeconds(1);
        invulnerable = false;
    }
}
