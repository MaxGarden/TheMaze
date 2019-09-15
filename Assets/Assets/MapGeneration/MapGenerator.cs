using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MapGenerator
{


    public int MAP_WIDTH = 80;
    public int MAP_HEIGHT = 80;

    public Map create()
    {
        Texture2D mapSchema = new Texture2D(MAP_WIDTH, MAP_HEIGHT, TextureFormat.ARGB32, false);


        mapSchema = generateTierOne(mapSchema);

        saveMapToPNG(mapSchema, "MapTier1");

        mapSchema = translateFromTierOne(mapSchema);

        mapSchema = reduceMap(mapSchema);


        saveMapToPNG(mapSchema, "Map");

        List<(byte type, byte id, byte rotation)> data = new List<(byte type, byte id, byte rotation)>();
        
        for (int j = MAP_HEIGHT - 1; j >= 0; j--)
        {
            for (int i = 0; i < MAP_WIDTH; i++)
            {

                Color32 currentPixel = mapSchema.GetPixel(i, j);

                data.Add( (Convert.ToByte(currentPixel.r), Convert.ToByte(currentPixel.g) , Convert.ToByte(currentPixel.b)) );
            }
        }

        return new Map(data,MAP_WIDTH,MAP_HEIGHT);

    }

    public Texture2D generateTierOne(Texture2D mapSchema)
    {
        GenerationAlgorithms algorithm = new GenerationAlgorithms(MAP_WIDTH, MAP_HEIGHT, mapSchema);

        return algorithm.create();
    } 

    public Texture2D translateFromTierOne(Texture2D mapSchema)
    {
        ElementsT1Collection elemT1 = new ElementsT1Collection();
        ElementsCollection elem = new ElementsCollection();

        for(int i=0;i< mapSchema.width;i++)
            for(int j=0;j<mapSchema.height;j++)
            {
                Color32 currentPixel = mapSchema.GetPixel(i, j);
                //if (currentPixel == elemT1.getElement(ElementsT1Collection.ElementsT1.Wall))
                if(compareColor32(currentPixel, elemT1.getElement(ElementsT1Collection.ElementsT1.Wall)))
                {

                    float torchChance = UnityEngine.Random.Range(0.0f, 1.0f);

                    if (compareColor32(mapSchema.GetPixel(i, j + 1), elemT1.getElement(ElementsT1Collection.ElementsT1.Path)) ||
                       compareColor32(mapSchema.GetPixel(i, j + 1), elem.getFloors(ElementsCollection.Floors.Floor_A)))
                    {
                        if (torchChance > 0.95f)
                            mapSchema.SetPixel(i, j, elem.getProp(ElementsCollection.Props.Torch_N));
                        else
                            mapSchema.SetPixel(i, j, elem.getWall(ElementsCollection.Walls.Wall_A, DirectionsEnum.North));
                        continue;
                    }

                    if (compareColor32(mapSchema.GetPixel(i+1, j), elemT1.getElement(ElementsT1Collection.ElementsT1.Path)) ||
                        compareColor32(mapSchema.GetPixel(i+1, j), elem.getFloors(ElementsCollection.Floors.Floor_A)))
                    {
                        if (torchChance > 0.95f)
                            mapSchema.SetPixel(i, j, elem.getProp(ElementsCollection.Props.Torch_E));
                        else
                            mapSchema.SetPixel(i, j, elem.getWall(ElementsCollection.Walls.Wall_A, DirectionsEnum.East));
                        continue;
                    }

                    if (compareColor32(mapSchema.GetPixel(i, j - 1), elemT1.getElement(ElementsT1Collection.ElementsT1.Path)) ||
                        compareColor32(mapSchema.GetPixel(i, j - 1), elem.getFloors(ElementsCollection.Floors.Floor_A)))
                    {
                        if (torchChance > 0.95f)
                            mapSchema.SetPixel(i, j, elem.getProp(ElementsCollection.Props.Torch_S));
                        else
                            mapSchema.SetPixel(i, j, elem.getWall(ElementsCollection.Walls.Wall_A, DirectionsEnum.South));
                        continue;
                    }

                    if (compareColor32(mapSchema.GetPixel(i - 1, j), elemT1.getElement(ElementsT1Collection.ElementsT1.Path)) ||
                        compareColor32(mapSchema.GetPixel(i - 1, j), elem.getFloors(ElementsCollection.Floors.Floor_A)))
                    {
                        if (torchChance > 0.95f)
                            mapSchema.SetPixel(i, j, elem.getProp(ElementsCollection.Props.Torch_W));
                        else
                            mapSchema.SetPixel(i, j, elem.getWall(ElementsCollection.Walls.Wall_A, DirectionsEnum.West));
                        continue;
                    }

                }

                //if (currentPixel == elemT1.getElement(ElementsT1Collection.ElementsT1.Path))
                if(compareColor32(currentPixel, elemT1.getElement(ElementsT1Collection.ElementsT1.Path)))
                {
                    float trapChance = UnityEngine.Random.Range(0.0f, 2.0f);
                    if (trapChance>1.95f)
                    { 
                        mapSchema.SetPixel(i, j, elem.getSpecial(ElementsCollection.Special.SpikeTrap));
                        continue;
                    }
                    else 
                    {
                            if( compareColor32(mapSchema.GetPixel(i,j+1),elemT1.getElement(ElementsT1Collection.ElementsT1.Wall)) &&
                               compareColor32(mapSchema.GetPixel(i+1, j), elemT1.getElement(ElementsT1Collection.ElementsT1.Wall)) ||
                               compareColor32(mapSchema.GetPixel(i,j+1),elem.getWall(ElementsCollection.Walls.Wall_A,DirectionsEnum.North)) &&
                               compareColor32(mapSchema.GetPixel(i+1,j), elem.getWall(ElementsCollection.Walls.Wall_A,DirectionsEnum.East)))
                            {
                                if (UnityEngine.Random.Range(0.0f, 1.0f) > 0.8f)
                                {
                                    mapSchema.SetPixel(i, j, elem.getProp(ElementsCollection.Props.TableACandleFloorA_N));
                                    continue;
                                }
                                else
                                {
                                    mapSchema.SetPixel(i, j, elem.getProp(ElementsCollection.Props.TableAFloorA_E));
                                    continue;
                                }
                            }

                            if (compareColor32(mapSchema.GetPixel(i, j + 1), elemT1.getElement(ElementsT1Collection.ElementsT1.Wall)) &&
                                compareColor32(mapSchema.GetPixel(i - 1, j), elemT1.getElement(ElementsT1Collection.ElementsT1.Wall)) ||
                                compareColor32(mapSchema.GetPixel(i, j + 1), elem.getWall(ElementsCollection.Walls.Wall_A, DirectionsEnum.North)) &&
                                compareColor32(mapSchema.GetPixel(i - 1, j), elem.getWall(ElementsCollection.Walls.Wall_A, DirectionsEnum.West)))
                            {
                                if (UnityEngine.Random.Range(0.0f, 1.0f) > 0.8f)
                                {
                                    mapSchema.SetPixel(i, j, elem.getProp(ElementsCollection.Props.TableACandleFloorA_N));
                                    continue;
                                }
                                else
                                {
                                    mapSchema.SetPixel(i, j, elem.getProp(ElementsCollection.Props.TableAFloorA_W));
                                    continue;
                                }
                            }

                            if (compareColor32(mapSchema.GetPixel(i, j - 1), elemT1.getElement(ElementsT1Collection.ElementsT1.Wall)) &&
                                compareColor32(mapSchema.GetPixel(i + 1, j), elemT1.getElement(ElementsT1Collection.ElementsT1.Wall)) ||
                                compareColor32(mapSchema.GetPixel(i, j - 1), elem.getWall(ElementsCollection.Walls.Wall_A, DirectionsEnum.South)) &&
                                compareColor32(mapSchema.GetPixel(i + 1, j), elem.getWall(ElementsCollection.Walls.Wall_A, DirectionsEnum.East)))
                            {
                                if (UnityEngine.Random.Range(0.0f, 1.0f) > 0.8f)
                                {
                                    mapSchema.SetPixel(i, j, elem.getProp(ElementsCollection.Props.TableACandleFloorA_S));
                                    continue;
                                }
                                else
                                {
                                    mapSchema.SetPixel(i, j, elem.getProp(ElementsCollection.Props.TableAFloorA_E));
                                    continue;
                                }
                            }

                            if (compareColor32(mapSchema.GetPixel(i, j - 1), elemT1.getElement(ElementsT1Collection.ElementsT1.Wall)) &&
                                compareColor32(mapSchema.GetPixel(i - 1, j), elemT1.getElement(ElementsT1Collection.ElementsT1.Wall)) ||
                                compareColor32(mapSchema.GetPixel(i, j - 1), elem.getWall(ElementsCollection.Walls.Wall_A, DirectionsEnum.South)) &&
                                compareColor32(mapSchema.GetPixel(i - 1, j), elem.getWall(ElementsCollection.Walls.Wall_A, DirectionsEnum.West)))
                            {
                                if (UnityEngine.Random.Range(0.0f, 1.0f) > 0.8f)
                                {
                                    mapSchema.SetPixel(i, j, elem.getProp(ElementsCollection.Props.TableACandleFloorA_S));
                                    continue;
                                }
                                else
                                {
                                    mapSchema.SetPixel(i, j, elem.getProp(ElementsCollection.Props.TableAFloorA_W));
                                    continue;
                                }
                            }

                    }
                        mapSchema.SetPixel(i, j, elem.getFloors(ElementsCollection.Floors.Floor_A));
                    continue;
                }

                    // Small room and decorations
                if(compareColor32(currentPixel, elemT1.getElement(ElementsT1Collection.ElementsT1.SmallRoom)))
                {
                    if (compareColor32(mapSchema.GetPixel(i, j + 1), elemT1.getElement(ElementsT1Collection.ElementsT1.Wall)) &&
                       compareColor32(mapSchema.GetPixel(i + 1, j), elemT1.getElement(ElementsT1Collection.ElementsT1.Wall)) &&
                       UnityEngine.Random.Range(0.0f, 1.0f) > 0.8f)
                    {
                        if (UnityEngine.Random.Range(0.0f, 1.0f) > 0.5f)
                            mapSchema.SetPixel(i, j, elem.getProp(ElementsCollection.Props.TableACandleFloorB_N));
                        else
                            mapSchema.SetPixel(i, j, elem.getProp(ElementsCollection.Props.TableAFloorB_E));
                        continue;
                    }
                    else
                    {
                        if (compareColor32(mapSchema.GetPixel(i, j + 1), elemT1.getElement(ElementsT1Collection.ElementsT1.Wall)) &&
                       compareColor32(mapSchema.GetPixel(i + 1, j), elemT1.getElement(ElementsT1Collection.ElementsT1.Wall)) &&
                       UnityEngine.Random.Range(0.0f, 1.0f) > 0.7f)
                        {
                            if (UnityEngine.Random.Range(0.0f, 1.0f) > 0.5f)
                                mapSchema.SetPixel(i, j, elem.getProp(ElementsCollection.Props.BarrelFloorB_N));
                            else
                                mapSchema.SetPixel(i, j, elem.getProp(ElementsCollection.Props.BucketFloorB_E));
                            continue;
                        }
                    }

                    if (compareColor32(mapSchema.GetPixel(i, j + 1), elemT1.getElement(ElementsT1Collection.ElementsT1.Wall)) &&
                       compareColor32(mapSchema.GetPixel(i - 1, j), elemT1.getElement(ElementsT1Collection.ElementsT1.Wall)) &&
                       UnityEngine.Random.Range(0.0f, 1.0f) > 0.8f)
                    {
                        if (UnityEngine.Random.Range(0.0f, 1.0f) > 0.5f)
                            mapSchema.SetPixel(i, j, elem.getProp(ElementsCollection.Props.TableACandleFloorB_N));
                        else
                            mapSchema.SetPixel(i, j, elem.getProp(ElementsCollection.Props.TableAFloorB_W));
                        continue;
                    }
                    else
                    {
                        if(compareColor32(mapSchema.GetPixel(i, j + 1), elemT1.getElement(ElementsT1Collection.ElementsT1.Wall)) &&
                       compareColor32(mapSchema.GetPixel(i - 1, j), elemT1.getElement(ElementsT1Collection.ElementsT1.Wall)) && 
                       UnityEngine.Random.Range(0.0f,1.0f) > 0.7f)
                        {
                            if (UnityEngine.Random.Range(0.0f, 1.0f) > 0.5f)
                                mapSchema.SetPixel(i, j, elem.getProp(ElementsCollection.Props.BarrelFloorB_N));
                            else
                                mapSchema.SetPixel(i, j, elem.getProp(ElementsCollection.Props.BucketFloorB_W));
                            continue;
                        }
                    }

                    if (compareColor32(mapSchema.GetPixel(i, j - 1), elemT1.getElement(ElementsT1Collection.ElementsT1.Wall)) &&
                       compareColor32(mapSchema.GetPixel(i + 1, j), elemT1.getElement(ElementsT1Collection.ElementsT1.Wall)) &&
                       UnityEngine.Random.Range(0.0f, 1.0f) > 0.8f)
                    {
                        if (UnityEngine.Random.Range(0.0f, 1.0f) > 0.5f)
                            mapSchema.SetPixel(i, j, elem.getProp(ElementsCollection.Props.TableACandleFloorB_S));
                        else
                            mapSchema.SetPixel(i, j, elem.getProp(ElementsCollection.Props.TableAFloorB_E));
                        continue;
                    }
                    else
                    {
                        if(compareColor32(mapSchema.GetPixel(i, j - 1), elemT1.getElement(ElementsT1Collection.ElementsT1.Wall)) &&
                       compareColor32(mapSchema.GetPixel(i + 1, j), elemT1.getElement(ElementsT1Collection.ElementsT1.Wall)) && 
                       UnityEngine.Random.Range(0.0f,1.0f) > 0.7f)
                        {
                            if (UnityEngine.Random.Range(0.0f, 1.0f) > 0.5f)
                                mapSchema.SetPixel(i, j, elem.getProp(ElementsCollection.Props.BarrelFloorB_S));
                            else
                                mapSchema.SetPixel(i, j, elem.getProp(ElementsCollection.Props.BucketFloorB_E));
                            continue;
                        }
                    }

                    if (compareColor32(mapSchema.GetPixel(i, j - 1), elemT1.getElement(ElementsT1Collection.ElementsT1.Wall)) &&
                       compareColor32(mapSchema.GetPixel(i - 1, j), elemT1.getElement(ElementsT1Collection.ElementsT1.Wall)) &&
                       UnityEngine.Random.Range(0.0f, 1.0f) > 0.8f)
                    {
                        if (UnityEngine.Random.Range(0.0f, 1.0f) > 0.5f)
                            mapSchema.SetPixel(i, j, elem.getProp(ElementsCollection.Props.TableACandleFloorB_S));
                        else
                            mapSchema.SetPixel(i, j, elem.getProp(ElementsCollection.Props.TableAFloorB_W));
                        continue;
                    }
                    else
                    {
                        if(compareColor32(mapSchema.GetPixel(i, j - 1), elemT1.getElement(ElementsT1Collection.ElementsT1.Wall)) &&
                       compareColor32(mapSchema.GetPixel(i - 1, j), elemT1.getElement(ElementsT1Collection.ElementsT1.Wall)) && 
                       UnityEngine.Random.Range(0.0f,1.0f) > 0.7f)
                        {
                            if (UnityEngine.Random.Range(0.0f, 1.0f) > 0.5f)
                                mapSchema.SetPixel(i, j, elem.getProp(ElementsCollection.Props.BarrelFloorB_S));
                            else
                                mapSchema.SetPixel(i, j, elem.getProp(ElementsCollection.Props.BucketFloorB_W));
                            continue;
                        }
                    }

                    mapSchema.SetPixel(i, j, elem.getFloors(ElementsCollection.Floors.Floor_B));
                    continue;
                }


                // Doors N

                if(
                    compareColor32(currentPixel, elemT1.getElement(ElementsT1Collection.ElementsT1.RoomDoors_N)) &&

                    (mapSchema.GetPixel(i, j + 1) == elemT1.getElement(ElementsT1Collection.ElementsT1.Path) ||
                    mapSchema.GetPixel(i, j + 1) == elem.getFloors(ElementsCollection.Floors.Floor_A))
                    )
                {
                    if (UnityEngine.Random.Range(0.0f, 1.0f) > 0.25f)
                        mapSchema.SetPixel(i, j, elem.getWall(ElementsCollection.Walls.Arch_A, DirectionsEnum.North)); // Open Arch
                    else
                        mapSchema.SetPixel(i, j, elem.getDoors(ElementsCollection.Doors.Rec_Door_A, DirectionsEnum.North)); // Open rect
                    continue;
                }
                else if (currentPixel.Equals(elemT1.getElement(ElementsT1Collection.ElementsT1.RoomDoors_N)))
                {
                    mapSchema.SetPixel(i, j, elem.getDoors(ElementsCollection.Doors.Rec_Door_A, DirectionsEnum.North)); // Closed Doors
                    continue;
                }


                // Doors E

                if (currentPixel.Equals(elemT1.getElement(ElementsT1Collection.ElementsT1.RoomDoors_E)) &&
                    (mapSchema.GetPixel(i + 1, j) == elemT1.getElement(ElementsT1Collection.ElementsT1.Path) ||
                    mapSchema.GetPixel(i + 1, j) == elem.getFloors(ElementsCollection.Floors.Floor_A)))
                {
                    if (UnityEngine.Random.Range(0.0f, 1.0f) > 0.25f)
                        mapSchema.SetPixel(i, j, elem.getWall(ElementsCollection.Walls.Arch_A, DirectionsEnum.East)); // Open Arch
                    else
                        mapSchema.SetPixel(i, j, elem.getDoors(ElementsCollection.Doors.Rec_Door_A, DirectionsEnum.East)); // Open rect
                    continue;
                }
                else if (currentPixel.Equals(elemT1.getElement(ElementsT1Collection.ElementsT1.RoomDoors_E)))
                {
                    mapSchema.SetPixel(i, j, elem.getDoors(ElementsCollection.Doors.Rec_Door_A, DirectionsEnum.East)); // Closed Doors
                    continue;
                }

                // Doors S

                if (currentPixel.Equals(elemT1.getElement(ElementsT1Collection.ElementsT1.RoomDoors_S)) &&
                    (mapSchema.GetPixel(i, j-1) == elemT1.getElement(ElementsT1Collection.ElementsT1.Path) ||
                    mapSchema.GetPixel(i, j-1) == elem.getFloors(ElementsCollection.Floors.Floor_A)))
                {
                    if (UnityEngine.Random.Range(0.0f, 1.0f) > 0.25f)
                        mapSchema.SetPixel(i, j, elem.getWall(ElementsCollection.Walls.Arch_A, DirectionsEnum.South)); // Open Arch
                    else
                        mapSchema.SetPixel(i, j, elem.getDoors(ElementsCollection.Doors.Rec_Door_A, DirectionsEnum.South)); // Open rect
                    continue;
                }
                else if (currentPixel.Equals(elemT1.getElement(ElementsT1Collection.ElementsT1.RoomDoors_S)))
                {
                    mapSchema.SetPixel(i, j, elem.getDoors(ElementsCollection.Doors.Rec_Door_A, DirectionsEnum.South)); // Closed Doors
                    continue;
                }

                // Doors W

                if (currentPixel.Equals(elemT1.getElement(ElementsT1Collection.ElementsT1.RoomDoors_W)) &&
                    (mapSchema.GetPixel(i - 1, j ) == elemT1.getElement(ElementsT1Collection.ElementsT1.Path) ||
                    mapSchema.GetPixel(i - 1, j) == elem.getFloors(ElementsCollection.Floors.Floor_A)))
                {
                    if(UnityEngine.Random.Range(0.0f,1.0f) > 0.25f)
                        mapSchema.SetPixel(i, j, elem.getWall(ElementsCollection.Walls.Arch_A, DirectionsEnum.West)); // Open Arch
                    else
                        mapSchema.SetPixel(i, j, elem.getDoors(ElementsCollection.Doors.Rec_Door_A, DirectionsEnum.West)); // Open rect
                    continue;
                }
                else if (currentPixel.Equals(elemT1.getElement(ElementsT1Collection.ElementsT1.RoomDoors_W)))
                {
                    mapSchema.SetPixel(i, j, elem.getDoors(ElementsCollection.Doors.Rec_Door_A, DirectionsEnum.West)); // Closed Doors
                    continue;
                }

                
            }

        return mapSchema;
    }

    private Texture2D reduceMap(Texture2D mapSchema)
    {
        ElementsT1Collection elemT1 = new ElementsT1Collection();
        ElementsCollection elem = new ElementsCollection();

        for (int i = 0; i < mapSchema.width; i++)
            for (int j = 0; j < mapSchema.height; j++)
            {
                if (i < mapSchema.width && i >= 0 && j < mapSchema.height && j >= 0)
                {
                    if ((compareColor32(mapSchema.GetPixel(i, j + 1), elemT1.getElement(ElementsT1Collection.ElementsT1.Wall)) ||
                        compareColor32(mapSchema.GetPixel(i, j + 1), new Color32(255, 255, 254, 1))) &&
                       (compareColor32(mapSchema.GetPixel(i, j - 1), elemT1.getElement(ElementsT1Collection.ElementsT1.Wall)) ||
                        compareColor32(mapSchema.GetPixel(i, j - 1), new Color32(255, 255, 254, 1))) &&
                        (compareColor32(mapSchema.GetPixel(i + 1, j), elemT1.getElement(ElementsT1Collection.ElementsT1.Wall)) ||
                        compareColor32(mapSchema.GetPixel(i + 1, j), new Color32(255, 255, 254, 1))) &&
                        (compareColor32(mapSchema.GetPixel(i - 1, j), elemT1.getElement(ElementsT1Collection.ElementsT1.Wall)) ||
                        compareColor32(mapSchema.GetPixel(i - 1, j), new Color32(255, 255, 254, 1))))
                    {
                        mapSchema.SetPixel(i, j, new Color32(255, 255, 254, 1));
                    }
                }
            }

        return mapSchema;
    }

    public void saveMapToPNG(Texture2D mapSchema, String fileName)
    {
        byte[] bytes = mapSchema.EncodeToPNG();
        File.WriteAllBytes(Application.dataPath + "/../" + fileName + ".png", bytes);
    }

    private bool compareColor32(Color32 c1, Color32 c2)
    {
        if (c1.a == c2.a &&
            c1.r == c2.r &&
            c1.g == c2.g &&
            c1.b == c2.b)
            return true;
        else return false;
    }
}
