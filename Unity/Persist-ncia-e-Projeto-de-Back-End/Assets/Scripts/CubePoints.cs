using Unity.VisualScripting;
using UnityEngine;

public class CubePoints : MonoBehaviour
{
    public int pointsToGive;

    void OnTriggerEnter(Collider other)
    {
       if(pointsToGive == 0){
            int r = Random.Range(-10, 11);
            SetPoints(r);
        }else{
            SetPoints(pointsToGive);
        }
        

  
    }

    void SetPoints(int val){
        ScoreHUD.instace.points += val;
        ScoreHUD.instace.ScoreUpdate(ScoreHUD.instace.points);
        Destroy(gameObject);
    }
    void OnMouseDown(){
        if(pointsToGive < 0)SetPoints(pointsToGive + 1);
        if(gameObject.name == "Bloqueio"){
            SetPoints(-5);
        }
        Destroy(gameObject);
        
    }
}
