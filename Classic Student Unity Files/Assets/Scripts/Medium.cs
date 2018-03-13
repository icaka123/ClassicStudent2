using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medium : MonoBehaviour {
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
    public GameObject Cir;
    public GameObject Tra;
    public GameObject Per;
    public GameObject Door;
    public GameObject TrueA;
    public GameObject FalseA;
    bool timer = false;
    public GameObject te;
    public TextMesh Timer;
    public GameObject Expl;
    // Use this for initialization
    void Start () {
    
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

    }
   
   

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Door")
        {
            Expl.SetActive(false);
            Cir.SetActive(false);
            Tri.SetActive(false);
            Rec.SetActive(false);
            Sq.SetActive(false);
            Tra.SetActive(false);
            Per.SetActive(false);
            TrueA.SetActive(true);
            Vector2 TE = te.transform.position;
            timing.transform.position = new Vector2(TE.x, TE.y);
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
        switch (y = Random.Range(1, 11))
        {//избиране на тип въпрос
            case 1: Sravnqvane(); break;
            case 2: UiD(); break;
            case 3: Sravnqane2(); break;
            case 4: SiI(); break;
            case 5: Neizv(); break;
            case 6: Usp(); break;
            case 7: Trap(); break;
            case 8: Krug(); break;
            case 9: STriugulnik(); break;
            case 10: Suk(); break;

        }
    }


    //Сравняване
    private void Sravnqvane()
    {
        instr.text = "Сравнете.";
        int x = Random.Range(5000, 9999);
        int z = Random.Range(5000, 9999);
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
        {
            tr.text = ">";
            if (b == 0)
            { fal.text = "<"; }
            else { fal.text = "="; }
        }
        else {
            tr.text = "<";
            if (b == 1)
            { fal.text = ">"; }
            else { fal.text = "="; }
        }
    }

    //Сравняване на сбор или разлика
    private void Sravnqane2()
    {
        instr.text = "Сравнете двете \n страни.";
        int x = Random.Range(1, 999);
        int d = Random.Range(1, 999);
        int z;
         z = Random.Range(x + d - 10, x + d + 10); 
       
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
                d = Random.Range(1, 999);

            }
            while (x < d);
            z = Random.Range(x - d - 10, x - d + 10);
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
        int x = Random.Range(2000, 9999);
        int y = Random.Range(2000, 9999);

        int c = Random.Range(0, 2);
        int d = Random.Range(0, 2);
        int z = Random.Range(1, 4);


        if (c == 0)
        {
            int Rf;
            int R;
            do
            {
                y = Random.Range(900, 1000);
                R = x - y;
                Rf = Random.Range(R - 100, R + 100);
            }
            while (y > x && Rf <= 0);


            quest.text = x + "-" + y + "= ?";
            tr.text = R.ToString();
            fal.text = Rf.ToString();
        }
        quest.text = x + "+" + y + "= ?";
        int S = x + y;
        double Sf1 = S - Mathf.Pow(10, z); ;
        double Sf2 = S + Mathf.Pow(10, z); ;
        tr.text = S.ToString();
        if (d == 0)
        { fal.text = Sf1.ToString(); }
        fal.text = Sf2.ToString();
    }
    //Умножение и деление
    private void UiD()
    {
        instr.text = " ";
        int z = Random.Range(1, 3);
        int n = Random.Range(2, 11);
        switch (z)
        {
            case 1:
                do
                {
                    int y = Random.Range(2000, 10000);
                }
                while (y % n != 0);
                int Ch = y / n;
                int Chf;
                do
                { Chf = Random.Range(Ch - 100, Ch + 100); }
                while (Chf == Ch && Chf <= 0);
                quest.text = y + "/" + n;
                tr.text = Ch.ToString();
                fal.text = Chf.ToString();
                break;
            case 2:
                int b = Random.Range(2000, 10000);
                int Pr = b * n;
                int Prf;
                do { Prf = Random.Range(Pr - 900, Pr + 900); }
                while (Prf <= 0 && Pr == Prf);
                quest.text = b + "*" + n;
                tr.text = Pr.ToString();
                fal.text = Prf.ToString();
                break;
        }
    }
    //Неизвестно число
    private void Neizv()

    {

        instr.text = "Намерете \n неизвестното. ";
        int a = Random.Range(1, 10);
        int c = Random.Range(1, 50);
        int S = Random.Range(50, 500);
        int n = Random.Range(1, 5);
        switch (n)
        {
            case 1:

                do
                {
                    a = Random.Range(1, 10);
                    c = Random.Range(1, 50);
                    S = Random.Range(50, 500);
                }
                while ((S - c) % a != 0);
                int x = (S - c) / a;
                quest.text = "x*" + a + "+" + c + "=" + S;
                int xf;
                do { xf = Random.Range(x - 10, x + 10); }
                while (xf == x);
                tr.text = "x= " + x;
                fal.text = "x= " + xf;
                break;
            case 2:
                do
                {
                    a = Random.Range(1, 10);
                    c = Random.Range(1, 50);
                    S = Random.Range(50, 500);
                }
                while ((S + c) % a != 0);
                x = (S + c) / a;
                quest.text = "x*" + a + "-" + c + "=" + S;
                do { xf = Random.Range(x - 10, x + 10); }
                while (xf == x);
                tr.text = "x= " + x;
                fal.text = "x= " + xf;
                break;
            case 3:
               
                    a = Random.Range(1, 10);
                    c = Random.Range(1, 50);
                    S = Random.Range(50, 500);
               
                x = (S - c) * a;
                quest.text = "x/" + a + "+" + c + "=" + S;
                do { xf = Random.Range(x - 10, x + 10); }
                while (xf == x);
                tr.text = "x= " + x;
                fal.text = "x= " + xf;
                break;
            case 4:
                x = (S + c) * a;
                quest.text = "x/" + a + "-" + c + "=" + S;
                do { xf = Random.Range(x - 10, x + 10); }
                while (xf == x);
                tr.text = "x= " + x;
                fal.text = "x= " + xf;
                break;
        }
    }
    //Лице на успоредник
    private void Usp()
    {
        instr.text = "Намерете лицето";
        Per.SetActive(true);
        int c = Random.Range(20, 50);
        int hc = Random.Range(20, 50);
        int S = c * hc;
        int Sf;
        do { Sf = Random.Range(S - 10, S + 10); }
        while (S == Sf);
        quest.text = "a=" + c + "; ha=" + hc;
        tr.text = S.ToString();
        fal.text = Sf.ToString();
    }
    //Лице на трапец
    private void Trap()
    {
        instr.text = "Намерете лицето";
        Tra.SetActive(true);
        int a ;
        int b ;
        int hb;
        int S ;
        int Sf;
        int St;
        do
        {
            a = Random.Range(2, 10);
            b = Random.Range(2, 10);
            hb = Random.Range(2, 10);
            S = (a + b) * hb;
            St = S / 2;
            Sf = Random.Range(St - 10, St + 10);
        }
        while (St == Sf && Sf <= 0 && S % 2 != 0);
        
        quest.text = "b=" + b+ "; \n" + "a=" + a + "; hb=" + hb;
        tr.text = St.ToString(); 
        fal.text = Sf.ToString();
    }


    //Лице на триъгълник
    private void STriugulnik()
    {
        instr.text = "Намерете лицето. ";
        int a2;
        int a3;
        int a1;
        do
        {
            a3 = Random.Range(10, 20);
            a1 = Random.Range(10, 20);
        }
        while (a1 * a3 % 2 != 0);

        int k = Random.Range(0, 2);
        int hc = Random.Range(10, 20);
        Tri.SetActive(true);
        int Sf;
        if (k == 0)
        {
            int St = a1 * a3 / 2;

            quest.text = "b =" + a1 + ";" + "a=" + a3 + "\n" + ";<ACB=90°;S=? ";
            do
            { Sf = Random.Range(St - 10, St + 10); }
            while (Sf == St && Sf <= 0);
            tr.text = St.ToString();
            fal.text = Sf.ToString();
        }
        do
        {
            hc = Random.Range(10, 20);
            a2 = Random.Range(1, 20);
        }
        while (hc * a2 % 2 != 0);
        int St1 = a2 * hc / 2;
        do
        { Sf = Random.Range(St1 - 10, St1 + 10); }
        while (Sf == St1 && Sf <= 0);
        quest.text = "c =" + a2 + ";" + "hc=" + hc + "\n" + ";S=? ";
        tr.text = St1.ToString();
        fal.text = Sf.ToString();


    }
    //Периметър и лице на кръг
    private void Krug()
    {
        Cir.SetActive(true);
        int r = Random.Range(1, 50);
        int d = 2 * r;
        int St = r * r;
        int Sf = d * d;
        int n = Random.Range(0, 2);
        if (n == 0)
        {
            instr.text = "Намерете дължината.";
            quest.text = "r=" + r + ";P=?";
            tr.text = d + "π";
            fal.text = r + "π";
        }
        instr.text = "Намерете лицето.";
        quest.text = "r=" + r + ";S=?";
        tr.text = St + "π";
        fal.text = Sf + "π";
    }

    //Формули за съкратено умножение
    private void Suk()
    {
        int n = Random.Range(1, 4);
        instr.text = "'^'- Степен";
        switch (n)
        {
            case 1:
                quest.text = "(x + y)^2 = ";
                tr.text = "x^2 + 2xy + y^2";
                fal.text = "x^2 + y^2^";
                break;
            case 2:
                quest.text = "(x - y)^2 = ";
                tr.text = "x^2 - 2xy + y^2";
                fal.text = "x^2 - y^2"; ; break;

            case 3:
                quest.text = "x^2 - y^2 =";
                tr.text = "(x - y)(x + y)";
                fal.text = "(x - y)(x - y)"; break;


        }
    }

}
