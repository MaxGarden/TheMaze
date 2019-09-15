using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementsCollection
{
    private Dictionary<string, Color> elements = new Dictionary<string, Color>()
    {
            // Walls

        // Wall_A
        {"Wall_A_N", new Color32(0,0,159,255) },
        {"Wall_A_E", new Color32(0,0,191,255) },
        {"Wall_A_S", new Color32(0,0,223,255) },
        {"Wall_A_W", new Color32(0,0,255,255) },

        // Wall_B
        {"Wall_B_N", new Color32(0,20,159,255) },
        {"Wall_B_E", new Color32(0,20,191,255) },
        {"Wall_B_S", new Color32(0,20,223,255) },
        {"Wall_B_W", new Color32(0,20,255,255) },

        // Wall_C
        {"Wall_C_N", new Color32(0,40,159,255) },
        {"Wall_C_E", new Color32(0,40,191,255) },
        {"Wall_C_S", new Color32(0,40,223,255) },
        {"Wall_C_W", new Color32(0,40,255,255) },

        // Wall_D
        {"Wall_D_N", new Color32(0,60,159,255) },
        {"Wall_D_E", new Color32(0,60,191,255) },
        {"Wall_D_S", new Color32(0,60,223,255) },
        {"Wall_D_W", new Color32(0,60,255,255) },

        // Wall_E
        {"Wall_E_N", new Color32(0,80,159,255) },
        {"Wall_E_E", new Color32(0,80,191,255) },
        {"Wall_E_S", new Color32(0,80,223,255) },
        {"Wall_E_W", new Color32(0,80,255,255) },

        // Arch_A
        {"Arch_A_NS", new Color32(0,100,223,255) },
        {"Arch_A_EW", new Color32(0,100,255,255) },

            // Doors

        // Rec_Door_A
        {"Rec_Door_A_N", new Color32(20,0,159,255) },
        {"Rec_Door_A_E", new Color32(20,0,191,255) },
        {"Rec_Door_A_S", new Color32(20,0,223,255) },
        {"Rec_Door_A_W", new Color32(20,0,255,255) },

        // Arch_Door_B
        {"Arch_Door_B_N", new Color32(20,20,159,255) },
        {"Arch_Door_B_E", new Color32(20,20,191,255) },
        {"Arch_Door_B_S", new Color32(20,20,223,255) },
        {"Arch_Door_B_W", new Color32(20,20,255,255) },

        // Rec_Door_C
        {"Rec_Door_C_N", new Color32(20,60,159,255) },
        {"Rec_Door_C_E", new Color32(20,60,191,255) },
        {"Rec_Door_C_S", new Color32(20,60,223,255) },
        {"Rec_Door_C_W", new Color32(20,60,255,255) },

            // Stairs

        // TODO

            // Props

        // Torch + Wall
        {"Torch_N", new Color32(60,0,159,255) },
        {"Torch_E", new Color32(60,0,191,255) },
        {"Torch_S", new Color32(60,0,223,255) },
        {"Torch_W", new Color32(60,0,255,255) },

            // Floors

        // Floor_A
        {"Floor_A", new Color32(80,0,255,255) },
        {"Floor_B", new Color32(80,20,255,255) },
        {"Floor_Gate", new Color32(80,40,255,255) },

            // Special

        {"StartPoint", new Color32(250,50,255,255) },
        {"EndPoint", new Color32(250,200,255,255) },
        {"SpikeTrap", new Color32(250,100,255,255) }
    };

    public Color32 getWall(Walls wall, DirectionsEnum direction)
    {
        Color32 elementColor = new Color32(100, 100 , 100, 255);
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

    public Color32 getDoors(Doors door, DirectionsEnum direction)
    {
        Color32 elementColor = new Color32(100, 100, 100, 255);
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

    public Color32 getProp(Props prop, DirectionsEnum direction)
    {
        Color32 elementColor = new Color32(100, 100, 100, 255);
        switch (prop)
        {
            case Props.Torch_N:
                elementColor = elements["Torch_N"];
                break;
            case Props.Torch_E:
                elementColor = elements["Torch_E"];
                break;
            case Props.Torch_S:
                elementColor = elements["Torch_S"];
                break;
            case Props.Torch_W:
                elementColor = elements["Torch_W"];
                break;
        }
        return elementColor;
    }

    public Color32 getFloors(Floors floor)
    {
        Color32 elementColor = new Color32(100, 100, 100, 255);
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

    public Color32 getSpecial(Special special)
    {
        Color32 elementColor = new Color32(100, 100, 100, 255);
        switch (special)
        {
            case Special.StartPoint:
                elementColor = elements["StartPoint"];
                break;
            case Special.EndPoint:
                elementColor = elements["EndPoint"];
                break;
            case Special.SpikeTrap:
                elementColor = elements["SpikeTrap"];
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

    public enum Props
    {
        Torch_N,
        Torch_E,
        Torch_S,
        Torch_W
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
        EndPoint,
        SpikeTrap
    }
} 