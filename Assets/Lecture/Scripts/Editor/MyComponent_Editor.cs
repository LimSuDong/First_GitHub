using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(MyComponent))] //(MyComponent)를 위한 커스텀 에디터 임을 명시
public class MyComponent_Editor : Editor
{
    void OnEnable()
    {
        
    }

    public override void OnInspectorGUI()
    {
        MyComponent myComponent = (MyComponent)target; // target이 Object타입이므로 사용할수있게 변환

        myComponent.intVariable =  EditorGUILayout.IntField("Int Variable", myComponent.intVariable);
        myComponent.floatVariable = EditorGUILayout.Slider("Float Variable", myComponent.floatVariable,0f,100f); // 슬라이더형태
        myComponent.IntVar = EditorGUILayout.IntField("Int Var", myComponent.IntVar);

        if(GUILayout.Button("Do something") == true) // 눌렀을경우 true
        {
            myComponent.DoSomething();
        }
    }

}
