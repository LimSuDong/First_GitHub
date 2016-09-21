using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(MyAsset))] //(MyAsset)를 위한 커스텀 에디터 임을 명시
public class MyAssetEditor : Editor {

    void OnEnable()
    {

    }

    public override void OnInspectorGUI()
    {
        MyAsset myAsset = (MyAsset)target;

        myAsset.intVar = EditorGUILayout.IntField("IntVar",myAsset.intVar);

        myAsset.floatVar = EditorGUILayout.IntField("FloatVar", myAsset.intVar);

        if(GUILayout.Button("Apply"))
        {
            EditorUtility.SetDirty(target);
            AssetDatabase.SaveAssets();
        }

        if (GUILayout.Button("Revert"))
        {
            myAsset.Revert();
            EditorUtility.SetDirty(target);
            AssetDatabase.SaveAssets();
        }
        //base.OnInspectorGUI();
    }



    [MenuItem("Assets/Create/MyAsset")]
    public static void CreateMyAsset()
    {
        MyAsset asset = CreateInstance<MyAsset>();
        
        //EditorUtility.OpenFilePane("Save", null, null);
        
        AssetDatabase.CreateAsset(asset,"Assets/MyAsset.asset");
        AssetDatabase.SaveAssets();
    }
}
