using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_HPeval : MonoBehaviour
{
    public bool at70 = false;
    public bool at30 = false;
    [SerializeField] GameObject player;
	private static FMOD.Studio.EventInstance Music;

    // Start is called before the first frame update
    void Start()
    {
		Music = FMODUnity.RuntimeManager.CreateInstance("event:/Music/Music");
		Music.start();
		Music.release();
    }

    // Update is called once per frame
    void Update()
    {
        int hp = player.GetComponent<scr_player>().hp;
        if (hp <= 70)
        {
            at70 = true;
			Music.setParameterByName("Health", 1f);
        }
        if (hp <= 30)
        {
            at30 = true;
			Music.setParameterByName("Health", 2f);
        }
    }
    private void OnDestroy()
	{
		Music.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
	}
}
