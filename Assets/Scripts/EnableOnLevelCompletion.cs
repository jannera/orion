using UnityEngine;
using System.Collections;

public class EnableOnLevelCompletion : MonoBehaviour {
    public Behaviour toBeEnabled;

	void Start() {
        GameState.OnLevelCompleted += delegate()
        {
            toBeEnabled.enabled = true;
        };
	}
}
