using UnityEngine;

public class Puzzle : MonoBehaviour
{
    [SerializeField] private GameObject text;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void MoveObject()
    {
        GameObject obj = GameObject.Find("Text");
        obj.transform.Translate(0f, 0f, 0f);
    }
}
