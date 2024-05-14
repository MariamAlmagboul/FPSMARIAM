using System;
using UnityEngine;
using UnityStandardAssets.Utility;

namespace ControlFreak2.Demos.Racing
{
public class CarDriverHeadBob : MonoBehaviour
    {
    public CurveControlledBob motionBob = new CurveControlledBob();
    public float StrideInterval = 1.0f;
	public Rigidbody sourceRigidbody;
 
    private Vector3 m_OriginalCameraPosition;
	private Camera cam;		


    private void Start()
	    {
		this.cam = this.GetComponent<Camera>();

        motionBob.Setup(this.cam, StrideInterval);
        m_OriginalCameraPosition = this.cam.transform.localPosition;
		//.transform, Camera.transform.localPosition);
    	}


        private void Update()
        	{
			float vel = 1; //((this.sourceRigidbody != null) ? this.sourceRigidbody.velocity.magnitude : 0);

            Vector3 newCameraPosition;
            //if (rigidbodyFirstPersonController.Velocity.magnitude > 0 && rigidbodyFirstPersonController.Grounded)
          	if (vel > 0.0001f)
				{
                this.cam.transform.localPosition = motionBob.DoHeadBob(vel);
               
            	}
            else
            	{
                newCameraPosition = this.cam.transform.localPosition;
                newCameraPosition.y = m_OriginalCameraPosition.y;
	            this.cam.transform.localPosition = newCameraPosition;
            	}

            
        }
    }
}
