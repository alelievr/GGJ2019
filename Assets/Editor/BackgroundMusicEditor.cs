using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BackgroundMusic))]
public class BackgroundMusicEditor : Editor
{
    BackgroundMusic     music;

    private void OnEnable()
    {
        music = target as BackgroundMusic;
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        // EditorGUILayout.Vector3Field("Happy start",  music.happyStart.position);
        // EditorGUILayout.Vector3Field("Happy End",  music.happyEnd.position);
        // EditorGUILayout.Vector3Field("Mood start",  music.moodStart.position);
        // EditorGUILayout.Vector3Field("Mood End",  music.moodEnd.position);
    }

    public void OnSceneGUI()
    {
        music.happyStart.position = Handles.PositionHandle(music.happyStart.position, Quaternion.identity);
        music.happyEnd.position = Handles.PositionHandle(music.happyEnd.position, Quaternion.identity);
        music.moodStart.position = Handles.PositionHandle(music.moodStart.position, Quaternion.identity);
        music.moodEnd.position = Handles.PositionHandle(music.moodEnd.position, Quaternion.identity);

        Handles.Label(music.happyStart.position, "Happy start");
        Handles.Label(music.happyEnd.position, "Happy end");
        Handles.Label(music.moodStart.position, "Mood start");
        Handles.Label(music.moodEnd.position, "Mood end");
    }
}
