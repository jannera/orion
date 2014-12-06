using UnityEngine;
using System.Collections;

public class MouseFollow : MonoBehaviour {
    int floorMask;
    float camRayLength = 100f;
    public float smoothTurning = 10f;
    Quaternion targetRotation;

	void Start () {
        floorMask = LayerMask.GetMask("Floor");
	}
	
	void Update () {
        UpdateRotationFromMouse();
        SmoothRotation();
	}

    private void UpdateRotationFromMouse()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit floorHit;

        if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        {
            Vector3 playerToMouse = floorHit.point - transform.position;

            playerToMouse.y = 0f;

            targetRotation = Quaternion.LookRotation(playerToMouse);
        }
    }

    private void SmoothRotation()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * smoothTurning);
    }
}
