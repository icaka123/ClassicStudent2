using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {
   
    public void ChangeScene(string sceneName)
    {
        Application.LoadLevel(sceneName);//прехвърляне на друга сцена при натискане на бутон
    }
}
