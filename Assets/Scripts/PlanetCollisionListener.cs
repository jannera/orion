using UnityEngine;
using System.Collections;

public class PlanetCollisionListener : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        GameState.LevelCompleted();
        Destroy(other.gameObject);
    }
}
