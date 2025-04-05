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
    public GameObject player;
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
        Instantiate(player,new Vector3(0,0,0), Quaternion.identity);
    }
   
    /*public void ScoreStart(){
        points = PlayerPrefs.GetInt("points",0);
        ScoreUpdate(points);
    }*/
    public void ScoreUpdate(int points){
         txtScore.text = "Score: " + points;
    }
}
