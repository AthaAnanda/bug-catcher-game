// using UnityEngine;

// public class BugInfo : MonoBehaviour
// {
//     [Header("Informasi Serangga")]
//     public string bugName;
//     [TextArea] public string bugDescription;
// }


using UnityEngine;

public class BugInfo : MonoBehaviour
{
    [Header("Data Serangga")]
    public BugData bugData;

    [HideInInspector] public string bugName;
    [HideInInspector] public string bugDescription;

    void Start()
    {
        if (bugData != null)
        {
            bugName = bugData.bugName;
            bugDescription = bugData.bugDescription;
        }
        else
        {
            Debug.LogWarning("BugData belum di-assign di " + gameObject.name);
        }
    }
}
