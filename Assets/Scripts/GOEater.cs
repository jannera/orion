using UnityEngine;
using System.Collections;

public class GOEater : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
}
