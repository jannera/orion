using UnityEngine;
using System.Collections;

public class AsteroidLauncher : MonoBehaviour {
    public GameObject asteroidPreFab;
    public Transform launchPoint;

    private float secsButtonHeld = 0;
    private const float maxPowerUpSecs = 3f;
    private bool poweringUp = false;
    private const float maxStartVelocity = 20/8f;

	void Start () {
	
	}
	
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            // start calculating force and show the force bar
            poweringUp = true;
        }

        if (poweringUp)
        {
            secsButtonHeld += Time.deltaTime;
            secsButtonHeld = Mathf.Clamp(secsButtonHeld, 0, maxPowerUpSecs);
        }

        if (Input.GetButtonUp("Fire1"))
        {
            // launch the asteroid
            
            // first create it
            Quaternion rotation = Quaternion.identity; // todo create a random rotation instead
            GameObject asteroid = (GameObject) Instantiate(asteroidPreFab, launchPoint.position, rotation);
            Rigidbody astRig = asteroid.rigidbody;

            // then cause a force on it, based on the time the button was held down
            Vector3 force = launchPoint.position - transform.position;
            force = force.normalized * astRig.mass * maxStartVelocity * (secsButtonHeld/maxPowerUpSecs);

            asteroid.rigidbody.AddForce(force, ForceMode.Impulse);
            poweringUp = false;
            secsButtonHeld = 0;
        }
	}
}
