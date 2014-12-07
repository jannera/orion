using UnityEngine;
using System.Collections;

public class GravityAttractor : MonoBehaviour {
    private Vector3 force = new Vector3();
    public AnimationCurve forceCurve;

	void FixedUpdate()
    {
        GameObject[] asteroids = GameObject.FindGameObjectsWithTag("Asteroid");
        
        for (int i = 0; i < asteroids.Length; i++)
        {
            force = transform.position - asteroids[i].transform.position;
            float dst = force.magnitude;
            force.Normalize();
            force *= forceCurve.Evaluate(dst);
            force *= Time.deltaTime;

            asteroids[i].rigidbody.AddForce(force, ForceMode.VelocityChange);
        }
    }
}
