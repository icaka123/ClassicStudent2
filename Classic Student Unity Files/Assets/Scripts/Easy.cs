using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Easy : MonoBehaviour {
    int y;
    public TextMesh instr;
    public TextMesh quest;
    public TextMesh tr;
    public TextMesh fal;
    public GameObject timing; //Въвеждане таймера 
    public float time; //Въвеждаме времето
    public GameObject Tri;
    public GameObject Rec;
    public GameObject Sq;
       public GameObject Door;
    public GameObject TrueA;
    public GameObject FalseA;
    bool timer = false;
    public TextMesh Timer;
    public GameObject Expl;
    


    void Start()
    {

        TrueA = GameObject.FindGameObjectWithTag("True");
        timing.SetActive(false);//заключване на таймера преди да започне отговарянето на въпроси
     
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Door")
        {
            Expl.SetActive(false);
                   instr.text = " ";
            Tri.SetActive(false);
            Rec.SetActive(false);
            Sq.SetActive(false);
            TrueA.SetActive(true);
            Vector2 exitPosition = Door.transform.position;//Транспортира до вратата героя
            transform.position = new Vector2(exitPosition.x, exitPosition.y);
            Vector2 trueAnswer = TrueA.transform.position;
            Vector2 falseAnswer = FalseA.transform.position;
            int x = Random.Range(1, 3);
            //Размесване на мястото за верен и грешен отговор
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
        //избиране на тип въпрос
        switch (y = Random.Range(1, 9))
        {
            case 1: Sravnqvane(); break;
            case 2: PTriugulnik(); break;
            case 3: Sravnqane2(); break;
            case 4: SiI(); break;          
            case 5: Izmervane(); break;
            case 6: Kvadrat(); break;
            case 7: Pravougulnik(); break;
            case 8: UiD(); break;
        }
    }
   // Update is called once per frame
    void Update()
    {
        if (timer == true)
        {
            time -= Time.deltaTime;//Изважда от зададеното за мен време секунда по секунда
            double b= Mathf.Floor(time);
            Timer.text = b.ToString();
            if (time < 0)//Ако времето мине под 0
            {
                Application.LoadLevel(6);// Отива на сцената с Game Over
            }
        }
        else { timing.SetActive(false); }
    }

    //Сравняване
    private void Sravnqvane()
    {instr.text="Сравнете.";
    int x = Random.Range(0, 500);
        int z = Random.Range(0, 500);
        int b = Random.Range(0, 2);
        quest.text = x + "_" + z;
        if (x == z)
        {
            tr.text = "=";
            if (b == 0)
            { fal.text = ">"; }
            else { fal.text = "<"; }
        }
        if (x > z)
        { tr.text = ">";
            if (b == 0)
            { fal.text = "<"; }
            else { fal.text = "="; }
        }
        else { tr.text = "<";
            if (b == 1)
            { fal.text = ">"; }
            else { fal.text = "="; }
        }

    }

    //Сравняване на сбор или разлика
    private void Sravnqane2()
    {
        instr.text = "Сравнете двете страни.";
        int x = Random.Range(1, 50);
        int d = Random.Range(1, 50);
        int z = Random.Range(1, 100);
        int b = Random.Range(0, 2);
        int k = Random.Range(0, 2);
        if (k == 0)
        {
            quest.text = x + "+" + d + "_" + z;
            if (x + d == z)
            {
                tr.text = "=";
                if (b == 0)
                { fal.text = ">"; }
                else { fal.text = "<"; }
            }
            if (x + d > z)
            {
                tr.text = ">";
                if (b == 0)
                { fal.text = "<"; }
                else { fal.text = "="; }
            }
            else {
                tr.text = "<";
                if (b == 0)
                { fal.text = ">"; }
                else { fal.text = "="; }
            }
        }
        else {
            do
            {
           d = Random.Range(1, 50);

            }
            while (x<d);

                quest.text = x + "-" + d + "_" + z;
                if (x - d == z)
                {
                    tr.text = "=";
                    if (b == 0)
                    { fal.text = ">"; }
                    else { fal.text = "<"; }
                }
                if (x - d > z)
                {
                    tr.text = ">";
                    if (b == 0)
                    { fal.text = "<"; }
                    else { fal.text = "="; }
                }
                else {
                    tr.text = "<";
                    if (b == 0)
                    { fal.text = ">"; }
                    else { fal.text = "="; }
                }
            
        }
    }
    //Събиране и изваждане
    private void SiI()
    {
        instr.text = " ";
        int x = Random.Range(1, 100);
        int y = Random.Range(1, 100);
       
        int c = Random.Range(0, 2);
        int d = Random.Range(0, 2);
        int z = Random.Range(1, 4);
   

        if (c == 0)
        {
            do {
                y = Random.Range(1, 100);
            }
            while (y>x);
            int R = x - y;
            int Rf = Random.Range(0, 50);
            quest.text = x + "-" + y + "= ?";
                tr.text = R.ToString();
           fal.text = Rf.ToString();
            }
        quest.text = x + "+" + y + "= ?";
        int S = x + y;
        int Sf1 = S - 10 * z;
        int Sf2 = S + 10 * z;
        tr.text = S.ToString();
        if (d==0)
        { fal.text = Sf1.ToString(); }
        fal.text = Sf2.ToString();
    }
    //Периметър на триъгълник
    private void PTriugulnik()
    {
        instr.text = "Намерете \n обиколката. ";
        int a2;
        int a3;
        int a1;
        do
        {
            a1 = Random.Range(2, 10);
            a2 = Random.Range(2, 10);
            a3 = Random.Range(2, 10);
        }
        while (a1 > a2 + a3);
        Tri.SetActive(true);
        int Pt = a2 + a3 + a1;
        int Pf ;
        do { Pf = Random.Range(Pt - 2, Pt + 2); }
        while (Pf==Pt);
        
        quest.text = "a=" + a1 + ";b=" + a2 + ";" + "\n" + "c=" + a3 + ";P=? ";
        tr.text = Pt.ToString();
        fal.text = Pf.ToString();
    
    }

 


    //Мерни единици
    private void Izmervane()
    {
        instr.text = "Мерни единици.";
        int m = Random.Range(1, 10);
        int km = Random.Range(1, 10);
        int dm = Random.Range(1, 10);
        int b = Random.Range(1, 5);
        switch (b)
        {
            case 1:
                quest.text = m + "м"+" =";
                tr.text = m + "00см";
                fal.text = m + "0см"; break;
            case 2:
                quest.text = km +"км" +" =";
                tr.text = km + "000м";
                fal.text = km + "00м"; break;
            case 3:
                quest.text = dm +"дм" +" =";
                tr.text = dm + "0см";
                fal.text = dm + "00см"; break;
            case 4:
                quest.text = m + "кг" + " =";
                tr.text = m + "000гр";
                fal.text = m + "00гр"; break;
        }
    }
    //Лице и периметър на квадрат
    private void Kvadrat()
    {       int a = Random.Range(1, 50);
        int n = Random.Range(0, 2);
        int Sf = Random.Range(1, 2500);
        int Pf = Random.Range(1, 200);
        int S = a * a;
        int P = a * 4;
        Sq.SetActive(true);
        if (n == 0)
        {
            instr.text = "Намерете \n обиколката.";
            quest.text = "a="+a+"; P=?";
            tr.text = P.ToString();
            fal.text = Pf.ToString();
        }
        a = Random.Range(2, 10);
        S = a * a;
        do
        { Sf = Random.Range(S - 2, S + 2); }
        while (Sf==S);
        instr.text = "Намерете лицето.";
        quest.text = "a=" + a + "; S=?";
        tr.text = S.ToString();
        fal.text = Sf.ToString();
    }
    //Лице и периметър на правоъгълник
    private void Pravougulnik()
    {
        int a = Random.Range(2, 10);
        int a1 = Random.Range(2, 10);
        int n = Random.Range(0, 2);
        int Sf = Random.Range(1, 2500);
        int Pf;
        int S;
        int P=a+a1+a+a1;
        do { Pf = Random.Range(1, 200); }
        while (Pf == P);
        Rec.SetActive(true);
        if (n == 0)
        {
            instr.text = "Намерете \n обиколката.";
            quest.text = "a=" + a + " ;b=" + a1 + "; P=?";
            tr.text = P.ToString();
            fal.text = Pf.ToString();
        }
        a = Random.Range(2, 10);
        a1 = Random.Range(2, 10);
        S = a * a1;
        do
        { Sf = Random.Range(S - 2, S + 2); }
        while (Sf == S);
        instr.text = "Намерете лицето.";
        quest.text = "a=" + a + " ;b=" + a1 + "; S=?";
        tr.text = S.ToString();
        fal.text = Sf.ToString();
    }
    //Умножение и деление
    private void UiD()
    {
        instr.text = "'*'-Умножение; \n '/'-Деление";
        int a = Random.Range(2, 10);
        int b = Random.Range(2, 10);
        int S = a * b;
        int Sf;
        do { Sf = Random.Range(S - 2, S + 2); }
        while (Sf == S);
        int bf;
        do { bf = Random.Range(b - 2, b + 2); }
        while (bf == b);
        int k = Random.Range(1, 3);
        switch (k)
        { case 1:
                quest.text = a+"*"+b;
                tr.text = S.ToString();
                fal.text = Sf.ToString();
                break;
                case 2:
                quest.text = S + "/" + a;
                tr.text = b.ToString();
                fal.text = bf.ToString();
                break;
        }
    }
}
