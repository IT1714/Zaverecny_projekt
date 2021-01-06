using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player_data
{
    public string classesString;
    public int classesInt;
    public string saveSlot;
    public string Name;
    public float Intellect;
    public float Agility;
    public float Strength;
    public float Stamina;
    public int lvl;
    public int character;
    

    public Player_data(CreateCharacter player){
        classesString = player.PlayerClass;
        saveSlot = player.saveSlot;
        lvl = player.lvl;
        Name = player.Name;
        classesInt = player.curent;
        Intellect = player.Intellect;
        Agility = player.Agility;
        Strength = player.Strength;
        Stamina = player.Stamina;
        character = player.characterIMG;
    }
}
