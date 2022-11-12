using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PressButton : MonoBehaviour
{

    private GameObject redPlatform;
    private GameObject bluePlatform;
    private GameObject greenPlatform;

    private Renderer redRenderer;
    private Renderer blueRenderer;
    private Renderer greenRenderer;

    private BoxCollider redCollider;
    private BoxCollider blueCollider;
    private BoxCollider greenCollider;

    void Start()
    {
        redPlatform = GameObject.Find("redDoor(Clone)");
        redRenderer = redPlatform.GetComponent<MeshRenderer>();
        redCollider = redPlatform.GetComponent<BoxCollider>();
        bluePlatform = GameObject.Find("blueDoor(Clone)");
        blueRenderer = bluePlatform.GetComponent<MeshRenderer>();
        blueCollider = bluePlatform.GetComponent<BoxCollider>();
        // greenPlatform = GameObject.Find("greenDoor(Clone)");
        // greenRenderer = greenPlatform.GetComponent<MeshRenderer>();
        // greenCollider = greenPlatform.GetComponent<BoxCollider>();

        // start state:
        deactivateBlue();
    }
    

    void OnTriggerEnter(Collider collision)
    {
        switch(collision.gameObject.layer)
        {
            case 7: // destroy
                PhotonNetwork.Destroy(this.gameObject);
                break;
            case 8: // red
                deactivateRed();
                break;
            case 9: // blue
                toggleBlue(); 
                break;
            case 10: // red
                deactivateGreen();
                break;
            default:
                break;
        }
    }

    void OnTriggerExit(Collider collision)
    {
        switch(collision.gameObject.layer)
        {
            case 8: // red
                activateRed();
                break;
            case 9: // blue
                // toggleBlue();
                break;
            case 10: // red
                activateRed();
                break;                
            default:
                break;
        }
    }

    void activateRed()
    {
        redRenderer.enabled = true;
        redCollider.enabled = true;
    }

    void deactivateRed()
    {
        redRenderer.enabled = false;
        redCollider.enabled = false;
    }

     void activateGreen()
    {
        greenRenderer.enabled = true;
        greenCollider.enabled = true;
    }

    void deactivateGreen()
    {
        greenRenderer.enabled = false;
        greenCollider.enabled = false;
    }

    void toggleBlue()
    {
        if (bluePlatform.GetComponent<MeshRenderer>().enabled) 
            deactivateBlue();
        else
            activateBlue();
    }

    void activateBlue()
    {
        blueRenderer.enabled = true;
        blueCollider.enabled = true;
    }

    void deactivateBlue()
    {
        blueRenderer.enabled = false;
        blueCollider.enabled = false;
    }
}
