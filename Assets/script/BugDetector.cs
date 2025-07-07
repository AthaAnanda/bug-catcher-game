using UnityEngine;
using UnityEngine.UI;

public class BugDetector : MonoBehaviour
{
    public GameObject infoPanel;
    public Text bugNameText;
    public Text bugDescriptionText;

    void Start()
    {
        infoPanel.SetActive(false); // Sembunyikan panel saat awal
    }

    private void OnTriggerEnter(Collider other)
    {
        BugInfo bug = other.GetComponent<BugInfo>();
        if (bug != null)
        {
            ShowBugInfo(bug);
        }
    }

    void ShowBugInfo(BugInfo bug)
    {
        bugNameText.text = bug.bugName;
        bugDescriptionText.text = bug.bugDescription;
    }

    public void ClosePanel()
    {
        infoPanel.SetActive(false);
    }
}
