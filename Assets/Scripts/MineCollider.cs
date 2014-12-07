using UnityEngine;
using System.Collections;

public class MineCollider : MonoBehaviour {
    private AudioSource audio;
    private ParticleSystem particle;
    private Animator anim;
	// Use this for initialization
	void Start () {
        audio = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        particle = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<OrionExploder>().Explode(transform.position);
        foreach (Transform t in transform)
        {
            t.gameObject.SetActive(false);
        }
        audio.Play();
        particle.Play();
        anim.SetTrigger("Explode");
        Destroy(other.gameObject);
    }
}
