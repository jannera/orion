using UnityEngine;
using System.Collections;

public class LaunchIndicator : MonoBehaviour {
    private AsteroidLauncher launcher;
    public Transform overlayCube;
    private float maxSize;
    private Vector3 pos;
	
	void Start () {
        launcher = GetComponentInParent<AsteroidLauncher>();
        maxSize = overlayCube.transform.localPosition.z;
        pos = overlayCube.transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(launcher.GetLaunchStatus());
        pos.z = launcher.GetLaunchStatus() * maxSize;
        overlayCube.transform.localPosition = pos;
	}
}
