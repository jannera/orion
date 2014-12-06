using UnityEngine;
using System.Collections;

public class GravityAttractor : MonoBehaviour {
    private const float GRAV_CONSTANT = 6.673E-5f;
    private Vector3 force = new Vector3();

	void FixedUpdate()
    {
        GameObject[] asteroids = GameObject.FindGameObjectsWithTag("Asteroid");
        
        for (int i = 0; i < asteroids.Length; i++)
        {
            force = transform.position - asteroids[i].transform.position;
            float dstSqr = force.sqrMagnitude;
            force.Normalize();
            force *= GetForceBetween(rigidbody, asteroids[i].rigidbody, dstSqr);
            force *= Time.deltaTime;

            asteroids[i].rigidbody.AddForce(force);
        }
    }

    private float GetForceBetween(Rigidbody a, Rigidbody b, float dstSqr)
    {
        return GRAV_CONSTANT * a.mass * b.mass / dstSqr;
    }
}
