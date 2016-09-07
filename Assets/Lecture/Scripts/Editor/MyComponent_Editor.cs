using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using System.Collections;

[CustomEditor(typeof(MyComponent))] //(MyComponent)를 위한 커스텀 에디터 임을 명시
public class MyComponent_Editor : Editor
{
    // myComponent에 있는 변수처럼 사용하기위해 똑같은 이름을 사용
    SerializedProperty intVarlable; 
    SerializedProperty floatVariable;
    SerializedProperty gameObjectsList;


    void OnEnable() // 클릭했을때 (start 비슷)
    {
        //한번만 시작되게하기위해 여기에 작성
        intVarlable = serializedObject.FindProperty("intVariable"); // serializedObject.FindProperty(변수명)
        floatVariable = serializedObject.FindProperty("floatVariable");
        gameObjectsList = serializedObject.FindProperty("gameObjectsList");
    }


    public override void OnInspectorGUI() // 보여지는 동안(Update 비슷)
    {
        //Automatic management (자동관리)
        serializedObject.Update(); // 동기화, 리플레쉬 같은것

        //EditorGUILayout.PropertyField(intVarlable);
        //EditorGUILayout.PropertyField(floatVariable);
        // 보이는 이름 변경시 
        EditorGUILayout.PropertyField(intVarlable, new GUIContent("Var1"));
        EditorGUILayout.PropertyField(floatVariable, new GUIContent("Var2"));
        EditorGUILayout.PropertyField(gameObjectsList, new GUIContent("List"),true);// 옵션이 디폴트가 false

        serializedObject.ApplyModifiedProperties(); // 변경사양 반영(apply)


        //Manual management (수동관리)
        MyComponent myComponent = (MyComponent)target; // target이 Object타입이므로 사용할수있게 변환

        int a = EditorGUILayout.IntField("Int Var", myComponent.IntVar);
        //변경사항이 있을경우
        if(a != myComponent.IntVar)
        {
            myComponent.IntVar = a;
            EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());//변경사항을 알려줌-매개변수 씬(현재 씬)
        }

        if(GUILayout.Button("Do something") == true) // 눌렀을경우 true
        {
            myComponent.DoSomething();
            EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());//변경사항을 알려줌-매개변수 씬(현재 씬)
        }

        //if (GUILayout.Button("Show My Window") == true) // 눌렀을경우 true
        //{
        //    MyEditorWindow.ShowWindow();
        //}
    }

}
