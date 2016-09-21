using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(PathDrawer))] //(PathNode)를 위한 커스텀 에디터 임을 명시
public class PathDrawerEditor : Editor
{

    void OnSceneGUI()   //씬에 그려줌
    {
        Debug.Log("GUI");
        PathDrawer pathDrawer = (PathDrawer)target; // target이 Object타입이므로 사용할수있게 변환

        Texture2D texture = new Texture2D(1, 1);
        texture.SetPixel(0, 0, Color.white);

        for (int i = 0; i < pathDrawer.Nodes.Length-1; i++)
        {
            GameObject startNode = pathDrawer.Nodes[i];
            GameObject endNode = pathDrawer.Nodes[i+1];
            Vector3 startPos = startNode.transform.position;
            Vector3 endPos = endNode.transform.position;
        
            Vector3 startTangent = startNode.transform.forward;
            Vector3 endTangent = -endNode.transform.forward;

            Handles.DrawBezier(startPos,endPos, startTangent, endTangent,Color.green, texture,3f);//끝까지돌면 end쪽에서 에러날수있으므로 끝까지 돌지 않는다
        }
    }
}