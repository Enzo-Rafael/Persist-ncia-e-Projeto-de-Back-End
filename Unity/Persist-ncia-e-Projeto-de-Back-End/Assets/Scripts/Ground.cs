using UnityEngine;

public class Ground : MonoBehaviour
{
    public GameObject[] prefabs;
    void OnMouseDown()
    {
        int r = Random.Range(0, prefabs.Length);
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.x = Mathf.Round(pos.x);
        pos.y = Mathf.Round(transform.position.y);
        pos.z = Mathf.Round(pos.z);   
        pos.y += 1;
        Instantiate(prefabs[r], pos, Quaternion.identity);
    }
}
