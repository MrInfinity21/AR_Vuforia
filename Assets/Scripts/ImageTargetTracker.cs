using UnityEngine;
using Vuforia;

public class ImageTargetTracker : MonoBehaviour
{
    private ObserverBehaviour observer;
    private MarkerInfo markerInfo;

    private void Start()
    {
        observer = GetComponent<ObserverBehaviour>();
        markerInfo = GetComponent<MarkerInfo>();

        observer.OnTargetStatusChanged += OnStatusChanged;
    }

    private void OnStatusChanged(ObserverBehaviour behaviour, TargetStatus status)
    {
        bool tracked =
            status.Status == Status.TRACKED ||
            status.Status == Status.EXTENDED_TRACKED;

        if (tracked)
        {
            InfoManagerAR.instance.SetCurrentMarker(markerInfo);
        }
        else
        {
            InfoManagerAR.instance.ClearMarker(markerInfo);
        }
    }

    private void OnDestroy()
    {
        if (observer != null)
        {
            observer.OnTargetStatusChanged -= OnStatusChanged;
        }
    }
}