using UnityEngine;
using System.Collections;

public class LastAsteroidListener : MonoBehaviour {
    private AsteroidLauncher launcher;
    private bool levelCompletedWithinTime;
    private bool lastAsteroidLaunched;
    public float secsToLiveAfterLastLaunch = 10f;
    private float timer = 0;

	void Start () {
        launcher = GetComponent<AsteroidLauncher>();
        GameState.OnAsteroidLaunched += AsteroidLaunched;
	}

    void Update()
    {
        if (lastAsteroidLaunched && !levelCompletedWithinTime)
        {
            timer += Time.deltaTime;

            if (timer > secsToLiveAfterLastLaunch)
            {
                GameState.LevelFailed();
                lastAsteroidLaunched = false;
            }
        }
    }

    private void AsteroidLaunched()
    {
        if (launcher.asteroids <= 0)
        {
            GameState.OnLevelCompleted += delegate()
            {
                levelCompletedWithinTime = true;
            };
            lastAsteroidLaunched = true;
        }
    }
}
