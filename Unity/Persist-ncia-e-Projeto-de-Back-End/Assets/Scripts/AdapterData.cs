using UnityEngine;
using System;

public class AdapterData
{
    public static void GetPlayer(PlayerData data, ref PlayerMove player){
        player.transform.position = data.position;
    }
    public static PlayerData GetPlayerData(PlayerMove player){
        PlayerData data = new PlayerData();
        data.position = player.transform.position;
        return data;
    }

    public static void GetCubes(CubesData data, ref CubePoints cube){
        cube.transform.position = data.position;
        cube.name = data.name;
    }
    public static CubesData GetCubesData(CubePoints cube){
        CubesData data = new CubesData();
        data.position = cube.transform.position;
        data.name = cube.name;
        return data;
    }

    public static void GetScore(ScoreData data, ref ScoreHUD score){
        score.points = data.score;
    }
    public static ScoreData GetScoreData(ScoreHUD score){
        ScoreData data = new ScoreData();
        data.score = score.points;
        return data;
    }
    
}
[Serializable]
public class PlayerData{
    public Vector3 position;
}
[Serializable]
public class CubesData{
    public Vector3 position;
    public String name;
}
[Serializable]
public class ScoreData{
    public int score;
}
[Serializable]
public class SceneData{
    public PlayerData player;
    public CubesData[] cubes;
    public ScoreData score;
}