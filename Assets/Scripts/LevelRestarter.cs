using UnityEngine;
using System.Collections;

public class LevelRestarter : MonoBehaviour {
    public void RestartCurrentLevel()
    {
        GameState.ResetListeners();
        Application.LoadLevel(Application.loadedLevel);
    }
}
