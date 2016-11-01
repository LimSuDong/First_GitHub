using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(MidiPlayer))]
public class MidiPlayerEditor : Editor
{

    SerializedProperty midi;
    SerializedProperty music;
    SerializedProperty audioSource;
    SerializedProperty playDelayTime;
    SerializedProperty playSpeed;

    // Use this for initialization
    void OnEnable()
    {
        midi = serializedObject.FindProperty("midi");
        music = serializedObject.FindProperty("music");
        audioSource = serializedObject.FindProperty("audioSource");
        playDelayTime = serializedObject.FindProperty("playDelayTime");
        playSpeed = serializedObject.FindProperty("playSpeed");
    }

    // Update is called once per frame
    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(midi);
        EditorGUILayout.PropertyField(music);
        EditorGUILayout.PropertyField(audioSource);
        EditorGUILayout.PropertyField(playDelayTime);
        EditorGUILayout.PropertyField(playSpeed);

        serializedObject.ApplyModifiedProperties();

        MidiPlayer midiplayer = (MidiPlayer)target;

        if (Application.isPlaying == true)
        {
            GUILayout.BeginHorizontal();
            if (midiplayer.IsPlaying == true)
            {
                if (GUILayout.Button("Pause") == true)
                {
                    midiplayer.Pause();
                }
                EditorUtility.SetDirty(target);

            }
            else
            {
                if (midiplayer.playTime == 0)
                {
                    if (GUILayout.Button("Play") == true)
                    {
                        midiplayer.Play();
                    }
                }
                else
                {
                    if (GUILayout.Button("Resume") == true)
                    {
                        midiplayer.Resume();
                    }
                }
            }

            if (GUILayout.Button("Stop") == true)
            {
                midiplayer.Stop();
            }
            GUILayout.EndHorizontal();

            EditorGUILayout.Slider(midiplayer.playTime, 0f, midiplayer.totalTime);
            EditorGUILayout.LabelField(string.Format("Time : {0:f1}sec", midiplayer.playTime));
        }
    }
}
