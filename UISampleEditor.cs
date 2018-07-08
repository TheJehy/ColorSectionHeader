using UnityEditor;



[CustomEditor(typeof(UISample))]
public class UISampleEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
    }
}