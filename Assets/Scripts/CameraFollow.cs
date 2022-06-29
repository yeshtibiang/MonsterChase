using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraFollow : MonoBehaviour
{

    // obtenir une reference du player transoform
    private Vector3 tempPos;
    private Transform player;

    [SerializeField]
    private float minX, maxX;

    // Start is called before the first frame update
    void Start()
    {
        //on va utiliser le tag pour trouver la position du joueur
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    // il faut appeler le fait que la camera suive le joueur dans lateUpdate et non update, LateUpdate est appelé après que tous les calculs dans update sont finis
    void LateUpdate()
    {
        if (!player)
            return;
        // position de la camera
        tempPos = transform.position;
        tempPos.x = player.position.x;

        // camera ne suit pas
        if (tempPos.x < minX)
        {
            tempPos.x = minX;
        }
        if (tempPos.x > maxX)
            tempPos.x = maxX;

        transform.position = tempPos;
    }
}
