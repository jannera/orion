using UnityEngine;
using System.Collections;

public class RandomRotation : MonoBehaviour {
    public float maxSpin = 1f;

	void Start () {
        Vector3 spin = new Vector3(Random.Range(-maxSpin, maxSpin), Random.Range(-maxSpin, maxSpin), Random.Range(-maxSpin, maxSpin));
        spin *= rigidbody.mass;
        rigidbody.AddTorque(spin, ForceMode.Impulse);
	}
}
