using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public float score;
    public float scorePerSecond;
    public Text scoreText;
    public Text scorePerSecondText;
    public float repeat_time; // время повтора в секундах
    private float curr_time;
    public Button UpgrButton_1;
    public Button UpgrButton_2;
    public Text UpgrButton_1Text;
    public Text UpgrButton_2Text;



    public void Start()
    {
        //curr_time = repeat_time * 1000f;
        //repeat_time = 1;
        

    }

    public void Update()
    {
        int kostilScore; //позволяет отображать тазики в целом формате
        kostilScore = (int)score;
        scoreText.text = "ТАЗИКИ: " + kostilScore + "₸";
        scorePerSecond = (one.IncreaseValue * one.Amount) + (two.IncreaseValue * two.Amount);
        scorePerSecondText.text = "Тазики в секунду: " + scorePerSecond;
        //curr_time -= Time.deltaTime; //Вычитаем из 1 секунды время кадра(оно в миллисекундах)

        score = score + (Time.deltaTime * one.IncreaseValue * one.Amount) + (Time.deltaTime * two.IncreaseValue * two.Amount); //я не понимаю почему оно работает (вчера оно прибавлялось по 500 тазиков/секунду)

        if (score >= one.Cost) //отображение доступности кнопки(когда недоступна - серия)
            UpgrButton_1.interactable = true;
        else
            UpgrButton_1.interactable = false;

        if (score >= two.Cost)
            UpgrButton_2.interactable = true;
        else
            UpgrButton_2.interactable = false;

        //UpgrButton_1Text.text = "Улучшение 1 " + one.Cost;
        ConvertCostDoubleToInt(UpgrButton_1Text, one.Cost, one.Amount, "Улучшение 1"); // функция отображения стоимости улучшения
        ConvertCostDoubleToInt(UpgrButton_2Text, two.Cost, two.Amount, "Улучшение 2");
        


    }

    public class Bonus
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
    public void Ugr_2_Click()
    {
        if (score >= two.Cost)
        {
            two.Amount++;
            float f;
            f = (float)two.Cost; 
            score = score - f; 
            two.Cost = two.Cost * 1.1;
        }
    }

    public void ConvertCostDoubleToInt(Text text, double Cost, int Amount, string UpgrName) //функция которая отображает на кнопке динамичную стоимость улучшения; первым параметром передаем сам текстовый объект кнопки, вторым стоимость, третьим название кнопки(потому что иначе стирается весь текст кнопочки)
    {
        int conv;
        conv = (int)Cost;
        text.text = UpgrName + "  " + conv + "₸  " + Amount + "шт.";
    }
}
