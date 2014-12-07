using UnityEngine;
using System.Collections;

public class BlackholeCollisionListener : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        Rigidbody r = other.gameObject.GetComponent<Rigidbody>();
        r.isKinematic = true;
        other.gameObject.GetComponent<Animator>().SetTrigger("StartDescent");
    }
}
