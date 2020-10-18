using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class Game : MonoBehaviour
{
    public float score;
    public Text scoreText;
    //public GameObject UpBut_1, UpBut_2, UpBut_3, UpBut_4;

    

    public void Update()
    {
        int kostilScore;
        kostilScore = (int)score;
        scoreText.text = "ТАЗИКИ: " + kostilScore;
        if (one.Amount > 0)
            score = score + (one.Amount * one.IncreaseValue);
        score = score + (Time.deltaTime * one.IncreaseValue * one.Amount);
        //while (true)
        // {

        //Thread.Sleep(1000);
        // }
    }

    class Bonus
    {
        public string Name;
        public double Cost; //цена
        public int Amount; // количество
        public bool Available; // досупность к покупке
        public int IncreaseValue; // скорость прибавления

    }



     Bonus one = new Bonus {Name = "one", Cost = 10, Amount = 0, Available = false, IncreaseValue = 1 }; //первый бонус 

     Bonus two = new Bonus {Name = "two", Cost = 20, Amount = 0, Available = false, IncreaseValue = 2 }; // второй бонус
    

    public void OnClick()
    {
        score++;

        
        
    }

    public void Ugr_1Click()
    {
        if (score >= one.Cost)
        {
            one.Amount++;
            float f;
            f = (float)one.Cost; //костыль который позводяет вычитать стоимость улучшения из счета
            score =  score - f; // изначально проблема была в том, что one.cost является double, а score float - вылезала ошибка: не удалется преобразовать double в float
            one.Cost = one.Cost * 1.1;

        }
    }
}
