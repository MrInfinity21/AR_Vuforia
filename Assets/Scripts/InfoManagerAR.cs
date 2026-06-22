using UnityEngine;
using TMPro;
public class InfoManagerAR : MonoBehaviour
{
    public static InfoManagerAR instance;

    [Header("UI")]
    public GameObject _infoPanel;
    public TMP_Text _infoText;

    private MarkerInfo _currentMarker;
    private bool panelOpen = false;

    private void Awake()
    {
        instance = this;
    }

    public void SetCurrentMarker(MarkerInfo marker)
    {
        _currentMarker = marker;

        if(panelOpen)
        {
            _infoText.text = marker.information;
        }
    }

    public void ClearMarker(MarkerInfo marker)
    {
        if (_currentMarker == marker)
        {
            _currentMarker = null;

            if (panelOpen)
            {
                _infoText.text = "No marker detected";
            }
        }
    }


    public void ShowInfo()
    {
        if (_currentMarker == null)
        {
            _infoText.text = "No marker detected";
        }
        else
        {
            _infoText.text = _currentMarker.information;
        }

        panelOpen = true;
        _infoPanel.SetActive(true);
    }

    public void CloseInfo()
    {
        panelOpen = false;
        _infoPanel.SetActive(false);
    }




}
