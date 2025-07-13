using UnityEngine;
using UnityEngine.UI;

public class BugDetector : MonoBehaviour
{
    public GameObject infoPanel;
    public Text bugNameText;
    public Text bugDescriptionText;

    private void Start()
    {
        infoPanel.SetActive(false); // Sembunyikan di awal
    }

    private void OnTriggerEnter(Collider other)
    {
        BugInfo bug = other.GetComponent<BugInfo>();
        if (bug != null)
        {
            ShowBugInfo(bug);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        BugInfo bug = other.GetComponent<BugInfo>();
        if (bug != null)
        {
            ClosePanel();
        }
    }

    void ShowBugInfo(BugInfo bug)
    {
        if (bugNameText != null) bugNameText.text = bug.bugName;
        if (bugDescriptionText != null) bugDescriptionText.text = bug.bugDescription;
        if (infoPanel != null) infoPanel.SetActive(true);
    }

    public void ClosePanel()
    {
        if (infoPanel != null) infoPanel.SetActive(false);
    }
}
