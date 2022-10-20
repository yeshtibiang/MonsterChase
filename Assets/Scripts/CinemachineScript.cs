using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CinemachineScript : MonoBehaviour
{
    private Transform player;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        GetComponent<CinemachineVirtualCamera>().Follow = player;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
