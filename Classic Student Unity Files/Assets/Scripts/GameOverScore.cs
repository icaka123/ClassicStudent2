using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScore : MonoBehaviour {
   public int score;
    public TextMesh scoreText;

    void Start ()
    {
     score=PlayerPrefs.GetInt("CScore");//Запазване на точките на другите сцени
    }
	

	void Update ()
    {
        scoreText.text = "Точки: " + score;//изписване на резултата в сцените Game Over
    }
}
