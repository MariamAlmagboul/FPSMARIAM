using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playertrigger : MonoBehaviour
{
    public void OnCollisionEnter(Collision other)
    {
       
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "bluekey")
        {
            Destroy(other.gameObject);
            GameManagerGP.instance.bluekey = true;
            GameManagerGP.instance.bluekeyimage.SetActive(true);
            GameManagerGP.instance.keystatus.gameObject.SetActive(true);
            GameManagerGP.instance.keystatus.text = "Blue key collected.";
        }
        if (other.gameObject.tag == "redkey")
        {
            Destroy(other.gameObject);
            GameManagerGP.instance.redkey = true;
            GameManagerGP.instance.redkeyimage.SetActive(true);
            GameManagerGP.instance.keystatus.gameObject.SetActive(true);
            GameManagerGP.instance.keystatus.text = "Red key collected.";
        }
        if (other.gameObject.tag == "greenkey")
        {
            Destroy(other.gameObject);
            GameManagerGP.instance.greenkey = true;
            GameManagerGP.instance.greenkeyimage.SetActive(true);
            GameManagerGP.instance.keystatus.gameObject.SetActive(true);
            GameManagerGP.instance.keystatus.text = "Green key collected.";
        }
        if (other.gameObject.tag == "bluedoor")
        {
            if (GameManagerGP.instance.bluekey == true)
            {
                Destroy(other.gameObject);
                GameManagerGP.instance.bluekeyimage.SetActive(false);
                GameManagerGP.instance.keystatus.gameObject.SetActive(true);
                GameManagerGP.instance.keystatus.text = "Door opened.";
            }
            else if (GameManagerGP.instance.bluekey == false)
            {
                GameManagerGP.instance.keystatus.gameObject.SetActive(true);
                GameManagerGP.instance.keystatus.text = "you do not have a specific key.";
            }
        }
        if (other.gameObject.tag == "reddoor")
        {
            if (GameManagerGP.instance.redkey == true)
            {
                Destroy(other.gameObject);
                GameManagerGP.instance.redkeyimage.SetActive(false);
                GameManagerGP.instance.keystatus.gameObject.SetActive(true);
                GameManagerGP.instance.keystatus.text = "Door opened.";
            }
            else if (GameManagerGP.instance.redkey == false)
            {
                GameManagerGP.instance.keystatus.gameObject.SetActive(true);
                GameManagerGP.instance.keystatus.text = "you do not have a specific key.";
            }
        }
        if (other.gameObject.tag == "greendoor")
        {
            if (GameManagerGP.instance.greenkey == true)
            {
                Destroy(other.gameObject);
                GameManagerGP.instance.greenkeyimage.SetActive(false);
                GameManagerGP.instance.keystatus.gameObject.SetActive(true);
                GameManagerGP.instance.keystatus.text = "Door opened.";
            }
            else if (GameManagerGP.instance.greenkey == false)
            {
                GameManagerGP.instance.keystatus.gameObject.SetActive(true);
                GameManagerGP.instance.keystatus.text = "you do not have a specific key.";
            }
        }
    }
}
