﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBuilder : MonoBehaviour
{
    public int mapWidth = 9;
    public int mapHeight = 9;

    private const float defaultGridSize = 5.9f;
    public float gridSize = 4.0f;
    private float scaleMargin = 0.1f;
    private Vector3 mapPosition;

    private string prefabsPath = "Decrepit Dungeon LITE/Prefabs";

    private bool rescaleToGrid = true;
    private GameObject parentObject;
    private int pixelNumber;

    public GameObject doorSpawner;
    public GameObject lockedDoorSpawner;
    public GameObject spikesSpawner;
    public GameObject medkitSpawner;
    public GameObject flashlightSpawner;
    public GameObject keySpawner;
    public GameObject collectibleSpawner;

    private (byte type, byte id, byte rotation)[] defaultMap =
    {
    (1,0,159),(1,0,159),(0,100,159),(1,0,159),(1,0,159),(0,60,223),(0,60,223),(0,60,223),(0,0,159),
    (1,0,159),(1,0,159),(0,100,159),(1,0,191),(0,0,191),(80,20,159),(80,20,159),(80,20,159),(0,20,255),
    (1,0,159),(0,0,159),(0,100,159),(60,0,223),(0,0,159),(60,150,159),(60,140,159),(60,160,159),(60,0,255),
    (0,0,191),(80,0,159),(80,0,191),(60,10,159),(60,30,159),(60,50,159),(60,60,191),(60,70,159),(0,20,255),
    (20,40,191),(80,0,159),(250,100,191),(250,50,191),(80,0,191),(80,0,191),(80,0,191),(80,0,159),(60,0,255),
    (0,0,191),(250,130,191),(250,155,191),(80,0,159),(250,180,191),(80,0,159),(80,0,191),(80,0,159),(0,20,255),
    (0,0,159),(0,0,159),(0,80,159),(60,0,159),(0,100,159),(60,0,159),(0,40,159),(0,0,159),(0,0,159),
    (20,20,191),(250,200,159),(0,100,191),(0,100,191),(80,0,159),(0,100,191),(0,100,191),(80,0,159),(20,0,191),
    (0,0,159),(0,0,159),(1,0,159),(1,0,159),(60,0,159),(1,0,159),(1,0,159),(60,0,159),(0,0,159)
    };
    //notation: (R: element type, G: element id, B: rotation)
    private List<(byte type, byte id, byte rotation)> map;

    void Awake()
    {
        generate();
    }


    public bool loadMap(List<(byte type, byte id, byte rotation)> _map, int _mapWidth, int _mapHeight)
    {
        //_map = null; // LOAD DEFAULT MAP
        if(_map != null && _mapWidth > 0 && _mapHeight > 0)
        {
            map = _map;
            mapWidth = _mapWidth;
            mapHeight = _mapHeight;
            return true;
        } else
        {
            map = new List<(byte type, byte id, byte rotation)>(defaultMap);
        }
        Debug.Log("Couldn't load the map. Using default one...");
        return false;
    }

    public void generate()
    {
        MapGenerator generator = new MapGenerator();
        Map createdMap = generator.create();
        loadMap(createdMap.getData(), createdMap.getMapWidth(), createdMap.getMapHeight());

        parentObject = GameObject.Find("Map");
        if (parentObject != null)
        {
            DestroyImmediate(parentObject);
        }
        parentObject = new GameObject("Map");

        mapPosition = new Vector3(-(mapWidth * gridSize) / 2.0f + gridSize/2.0f, 0.0f, -(mapHeight * gridSize) / 2.0f + gridSize / 2.0f);

        for (int y = 0; y < mapHeight; y++)
        {
            for (int x = 0; x < mapWidth; x++)
            {
                pixelNumber = y * mapWidth + x;
                Vector3 pos = new Vector3(x, 0, y) * gridSize;
                Vector3 posOffset = new Vector3(0, 0, 0);
                Vector3 rotOffset = new Vector3(0, 0, 0);

                Vector3 scale = new Vector3(gridSize, gridSize, gridSize);
                string elementPath = prefabsPath;
                rescaleToGrid = true;

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
                                spawn(prefabsPath + "/Floors/Floor_B", pos, new Vector3(0, 0.01f, 0), rotOffset, new Vector3(gridSize, 0.5f, gridSize));
                                elementPath += "/Wall_C";
                                scale.x += 4 * scaleMargin;
                                break;
                            case 60:
                                spawn(prefabsPath + "/Floors/Floor_B", pos, new Vector3(0, 0.01f, 0), rotOffset, new Vector3(gridSize, 0.5f, gridSize));
                                elementPath += "/Wall_D";
                                scale.x += 2 * scaleMargin;
                                scale.z += scaleMargin;
                                posOffset.x += -0.35f;
                                break;
                            case 80:
                                spawn(prefabsPath + "/Floors/Floor_B", pos, new Vector3(0, 0.01f, 0), rotOffset, new Vector3(gridSize, 0.5f, gridSize));
                                elementPath += "/Wall_E";
                                scale.x += 3.5f * scaleMargin;
                                scale.z += scaleMargin;
                                posOffset.x += 1.11f;
                                break;
                            case 100:
                                spawn(prefabsPath + "/Floors/Floor_A", pos, new Vector3(0, 0.01f, 0), rotOffset, new Vector3(gridSize, 0.5f, gridSize));
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
                                spawn(prefabsPath + "/Doorways/Doorway_A", pos, posOffset, rotOffset, new Vector3(1.0f, gridSize, gridSize + scaleMargin));
                                //spawn(prefabsPath + "/Doors/Door_A", pos, new Vector3(0, 0, 1.2f), rotOffset, Vector3.zero);
                                spawn(doorSpawner, pos, new Vector3(0, 0, 1.2f), rotOffset, Vector3.zero);
                                scale.y = 0.5f;
                                posOffset.y += 0.01f;
                                elementPath += "/Floors/Floor_A";
                                break;
                            case 20:
                                spawn(prefabsPath + "/Walls/Arch_A", pos, new Vector3(0, 0, -0.02f), rotOffset, new Vector3(1.0f, gridSize, gridSize + scaleMargin));
                                spawn(prefabsPath + "/Doors/Door_B", pos, new Vector3(0, 0.05f, 1.75f), rotOffset, Vector3.zero);
                                scale.y = 0.5f;
                                posOffset.y += 0.01f;
                                elementPath += "/Floors/Floor_A";
                                break;
                            case 40:
                                spawn(prefabsPath + "/Doorways/Doorway_A", pos, posOffset, rotOffset, new Vector3(1.0f, gridSize, gridSize + scaleMargin));
                                spawn(prefabsPath + "/Doors/Door_C", pos, new Vector3(0, 0.1f, 1.2f), rotOffset, Vector3.zero);
                                scale.y = 0.5f;
                                posOffset.y += 0.01f;
                                elementPath += "/Floors/Floor_A";
                                break;
                            case 60:
                                // tbc
                                scale.y = 0.5f;
                                posOffset.y += 0.01f;
                                elementPath += "/Floors/Floor_C";
                                break;
                            case 80:
                                spawn(prefabsPath + "/Doorways/Doorway_A", pos, posOffset, rotOffset, new Vector3(1.0f, gridSize, gridSize + scaleMargin));
                                spawn(lockedDoorSpawner, pos, new Vector3(0, 0, 1.2f), rotOffset, Vector3.zero);
                                scale.y = 0.5f;
                                posOffset.y += 0.01f;
                                elementPath += "/Floors/Floor_A";
                                break;
                            case 100:
                                spawn(prefabsPath + "/Doorways/Doorway_A", pos, posOffset, rotOffset, new Vector3(1.0f, gridSize, gridSize + scaleMargin));
                               spawn(doorSpawner, pos, new Vector3(0, 0, 1.2f), rotOffset, Vector3.zero);
                                scale.y = 0.5f;
                                posOffset.y += 0.01f;
                                elementPath += "/Floors/Floor_A";
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
                                spawn(prefabsPath + "/Walls/Wall_A", pos, posOffset, rotOffset, scale);
                                elementPath += "/Torch";
                                posOffset.x += -2.95f;
                                posOffset.y += 3.0f;
                                scale = Vector3.zero;
                                break;
                            case 10:
                                spawn(prefabsPath + "/Floors/Floor_A", pos, new Vector3(0, 0.01f, 0), rotOffset, new Vector3(gridSize, 0.5f, gridSize));
                                elementPath += "/Barrel";
                                posOffset.x = -2.0f;
                                rotOffset.y = getRandomizedRotationOffset(45.0f);
                                scale = Vector3.zero;
                                break;
                            case 20:
                                spawn(prefabsPath + "/Floors/Floor_B", pos, new Vector3(0, 0.01f, 0), rotOffset, new Vector3(gridSize, 0.5f, gridSize));
                                elementPath += "/Barrel";
                                posOffset.x = -2.0f;
                                rotOffset.y = getRandomizedRotationOffset(45.0f);
                                scale = Vector3.zero;
                                break;
                            case 30:
                                spawn(prefabsPath + "/Floors/Floor_A", pos, new Vector3(0, 0.01f, 0), rotOffset, new Vector3(gridSize, 0.5f, gridSize));
                                elementPath += "/Bucket";
                                posOffset.x = -2.0f;
                                rotOffset.y = getRandomizedRotationOffset(45.0f);
                                scale *= 0.2f;
                                break;
                            case 40:
                                spawn(prefabsPath + "/Floors/Floor_B", pos, new Vector3(0, 0.01f, 0), rotOffset, new Vector3(gridSize, 0.5f, gridSize));
                                elementPath += "/Bucket";
                                posOffset.x = -2.0f;
                                rotOffset.y = getRandomizedRotationOffset(45.0f);
                                scale *= 0.2f;
                                break;
                            case 50:
                                spawn(prefabsPath + "/Floors/Floor_A", pos, new Vector3(0, 0.01f, 0), rotOffset, new Vector3(gridSize, 0.5f, gridSize));
                                elementPath += "/Table_A";
                                posOffset.x = -2.0f;
                                rotOffset.y = getRandomizedRotationOffset(10.0f);
                                scale = Vector3.zero;
                                break;
                            case 60:
                                spawn(prefabsPath + "/Floors/Floor_A", pos, new Vector3(0, 0.01f, 0), rotOffset, new Vector3(gridSize, 0.5f, gridSize));
                                elementPath += "/Table_B";
                                posOffset.x = -1.8f;
                                rotOffset.y = getRandomizedRotationOffset(10.0f);
                                scale = Vector3.zero;
                                break;
                            case 70:
                                spawn(prefabsPath + "/Floors/Floor_A", pos, new Vector3(0, 0.01f, 0), rotOffset, new Vector3(gridSize, 0.5f, gridSize));
                                elementPath += "/Table_C";
                                posOffset.x = -1.8f;
                                rotOffset.y = getRandomizedRotationOffset(10.0f);
                                scale = Vector3.zero;
                                break;
                            case 80:
                                spawn(prefabsPath + "/Floors/Floor_A", pos, new Vector3(0, 0.01f, 0), rotOffset, new Vector3(gridSize, 0.5f, gridSize));
                                posOffset.x = -1.8f;
                                rotOffset.y = getRandomizedRotationOffset(10.0f);
                                {
                                    Vector3 candlePos = posOffset + getRandomizedPosOffset(0.1f);
                                    candlePos.y += 1.46f;
                                    spawn(elementPath + "/Candles", pos, candlePos, rotOffset, Vector3.zero);
                                }
                                elementPath += "/Table_A";
                                scale = Vector3.zero;
                                break;
                            case 90:
                                spawn(prefabsPath + "/Floors/Floor_A", pos, new Vector3(0, 0.01f, 0), rotOffset, new Vector3(gridSize, 0.5f, gridSize));
                                posOffset.x = -1.8f;
                                rotOffset.y = getRandomizedRotationOffset(10.0f);
                                {
                                    Vector3 candlePos = posOffset + getRandomizedPosOffset(0.1f);
                                    candlePos.y += 1.46f;
                                    candlePos.z += getRandomizedPosOffset(0.4f).x;
                                    spawn(elementPath + "/Candles", pos, candlePos, rotOffset, Vector3.zero);
                                }
                                elementPath += "/Table_B";
                                scale = Vector3.zero;
                                break;
                            case 100:
                                spawn(prefabsPath + "/Floors/Floor_A", pos, new Vector3(0, 0.01f, 0), rotOffset, new Vector3(gridSize, 0.5f, gridSize));
                                posOffset.x = -1.8f;
                                rotOffset.y = getRandomizedRotationOffset(10.0f);
                                {
                                    Vector3 candlePos = posOffset + getRandomizedPosOffset(0.1f);
                                    candlePos.y += 1.46f;
                                    candlePos.z += getRandomizedPosOffset(0.4f).x;
                                    spawn(elementPath + "/Candles", pos, candlePos, rotOffset, Vector3.zero);
                                }
                                elementPath += "/Table_C";
                                scale = Vector3.zero;
                                break;
                            case 110:
                                spawn(prefabsPath + "/Floors/Floor_B", pos, new Vector3(0, 0.01f, 0), rotOffset, new Vector3(gridSize, 0.5f, gridSize));
                                elementPath += "/Table_A";
                                posOffset.x = -1.8f;
                                rotOffset.y = getRandomizedRotationOffset(10.0f);
                                scale = Vector3.zero;
                                break;
                            case 120:
                                spawn(prefabsPath + "/Floors/Floor_B", pos, new Vector3(0, 0.01f, 0), rotOffset, new Vector3(gridSize, 0.5f, gridSize));
                                elementPath += "/Table_B";
                                posOffset.x = -1.8f;
                                rotOffset.y = getRandomizedRotationOffset(10.0f);
                                scale = Vector3.zero;
                                break;
                            case 130:
                                spawn(prefabsPath + "/Floors/Floor_B", pos, new Vector3(0, 0.01f, 0), rotOffset, new Vector3(gridSize, 0.5f, gridSize));
                                elementPath += "/Table_C";
                                posOffset.x = -1.8f;
                                rotOffset.y = getRandomizedRotationOffset(10.0f);
                                scale = Vector3.zero;
                                break;
                            case 140:
                                spawn(prefabsPath + "/Floors/Floor_B", pos, new Vector3(0, 0.01f, 0), rotOffset, new Vector3(gridSize, 0.5f, gridSize));
                                posOffset.x = -1.8f;
                                rotOffset.y = getRandomizedRotationOffset(10.0f);
                                {
                                    Vector3 candlePos = posOffset + getRandomizedPosOffset(0.1f);
                                    candlePos.y += 1.46f;
                                    spawn(elementPath + "/Candles", pos, candlePos, rotOffset, Vector3.zero);
                                }
                                elementPath += "/Table_A";
                                scale = Vector3.zero;
                                break;
                            case 150:
                                spawn(prefabsPath + "/Floors/Floor_B", pos, new Vector3(0, 0.01f, 0), rotOffset, new Vector3(gridSize, 0.5f, gridSize));
                                posOffset.x = -1.8f;
                                rotOffset.y = getRandomizedRotationOffset(10.0f);
                                {
                                    Vector3 candlePos = posOffset + getRandomizedPosOffset(0.1f);
                                    candlePos.y += 1.46f;
                                    candlePos.z += getRandomizedPosOffset(0.4f).x;
                                    spawn(elementPath + "/Candles", pos, candlePos, rotOffset, Vector3.zero);
                                }
                                elementPath += "/Table_B";
                                scale = Vector3.zero;
                                break;
                            case 160:
                                spawn(prefabsPath + "/Floors/Floor_B", pos, new Vector3(0, 0.01f, 0), rotOffset, new Vector3(gridSize, 0.5f, gridSize));
                                posOffset.x = -1.8f;
                                rotOffset.y = getRandomizedRotationOffset(10.0f);
                                {
                                    Vector3 candlePos = posOffset + getRandomizedPosOffset(0.1f);
                                    candlePos.y += 1.46f;
                                    candlePos.z += getRandomizedPosOffset(0.4f).x;
                                    spawn(elementPath + "/Candles", pos, candlePos, rotOffset, Vector3.zero);
                                }
                                elementPath += "/Table_C";
                                scale = Vector3.zero;
                                break;
                            case 170:
                                spawn(prefabsPath + "/Floors/Floor_A", pos, new Vector3(0, 0.01f, 0), rotOffset, new Vector3(gridSize, 0.5f, gridSize));
                                posOffset.x = -1.8f;
                                rotOffset.y = getRandomizedRotationOffset(10.0f);
                                {
                                    Vector3 keyPos = posOffset + getRandomizedPosOffset(0.1f);
                                    keyPos.y += 1.46f;
                                    keyPos.z += getRandomizedPosOffset(0.4f).x;
                                    spawn(keySpawner, pos, keyPos, rotOffset, Vector3.zero);
                                }
                                elementPath += "/Table_C";
                                scale = Vector3.zero;
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

                    // Special
                    case 250:
                        elementPath += "/Special";
                        scale.y = 0.5f;
                        posOffset.y += 0.01f;
                        switch (map[pixelNumber].id)
                        {
                            case 50:
                                setPlayerSpawnPosition(pos);
                                elementPath += "/Start";
                                spawn(flashlightSpawner, pos, new Vector3(0,1,0), new Vector3(0, getRandomizedRotationOffset(90.0f), 0), Vector3.zero);
                                break;
                            case 100:
                                spawn(prefabsPath + "/Floors/Floor_A", pos, new Vector3(0, 0.01f, 0), rotOffset, new Vector3(gridSize, 0.5f, gridSize));
                                pos.y -= 0.02f;
                                spawn(spikesSpawner, pos, Vector3.zero, rotOffset, Vector3.zero);
                                break;
                            case 125:
                                spawn(prefabsPath + "/Floors/Floor_A", pos, new Vector3(0, 0.01f, 0), rotOffset, new Vector3(gridSize, 0.5f, gridSize));
                                posOffset = getRandomizedPosOffset(0.7f);
                                rotOffset.y = getRandomizedRotationOffset(90.0f);
                                spawn(medkitSpawner, pos, Vector3.zero, rotOffset, Vector3.zero);
                                break;
                            case 130:
                                spawn(prefabsPath + "/Floors/Floor_B", pos, new Vector3(0, 0.01f, 0), rotOffset, new Vector3(gridSize, 0.5f, gridSize));
                                posOffset = getRandomizedPosOffset(0.7f);
                                rotOffset.y = getRandomizedRotationOffset(90.0f);
                                spawn(medkitSpawner, pos, posOffset, rotOffset, Vector3.zero);
                                break;
                            case 150:
                                spawn(prefabsPath + "/Floors/Floor_A", pos, new Vector3(0, 0.01f, 0), rotOffset, new Vector3(gridSize, 0.5f, gridSize));
                                posOffset.x = -1.8f;
                                rotOffset.y = getRandomizedRotationOffset(10.0f);
                                {
                                    Vector3 flashlightPos = posOffset;
                                    flashlightPos.y += 1.46f;
                                    flashlightPos.z += getRandomizedPosOffset(0.2f).x;
                                    spawn(flashlightSpawner, pos, flashlightPos, new Vector3(0, getRandomizedRotationOffset(90.0f), 0), Vector3.zero);
                                }
                                elementPath = prefabsPath + "/Props/Table_C";
                                scale = Vector3.zero;
                                break;
                            case 155:
                                spawn(prefabsPath + "/Floors/Floor_B", pos, new Vector3(0, 0.01f, 0), rotOffset, new Vector3(gridSize, 0.5f, gridSize));
                                posOffset.x = -1.8f;
                                rotOffset.y = getRandomizedRotationOffset(10.0f);
                                {
                                    Vector3 flashlightPos = posOffset;
                                    flashlightPos.y += 1.46f;
                                    flashlightPos.z += getRandomizedPosOffset(0.2f).x;
                                    spawn(flashlightSpawner, pos, flashlightPos, new Vector3(0, getRandomizedRotationOffset(90.0f),0), Vector3.zero);
                                }
                                elementPath = prefabsPath + "/Props/Table_C";
                                scale = Vector3.zero;
                                break;
                            case 175:
                                spawn(prefabsPath + "/Floors/Floor_B", pos, new Vector3(0, 0.01f, 0), rotOffset, new Vector3(gridSize, 0.5f, gridSize));
                                posOffset.x = -1.8f;
                                {
                                    Vector3 flashlightPos = posOffset;
                                    flashlightPos.y += 1.7f;
                                    flashlightPos.x += 0.2f;
                                    spawn(flashlightSpawner, pos, flashlightPos, Vector3.zero, Vector3.zero);
                                }
                                elementPath = prefabsPath + "/Props/Barrel";
                                scale = Vector3.zero;
                                break;
                            case 180:
                                spawn(prefabsPath + "/Floors/Floor_A", pos, new Vector3(0, 0.01f, 0), rotOffset, new Vector3(gridSize, 0.5f, gridSize));
                                posOffset = getRandomizedPosOffset(0.7f);
                                rotOffset.y = getRandomizedRotationOffset(90.0f);
                                spawn(collectibleSpawner, pos, posOffset, rotOffset, Vector3.zero);
                                break;
                            case 190:
                                spawn(prefabsPath + "/Floors/Floor_B", pos, new Vector3(0, 0.01f, 0), rotOffset, new Vector3(gridSize, 0.5f, gridSize));
                                posOffset = getRandomizedPosOffset(0.7f);
                                rotOffset.y = getRandomizedRotationOffset(90.0f);
                                spawn(collectibleSpawner, pos, posOffset, rotOffset, Vector3.zero);
                                break;
                            case 200:
                                setPlayerFinishPosition(pos);
                                elementPath += "/Finish";
                                break;
                        }
                        break;

                }
                if (elementPath != prefabsPath)
                {
                    spawn(elementPath, pos, posOffset, rotOffset, scale);
                    addFloorDecal(pos);
                    spawn(prefabsPath + "/Walls/Ceiling", new Vector3(x, 0, y) * gridSize + new Vector3(0, gridSize, 0), new Vector3(0, 0, 0), new Vector3(0, 0, 0), new Vector3(gridSize, 0.5f, gridSize));
                }
            }
        }
        parentObject.transform.position = mapPosition;

    }

    private void spawn(string path, Vector3 position, Vector3 positionOffset, Vector3 rotationOffset, Vector3 scale)
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
            else
            {
                rescaleRelative(spawner, gridSize, gridSize, gridSize);
            }

            if(rotationOffset == null)
            {
                rotationOffset = Vector3.zero;
            }
            spawner.transform.Rotate(rotationOffset.x, 90f * ((255 - map[pixelNumber].rotation) / 32) + rotationOffset.y, rotationOffset.z, Space.World);
            spawner.transform.Translate(positionOffset*(gridSize/ defaultGridSize), Space.Self);
        }
    }

    private void spawn(GameObject spawner_, Vector3 position, Vector3 positionOffset, Vector3 rotationOffset, Vector3 scale)
    {
        GameObject spawner = Instantiate(spawner_, position, Quaternion.identity, parentObject.transform);

        if (spawner != null)
        {
            if (rescaleToGrid && scale != Vector3.zero)
            {
                rescale(spawner, scale.x, scale.y, scale.z);
            }
            else
            {
                rescaleRelative(spawner, gridSize, gridSize, gridSize);
            }

            if (rotationOffset == null)
            {
                rotationOffset = Vector3.zero;
            }
            spawner.transform.Rotate(rotationOffset.x, 90f * ((255 - map[pixelNumber].rotation) / 32) + rotationOffset.y, rotationOffset.z, Space.World);
            spawner.transform.Translate(positionOffset * (gridSize / defaultGridSize), Space.Self);
        }
    }


    private Vector3 getRandomizedPosOffset(float deltaPos = 1.0f)
    {
        Vector2 randPos = new Vector2((Random.value - 0.5f) * (gridSize * deltaPos), (Random.value - 0.5f) * (gridSize * deltaPos));
        return new Vector3(randPos.x, 0.0f, randPos.y);
    }

    private float getRandomizedRotationOffset(float deltaRot = 20.0f)
    {
        return (Random.value - 0.5f) * 2.0f * deltaRot;
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

    private void rescaleRelative(GameObject gameObj, float scaleX, float scaleY, float scaleZ)
    {
        gameObj.transform.localScale = new Vector3(scaleX / defaultGridSize, scaleY / defaultGridSize, scaleZ / defaultGridSize);
    }

    private void addFloorDecal(Vector3 position)
    {
        if(Random.value > 0.75f)
        {
            char elementLetter =(char) 65;
            elementLetter += (char)Mathf.Round(5.0f * Random.value); // A - F
            position.y += 0.02f;
            spawn(prefabsPath + "/Decals/Grunge_" + elementLetter, position, getRandomizedPosOffset(), new Vector3(0,getRandomizedRotationOffset(180.0f),0), Vector3.zero);
        }
    }

    private void setPlayerSpawnPosition(Vector3 _position)
    {
        _position.y += 1.5f;
        GameObject player = GameObject.Find("FPSController");
        if (player != null)
        {
            player.transform.position = mapPosition + _position;
        }
    }

    private void setPlayerFinishPosition(Vector3 _position)
    {
        _position.y += 1.0f;
        GameObject player = GameObject.Find("FinishTag");
        player.transform.position = mapPosition + _position;
    }
}
