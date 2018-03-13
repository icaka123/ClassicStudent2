using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hard : MonoBehaviour {
    public TextMesh instr;
    public TextMesh quest;
    public TextMesh tr;
    public TextMesh fal;
    public GameObject timing; //Въвеждане таймера 
    public float time; //Въвеждаме времето
    public GameObject Door;
    public GameObject TrueA;
    public GameObject FalseA;
    bool timer = false;
    int y;
    public GameObject Expl;
    public GameObject te;
    public TextMesh Timer;
    // Use this for initialization
    void Start () {
        TrueA = GameObject.FindGameObjectWithTag("True");
    }
	
	// Update is called once per frame
	void Update () {
        if (timer == true)
        {
            time -= Time.deltaTime;//Изважда от зададеното за мен време секунда по секунда
            double b = Mathf.Floor(time);
            Timer.text = b.ToString();
            if (time < 0)//Ако времето мине под 0
            {
                Application.LoadLevel(6);// Отива на сцената с Game Over
            }
        }
        else { timing.SetActive(false); }
    }
  


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Door")
        {
            Expl.SetActive(false);
            Vector2 TE = te.transform.position;
            timing.transform.position = new Vector2(TE.x, TE.y);
            TrueA.SetActive(true);
            Vector2 exitPosition = Door.transform.position;//Транспортира до вратата героя
            transform.position = new Vector2(exitPosition.x, exitPosition.y);
            Vector2 trueAnswer = TrueA.transform.position;
            Vector2 falseAnswer = FalseA.transform.position;
            int x = Random.Range(1, 3);
            if (x == 1)
            {
                TrueA.transform.position = new Vector2(trueAnswer.x, trueAnswer.y);
                FalseA.transform.position = new Vector2(falseAnswer.x, falseAnswer.y);
                Expl.transform.position = new Vector2(trueAnswer.x, trueAnswer.y);
            }
            else
            {
                FalseA.transform.position = new Vector2(trueAnswer.x, trueAnswer.y);
                TrueA.transform.position = new Vector2(falseAnswer.x, falseAnswer.y);
                Expl.transform.position = new Vector2(falseAnswer.x, falseAnswer.y);

            }
            timer = true;
            timing.SetActive(true);
        }
        else { return; }
        switch (y = Random.Range(1, 6))
        //избиране на тип въпрос
        {
            case 1: Koren(); break;
            case 2: Fun(); break;
            case 3: SiI(); break;
            case 4: Ste(); break;
            case 5: NeS(); break;
        }
    }

    //Корени
    private void Koren()
    {
        instr.text = "'√'-корен квадратен";
        int x = Random.Range(3, 21);
        int x2 = x * x;
        int xf;
        do
        { xf = Random.Range(x - 2, x + 2); }
        while (xf == x);
        quest.text = "√" + x2 + " =";
        tr.text = x.ToString();
        fal.text = xf.ToString();
    }
    //Тригонометрични функции
    private void Fun()
    {
        instr.text = " ";
        int n = Random.Range(1, 22);

        switch (n)
        {
            case 1:
                quest.text = "sin30°";
                tr.text = "1/2";
                fal.text = "√3/2";
                break;
            case 2:
                quest.text = "sin45°";
                tr.text = "√2/2";
                fal.text = "√3/2"; ; break;
            case 3:
                quest.text = "sin60°";
                tr.text = "√3/2";
                fal.text = "1/2"; ; break;
            case 4:
                quest.text = "sin90°";
                tr.text = "1";
                fal.text = "0"; ; break;
            case 5:
                quest.text = "sin120°";
                tr.text = "√3/2";
                fal.text = "-1/2"; ; break;
            case 6:
                quest.text = "cos30°";
                tr.text = "√3/2";
                fal.text = "1/2"; ; break;
            case 7:
                quest.text = "cos45°";
                tr.text = "√2/2";
                fal.text = "√3/2"; ; break;
            case 8:
                quest.text = "cos60°";
                tr.text = "1/2";
                fal.text = "√3/2"; ; break;
            case 9:
                quest.text = "cos90°";
                tr.text = "0";
                fal.text = "1"; ; break;
            case 10:
                quest.text = "cos120°";
                tr.text = "-1/2";
                fal.text = "√3/2"; ; break;
            case 11:
                quest.text = "tg30°";
                tr.text = "√3/3";
                fal.text = "√3"; ; break;
            case 12:
                quest.text = "tg45°";
                tr.text = "1";
                fal.text = "0"; ; break;
            case 13:
                quest.text = "tg60°";
                tr.text = "√3";
                fal.text = "√3/3"; ; break;
            case 14:
                quest.text = "tg120°";
                tr.text = "-√3";
                fal.text = "-√3/3"; ; break;
            case 15:
                quest.text = "cotg30°";
                tr.text = "√3";
                fal.text = "√3/3"; ; break;
            case 16:
                quest.text = "cotg45°";
                tr.text = "1";
                fal.text = "0"; ; break;
            case 17:
                quest.text = "cotg60°";
                tr.text = "√3/3";
                fal.text = "√3"; ; break;
            case 18:
                quest.text = "cotg90°";
                tr.text = "0";
                fal.text = "1"; ; break;
            case 19:
                quest.text = "cotg120°";
                tr.text = "-√3/3";
                fal.text = "-√3"; ; break;
            case 20:
                quest.text = "-1 < sin x < 1; /n -1 < cos x < 1";
                tr.text = "True";
                fal.text = "False"; ; break;
            case 21:
                quest.text = "-1 > sin x; /n -1 > cos x";
                tr.text = "False";
                fal.text = "True"; ; break;

        }
    }
    //Събиране и изваждане
    private void SiI()
    {
        instr.text = " ";
        int x = Random.Range(10000, 99999);
        int y = Random.Range(10000, 99999);
        int c = Random.Range(0, 2);
        int d = Random.Range(0, 2);
        int z = Random.Range(1, 5);
        if (c == 0)
        {
            do
            {
                y = Random.Range(10000, 100000);
            }
            while (y > x);
            int R = x - y;
            int Rf;
            do { Rf = Random.Range(0, R + 100); }
            while (Rf == R);
            quest.text = x + "-" + y + "= ?";
            tr.text = R.ToString();
            fal.text = Rf.ToString();
        }
        quest.text = x + "+" + y + "= ?";
        int S = x + y;
        int Sf1 = S - 10 * z;
        int Sf2 = S + 10 * z;
        tr.text = S.ToString();
        if (d == 0)
        { fal.text = Sf1.ToString(); }
        fal.text = Sf2.ToString();
    }


    //Неизвестно на степен
    private void NeS()
    {
        instr.text = "Намерете  неизвестното \n '^'- Степен";
        int n = Random.Range(2, 6);
        int x = Random.Range(2, 7);
        double O = Mathf.Pow(x, n);
        int xf;
        do { xf = Random.Range(x - 1, x + 2); }
        while (xf == x);
        quest.text = "x ^" + n + " = " + O;
        tr.text = "x= " + x;
        fal.text = "x= " + xf;
    }
    //Степенуване
    private void Ste()
    {
        instr.text = "'^'- Степен ";
        int n = Random.Range(3, 5);
        int x = Random.Range(2, 7);
        double O = Mathf.Pow(x, n);
        int Of;
        do { Of = Random.Range(20, 2000); }
        while (Of == O);
        quest.text = x + "^(" + n + ") = ?";
        tr.text = O.ToString();
        fal.text = Of.ToString();
    }
}
