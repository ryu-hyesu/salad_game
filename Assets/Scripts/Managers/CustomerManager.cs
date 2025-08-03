using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerManager : MonoBehaviour
{
    public static CustomerManager Instance;

    public string customerName;
    public string welcomeText;
    public string successReaction;
    public string failureReaction;
    
    //public List<string> playerSalad = new();
    public List<string> currentOrder = new();

    void Awake() => Instance = this;

    public void SpawnNewCustomer()
    {
        customerName = "김손님";
        welcomeText = "방울토마토랑 양상추로 부탁해요!";
        successReaction = "완벽해요!";
        failureReaction = "이건 좀 아닌데요…";

        currentOrder = new List<string> { "Tomato", "Lettuce" };

        UIManager.Instance.ShowOrder(welcomeText);
    }

    public void EvaluateSalad()
    {
        bool isCorrect = false;
        string result = failureReaction;

        UIManager.Instance.ShowReaction(result);
    }
}
