using System;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    private Vector3 offset;
    private float followSpeed = 5.0f;

    private void Awake()
    {
        offset = transform.position - target.position;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        //  ダイレクト移動
        transform.position = target.position + offset;
        //  遅延移動
        //var targetposition = target.position + offset;
        //transform.position = Vector3.Lerp(transform.position, targetposition, followSpeed * Time.deltaTime);
    }
}
