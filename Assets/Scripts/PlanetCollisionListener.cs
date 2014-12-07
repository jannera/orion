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
        LevelCompletion.MarkCurrentLevelCompleted();
        GameState.LevelCompleted();
        Rigidbody r = other.gameObject.GetComponent<Rigidbody>();
        r.isKinematic = true;
        other.gameObject.GetComponent<Animator>().SetTrigger("StartDescent");
    }
}
