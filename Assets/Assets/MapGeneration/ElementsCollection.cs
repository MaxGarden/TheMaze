using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementsCollection : MonoBehaviour
{
    private Dictionary<string, Color> elements = new Dictionary<string, Color>()
    {
            // Walls

        // Wall_A
        {"Wall_A_N", new Color(0,0,0,159) },
        {"Wall_A_E", new Color(0,0,0,191) },
        {"Wall_A_S", new Color(0,0,0,223) },
        {"Wall_A_W", new Color(0,0,0,255) },

        // Wall_B
        {"Wall_B_N", new Color(0,20,0,159) },
        {"Wall_B_E", new Color(0,20,0,191) },
        {"Wall_B_S", new Color(0,20,0,223) },
        {"Wall_B_W", new Color(0,20,0,255) },

        // Wall_C
        {"Wall_C_N", new Color(0,40,0,159) },
        {"Wall_C_E", new Color(0,40,0,191) },
        {"Wall_C_S", new Color(0,40,0,223) },
        {"Wall_C_W", new Color(0,40,0,255) },

        // Wall_D
        {"Wall_D_N", new Color(0,60,0,159) },
        {"Wall_D_E", new Color(0,60,0,191) },
        {"Wall_D_S", new Color(0,60,0,223) },
        {"Wall_D_W", new Color(0,60,0,255) },

        // Wall_E
        {"Wall_E_N", new Color(0,80,0,159) },
        {"Wall_E_E", new Color(0,80,0,191) },
        {"Wall_E_S", new Color(0,80,0,223) },
        {"Wall_E_W", new Color(0,80,0,255) },

        // Arch_A
        {"Arch_A_NS", new Color(0,100,0,223) },
        {"Arch_A_EW", new Color(0,100,0,255) },

            // Doors

        // Rec_Door_A
        {"Rec_Door_A_N", new Color(20,0,0,159) },
        {"Rec_Door_A_E", new Color(20,0,0,191) },
        {"Rec_Door_A_S", new Color(20,0,0,223) },
        {"Rec_Door_A_W", new Color(20,0,0,255) },

        // Arch_Door_B
        {"Arch_Door_B_N", new Color(20,20,0,159) },
        {"Arch_Door_B_E", new Color(20,20,0,191) },
        {"Arch_Door_B_S", new Color(20,20,0,223) },
        {"Arch_Door_B_W", new Color(20,20,0,255) },

        // Rec_Door_C
        {"Rec_Door_C_N", new Color(20,60,0,159) },
        {"Rec_Door_C_E", new Color(20,60,0,191) },
        {"Rec_Door_C_S", new Color(20,60,0,223) },
        {"Rec_Door_C_W", new Color(20,60,0,255) },

            // Stairs

        // TODO

            // Floors

        // Floor_A
        {"Floor_A", new Color(80,0,0,255) },
        {"Floor_B", new Color(80,20,0,255) },
        {"Floor_Gate", new Color(80,40,0,255) }
    };

    public Color getWall(Walls wall, DirectionsEnum direction)
    {
        Color toReturn = new Color(100, 100, 100, 255);
        switch (wall)
        {
            case Walls.Wall_A:
                if (direction == DirectionsEnum.North)
                    toReturn = elements["Wall_A_N"];
                if (direction == DirectionsEnum.East)
                    toReturn = elements["Wall_A_E"];
                if (direction == DirectionsEnum.South)
                    toReturn = elements["Wall_A_S"];
                if (direction == DirectionsEnum.West)
                    toReturn = elements["Wall_A_W"];
                break;

            case Walls.Wall_B:
                if (direction == DirectionsEnum.North)
                    toReturn = elements["Wall_B_N"];
                if (direction == DirectionsEnum.East)
                    toReturn = elements["Wall_B_E"];
                if (direction == DirectionsEnum.South)
                    toReturn = elements["Wall_B_S"];
                if (direction == DirectionsEnum.West)
                    toReturn = elements["Wall_B_W"];
                break;

            case Walls.Wall_C:
                if (direction == DirectionsEnum.North)
                    toReturn = elements["Wall_C_N"];
                if (direction == DirectionsEnum.East)
                    toReturn = elements["Wall_C_E"];
                if (direction == DirectionsEnum.South)
                    toReturn = elements["Wall_C_S"];
                if (direction == DirectionsEnum.West)
                    toReturn = elements["Wall_C_W"];
                break;

            case Walls.Wall_D:
                if (direction == DirectionsEnum.North)
                    toReturn = elements["Wall_D_N"];
                if (direction == DirectionsEnum.East)
                    toReturn = elements["Wall_D_E"];
                if (direction == DirectionsEnum.South)
                    toReturn = elements["Wall_D_S"];
                if (direction == DirectionsEnum.West)
                    toReturn = elements["Wall_D_W"];
                break;

            case Walls.Wall_E:
                if (direction == DirectionsEnum.North)
                    toReturn = elements["Wall_E_N"];
                if (direction == DirectionsEnum.East)
                    toReturn = elements["Wall_E_E"];
                if (direction == DirectionsEnum.South)
                    toReturn = elements["Wall_E_S"];
                if (direction == DirectionsEnum.West)
                    toReturn = elements["Wall_E_W"];
                break;
            case Walls.Arch_A:
                if (direction == DirectionsEnum.North || direction == DirectionsEnum.South)
                    toReturn = elements["Arch_A_NS"];
                if (direction == DirectionsEnum.East || direction == DirectionsEnum.West)
                    toReturn = elements["Arch_A_EW"];
                break;
        }
        return toReturn;
    }

    public Color getDoors(Doors door, DirectionsEnum direction)
    {
        Color toReturn = new Color(100, 100, 100, 255);
        switch(door)
        {
            case Doors.Rec_Door_A:
                if(direction == DirectionsEnum.North)
                    toReturn = elements["Rec_Door_A_N"];
                if (direction == DirectionsEnum.East)
                    toReturn = elements["Rec_Door_A_E"];
                if (direction == DirectionsEnum.South)
                    toReturn = elements["Rec_Door_A_S"];
                if (direction == DirectionsEnum.West)
                    toReturn = elements["Rec_Door_A_W"];
                break;
            case Doors.Arch_Door_B:
                if(direction == DirectionsEnum.North)
                    toReturn = elements["Arch_Door_B_N"];
                if (direction == DirectionsEnum.East)
                    toReturn = elements["Arch_Door_B_E"];
                if (direction == DirectionsEnum.South)
                    toReturn = elements["Arch_Door_B_S"];
                if (direction == DirectionsEnum.West)
                    toReturn = elements["Arch_Door_B_W"];
                break;
            case Doors.Rec_Door_C:
                if (direction == DirectionsEnum.North)
                    toReturn = elements["Rec_Door_C_N"];
                if (direction == DirectionsEnum.East)
                    toReturn = elements["Rec_Door_C_E"];
                if (direction == DirectionsEnum.South)
                    toReturn = elements["Rec_Door_C_S"];
                if (direction == DirectionsEnum.West)
                    toReturn = elements["Rec_Door_C_W"];
                break;
        }
        return toReturn;
    }

    public Color getFloors(Floors floor)
    {
        Color toReturn = new Color(100, 100, 100, 255);
        switch (floor)
        {
            case Floors.Floor_A:
                toReturn = elements["Floor_A"];
                break;
            case Floors.Floor_B:
                toReturn = elements["Floor_B"];
                break;
            case Floors.Floor_Gate:
                toReturn = elements["Floor_Gate"];
                break;
        }
        return toReturn;
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
} 