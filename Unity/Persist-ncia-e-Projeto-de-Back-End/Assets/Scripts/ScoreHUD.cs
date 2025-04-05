using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ScoreHUD : MonoBehaviour
{
    public static ScoreHUD instace;
    public Text txtScore;
    public int points = 0;

    //Sistema de save
    private string path;

    void Awake()
    {
        instace = this;
    }
    void Start()
    {
        path = Application.persistentDataPath + "/Points.txt";
        Debug.Log(path);
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.L)){
            Load();
        }
         if(Input.GetKeyDown(KeyCode.K)){
            Save();
        }
    }
    /*public void ScoreStart(){
        points = PlayerPrefs.GetInt("points",0);
        ScoreUpdate(points);
    }*/
    public void ScoreUpdate(int points){
         txtScore.text = "Score: " + points;
    }
    void Load(){
        points = Int32.Parse(File.ReadAllText(path));
        ScoreUpdate(points);
    }
    void Save(){
        File.WriteAllText(path, points.ToString());
        ScoreUpdate(points);
    }
}
