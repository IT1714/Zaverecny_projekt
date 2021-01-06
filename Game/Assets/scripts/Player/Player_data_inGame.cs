using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player_data_inGame
{
    public string classesString;
    public float xp;
    public string saveSlot;
    public string Name;
    public float Intellect;
    public float Agility;
    public float Strength;
    public float Stamina;
    public int lvl;
    public float[] position;
    public int character;
    

    public Player_data_inGame(stats player){
        classesString = player.Class;
        saveSlot = player.saveSlot;
        lvl = player.lvl;
        Name = player.Name;
        xp = player.XP;
        Intellect = player.Intellect;
        Agility = player.Agility;
        Strength = player.Strength;
        Stamina = player.Stamina;
        position = new float[3];
        position[0]=player.transform.position.x;
        position[1]=player.transform.position.y;
        position[2]=player.transform.position.z;
        character= player.character;
    }
}
