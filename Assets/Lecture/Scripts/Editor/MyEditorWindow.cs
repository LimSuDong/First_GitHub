using UnityEngine;
using UnityEditor;
using System.Collections;

public class MyEditorWindow : EditorWindow {

    [MenuItem("My Menu/Show My window")] // 매뉴 생성, 누를시 함수실행 (매뉴폴더명, 매뉴명)
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(MyEditorWindow),false, "My Window"); // false시 도킹해서 사용 가능
    }

    [MenuItem("My Menu/add MyComponent", true)] // 두번째변수
    public static bool ValidateAddMyComponent()
    {
        if (Selection.activeGameObject == null)//현재 선택된 오브젝트가 없을경우
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    [MenuItem("My Menu/add MyComponent")] // 매뉴 생성, 누를시 함수실행
    public static void addCompnent()
    {
        if (Selection.activeGameObject == null)//현재 선택된 오브젝트가 없을경우
        {
            Selection.activeGameObject.AddComponent<MyComponent>(); // component 추가
        }
    }

    /// <summary>
    /// Layout이 붙은것 호출시 자동배치
    /// 기본적으로 수직으로 순서대로 배치
    /// </summary>
	void OnGUI()
    {
        GUILayout.BeginHorizontal(); // 수평배치 시작
        GUILayout.Button("My button");
        GUILayout.Button("My button1");
        GUILayout.Button("My button2");
        GUILayout.Button("My button3");
        GUILayout.EndHorizontal(); // 수평배치 끝

        Rect rectGUI = new Rect(100, 200, 200, 30);// x,y,너비, 높이
        if (Selection.activeGameObject == null)//현재 선택된 오브젝트가 없을경우
        {
            GUI.Label(rectGUI, "No Selection");
        }
        else
        {
            GUI.Label(rectGUI, Selection.activeGameObject.name);

            rectGUI = new Rect(100, 300, 200, 30);// x,y,너비, 높이
            if(GUI.Button(rectGUI, "add MyComponent")== true)  // GUI수동배치
            {
                Selection.activeGameObject.AddComponent<MyComponent>(); // component 추가
            }
        }
        

        if(Event.current.button == 1)//Event.current 현재 마우스 상태를 가져옴, 1은 마우스 오른쪽
        {
            if(Event.current.type == EventType.MouseUp)
            {
                GenericMenu contextMenu = new GenericMenu(); // contextMenu생성(오른쪽 눌렀을떄 나오는 메뉴)
                contextMenu.AddItem(new GUIContent("Menu 1"), false, DoMenu1); // 2번째 인자는 메뉴옆에 체크표시
                contextMenu.AddItem(new GUIContent("Menu 2"), false, DoMenu2); // 2번째 인자는 메뉴옆에 체크표시
                contextMenu.ShowAsContext(); // 메뉴를 보여줌
            }
        }
    }

    void DoMenu1()
    {
        Debug.Log("Click Menu1");
    }

    void DoMenu2()
    {
        Debug.Log("Click Menu2");
    }
}
