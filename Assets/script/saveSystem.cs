
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public static class saveSystem 
{
    
   public static void savePlayer(saveDataManager nick){
       BinaryFormatter formatter = new BinaryFormatter();
       string path = Application.persistentDataPath + "/player.sav";
       FileStream stream = new FileStream(path, FileMode.Create);
       gameData data = new gameData(nick);
       formatter.Serialize(stream,data);
       stream.Close();
   }
   public static gameData loadPlayer(){
       string path = Application.persistentDataPath + "/player.sav";
       if(File.Exists(path)){
           BinaryFormatter formatter = new BinaryFormatter();
           FileStream stream = new FileStream(path, FileMode.Open);
           gameData data =formatter.Deserialize(stream) as gameData;
           stream.Close();
           return data;
       }else{
           Debug.Log("file is not found");
           return null;
       }
   }
}
