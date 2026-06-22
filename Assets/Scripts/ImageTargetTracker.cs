using UnityEngine;
using Vuforia;

public class ImageTargetTracker : MonoBehaviour
{
    private ObserverBehaviour _observer;
    private MarkerInfo _markerInfo;

    private void Start()
    {
        _observer = GetComponent<ObserverBehaviour>();
        _markerInfo = GetComponent<MarkerInfo>();

        _observer.OnTargetStatusChanged += OnStatusChanged;
    }

    private void OnStatusChanged(ObserverBehaviour behaviour, TargetStatus status)
    {
        bool tracked =
            status.Status == Status.TRACKED ||
            status.Status == Status.EXTENDED_TRACKED;

        if (tracked)
        {
            InfoManagerAR.instance.SetCurrentMarker(_markerInfo);
        }
        else
        {
            InfoManagerAR.instance.ClearMarker(_markerInfo);
        }
    }

    private void OnDestroy()
    {
        if (_observer != null)
        {
            _observer.OnTargetStatusChanged -= OnStatusChanged;
        }
    }
}