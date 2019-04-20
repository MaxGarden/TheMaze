using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBuilder : MonoBehaviour
{
    public int mapWidth = 3;
    public int mapHeight = 9;

    private float gridSize = 5.9f;
    private float scaleMargin = 0.1f;
    private Vector3 positionOffset = new Vector3(0.0f, 0.0f, 25.0f);

    private string prefabsPath = "Decrepit Dungeon LITE/Prefabs";


    //notation: (R: element type, G: element id, B: height level, Alpha: rotation)
    private (byte type, byte id, byte height, byte rotation)[] map = {(0,0,0,255),(0,20,0,255),(0,40,0,255),(0,100,0,255),(255,255,255,255),(0,60,0,255),(0,80,0,255),(0,0,0,255),(0,60,0,255),
    (0,0,1,223),(0,20,1,223),(0,40,1,223),(0,100,1,223),(255,255,255,255),(0,60,1,223),(0,80,1,223),(0,0,1,223),(0,60,1,223),
    (0,0,2,191),(0,20,2,191),(0,40,2,191),(0,100,2,191),(255,255,255,255),(0,60,2,191),(0,80,2,191),(0,0,2,191),(0,60,2,191)};

    public void generate()
    {
        GameObject parentObject = GameObject.Find("Map");
        if (parentObject != null)
        {
            DestroyImmediate(parentObject);
        }
        parentObject = new GameObject("Map");

        for (int y = 0; y < mapHeight; y++)
        {
            for (int x = 0; x < mapWidth; x++)
            {
                int pixelNumber = y * mapWidth + x;
                Vector3 pos = new Vector3(x, map[pixelNumber].height, y) * gridSize;

                GameObject spawner = null;
                Vector3 scale = new Vector3(gridSize, gridSize, gridSize);
                string elementPath = prefabsPath;

                switch (map[pixelNumber].type)
                {
                    // Walls
                    case 0:
                        elementPath += "/Walls";
                        switch (map[pixelNumber].id)
                        {
                            case 0:
                                elementPath += "/Wall_A";
                                break;
                            case 20:
                                elementPath += "/Wall_B";
                                break;
                            case 40:
                                elementPath += "/Wall_C";
                                break;
                            case 60:
                                elementPath += "/Wall_D";
                                break;
                            case 80:
                                elementPath += "/Wall_E";
                                break;
                            case 100:
                                elementPath = prefabsPath + "/Arches/Arch_A";
                                scale.z += scaleMargin;
                                break;
                        }
                        break;

                    // Doors
                    case 20:

                        switch (map[pixelNumber].id)
                        {
                            case 0:
                                
                                break;
                        }
                        break;

                    // Stairs
                    case 40:

                        switch (map[pixelNumber].id)
                        {
                            case 0:
                                
                                break;
                        }
                        break;

                    // Props
                    case 60:

                        switch (map[pixelNumber].id)
                        {
                            case 0:
                                
                                break;
                        }
                        break;

                    // Floors
                    case 80:

                        switch (map[pixelNumber].id)
                        {
                            case 0:
                                
                                break;
                        }
                        break;
                }

                if(Resources.Load(elementPath))
                { 
                    spawner = Instantiate((GameObject)Resources.Load(elementPath, typeof(GameObject)), pos, Quaternion.identity, parentObject.transform);
                }

                if (spawner != null)
                {
                    rescale(spawner, scale.x, scale.y, scale.z);
                    spawner.transform.Rotate(0, 90f * ((255 - map[pixelNumber].rotation) / 32), 0, Space.World);
                }

            }
        }
        parentObject.transform.position = positionOffset;
    }

    public void rescale(GameObject gameObj, float newSizeX, float newSizeY, float newSizeZ)
    {

        Vector3 size = gameObj.GetComponent<Renderer>().bounds.size;

        Vector3 rescale = gameObj.transform.localScale;

        rescale.x = newSizeX * rescale.x / size.x;
        rescale.y = newSizeY * rescale.y / size.y;
        rescale.z = newSizeZ * rescale.z / size.z;

        gameObj.transform.localScale = rescale;

    }
}
