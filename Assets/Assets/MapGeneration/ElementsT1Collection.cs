using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementsT1Collection
{
    private Dictionary<string, Color> elements = new Dictionary<string, Color>()
    {

        {"Path", new Color(1f,1f,1f,1f)  },
        {"Wall", new Color(0,0,0,1f) },
 
        {"SmallRoom", new Color(0,200/255f,0,1) },
        {"MediumRoom", new Color(0,200/255f,200/255f,1f) },
        {"LargeRoom", new Color(200/255f,0,200/255f,1f) },

        {"RoomDoors_N", new Color(200/255f,0,0,159/255f) },
        {"RoomDoors_E", new Color(200/255f,0,0,191/255f) },
        {"RoomDoors_S", new Color(200/255f,0,0,223/255f) },
        {"RoomDoors_W", new Color(200/255f,0,0,1f) },

        {"StartPoint", new Color(250/255f,50/255f,0,1f) },
        {"EndPoint", new Color(250/255f,200/255f,0,1f) }
    };

    public Color getElement(ElementsT1 element)
    {
        Color elementColor = new Color(100/255f,100/255f,100/255f,1f);
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

