using System;
using UnityEngine;

[Serializable]
public class SaveData
{
    public int scrapMetal = 19;
    public int coins = 10;
    public int gold = 11;
    public int silver = 53;
    public int copper = 63;
    public int iron = 12;

    public bool key1;
    public bool key2;
    public bool key3;
    public bool key4;

    public bool shootgun = true;
    public bool pistol = false;
    public bool AR = false;
    public bool HasShootgun = true;
    public bool HasPistol = true; 
    public bool HasAR = true;
}
