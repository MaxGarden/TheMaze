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

        // Key_Door
        {"Key_Door_N", new Color32(20,80,159,255) },
        {"Key_Door_E", new Color32(20,80,191,255) },
        {"Key_Door_S", new Color32(20,80,223,255) },
        {"Key_Door_W", new Color32(20,80,255,255) },
            // Props

        // Torch + Wall
        {"Torch_N", new Color32(60,0,159,255) },
        {"Torch_E", new Color32(60,0,191,255) },
        {"Torch_S", new Color32(60,0,223,255) },
        {"Torch_W", new Color32(60,0,255,255) },
        {"BarrelFloorA_N", new Color32(60,10,159,255) },
        {"BarrelFloorA_E", new Color(60,10,191,255) },
        {"BarrelFloorA_S", new Color(60,10,223,255) },
        {"BarrelFloorA_W", new Color(60,10,255,255) },
        {"BarrelFloorB_N", new Color32(60,20,159, 255) },
        {"BarrelFloorB_E", new Color32(60,20,191, 255) },
        {"BarrelFloorB_S", new Color32(60,20,223, 255) },
        {"BarrelFloorB_W", new Color32(60,20,255, 255) },
        {"BucketFloorA_N", new Color32(60,30,159,255) },
        {"BucketFloorA_E", new Color32(60,30,191,255) },
        {"BucketFloorA_S", new Color32(60,30,223,255) },
        {"BucketFloorA_W", new Color32(60,30,255,255) },
        {"BucketFloorB_N", new Color32(60,40,159,255) },
        {"BucketFloorB_E", new Color32(60,40,191,255) },
        {"BucketFloorB_S", new Color32(60,40,223,255) },
        {"BucketFloorB_W", new Color32(60,40,255,255) },
        {"TableAFloorA_N", new Color32(60,50,159,255) },
        {"TableAFloorA_E", new Color32(60,50,191,255) },
        {"TableAFloorA_S", new Color32(60,50,223,255) },
        {"TableAFloorA_W", new Color32(60,50,255,255) },
        {"TableAFloorB_N", new Color32(60,110,159,255) },
        {"TableAFloorB_E", new Color32(60,110,191,255) },
        {"TableAFloorB_S", new Color32(60,110,223,255) },
        {"TableAFloorB_W", new Color32(60,110,255,255) },
        {"TableACandleFloorA_N", new Color32(60,80,159,255) },
        {"TableACandleFloorA_E", new Color32(60,80,191,255) },
        {"TableACandleFloorA_S", new Color32(60,80,223,255) },
        {"TableACandleFloorA_W", new Color32(60,80,255,255) },
        {"TableACandleFloorB_N", new Color32(60,140,159,255) },
        {"TableACandleFloorB_E", new Color32(60,140,191,255) },
        {"TableACandleFloorB_S", new Color32(60,140,223,255) },
        {"TableACandleFloorB_W", new Color32(60,140,255,255) },
        {"TableACandleKey_N", new Color32(60,170,159,255) },
        {"TableACandleKey_E", new Color32(60,170,191,255) },
        {"TableACandleKey_S", new Color32(60,170,223,255) },
        {"TableACandleKey_W", new Color32(60,170,255,255) },

            // Floors

        // Floor_A
        {"Floor_A", new Color32(80,0,255,255) },
        {"Floor_B", new Color32(80,20,255,255) },
        {"Floor_Gate", new Color32(80,40,255,255) },

            // Special

        {"StartPoint", new Color32(250,50,255,255) },
        {"EndPoint", new Color32(250,200,255,255) },
        {"SpikeTrap", new Color32(250,100,255,255) },
        {"MedkitFloorA", new Color32(250,125,25,255) },
        {"MedkitFloorB", new Color32(250,130,255,255)},
        {"FlashlightTableCFloorA_N", new Color32(250,150,159,255) },
        {"FlashlightTableCFloorA_E", new Color32(250,150,191,255) },
        {"FlashlightTableCFloorA_S", new Color32(250,150,223,255) },
        {"FlashlightTableCFloorA_W", new Color32(250,150,255,255) },
        {"FlashlightTableCFloorB_N", new Color32(250,155,159,255) },
        {"FlashlightTableCFloorB_E", new Color32(250,155,191,255) },
        {"FlashlightTableCFloorB_S", new Color32(250,155,223,255) },
        {"FlashlightTableCFloorB_W", new Color32(250,155,255,255) },
        {"CoinFloorA", new Color32(250,180,255,255) },
        {"CoinFloorB", new Color32(250,190,255,255) }
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
            case Doors.Key_Door:
                if (direction == DirectionsEnum.North)
                    elementColor = elements["Key_Door_N"];
                if (direction == DirectionsEnum.East)
                    elementColor = elements["Key_Door_E"];
                if (direction == DirectionsEnum.South)
                    elementColor = elements["Key_Door_S"];
                if (direction == DirectionsEnum.West)
                    elementColor = elements["Key_Door_W"];
                break;
        }
        return elementColor;
    }

    public Color32 getProp(Props prop)
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
            case Props.BarrelFloorA_N:
                elementColor = elements["BarrelFloorA_N"];
                break;
            case Props.BarrelFloorA_E:
                elementColor = elements["BarrelFloorA_E"];
                break;
            case Props.BarrelFloorA_S:
                elementColor = elements["BarrelFloorA_S"];
                break;
            case Props.BarrelFloorA_W:
                elementColor = elements["BarrelFloorA_W"];
                break;
            case Props.BarrelFloorB_N:
                elementColor = elements["BarrelFloorB_N"];
                break;
            case Props.BarrelFloorB_E:
                elementColor = elements["BarrelFloorB_E"];
                break;
            case Props.BarrelFloorB_S:
                elementColor = elements["BarrelFloorB_S"];
                break;
            case Props.BarrelFloorB_W:
                elementColor = elements["BarrelFloorB_W"];
                break;
            case Props.BucketFloorA_N:
                elementColor = elements["BucketFloorA_N"];
                break;
            case Props.BucketFloorA_E:
                elementColor = elements["BucketFloorA_E"];
                break;
            case Props.BucketFloorA_S:
                elementColor = elements["BucketFloorA_S"];
                break;
            case Props.BucketFloorA_W:
                elementColor = elements["BucketFloorA_W"];
                break;
            case Props.BucketFloorB_N:
                elementColor = elements["BucketFloorB_N"];
                break;
            case Props.BucketFloorB_E:
                elementColor = elements["BucketFloorB_E"];
                break;
            case Props.BucketFloorB_S:
                elementColor = elements["BucketFloorB_S"];
                break;
            case Props.BucketFloorB_W:
                elementColor = elements["BucketFloorB_W"];
                break;
            case Props.TableACandleFloorB_N:
                elementColor = elements["TableACandleFloorB_N"];
                break;
            case Props.TableACandleFloorB_E:
                elementColor = elements["TableACandleFloorB_E"];
                break;
            case Props.TableACandleFloorB_S:
                elementColor = elements["TableACandleFloorB_S"];
                break;
            case Props.TableACandleFloorB_W:
                elementColor = elements["TableACandleFloorB_W"];
                break;
            case Props.TableAFloorB_N:
                elementColor = elements["TableAFloorB_N"];
                break;
            case Props.TableAFloorB_E:
                elementColor = elements["TableAFloorB_E"];
                break;
            case Props.TableAFloorB_S:
                elementColor = elements["TableAFloorB_S"];
                break;
            case Props.TableAFloorB_W:
                elementColor = elements["TableAFloorB_W"];
                break;
            case Props.TableAFloorA_N:
                elementColor = elements["TableAFloorA_N"];
                break;
            case Props.TableAFloorA_E:
                elementColor = elements["TableAFloorA_E"];
                break;
            case Props.TableAFloorA_S:
                elementColor = elements["TableAFloorA_S"];
                break;
            case Props.TableAFloorA_W:
                elementColor = elements["TableAFloorA_W"];
                break;
            case Props.TableACandleFloorA_N:
                elementColor = elements["TableACandleFloorA_N"];
                break;
            case Props.TableACandleFloorA_E:
                elementColor = elements["TableACandleFloorA_E"];
                break;
            case Props.TableACandleFloorA_S:
                elementColor = elements["TableACandleFloorA_S"];
                break;
            case Props.TableACandleFloorA_W:
                elementColor = elements["TableACandleFloorA_W"];
                break;
            case Props.TableACandleKey_N:
                elementColor = elements["TableACandleKey_N"];
                break;
            case Props.TableACandleKey_E:
                elementColor = elements["TableACandleKey_E"];
                break;
            case Props.TableACandleKey_S:
                elementColor = elements["TableACandleKey_S"];
                break;
            case Props.TableACandleKey_W:
                elementColor = elements["TableACandleKey_W"];
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
            case Special.MedkitFloorA:
                elementColor = elements["MedkitFloorA"];
                break;
            case Special.MedkitFloorB:
                elementColor = elements["MedkitFloorB"];
                break;
            case Special.FlashlightTableCFloorA_N:
                elementColor = elements["FlashlightTableCFloorA_N"];
                break;
            case Special.FlashlightTableCFloorA_E:
                elementColor = elements["FlashlightTableCFloorA_E"];
                break;
            case Special.FlashlightTableCFloorA_S:
                elementColor = elements["FlashlightTableCFloorA_S"];
                break;
            case Special.FlashlightTableCFloorA_W:
                elementColor = elements["FlashlightTableCFloorA_W"];
                break;
            case Special.FlashlightTableCFloorB_N:
                elementColor = elements["FlashlightTableCFloorB_N"];
                break;
            case Special.FlashlightTableCFloorB_E:
                elementColor = elements["FlashlightTableCFloorB_E"];
                break;
            case Special.FlashlightTableCFloorB_S:
                elementColor = elements["FlashlightTableCFloorB_S"];
                break;
            case Special.FlashlightTableCFloorB_W:
                elementColor = elements["FlashlightTableCFloorB_W"];
                break;
            case Special.CoinFloorA:
                elementColor = elements["CoinFloorA"];
                break;
            case Special.CoinFloorB:
                elementColor = elements["CoinFloorB"];
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
        Rec_Door_C,
        Key_Door
    }

    public enum Props
    {
        Torch_N,
        Torch_E,
        Torch_S,
        Torch_W,
        BarrelFloorA_N,
        BarrelFloorA_E,
        BarrelFloorA_S,
        BarrelFloorA_W,
        BarrelFloorB_N,
        BarrelFloorB_E,
        BarrelFloorB_S,
        BarrelFloorB_W,
        BucketFloorB_N,
        BucketFloorB_E,
        BucketFloorB_S,
        BucketFloorB_W,
        BucketFloorA_N,
        BucketFloorA_E,
        BucketFloorA_S,
        BucketFloorA_W,
        TableAFloorB_N,
        TableAFloorB_E,
        TableAFloorB_S,
        TableAFloorB_W,
        TableAFloorA_N,
        TableAFloorA_E,
        TableAFloorA_S,
        TableAFloorA_W,
        TableACandleFloorB_N,
        TableACandleFloorB_E,
        TableACandleFloorB_S,
        TableACandleFloorB_W,
        TableACandleFloorA_N,
        TableACandleFloorA_E,
        TableACandleFloorA_S,
        TableACandleFloorA_W,
        
        TableACandleKey_N,
        TableACandleKey_E,
        TableACandleKey_S,
        TableACandleKey_W
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
        SpikeTrap,
        MedkitFloorA,
        MedkitFloorB,
        FlashlightTableCFloorA_N,
        FlashlightTableCFloorA_E,
        FlashlightTableCFloorA_S,
        FlashlightTableCFloorA_W,
        FlashlightTableCFloorB_N,
        FlashlightTableCFloorB_E,
        FlashlightTableCFloorB_S,
        FlashlightTableCFloorB_W,
        CoinFloorA,
        CoinFloorB
    }
} 