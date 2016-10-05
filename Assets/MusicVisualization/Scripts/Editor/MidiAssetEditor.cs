using UnityEngine;
using UnityEditor;
using System.Collections;
using System.IO;

[CustomEditor(typeof(MidiAsset))]
public class MidiAssetEditor : Editor
{
    private bool _foldout;

    void OnEnable() //클릭했을떄(start,초기화역할)
    {
        _foldout = true;
    }

    public override void OnInspectorGUI()
    {
        MidiAsset midiAsset = (MidiAsset)target;

        GUILayout.Label("File Name:" + Path.GetFileNameWithoutExtension(midiAsset.fileName));
        GUILayout.Label(string.Format("Total Time: {0:f1} sec", midiAsset.totalTime));

        _foldout = EditorGUILayout.Foldout(_foldout, "Time Signiture");//true시 열림
        if(_foldout == true)
        {
            EditorGUI.indentLevel++; // 들여쓰기
            EditorGUILayout.LabelField(string.Format("PPQN: {0:d} ", midiAsset.PPQN));
            EditorGUILayout.LabelField(string.Format("Pulse: {0:f} sec", midiAsset.pulseTime));
            EditorGUILayout.LabelField(string.Format("BPM: {0:d}", midiAsset.BPM));
            EditorGUILayout.LabelField(string.Format("Numerator: {0:f1}", midiAsset.numerator));
            EditorGUILayout.LabelField(string.Format("denominator: {0:f1}", midiAsset.denominator));
            EditorGUI.indentLevel--; // 원상복구
        }

        if(GUILayout.Button("Track Viewer"))
        {
            MidiTrackWindow.ShowWindow(midiAsset);
        }
    }
	
}
