using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddScore : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Score.score++;
    }
}
