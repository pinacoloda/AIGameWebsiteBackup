using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {
	public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
	public RotationAxes axes = RotationAxes.MouseXAndY;
    private Vector3 offset;
    public GameObject player;

	public float sensitivityX = 15F;
	public float sensitivityY = 15F;
	public float minimumX = -360F;
	public float maximumX = 360F;
	public float minimumY = -60F;
	public float maximumY = 60F;
    public bool inverseY;

	float rotationY = 0F;

	void Update ()
	{
		if (axes == RotationAxes.MouseXAndY)
		{
            // Clamp Y amount of degrees to view up and down
            float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;
			
			rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
			rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);

            if (inverseY)
                transform.eulerAngles = new Vector3(0, rotationX, -rotationY);
            else
                transform.eulerAngles = new Vector3(0, rotationX, rotationY);


            /*
            if(inverseY)
			    transform.localEulerAngles = new Vector3(0, rotationX, -rotationY);
            else
                transform.localEulerAngles = new Vector3(0, rotationX, rotationY);
                */
        }
		else if (axes == RotationAxes.MouseX)
		{
			//transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
		}
		else
		{
            
			rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
			rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
			
			transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
		}
	}

    // Both functions below are used to make the capsule with main camera follow the player and doesn't rotate with it.
    void LateUpdate()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        transform.position = player.transform.position + offset;
    }

   
    void Start ()
	{
        
		// Make the rigid body not change rotation
		if (GetComponent<Rigidbody>())
			GetComponent<Rigidbody>().freezeRotation = true;

        offset = transform.position - player.transform.position;
    }
}