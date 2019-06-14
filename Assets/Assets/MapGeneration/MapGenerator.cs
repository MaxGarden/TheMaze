using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{


    public int MAP_WIDTH = 60;
    public int MAP_HEIGHT = 60;
    Texture2D mapSchema;

    public void create()
    {
        mapSchema = new Texture2D(MAP_WIDTH, MAP_HEIGHT, TextureFormat.RGB24, false);

        mapSchema = generateTierOne(mapSchema);

        saveMapToPNG(mapSchema);



    }

    public Texture2D generateTierOne(Texture2D mapSchema)
    {
        GenerationAlgorithms algorithm = new GenerationAlgorithms(MAP_WIDTH, MAP_HEIGHT);

        List <Point> bb = algorithm.createStartEndPoints();

        Point startPoint = bb[0];
        Point endPoint = bb[1];

        mapSchema.SetPixel(startPoint.x, startPoint.y, new Color(200/255f, 200/255f, 100/255f,1));
        mapSchema.SetPixel(endPoint.x, endPoint.y, new Color(250/255f,50/255f,0/255f,1));
        return mapSchema;
    }

    public void saveMapToPNG(Texture2D mapSchema)
    {
        byte[] bytes = mapSchema.EncodeToPNG();
        File.WriteAllBytes(Application.dataPath + "/../MapPreview.png", bytes);
    }
}
