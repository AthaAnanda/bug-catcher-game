using UnityEngine;

[CreateAssetMenu(fileName = "New Bug Data", menuName = "Bug/Create New Bug")]
public class BugData : ScriptableObject
{
    [Header("Informasi Serangga")]
    public string bugName;
    [TextArea]
    public string bugDescription;
}
