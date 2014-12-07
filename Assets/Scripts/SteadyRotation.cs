using UnityEngine;
using System.Collections;

public class SteadyRotation : MonoBehaviour {
    public Vector3 spin;
	
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        Vector3 diff = -(rigidbody.angularVelocity - spin);
        rigidbody.AddTorque(diff * Time.deltaTime, ForceMode.VelocityChange);
    }
}
