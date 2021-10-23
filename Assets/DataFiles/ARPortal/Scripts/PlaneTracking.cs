using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;

public class PlaneTracking : MonoBehaviour
{
    public ARRaycastManager arRay;
    public Transform planeMarker;
    public GameObject arObjectPrefab;
    public GameObject instruction;

    private List<ARRaycastHit> hits = new List<ARRaycastHit>();
    private Pose hitPose;
    private Vector2 point;
    private bool isSpawned = false;

    // Update is called once per frame
    void Update()
    {
        if (isSpawned == false)
        {
            point = new Vector2(Screen.width, Screen.height) / 2f;
            if(arRay.Raycast(point, hits, TrackableType.Planes))
            {
                hitPose = hits[0].pose;
                planeMarker.position = hitPose.position;
                planeMarker.rotation = hitPose.rotation;
                instruction.SetActive(false);
            }
        }

        if (isSpawned == false && Input.GetMouseButtonDown(0))
        {
            SpawnObject();
        }
    }

    public void SpawnObject()
    {
        GameObject item = Instantiate(arObjectPrefab);
        item.transform.position = hitPose.position;
        item.transform.rotation = hitPose.rotation;
        Destroy(planeMarker.gameObject);
        isSpawned = true;
    }
}
