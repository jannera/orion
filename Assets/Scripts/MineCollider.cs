using UnityEngine;
using System.Collections;

public class MineCollider : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<OrionExploder>().Explode(transform.position);
        Destroy(other.gameObject);
        Destroy(this.gameObject);
    }
}
