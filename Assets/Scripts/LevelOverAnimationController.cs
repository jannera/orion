using UnityEngine;
using System.Collections;

public class LevelOverAnimationController : MonoBehaviour {
    private Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        GameState.OnLevelCompleted += delegate()
        {
            anim.SetTrigger("LevelCompleted");
        };
        GameState.OnLevelFailed += delegate()
        {
            anim.SetTrigger("LevelFailed");
        };
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
