using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_spawnController : MonoBehaviour
{
    public GameObject FactoryPrefab;
    [SerializeField] GameObject ReactorPrefab;
    public int initialSpawnF = 0;
    public int initialSpawnR = 0;

    public GameObject earf;
    public int spawn_delayF = 0;
    public int spawn_delayR = 0;
    bool factory_spawned = false;
    bool reactor_spawned = false;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i< initialSpawnF; i++)
        {
            spawnFactory();
        }
        StartCoroutine("factoryCoroutine");

        for (int i = 0; i < initialSpawnR; i++)
        {
            spawnReactor();
        }
        StartCoroutine("reactorCoroutine");
    }

    // Update is called once per frame
    void Update()
    {
        if (factory_spawned == true)
        {
            StartCoroutine("factoryCoroutine");
            factory_spawned = false;
        }
        if (reactor_spawned == true)
        {
            StartCoroutine("reactorCoroutine");
            reactor_spawned = false;
        }
    }

    void spawnFactory()
    {
        //Get center point & randomize placement 
        
        Vector3 spawnPoint = earf.transform.position;
        Vector3 randomDir = Random.onUnitSphere;
        spawnPoint += (randomDir * ((earf.transform.localScale.y/2) + 0.05f));
        Vector3 spawnRotation = (spawnPoint - earf.transform.position).normalized;
        

        //Spawn & rotate & parent appropriately
        GameObject addSpawn = Instantiate(FactoryPrefab, spawnPoint, new Quaternion(0, 0, 0, 0));
       addSpawn.transform.rotation = Quaternion.FromToRotation(addSpawn.transform.up, spawnRotation) * addSpawn.transform.rotation;

        addSpawn.transform.parent = earf.transform;
    }

    IEnumerator factoryCoroutine()
    {
        yield return new WaitForSeconds(spawn_delayF);
        spawnFactory();
        factory_spawned = true;
    }

    void spawnReactor()
    {
        //Get center point & randomize placement 

        Vector3 spawnPoint = earf.transform.position;
        Vector3 randomDir = Random.onUnitSphere;
        spawnPoint += (randomDir * ((earf.transform.localScale.y / 2) + 0.05f));
        Vector3 spawnRotation = (spawnPoint - earf.transform.position).normalized;


        //Spawn & rotate & parent appropriately
        GameObject addSpawn = Instantiate(ReactorPrefab, spawnPoint, new Quaternion(0, 0, 0, 0));
        addSpawn.transform.rotation = Quaternion.FromToRotation(addSpawn.transform.up, spawnRotation) * addSpawn.transform.rotation;

        addSpawn.transform.parent = earf.transform;
    }

    IEnumerator reactorCoroutine()
    {
        yield return new WaitForSeconds(spawn_delayR);
        spawnReactor();
        reactor_spawned = true;
    }
}
