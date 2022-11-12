using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class FollowPlayer : MonoBehaviour
{

    public List<GameObject> players;
    private List<Transform> targets = new List<Transform>();

    public Vector3 offset;
    public float smoothSpeed = 0.5f;
    private Vector3 velocity;

    public float minZoom = 40f;
    public float maxZoom = 10f;
    public float zoomLimiter = 50f;

    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
        //players.Add(GameObject.Find("Player(Clone)"));
    }

    Vector3 GetAveragePos()
    {
        if (targets.Count == 1) return targets[0].transform.position;

        var bounds = new Bounds(targets[0].transform.position, Vector3.zero);
        foreach(var target in targets)
        {
            bounds.Encapsulate(target.transform.position);
        }

        return bounds.center;
    }

    void Update() 
    {
        UpdateList();

        if (targets.Count == 0) return;

        Move();
        Zoom();
    }

    void UpdateList()
    {
        targets.Clear();
        foreach (GameObject player in players)
        {
            foreach (Transform target in player.transform) targets.Add(target);
        }
    }

    void Move()
    {
        if (targets.Count != 0)
        {
            Vector3 desiredPosition = GetAveragePos() + offset;
            transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed);
        }
    }

    void Zoom()
    {
        float newZoom = Mathf.Lerp(maxZoom, minZoom, GetGreatestDistance() / zoomLimiter);
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, newZoom, Time.deltaTime);
    }

    float GetGreatestDistance()
    {
        var bounds = new Bounds(targets[0].position, Vector3.zero);
        foreach(var target in targets)
        {
            bounds.Encapsulate(target.transform.position);
        }

        return Mathf.Max(bounds.size.x, bounds.size.y);
    }

}
