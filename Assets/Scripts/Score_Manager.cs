using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score_Manager : MonoBehaviour
{
    public int score = 0;

    private float distance = 0;

    public int scale = 4;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        distance = 0;
    }

    // Update is called once per frame
    void Update()
    {
        score = (int) distance;

        distance = gameObject.transform.position.z / scale;
    }
}
