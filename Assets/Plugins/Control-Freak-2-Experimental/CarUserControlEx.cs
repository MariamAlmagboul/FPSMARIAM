
// ----------------------------------
// Most of the code comes from Unity Standard Assets CarUserControl.cs.
// ----------------------------------

using ControlFreak2;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

namespace ControlFreak2.Demos.Racing
{
[RequireComponent(typeof (CarController))]
public class CarUserControlEx : MonoBehaviour
	{
	public bool autoAcceleration = false;

	private CarController m_Car;

		
	// -----------------
	private void Awake()
		{
		m_Car = GetComponent<CarController>();
        }


	// -----------------
	private void FixedUpdate()
    	{
		float h	= CF2Input.GetAxis("Horizontal");
		float v = CF2Input.GetAxis("Vertical");
		float handbrake = CF2Input.GetAxis("Jump");
			
		

		m_Car.Move(h, ((this.autoAcceleration && (v >= 0.0f)) ? 1.0f : v) , v, handbrake);
		}
	}
}
