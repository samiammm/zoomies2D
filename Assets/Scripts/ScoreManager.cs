using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreManager : MonoBehaviour
{

    public Transform player;

    public Vector3 lastPosition;
    private float totalDistance;

    public float score;
    private float hiScore;
//    public float pointsPerSec;
    public Text scoreText;
    public Text hiScoreText;

    public bool isScoreIncreasing;

    void Start()
    {
        isScoreIncreasing = true;
        if(PlayerPrefs.HasKey("HiScore")) {
            hiScore = PlayerPrefs.GetFloat("HiScore");
        }
    }

    // Update is called once per frame
    void Update()
    {


        float distanceTraveled = Vector3.Distance(lastPosition, player.position);

        totalDistance += distanceTraveled;

        lastPosition = player.position;

        if(isScoreIncreasing) {
//            score += pointsPerSec * Time.deltaTime;
            score += distanceTraveled;
        }
        
        if(score > hiScore) {
            hiScore = score;
            PlayerPrefs.SetFloat("HiScore", hiScore);
        }

        scoreText.text = Mathf.Round(score).ToString();
        hiScoreText.text = Mathf.Round(hiScore).ToString();

    }
}
