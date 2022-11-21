using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject player;
    private Vector3 pos = new Vector3(0, 15, -10);


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // z카메라 -> 0, 15, -10
        // 즉, 플레이어의 좌표에서 0, 15, -10 더해주면
        gameObject.transform.position = player.transform.position + pos;
    }
}
