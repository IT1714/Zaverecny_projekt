using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSys
{
    public static void SavePlayer(CreateCharacter player, string saveSlot){
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/"+saveSlot+".txt";
        FileStream stream = new FileStream(path, FileMode.Create);

        Player_data data = new Player_data(player);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static Player_data LoadPlayerWithSave(string save){
        string path = Application.persistentDataPath +"/"+save+".txt";
        if(File.Exists(path)){
            BinaryFormatter formatter =new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            Player_data data = formatter.Deserialize(stream) as Player_data;
            stream.Close();
            return data;
        }else{
            //Debug.Log("lul");
            return null;

        }
    }
    public static void SavePlayerInGame(stats player, string saveSlot){
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/"+saveSlot+"pom.txt";
        FileStream stream = new FileStream(path, FileMode.Create);

        Player_data_inGame data = new Player_data_inGame(player);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static Player_data_inGame LoadPlayerWithSaveInGame(string save){
        string path = Application.persistentDataPath +"/"+save+"pom.txt";
        if(File.Exists(path)){
            BinaryFormatter formatter =new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            Player_data_inGame data = formatter.Deserialize(stream) as Player_data_inGame;
            stream.Close();
            return data;
        }else{
            //Debug.Log("lul");
            return null;

        }
    }
}
