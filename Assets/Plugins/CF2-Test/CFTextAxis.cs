using UnityEngine;
using System.Collections;

public class CFTextAxis : MonoBehaviour {
	
	public string axisName = "Horizontal";
	public float val;

	void Update () 
		{
	
		this.val = ControlFreak2.CF2Input.GetAxis (this.axisName);
		}
}
