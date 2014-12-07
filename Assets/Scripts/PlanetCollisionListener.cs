﻿using UnityEngine;
using System.Collections;

public class PlanetCollisionListener : MonoBehaviour {

	void OnTriggerEnter(Collider other)
    {
        LevelCompletion.MarkCurrentLevelCompleted();
        GameState.LevelCompleted();
        Rigidbody r = other.gameObject.GetComponent<Rigidbody>();
        r.isKinematic = true;
        other.gameObject.GetComponent<Animator>().SetTrigger("StartDescent");
    }
}
