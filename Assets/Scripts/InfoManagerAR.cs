using UnityEngine;
using TMPro;

public class InfoManagerAR : MonoBehaviour
{
    public static InfoManagerAR instance;

    [Header("UI")]
    public GameObject _infoPanel;
    public TMP_Text _infoText;

    private MarkerInfo _currentMarker;
    private bool panelOpen;

    private void Awake()
    {
        instance = this;
    }

    // Called when ANY marker is tracked
    public void SetCurrentMarker(MarkerInfo marker)
    {
        _currentMarker = marker;

        // Update instantly if panel is open
        if (panelOpen && _currentMarker != null)
        {
            _infoText.text = _currentMarker.information;
        }
    }

    public void ClearMarker(MarkerInfo marker)
    {
        if (_currentMarker == marker)
        {
            _currentMarker = null;

            // optional: keep panel open but show message
            if (panelOpen)
            {
                _infoText.text = "No marker detected";
            }
        }
    }

    // INFO BUTTON
    public void ShowInfo()
    {
        panelOpen = true;
        _infoPanel.SetActive(true);

        if (_currentMarker != null)
        {
            _infoText.text = _currentMarker.information;
        }
        else
        {
            _infoText.text = "No marker detected";
        }
    }

    // CLOSE BUTTON
    public void CloseInfo()
    {
        panelOpen = false;
        _infoPanel.SetActive(false);
    }
}