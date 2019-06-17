using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{


    public int MAP_WIDTH = 60;
    public int MAP_HEIGHT = 60;
    //Texture2D mapSchema;

    public Map create()
    {
        Texture2D mapSchema = new Texture2D(MAP_WIDTH, MAP_HEIGHT, TextureFormat.ARGB32, false);


        mapSchema = generateTierOne(mapSchema);

        mapSchema = translateFromTierOne(mapSchema);


        saveMapToPNG(mapSchema);

        List<(byte type, byte id, byte height, byte rotation)> data = new List<(byte type, byte id, byte height, byte rotation)>();

        //(byte type, byte id, byte height, byte rotation)[] data = new (byte type, byte id, byte height, byte rotation)[MAP_WIDTH*MAP_HEIGHT];

        int index = 0;
        
        for (int j = MAP_HEIGHT - 1; j >= 0; j--)
        {
            for (int i = 0; i < MAP_WIDTH; i++)
            {

                Color32 currentPixel = mapSchema.GetPixel(i, j);
                //data[index].type = Convert.ToByte(currentPixel.r);
                //data[index].id = Convert.ToByte(currentPixel.g);
                //data[index].height = Convert.ToByte(currentPixel.b);
                //data[index].rotation = Convert.ToByte(currentPixel.a);

                data.Add( (Convert.ToByte(currentPixel.r), Convert.ToByte(currentPixel.g) , Convert.ToByte(currentPixel.b) , Convert.ToByte(currentPixel.a)) );
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
                if(
                   currentPixel.r == elemT1.getElement(ElementsT1Collection.ElementsT1.Wall).r &&
                   currentPixel.g == elemT1.getElement(ElementsT1Collection.ElementsT1.Wall).g &&
                   currentPixel.b == elemT1.getElement(ElementsT1Collection.ElementsT1.Wall).b &&
                   currentPixel.a == elemT1.getElement(ElementsT1Collection.ElementsT1.Wall).a 
                   )
                {
                    mapSchema.SetPixel(i, j, elem.getWall(ElementsCollection.Walls.Wall_A, DirectionsEnum.North));
                    continue;
                }

                //if (currentPixel == elemT1.getElement(ElementsT1Collection.ElementsT1.Path))
                if(
                    currentPixel.r == elemT1.getElement(ElementsT1Collection.ElementsT1.Path).r &&
                    currentPixel.g == elemT1.getElement(ElementsT1Collection.ElementsT1.Path).g &&
                    currentPixel.b == elemT1.getElement(ElementsT1Collection.ElementsT1.Path).b &&
                    currentPixel.a == elemT1.getElement(ElementsT1Collection.ElementsT1.Path).a 

                    )
                {
                    mapSchema.SetPixel(i, j, elem.getFloors(ElementsCollection.Floors.Floor_A));
                    continue;
                }

                //if (currentPixel == elemT1.getElement(ElementsT1Collection.ElementsT1.SmallRoom))
                if(
                    currentPixel.r == elemT1.getElement(ElementsT1Collection.ElementsT1.SmallRoom).r &&
                    currentPixel.g == elemT1.getElement(ElementsT1Collection.ElementsT1.SmallRoom).g &&
                    currentPixel.b == elemT1.getElement(ElementsT1Collection.ElementsT1.SmallRoom).b &&
                    currentPixel.a == elemT1.getElement(ElementsT1Collection.ElementsT1.SmallRoom).a
                    )
                {
                    mapSchema.SetPixel(i, j, elem.getFloors(ElementsCollection.Floors.Floor_B));
                    continue;
                }


                // Doors N

                //if (currentPixel == elemT1.getElement(ElementsT1Collection.ElementsT1.RoomDoors_N) &&
                //    (mapSchema.GetPixel(i, j + 1) == elemT1.getElement(ElementsT1Collection.ElementsT1.Path) ||
                //    mapSchema.GetPixel(i, j + 1) == elem.getFloors(ElementsCollection.Floors.Floor_A)))

                if(
                    currentPixel.r == elemT1.getElement(ElementsT1Collection.ElementsT1.RoomDoors_N).r &&
                    currentPixel.r == elemT1.getElement(ElementsT1Collection.ElementsT1.RoomDoors_N).r &&
                    currentPixel.r == elemT1.getElement(ElementsT1Collection.ElementsT1.RoomDoors_N).r &&
                    currentPixel.r == elemT1.getElement(ElementsT1Collection.ElementsT1.RoomDoors_N).r &&

                    (mapSchema.GetPixel(i, j + 1) == elemT1.getElement(ElementsT1Collection.ElementsT1.Path) ||
                    mapSchema.GetPixel(i, j + 1) == elem.getFloors(ElementsCollection.Floors.Floor_A))
                    )
                {
                    mapSchema.SetPixel(i, j, elem.getWall(ElementsCollection.Walls.Arch_A, DirectionsEnum.North)); // Open Arch
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
                    mapSchema.SetPixel(i, j, elem.getWall(ElementsCollection.Walls.Arch_A, DirectionsEnum.East)); // Open Arch
                    continue;
                }
                else if (currentPixel.Equals(elemT1.getElement(ElementsT1Collection.ElementsT1.RoomDoors_E)))
                {
                    mapSchema.SetPixel(i, j, elem.getDoors(ElementsCollection.Doors.Rec_Door_A, DirectionsEnum.East)); // Closed Doors
                    continue;
                }

                // Doors S

                if (currentPixel.Equals(elemT1.getElement(ElementsT1Collection.ElementsT1.RoomDoors_S)) &&
                    (mapSchema.GetPixel(i - 1, j) == elemT1.getElement(ElementsT1Collection.ElementsT1.Path) ||
                    mapSchema.GetPixel(i - 1, j) == elem.getFloors(ElementsCollection.Floors.Floor_A)))
                {
                    mapSchema.SetPixel(i, j, elem.getWall(ElementsCollection.Walls.Arch_A, DirectionsEnum.South)); // Open Arch
                    continue;
                }
                else if (currentPixel.Equals(elemT1.getElement(ElementsT1Collection.ElementsT1.RoomDoors_S)))
                {
                    mapSchema.SetPixel(i, j, elem.getDoors(ElementsCollection.Doors.Rec_Door_A, DirectionsEnum.South)); // Closed Doors
                    continue;
                }

                // Doors W

                if (currentPixel.Equals(elemT1.getElement(ElementsT1Collection.ElementsT1.RoomDoors_W)) &&
                    (mapSchema.GetPixel(i, j - 1) == elemT1.getElement(ElementsT1Collection.ElementsT1.Path) ||
                    mapSchema.GetPixel(i, j - 1) == elem.getFloors(ElementsCollection.Floors.Floor_A)))
                {
                    mapSchema.SetPixel(i, j, elem.getWall(ElementsCollection.Walls.Arch_A, DirectionsEnum.West)); // Open Arch
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

    public void saveMapToPNG(Texture2D mapSchema)
    {
        byte[] bytes = mapSchema.EncodeToPNG();
        File.WriteAllBytes(Application.dataPath + "/../MapPreview.png", bytes);
    }
}
