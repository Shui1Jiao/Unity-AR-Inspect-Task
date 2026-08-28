using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic;

public class ARMarkerPlacer : MonoBehaviour
{
    public GameObject markerPrefab;
    public ReportUIManager reportUIManager;

    private ARRaycastManager raycastManager;
    private GameObject spawnedMarker;
    private List<ARRaycastHit> hitsList = new List<ARRaycastHit>();

    void Awake()
    {
        raycastManager = GetComponent<ARRaycastManager>();
    }

    void Update()
    {
        if (Input.touchCount == 0) return;
        Touch touch = Input.GetTouch(0);
        if (touch.phase != TouchPhase.Began) return;

        if (raycastManager.Raycast(touch.position, hitsList, TrackableType.PlaneWithinPolygon))
        {
            var hitPose = hitsList[0].pose;
            if (spawnedMarker == null)
            {
                spawnedMarker = Instantiate(markerPrefab, hitPose.position, hitPose.rotation);
            }
            else
            {
                spawnedMarker.transform.SetPositionAndRotation(hitPose.position, hitPose.rotation);
            }
            reportUIManager.ShowPanel(spawnedMarker.transform);
        }
    }
}
