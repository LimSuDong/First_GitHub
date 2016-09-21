using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(PathNode))] //(PathNode)를 위한 커스텀 에디터 임을 명시
public class PathNodeEditor : Editor
{
    void OnSceneGUI()   //씬에 그려줌
    {
        PathNode pathNode = (PathNode)target; // target이 Object타입이므로 사용할수있게 변환


        Handles.color = Color.red;
        Handles.Label(pathNode.transform.position, pathNode.name);
    }
}
