using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallex2 : MonoBehaviour
    
{
    public Transform[] backGrounds;
    private float[] parallexScales;
    public float smoothing = 1f;

    private Transform cam;
    private Vector3 previousCamPos;

    private void Awake()
    {
        cam = Camera.main.transform;
    }
    // Start is called before the first frame update
    void Start()
    {
        previousCamPos = cam.position;

        parallexScales = new float[backGrounds.Length];
        for(int i =0; i<backGrounds.Length; i++)
        {
            parallexScales[i] = backGrounds[i].position.z * -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < backGrounds.Length; i++)
        {
            float parallex = (previousCamPos.x - cam.position.x) * parallexScales[i];

            float backgroundTargetPosX = backGrounds[i].position.x + parallex;

            Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, backGrounds[i].position.y, backGrounds[i].position.z);

            backGrounds[i].position = Vector3.Lerp(backGrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);

        }

        previousCamPos = cam.position;
    }
}
