using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementsCollection
{
    private Dictionary<string, Color> elements = new Dictionary<string, Color>()
    {
            // Walls

        // Wall_A
        {"Wall_A_N", new Color(0,0,0,159/255f) },
        {"Wall_A_E", new Color(0,0,0,191/255f) },
        {"Wall_A_S", new Color(0,0,0,223/255f) },
        {"Wall_A_W", new Color(0,0,0,255/255f) },

        // Wall_B
        {"Wall_B_N", new Color(0,20/255f,0,159/255f) },
        {"Wall_B_E", new Color(0,20/255f,0,191/255f) },
        {"Wall_B_S", new Color(0,20/255f,0,223/255f) },
        {"Wall_B_W", new Color(0,20/255f,0,255/255f) },

        // Wall_C
        {"Wall_C_N", new Color(0,40/255f,0,159/255f) },
        {"Wall_C_E", new Color(0,40/255f,0,191/255f) },
        {"Wall_C_S", new Color(0,40/255f,0,223/255f) },
        {"Wall_C_W", new Color(0,40/255f,0,255/255f) },

        // Wall_D
        {"Wall_D_N", new Color(0,60/255f,0,159/255f) },
        {"Wall_D_E", new Color(0,60/255f,0,191/255f) },
        {"Wall_D_S", new Color(0,60/255f,0,223/255f) },
        {"Wall_D_W", new Color(0,60/255f,0,255/255f) },

        // Wall_E
        {"Wall_E_N", new Color(0,80/255f,0,159/255f) },
        {"Wall_E_E", new Color(0,80/255f,0,191/255f) },
        {"Wall_E_S", new Color(0,80/255f,0,223/255f) },
        {"Wall_E_W", new Color(0,80/255f,0,255/255f) },

        // Arch_A
        {"Arch_A_NS", new Color(0,100/255f,0,223/255f) },
        {"Arch_A_EW", new Color(0,100/255f,0,255/255f) },

            // Doors

        // Rec_Door_A
        {"Rec_Door_A_N", new Color(20/255f,0,0,159/255f) },
        {"Rec_Door_A_E", new Color(20/255f,0,0,191/255f) },
        {"Rec_Door_A_S", new Color(20/255f,0,0,223/255f) },
        {"Rec_Door_A_W", new Color(20/255f,0,0,255/255f) },

        // Arch_Door_B
        {"Arch_Door_B_N", new Color(20/255f,20/255f,0,159/255f) },
        {"Arch_Door_B_E", new Color(20/255f,20/255f,0,191/255f) },
        {"Arch_Door_B_S", new Color(20/255f,20/255f,0,223/255f) },
        {"Arch_Door_B_W", new Color(20/255f,20/255f,0,255/255f) },

        // Rec_Door_C
        {"Rec_Door_C_N", new Color(20/255f,60/255f,0,159/255f) },
        {"Rec_Door_C_E", new Color(20/255f,60/255f,0,191/255f) },
        {"Rec_Door_C_S", new Color(20/255f,60/255f,0,223/255f) },
        {"Rec_Door_C_W", new Color(20/255f,60/255f,0,255/255f) },

            // Stairs

        // TODO

            // Floors

        // Floor_A
        {"Floor_A", new Color(80/255f,0,0,1f) },
        {"Floor_B", new Color(80/255f,20/255f,0,1f) },
        {"Floor_Gate", new Color(80/255f,40/255f,0,1f) },

            // Special

        {"StartPoint", new Color(250/255f,50/255f,0,1f) },
        {"EndPoint", new Color(250/255f,200/255f,0,1f) }
    };

    public Color getWall(Walls wall, DirectionsEnum direction)
    {
        Color elementColor = new Color(100 / 255f, 100 / 255f, 100 / 255f, 1f);
        switch (wall)
        {
            case Walls.Wall_A:
                if (direction == DirectionsEnum.North)
                    elementColor = elements["Wall_A_N"];
                if (direction == DirectionsEnum.East)
                    elementColor = elements["Wall_A_E"];
                if (direction == DirectionsEnum.South)
                    elementColor = elements["Wall_A_S"];
                if (direction == DirectionsEnum.West)
                    elementColor = elements["Wall_A_W"];
                break;

            case Walls.Wall_B:
                if (direction == DirectionsEnum.North)
                    elementColor = elements["Wall_B_N"];
                if (direction == DirectionsEnum.East)
                    elementColor = elements["Wall_B_E"];
                if (direction == DirectionsEnum.South)
                    elementColor = elements["Wall_B_S"];
                if (direction == DirectionsEnum.West)
                    elementColor = elements["Wall_B_W"];
                break;

            case Walls.Wall_C:
                if (direction == DirectionsEnum.North)
                    elementColor = elements["Wall_C_N"];
                if (direction == DirectionsEnum.East)
                    elementColor = elements["Wall_C_E"];
                if (direction == DirectionsEnum.South)
                    elementColor = elements["Wall_C_S"];
                if (direction == DirectionsEnum.West)
                    elementColor = elements["Wall_C_W"];
                break;

            case Walls.Wall_D:
                if (direction == DirectionsEnum.North)
                    elementColor = elements["Wall_D_N"];
                if (direction == DirectionsEnum.East)
                    elementColor = elements["Wall_D_E"];
                if (direction == DirectionsEnum.South)
                    elementColor = elements["Wall_D_S"];
                if (direction == DirectionsEnum.West)
                    elementColor = elements["Wall_D_W"];
                break;

            case Walls.Wall_E:
                if (direction == DirectionsEnum.North)
                    elementColor = elements["Wall_E_N"];
                if (direction == DirectionsEnum.East)
                    elementColor = elements["Wall_E_E"];
                if (direction == DirectionsEnum.South)
                    elementColor = elements["Wall_E_S"];
                if (direction == DirectionsEnum.West)
                    elementColor = elements["Wall_E_W"];
                break;
            case Walls.Arch_A:
                if (direction == DirectionsEnum.North || direction == DirectionsEnum.South)
                    elementColor = elements["Arch_A_NS"];
                if (direction == DirectionsEnum.East || direction == DirectionsEnum.West)
                    elementColor = elements["Arch_A_EW"];
                break;
        }
        return elementColor;
    }

    public Color getDoors(Doors door, DirectionsEnum direction)
    {
        Color elementColor = new Color(100 / 255f, 100 / 255f, 100 / 255f, 1f);
        switch (door)
        {
            case Doors.Rec_Door_A:
                if(direction == DirectionsEnum.North)
                    elementColor = elements["Rec_Door_A_N"];
                if (direction == DirectionsEnum.East)
                    elementColor = elements["Rec_Door_A_E"];
                if (direction == DirectionsEnum.South)
                    elementColor = elements["Rec_Door_A_S"];
                if (direction == DirectionsEnum.West)
                    elementColor = elements["Rec_Door_A_W"];
                break;
            case Doors.Arch_Door_B:
                if(direction == DirectionsEnum.North)
                    elementColor = elements["Arch_Door_B_N"];
                if (direction == DirectionsEnum.East)
                    elementColor = elements["Arch_Door_B_E"];
                if (direction == DirectionsEnum.South)
                    elementColor = elements["Arch_Door_B_S"];
                if (direction == DirectionsEnum.West)
                    elementColor = elements["Arch_Door_B_W"];
                break;
            case Doors.Rec_Door_C:
                if (direction == DirectionsEnum.North)
                    elementColor = elements["Rec_Door_C_N"];
                if (direction == DirectionsEnum.East)
                    elementColor = elements["Rec_Door_C_E"];
                if (direction == DirectionsEnum.South)
                    elementColor = elements["Rec_Door_C_S"];
                if (direction == DirectionsEnum.West)
                    elementColor = elements["Rec_Door_C_W"];
                break;
        }
        return elementColor;
    }

    public Color getFloors(Floors floor)
    {
        Color elementColor = new Color(100 / 255f, 100 / 255f, 100 / 255f, 1);
        switch (floor)
        {
            case Floors.Floor_A:
                elementColor = elements["Floor_A"];
                break;
            case Floors.Floor_B:
                elementColor = elements["Floor_B"];
                break;
            case Floors.Floor_Gate:
                elementColor = elements["Floor_Gate"];
                break;
        }
        return elementColor;
    }

    public Color getSpecial(Special special)
    {
        Color elementColor = new Color(100 / 255f, 100 / 255f, 100 / 255f, 1);
        switch (special)
        {
            case Special.StartPoint:
                elementColor = elements["StartPoint"];
                break;
            case Special.EndPoint:
                elementColor = elements["EndPoint"];
                break;
        }
        return elementColor;
    }

    public enum Walls
    {
        Wall_A,
        Wall_B,
        Wall_C,
        Wall_D,
        Wall_E,
        Arch_A

    }

    public enum Doors
    {
        Rec_Door_A,
        Arch_Door_B,
        Rec_Door_C
    }

    public enum Floors
    {
        Floor_A,
        Floor_B,
        Floor_Gate
    }
    
    public enum Special
    {
        StartPoint,
        EndPoint
    }
} 