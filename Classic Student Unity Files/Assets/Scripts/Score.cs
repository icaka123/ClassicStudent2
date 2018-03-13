using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

    public int score = 0;
    public GUIText scoreText;

    public GameObject Expl;


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Coins")
        {
            Expl.SetActive(true);
    
            score = score + 1; //изчисляване на точките
            scoreText.text = "Точки: " + score; //Изписване на точките
            PlayerPrefs.SetInt("CScore",score);//Запазване на резултата за сцената с Game Over
   
        }

    }
  
}
