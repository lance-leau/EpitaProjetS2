using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerSplit : MonoBehaviour
{

    [SerializeField] GameObject blob;
    private Transform player;
    private PlayerMouvement playerMouvement;

    public int blobNumber;
    private int blobCounter = 1;

    bool splitReady = false;

    PhotonView view;

    // Start is called before the first frame update
    void Start()
    {
        view = GetComponentInParent<PhotonView>();
        player = GetComponentInParent<Transform>();
        playerMouvement = GetComponent<PlayerMouvement>();
        Invoke(nameof(setCollider), .5f);
        Invoke(nameof(resetSplit), 1.0f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (view.IsMine)
        {
            if (transform.localScale[0] > 1 && splitReady)
            {
                if (Input.GetKey("up")) split(new Vector3(0, 50, 0));
                if (Input.GetKey("down")) split(new Vector3(0, -50, 0));
                if (Input.GetKey("left")) split(new Vector3(0, 0, -50));
                if (Input.GetKey("right")) split(new Vector3(0, 0, 50));
            }
        }
        
    }

    private int _blobCounter()
    {
        return blobCounter += blobNumber;
    }

    void split(Vector3 vect)
    {
        // float scale = Mathf.Pow(Mathf.Pow(transform.lossyScale[0], 3)/2, (1/3));
        this.transform.localScale /= 1.5f;
        playerMouvement.playerHeight /= 1.5f;

        GameObject blobCopy = PhotonNetwork.Instantiate("PlayerBody", this.transform.position, this.transform.rotation);
        blobCopy.transform.parent = player.parent;
        

        splitReady = false;
        blobCopy.transform.localScale = this.transform.localScale;
        blobCopy.GetComponent<PlayerMouvement>().playerHeight /= 1.5f;
        blobCopy.GetComponent<PlayerSplit>().blobNumber += _blobCounter();
        blobCounter *= 2;

        blobCopy.GetComponent<Rigidbody>().AddForce(vect, ForceMode.Impulse);
        Invoke(nameof(resetSplit), 1f);
    }

    void resetSplit()
    {
        splitReady = true;
    }

    void setCollider()
    {
        GetComponent<Collider>().enabled = true;
    }
}
