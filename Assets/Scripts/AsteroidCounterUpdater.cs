using UnityEngine;
using System.Collections;

public class AsteroidCounterUpdater : MonoBehaviour {
    public GameObject counterPreFab;
    public AsteroidLauncher launcher;
	
	void Start () {
        PopulateCounters();

        GameState.OnAsteroidLaunched += PopulateCounters;
	}

    private void PopulateCounters()
    {
        // destroy earlier counters
        foreach (Transform t in transform)
        {
            Destroy(t.gameObject);
        }

        for (int i = 0; i < launcher.asteroids; i++)
        {
            GameObject go = (GameObject)Instantiate(counterPreFab);
            go.transform.SetParent(transform);
        }
    }
}
