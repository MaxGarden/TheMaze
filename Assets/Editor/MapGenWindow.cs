using UnityEngine;
using UnityEditor;
using System.Collections;

public class MapGenWindow : EditorWindow
{

    [MenuItem("Edit/Generate Map")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(MapGenWindow));
    }

    void OnGUI()
    {

            if (EditorApplication.isPlaying == true)
            {
                EditorApplication.isPlaying = false;
            }

            GameObject script = GameObject.Find("MapGenerator");
            MapBuilder mapBuilder = (MapBuilder) script.GetComponent(typeof(MapBuilder));
            mapBuilder.generate();


            EditorWindow.GetWindow(typeof(MapGenWindow)).Close();
        
    }
}
