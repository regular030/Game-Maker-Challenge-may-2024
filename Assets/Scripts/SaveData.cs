using System;
using UnityEngine;

[Serializable]
public class SaveData
{
    public int scrapMetal;
    public int coins;
    public int gold;
    public int silver;
    public int copper;
    public int iron;

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
