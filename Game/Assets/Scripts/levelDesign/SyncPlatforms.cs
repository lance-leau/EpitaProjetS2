using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SyncPlatforms : MonoBehaviour
{
    [Header("Platform Ancher")]
    [SerializeField] Transform AncherA;
    [SerializeField] Transform AncherB;

    [Header("Platform Control")]
    [SerializeField] float PlatformSpeed = 0.01f;

    float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = Mathf.Ceil((float)PhotonNetwork.Time % 100)/100;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer = (Mathf.Round((timer + PlatformSpeed)*100)/100)%1;

        if (timer == 0 || timer == 1) (AncherA, AncherB) = (AncherB, AncherA);
        movePlatform(timer);        
    }

    void movePlatform(float timer)
    {
        transform.position = new Vector3(Mathf.Lerp(AncherA.position.x, AncherB.position.x, timer), Mathf.Lerp(AncherA.position.y, AncherB.position.y, timer), Mathf.Lerp(AncherA.position.z, AncherB.position.z, timer));
        print(timer);
    }
}
