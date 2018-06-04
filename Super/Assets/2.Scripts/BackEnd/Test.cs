using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using System;
using System.IO;

public class Skill
{
    public int ID;
    public string SkillName;

    public Skill(int id, string skillName)
    {
        ID = id;
        SkillName = skillName;
    }
}

public class Test : MonoBehaviour {

    public List<Skill> SkillList = new List<Skill>();

    void JsonTest()
    {
        TextAsset Json = Resources.Load("json/jsonfile") as TextAsset;
        string JsonStr = Json.text;

        var JsonData = JSON.Parse(JsonStr);
        if(JsonData["data"]["Skill"] == null)
        {
            JsonData["data"].Add("Skill");
        }
        var versionString = JsonData["version"].Value;
        var versionNumber = JsonData["version"].AsFloat;
        //var name = JsonData["data"]["sampleArray"][2]["name"].ToString();

        
        Debug.Log(JsonData);
    }

    void SaveJson()
    {

        if (!File.Exists(Application.dataPath + "/Save/Savefile.json"))
        {
            TextAsset Json = Resources.Load("json/jsonfile") as TextAsset;
            string JsonStr = Json.text;

            var JsonData = JSON.Parse(JsonStr);
            
            File.WriteAllText(Application.dataPath + "/Save/Savefile.json", JsonData.ToString());
            
        }
        string SaveStr = File.ReadAllText(Application.dataPath + "/Save/Savefile.json");

        var SaveData = JSON.Parse(SaveStr);

        //세이브 내용

        foreach (Skill skill in SkillList)
        {
            if (SaveData["data"]["Skill"][skill.SkillName.ToString()] == null)
            {
                SaveData["data"]["Skill"].Add(skill.SkillName, skill.ID);
            }
        }


        File.WriteAllText(Application.dataPath + "/Save/Savefile.json", SaveData.ToString());
    }

    void LoadJson()
    {
        if(!File.Exists(Application.dataPath + "/Save/Savefile.json"))
        {
            Debug.Log("Found Not SaveData");
            return;
        }
        string LoadStr = File.ReadAllText(Application.dataPath + "/Save/Savefile.json");

        var LoadData = JSON.Parse(LoadStr);

        //LoadData에 들어있는 값을 각 스크립트에 넣어줘야됨



    }
    
    public void SkillSave(Skill skill)
    {
        SkillList.Add(skill);
    }
    public void JsonStart()
    {
        SaveJson();
    }
    

    private void Start()
    {
        
    }
}