using UnityEngine;
using UnityEditor;
using System.Collections;
using System.IO;

public class MidiAssetImporter : AssetPostprocessor // import 되는 시점을 알기위에 상속
{

    static void OnPostprocessAllAssets(string[] importedAssets, string[] movedAssets, string[] movedFromAssetPaths)
    {      

        foreach (string asset in importedAssets)
        {
            string extension = Path.GetExtension(asset);
            if (extension.Equals(".mid") == true)
            {
                Debug.Log("Found it!");
                //Create Midi Asset
            }
        }

       
    }
}
