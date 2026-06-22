using UnityEngine;
using TMPro;

public class InfoManagerAR : MonoBehaviour
{
    public static InfoManagerAR instance;

    [Header("UI")]
    public GameObject infoPanel;
    public TMP_Text infoText;

    private MarkerInfo currentMarker;

    private void Awake()
    {
        instance = this;
    }

    // Called when marker is detected
    public void SetCurrentMarker(MarkerInfo marker)
    {
        currentMarker = marker;
    }

    // Called when marker is lost
    public void ClearMarker(MarkerInfo marker)
    {
        if (currentMarker == marker)
        {
            currentMarker = null;
        }
    }

    //  INFO BUTTON (OPEN ONLY)
    public void ShowInfo()
    {
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

    //  CLOSE BUTTON
    public void CloseInfo()
    {
        infoPanel.SetActive(false);
    }
}