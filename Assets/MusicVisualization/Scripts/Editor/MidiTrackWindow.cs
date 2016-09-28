using UnityEngine;
using UnityEditor;
using System.Collections;

public class MidiTrackWindow : EditorWindow
{
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(MidiTrackWindow), false, "Midi Track"); // false시 도킹해서 사용 가능
    }

    void OnGUI()
    {
        Rect rect;
        float titleHeight = 30;
        float musicalScaleWidth = 60f;
        float TiemHight = 50f;


        //Draw Create Title Area
        rect = new Rect(0, 0, position.width, titleHeight);
        GUI.Box(rect,"");
        GUILayout.BeginArea(rect);
        
        GUILayout.EndArea();

        //Draw Create Musical Scale Area
        rect = new Rect(0, 30, 60, position.height- titleHeight);
        GUI.Box(rect, "");
        GUI.BeginGroup(rect);

        GUI.EndGroup();

        //Draw Create Track List Area
        rect = new Rect(position.width* 0.75f, titleHeight, position.width * 0.25f, position.height - titleHeight);
        GUI.Box(rect, "");
        GUILayout.BeginArea(rect);

        GUILayout.EndArea();

        //Draw Create Time Area
        rect = new Rect(musicalScaleWidth, titleHeight, position.width - position.width * 0.25f - musicalScaleWidth, TiemHight);
        GUI.Box(rect, "");
        GUILayout.BeginArea(rect);

        GUILayout.EndArea();

        //Draw Note Area
        rect = new Rect(musicalScaleWidth, TiemHight+ titleHeight, position.width - position.width * 0.25f - musicalScaleWidth, position.height- titleHeight - TiemHight);
        GUI.Box(rect, "");
        GUILayout.BeginArea(rect);

        GUILayout.EndArea();

    }
}
