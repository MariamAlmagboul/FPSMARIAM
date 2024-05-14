using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autodisablescript : MonoBehaviour
{
    // Start is called before the first frame update
    void OnEnable()
    {
        Invoke("disableit", 1.0f);
    }
   public void disableit()
    {
        this.gameObject.SetActive(false);
    }
}
