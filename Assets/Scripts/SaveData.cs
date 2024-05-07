using System;
using UnityEngine;

[Serializable]
public class SaveData
{
    public int scrapMetal = 0;
    public int coins = 0;
    public int gold = 0;
    public int silver = 0;
    public int copper = 0;
    public int iron = 0;

    public bool key1;
    public bool key2;
    public bool key3;
    public bool key4;

    public bool shootgun = true;
    public bool pistol;
    public bool AR;
    public bool HasShootgun = true;
    public bool HasPistol = true; 
    public bool HasAR = true;
}
