using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementsT1Collection
{
    private Dictionary<string, Color> elements = new Dictionary<string, Color>()
    {

        {"Path", new Color32(1,1,1,1)  },
        {"Wall", new Color32(0,0,0,1) },
 
        {"SmallRoom", new Color32(0,200,0,1) },
        {"MediumRoom", new Color32(0,200,200,1) },
        {"LargeRoom", new Color32(200,0,200,1) },

        {"RoomDoors_N", new Color32(200,0,0,159) },
        {"RoomDoors_E", new Color32(200,0,0,191) },
        {"RoomDoors_S", new Color32(200,0,0,223) },
        {"RoomDoors_W", new Color32(200,0,0,1) },

        {"StartPoint", new Color32(250,50,0,1) },
        {"EndPoint", new Color32(250,200,0,1) }
    };

    public Color32 getElement(ElementsT1 element)
    {
        Color32 elementColor = new Color32(100,100,100,1);
        switch(element)
        {
            case ElementsT1.Path:
                elementColor = elements["Path"];
                break;
            case ElementsT1.Wall:
                elementColor = elements["Wall"];
                break;
            case ElementsT1.SmallRoom:
                elementColor =  elements["SmallRoom"];
                break;
            case ElementsT1.MediumRoom:
                elementColor = elements["MediumRoom"];
                break;
            case ElementsT1.LargeRoom:
                elementColor = elements["LargeRoom"];
                break;
            case ElementsT1.RoomDoors_N:
                elementColor = elements["RoomDoors_N"];
                break;
            case ElementsT1.RoomDoors_E:
                elementColor = elements["RoomDoors_E"];
                break;
            case ElementsT1.RoomDoors_S:
                elementColor = elements["RoomDoors_S"];
                break;
            case ElementsT1.RoomDoors_W:
                elementColor = elements["RoomDoors_W"];
                break;
            case ElementsT1.StartPoint:
                elementColor = elements["StartPoint"];
                break;
            case ElementsT1.EndPoint:
                elementColor = elements["EndPoint"];
                break;
        }
        return elementColor;
    }


    public enum ElementsT1
    {
        Path,
        Wall,
        SmallRoom,
        MediumRoom,
        LargeRoom,
        RoomDoors_N,
        RoomDoors_E,
        RoomDoors_S,
        RoomDoors_W,
        StartPoint,
        EndPoint
    }

}

