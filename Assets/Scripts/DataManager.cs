using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;



    private GameData data;
    private string file = "highscore.json";

    public string playername="Player";
    public int currenthighScore = 0;
    public int currentScore = 0;
    public bool isnewscore = false;
    private void Awake()
    {


        if(instance==null)
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
    private void Start()
    {
        data = new GameData();
        currentScore = 0;

        data.scoredata = new List<GameData.scores>();
      
        Debug.Log("data before : " + data.scoredata.Count);
      

        Load();

    


        currenthighScore = data.scoredata[0].score;
        Debug.Log("data after : " + data.scoredata.Count);
    }
    private void OnLevelWasLoaded(int level)
    {
        if (level == 0)
        {
            data = new GameData();
            currentScore = 0;
            isnewscore = false;
            data.scoredata = new List<GameData.scores>();

            Debug.Log("data before : " + data.scoredata.Count);


            Load();




            currenthighScore = data.scoredata[0].score;
            Debug.Log("data after : " + data.scoredata.Count);
        }
    }

    public bool check_Can_StoreNewHighScore()
    {

        bool check = false;

        if (data.scoredata.Count < 10)
        {
            check = true;
        }
        else
        {
            for (int i = 0; i < data.scoredata.Count; i++)
            {
                if (currentScore >= data.scoredata[i].score)
                {
                    check = true;
                }


            }
        }

        return check;
    }

    public void savenewHighScore(int n)
    {





       
        //bool valset = false;
        //for (int i = 0; i < data.scoredata.Count; i++)
        //{
        //    if (data.scoredata[i].name.Equals(playername))
        //    {
        //        GameData.scores temp = new GameData.scores();
        //        temp.name = playername;
        //        temp.score = n;
        //        data.scoredata[i] = temp;
        //        valset = true;
        //        break;
        //    }
        //}

       // if (valset == false)
        {
            GameData.scores tempdata = new GameData.scores();
            tempdata.name = playername;
            tempdata.score = n;

            data.scoredata.Add(tempdata);

        }

        for (int i = 0; i < data.scoredata.Count-1; i++)
        {
            int n1 = data.scoredata[i].score;
            int n2 = data.scoredata[i+1].score;

            if(n1<n2)
            {
                GameData.scores temp = new GameData.scores();
                 temp= data.scoredata[i];

                data.scoredata[i] = data.scoredata[i + 1];

                data.scoredata[i + 1] = temp;
                i =- 1;




            }

        }


        int len = data.scoredata.Count;

        
            if(len>10)
            {
                data.scoredata.RemoveAt(data.scoredata.Count-1);
            }

        
        

        Save();
    }
    public void Load()
    {

        data = new GameData();
        data.scoredata = new List<GameData.scores>();

        string path = GetFilePath(file);
        if (File.Exists(path))
        {
            string json = ReadFromFIle(file);

            JsonUtility.FromJsonOverwrite(json, data);

            loaddatatoui();
        }else
        {
            GameData.scores tempdata = new GameData.scores();
            tempdata.name = playername;
            tempdata.score = 0;
            data.scoredata.Add(tempdata);
            Save();
            Load();
        }
    }

    public void Save()
    {
        Debug.Log("saving data");
        string json = JsonUtility.ToJson(data);
        WriteToFile(file, json);
    }

    private void WriteToFile(string fileName, string json)
    {
        string path = GetFilePath(fileName);
        FileStream fileStream = new FileStream(path, FileMode.Create);
        Debug.Log("path : " + path);
        using (StreamWriter writer = new StreamWriter(fileStream))
        {
            writer.Write(json);
        }
    }

    private string ReadFromFIle(string fileName)
    {
        string path = GetFilePath(fileName);
        if (File.Exists(path))
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string json = reader.ReadToEnd();
                return json;
            }
        }
        else
        {
            Debug.LogWarning("File not found");
        }
       
        return "Success";
    }
    public void loaddatatoui()
    {
        Debug.Log("setting data");
        for (int i = 0; i < ShowScore.instance.uiscore.Count; i++)
        {
            if (i < data.scoredata.Count)
            {
                ShowScore.instance.uiscore[i].txt_name.text = "" + data.scoredata[i].name;
                ShowScore.instance.uiscore[i].txt_score.text = "" + data.scoredata[i].score;
            }else
            {
                ShowScore.instance.uiscore[i].txt_name.text = ""    ;
                ShowScore.instance.uiscore[i].txt_score.text = ""  ;

            }
        }
    }

    private string GetFilePath(string fileName)
    {
        return Application.persistentDataPath + "/" + fileName;
    }

    private void OnApplicationPause(bool pause)
    {
        if (pause) Save();
    }
}
