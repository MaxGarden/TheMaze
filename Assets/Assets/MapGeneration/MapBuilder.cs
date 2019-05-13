using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBuilder : MonoBehaviour
{
    public int mapWidth = 9;
    public int mapHeight = 9;

    private float gridSize = 5.9f;
    private float scaleMargin = 0.1f;
    private Vector3 position;

    private string prefabsPath = "Decrepit Dungeon LITE/Prefabs";

    private bool rescaleToGrid = true;
    private GameObject parentObject;
    private int pixelNumber;

    //notation: (R: element type, G: element id, B: height level, Alpha: rotation)
    private (byte type, byte id, byte height, byte rotation)[] map = 
    {
    (1,0,0,159),(1,0,0,159),(0,100,0,159),(1,0,0,159),(1,0,0,159),(0,60,0,223),(0,60,0,223),(0,60,0,223),(0,0,0,159),
    (1,0,0,159),(1,0,0,159),(0,100,0,159),(1,0,0,191),(0,0,0,191),(80,20,0,159),(80,20,0,159),(80,20,0,159),(0,20,0,255),
    (1,0,0,159),(0,0,0,159),(0,100,0,159),(60,0,0,223),(0,0,0,159),(80,20,0,159),(80,20,0,159),(80,20,0,159),(60,0,0,255),
    (0,0,0,191),(80,0,0,159),(80,0,0,191),(80,0,0,159),(80,0,0,159),(80,0,0,159),(80,0,0,191),(80,0,0,159),(0,20,0,255),
    (20,40,0,191),(80,0,0,159),(80,0,0,191),(80,0,0,191),(80,0,0,159),(80,0,0,191),(80,0,0,191),(80,0,0,159),(60,0,0,255),
    (0,0,0,191),(80,0,0,159),(80,0,0,191),(80,0,0,159),(80,0,0,159),(80,0,0,159),(80,0,0,191),(80,0,0,159),(0,20,0,255),
    (0,0,0,159),(0,0,0,159),(0,80,0,159),(60,0,0,159),(0,100,0,159),(60,0,0,159),(0,40,0,159),(0,0,0,159),(0,0,0,159),
    (20,20,0,191),(80,0,0,159),(0,100,0,191),(0,100,0,191),(80,0,0,159),(0,100,0,191),(0,100,0,191),(80,0,0,159),(20,0,0,191),
    (0,0,0,159),(60,0,0,159),(1,0,0,159),(1,0,0,159),(60,0,0,159),(1,0,0,159),(1,0,0,159),(60,0,0,159),(0,0,0,159)
    };

    public void generate()
    {
        parentObject = GameObject.Find("Map");
        if (parentObject != null)
        {
            DestroyImmediate(parentObject);
        }
        parentObject = new GameObject("Map");

        position = new Vector3(-(mapWidth * gridSize) / 2.0f + gridSize/2, 0.0f, -(mapHeight * gridSize) / 2.0f + gridSize / 2);

        for (int y = 0; y < mapHeight; y++)
        {
            for (int x = 0; x < mapWidth; x++)
            {
                pixelNumber = y * mapWidth + x;
                Vector3 pos = new Vector3(x, map[pixelNumber].height, y) * gridSize;
                Vector3 posOffset = new Vector3(0, 0, 0);

                Vector3 scale = new Vector3(gridSize, gridSize, gridSize);
                string elementPath = prefabsPath;
                rescaleToGrid = true;

                pos.y += 5.9f;
                spawn(prefabsPath + "/Walls/Ceiling", pos, posOffset, new Vector3(gridSize, 0.5f, gridSize));
                pos.y -= 5.9f;

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
                                posOffset.x += -0.6f;
                                scale.x += scaleMargin;
                                break;
                            case 40:
                                spawn(prefabsPath + "/Floors/Floor_B", pos, new Vector3(0, 0.01f, 0), new Vector3(gridSize, 0.5f, gridSize));
                                elementPath += "/Wall_C";
                                scale.x += 4 * scaleMargin;
                                break;
                            case 60:
                                spawn(prefabsPath + "/Floors/Floor_B", pos, new Vector3(0, 0.01f, 0), new Vector3(gridSize, 0.5f, gridSize));
                                elementPath += "/Wall_D";
                                scale.x += 2 * scaleMargin;
                                scale.z += scaleMargin;
                                posOffset.x += -0.35f;
                                break;
                            case 80:
                                spawn(prefabsPath + "/Floors/Floor_B", pos, new Vector3(0, 0.01f, 0), new Vector3(gridSize, 0.5f, gridSize));
                                elementPath += "/Wall_E";
                                scale.x += 3.5f * scaleMargin;
                                scale.z += scaleMargin;
                                posOffset.x += 1.11f;
                                break;
                            case 100:
                                spawn(prefabsPath + "/Floors/Floor_A", pos, new Vector3(0, 0.01f, 0), new Vector3(gridSize, 0.5f, gridSize));
                                elementPath += "/Arch_A";
                                scale.x += 8 * scaleMargin;
                                scale.z += scaleMargin;
                                posOffset.x += 0.05f;
                                break;
                        }
                        break;

                    // Doors
                    case 20:

                        switch (map[pixelNumber].id)
                        {
                            case 0:
                                spawn(prefabsPath + "/Doorways/Doorway_A", pos, posOffset, new Vector3(1.0f, gridSize, gridSize + scaleMargin));
                                spawn(prefabsPath + "/Doors/Door_A", pos, new Vector3(0, 0, 1.2f), Vector3.zero);
                                scale.y = 0.5f;
                                posOffset.y += 0.01f;
                                elementPath += "/Floors/Floor_A";
                                break;
                            case 20:
                                spawn(prefabsPath + "/Walls/Arch_A", pos, new Vector3(0, 0, -0.02f), new Vector3(1.0f, gridSize, gridSize + scaleMargin));
                                spawn(prefabsPath + "/Doors/Door_B", pos, new Vector3(0, 0.05f, 1.75f), Vector3.zero);
                                scale.y = 0.5f;
                                posOffset.y += 0.01f;
                                elementPath += "/Floors/Floor_A";
                                break;
                            case 40:
                                spawn(prefabsPath + "/Doorways/Doorway_A", pos, posOffset, new Vector3(1.0f, gridSize, gridSize + scaleMargin));
                                spawn(prefabsPath + "/Doors/Door_C", pos, new Vector3(0, 0.1f, 1.2f), Vector3.zero);
                                scale.y = 0.5f;
                                posOffset.y += 0.01f;
                                elementPath += "/Floors/Floor_A";
                                break;
                            case 60:
                                // Unfinished
                                scale.y = 0.5f;
                                posOffset.y += 0.01f;
                                elementPath += "/Floors/Floor_C";
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
                        elementPath += "/Props";
                        switch (map[pixelNumber].id)
                        {
                            case 0:
                                spawn(prefabsPath + "/Walls/Wall_A", pos, posOffset, scale);
                                elementPath += "/Torch";
                                posOffset.x += -2.95f;
                                posOffset.y += 3.0f;
                                scale = Vector3.zero;
                                break;
                            case 20:

                                break;
                            case 40:

                                break;
                            case 60:

                                break;
                            case 80:

                                break;
                            case 100:

                                break;
                            case 120:

                                break;
                            case 140:

                                break;
                            case 160:

                                break;
                        }
                        break;

                    // Floors
                    case 80:
                        elementPath += "/Floors";
                        scale.y = 0.5f;
                        posOffset.y += 0.01f;
                        switch (map[pixelNumber].id)
                        {
                            case 0:
                                elementPath += "/Floor_A";
                                break;
                            case 20:
                                elementPath += "/Floor_B";
                                break;
                            case 40:
                                elementPath += "/Floor_Gate";
                                posOffset.y += -0.5f;
                                posOffset.x += 2.95f;
                                break;
                        }
                        break;
                }
                spawn(elementPath, pos, posOffset, scale);

            }
        }
        parentObject.transform.position = position;

    }

    private void spawn(string path, Vector3 position, Vector3 positionOffset, Vector3 scale)
    {
        GameObject spawner = null;

        if (Resources.Load(path))
        {
            spawner = Instantiate((GameObject)Resources.Load(path, typeof(GameObject)), position, Quaternion.identity, parentObject.transform);
        }

        if (spawner != null)
        {
            if (rescaleToGrid && scale != Vector3.zero)
            {
                rescale(spawner, scale.x, scale.y, scale.z);
            }
            spawner.transform.Rotate(0, 90f * ((255 - map[pixelNumber].rotation) / 32), 0, Space.World);
            spawner.transform.Translate(positionOffset, Space.Self);
        }
    }

    private void rescale(GameObject gameObj, float newSizeX, float newSizeY, float newSizeZ)
    {
        Vector3 size = gameObj.GetComponent<Renderer>().bounds.size;

        Vector3 rescale = gameObj.transform.localScale;

        rescale.x = newSizeX * rescale.x / size.x;
        rescale.y = newSizeY * rescale.y / size.y;
        rescale.z = newSizeZ * rescale.z / size.z;

        gameObj.transform.localScale = rescale;
    }
}
