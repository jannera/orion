using UnityEngine;
using System.Collections;
using System;

public class OrionExploder : MonoBehaviour {
    [Serializable]
    public class ExplosionPair
    {
        public Transform sourcePart;
        public GameObject destinationPreFab;
    }

    public ExplosionPair[] partLinks;

    private const float maxRotation = 2f;

    public void Explode(Vector3 explosionPos)
    {
        for (int i = 0; i < partLinks.Length; i++)
        {
            ExplosionPair p = partLinks[i];
            GameObject go = (GameObject) Instantiate(p.destinationPreFab, p.sourcePart.transform.position, p.sourcePart.transform.rotation);
            go.rigidbody.AddExplosionForce(1, explosionPos, 0, 0, ForceMode.VelocityChange);
            go.rigidbody.AddTorque(UnityEngine.Random.insideUnitSphere * maxRotation, ForceMode.VelocityChange);
        }
    }
}
