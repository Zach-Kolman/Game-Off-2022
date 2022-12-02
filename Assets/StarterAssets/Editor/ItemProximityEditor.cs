using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(JournalEntryGlow))]

public class ItemProximityEditor : Editor
{
    private void OnSceneGUI()
    {
        JournalEntryGlow proximity = (JournalEntryGlow)target;
        Handles.color = Color.white;
        Handles.DrawWireArc(proximity.transform.position, Vector3.up, Vector3.forward, 360, proximity.glowRadius);
    }
}
