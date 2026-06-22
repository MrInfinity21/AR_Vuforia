using UnityEngine;
using TMPro;

public class InfoManagerAR : MonoBehaviour
{
    public static InfoManagerAR instance;

    [Header("UI (Info Canvas ONLY)")]
    public GameObject infoPanel;
    public TMP_Text infoText;

    private MarkerInfo currentMarker;
    private bool panelOpen;

    private void Awake()
    {
        instance = this;
    }

    // Called when marker is detected
    public void SetCurrentMarker(MarkerInfo marker)
    {
        currentMarker = marker;

        // Auto update if panel is open
        if (panelOpen && currentMarker != null)
        {
            infoText.text = currentMarker.information;
        }
    }

    // Called when marker lost
    public void ClearMarker(MarkerInfo marker)
    {
        if (currentMarker == marker)
        {
            currentMarker = null;

            if (panelOpen)
            {
                infoText.text = "No marker detected";
            }
        }
    }

    // BUTTON: Show Info (DOES NOT TOUCH CANVAS)
    public void ShowInfo()
    {
        panelOpen = true;
        infoPanel.SetActive(true);

        if (currentMarker != null)
        {
            infoText.text = currentMarker.information;
        }
        else
        {
            infoText.text = "No marker detected";
        }
    }

    // BUTTON: Close Info
    public void CloseInfo()
    {
        panelOpen = false;
        infoPanel.SetActive(false);
    }
}