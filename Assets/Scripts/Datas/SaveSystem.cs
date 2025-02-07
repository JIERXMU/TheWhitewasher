using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveSystem
{
    public static void LoadData()
    {
        SaveDataInfor saveDataInfor = new SaveDataInfor();
        saveDataInfor.GetJson();
        SetDatas(saveDataInfor);
    }
    private static void SetDatas(SaveDataInfor saveDataInfor)
    {
        StaticDatas.MaxLevel = saveDataInfor.MaxLevel;
        StaticDatas.IsBeginCGShown = saveDataInfor.IsBeginCGShown;
        StaticDatas.IsDialogCGShown = saveDataInfor.IsDialogCGShown;
        StaticDatas.IsEndCGShown = saveDataInfor.IsEndCGShown;
        StaticDatas.IsTPFDUsed = saveDataInfor.IsTPFDUsed;
        StaticDatas.SESoundVolume = saveDataInfor.SESoundVolume;
        StaticDatas.BGMVolume = saveDataInfor.BGMVolume;

    }
    public static void SaveData()
    {
        SaveDataInfor saveDataInfor = new SaveDataInfor();
        saveDataInfor.MaxLevel = StaticDatas.MaxLevel;
        saveDataInfor.IsBeginCGShown = StaticDatas.IsBeginCGShown;
        saveDataInfor.IsDialogCGShown = StaticDatas.IsDialogCGShown;
        saveDataInfor.IsEndCGShown = StaticDatas.IsEndCGShown;
        saveDataInfor.IsTPFDUsed = StaticDatas.IsTPFDUsed;
        saveDataInfor.SESoundVolume = StaticDatas.SESoundVolume;
        saveDataInfor.BGMVolume = StaticDatas.BGMVolume;
        saveDataInfor.ToJson();
    }

}
[Serializable]
public class SaveDataInfor
{
    public int MaxLevel = 1;
    public bool IsBeginCGShown = false;
    public bool IsDialogCGShown = false;
    public bool IsEndCGShown = false;
    public bool IsTPFDUsed = false;
    public float SESoundVolume = 0.75f;
    public float BGMVolume = 0.75f;
    public void ToJson()
    {
        string json = JsonUtility.ToJson(this);
        Debug.Log("SaveData:" + json);
        if (!Directory.Exists(Application.streamingAssetsPath))
        {
            Directory.CreateDirectory(Application.streamingAssetsPath);
        }
        if (!File.Exists(Application.streamingAssetsPath + "/SaveData.json"))
        {
            File.Create(Application.streamingAssetsPath + "/SaveData.json");
        }
        File.WriteAllText(Application.streamingAssetsPath + "/SaveData.json", json);
    }
    public void GetJson()
    {
        if (!File.Exists(Application.streamingAssetsPath + "/SaveData.json"))
        {
            Debug.Log("SaveData.json not found");
            return;
        }
        else
        {
            string json = File.ReadAllText(Application.streamingAssetsPath + "/SaveData.json");
            FromJson(json);
            Debug.Log("SaveData.json loaded:" + json);
        }
    }
    public void FromJson(string json)
    {
        SaveDataInfor saveDataInfor = JsonUtility.FromJson<SaveDataInfor>(json);
        MaxLevel = saveDataInfor.MaxLevel;
        IsBeginCGShown = saveDataInfor.IsBeginCGShown;
        IsDialogCGShown = saveDataInfor.IsDialogCGShown;
        IsEndCGShown = saveDataInfor.IsEndCGShown;
        IsTPFDUsed = saveDataInfor.IsTPFDUsed;
        SESoundVolume = saveDataInfor.SESoundVolume;
        BGMVolume = saveDataInfor.BGMVolume;

    }
}