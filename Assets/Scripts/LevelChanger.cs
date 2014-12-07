using UnityEngine;
using System.Collections;

public class LevelChanger : MonoBehaviour {
    private bool wasLevelCompleted;
    private LevelRestarter restarter;

	// Use this for initialization
	void Start () {
        wasLevelCompleted = LevelCompletion.HasCurrentLevelBeenCompleted();
        restarter = GetComponent<LevelRestarter>();
	}

    public void LevelCompletionAnimationOver()
    {
        if (!wasLevelCompleted)
        {
            // first time this level was completed. move on to the next level
            GameState.ResetListeners();
            int nextLevel = Mathf.Clamp(Application.loadedLevel + 1, 0, Application.levelCount - 1);
            Debug.Log(Application.loadedLevel + " -> " + nextLevel);
            Application.LoadLevel(nextLevel);
        }
        else
        {
            restarter.RestartCurrentLevel();
        }
    }
}
