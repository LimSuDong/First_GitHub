using UnityEngine;
using UnityEditor;
using System.Collections;
using System.IO;

public class MidiAssetImporter : AssetPostprocessor // import 되는 시점을 알기위에 상속
{

    static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
    {

        foreach (string asset in importedAssets)
        {
            string extension = Path.GetExtension(asset);
            if (extension.Equals(".mid") == true)
            {
                Debug.Log("Found it!");
                //Create Midi Asset
                MidiAsset createdAsset = ScriptableObject.CreateInstance<MidiAsset>();

                string newFileName = Path.ChangeExtension(asset, ".asset");  //확장자만 바꿔주는 함수
                //Load Midi Asset
                createdAsset.FileLoad(asset);

                AssetDatabase.CreateAsset(createdAsset, newFileName);                          
                AssetDatabase.SaveAssets();


            }
        }


    }
    //static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
    //{
    //    foreach (string asset in importedAssets)
    //    {
    //        string extension = Path.GetExtension(asset);
    //        if (extension.Equals(".mid") == true)
    //        {
    //            MidiAsset createdAsset = ScriptableObject.CreateInstance<MidiAsset>();

    //            string newFileName = Path.ChangeExtension(asset, ".asset"); //확장자만 바꿔주는 함수

    //            AssetDatabase.CreateAsset(createdAsset, newFileName);
    //            AssetDatabase.SaveAssets();
    //        }
    //    }
    //}
}
