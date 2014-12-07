using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class AsteroidLauncher : MonoBehaviour {
    public GameObject asteroidPreFab;
    public Transform launchPoint;

    private float secsButtonHeld = 0;
    private const float maxPowerUpSecs = 1.75f;
    private bool poweringUp = false;
    private const float maxStartVelocity = 2.5f;

    public int startAsteroids = 3;
    public int asteroids;

    public AudioSource chargeUp;
    public AudioSource launch;
    public EventSystem events;

    void Awake()
    {
        asteroids = startAsteroids;

    }

	void Start () {
        poweringUp = false;
        secsButtonHeld = 0;
	}
	
	void Update () {
        if (!CanFire())
        {
            return;
        }

        if (events.currentSelectedGameObject != null)
        {
            return;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            // start calculating force and show the force bar
            poweringUp = true;
            chargeUp.Play();
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
            Quaternion rotation = Quaternion.identity;
            GameObject asteroid = (GameObject) Instantiate(asteroidPreFab, launchPoint.position, rotation);
            Rigidbody astRig = asteroid.rigidbody;

            // then cause a force on it, based on the time the button was held down
            Vector3 force = launchPoint.position - transform.position;
            force = force.normalized * astRig.mass * maxStartVelocity * (secsButtonHeld/maxPowerUpSecs);

            // put a random spin on it
            Vector3 spin = new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), Random.Range(-1, 1));
            spin *= astRig.mass;
            astRig.AddRelativeTorque(spin, ForceMode.Impulse);

            asteroid.rigidbody.AddForce(force, ForceMode.Impulse);
            poweringUp = false;
            secsButtonHeld = 0;

            asteroids--;
            chargeUp.Stop();
            launch.Play();
            GameState.LaunchAsteroid();
        }
	}

    private bool CanFire()
    {
        return asteroids > 0;
    }

    // how long button has been held, as number between 0-1
    public float GetLaunchStatus()
    {
        return secsButtonHeld / maxPowerUpSecs;
    }
}
