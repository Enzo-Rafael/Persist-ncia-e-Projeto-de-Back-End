using UnityEngine;

public class CubePoints : MonoBehaviour
{
    public int pointsToGive;

    void OnCollisionEnter(Collision collision)
    {
      
        SetPoints(pointsToGive);
  
    }

    void SetPoints(int val){
        ScoreHUD.instace.points += val;
       // PlayerPrefs.SetInt("points", ScoreHUD.instace.points);
        ScoreHUD.instace.ScoreUpdate(ScoreHUD.instace.points);
    }
}
