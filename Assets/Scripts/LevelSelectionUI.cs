using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelSelectionUI : MonoBehaviour {
    public int lvlNumber;

	void Start () {
        GetComponentInChildren<Text>().text = "Level " + lvlNumber;
	}

    public void ChangeLevel()
    {
        GameState.ResetListeners();
        Application.LoadLevel(lvlNumber);
    }
}
