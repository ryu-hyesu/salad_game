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
        customerName = "��մ�";
        welcomeText = "����丶��� ����߷� ��Ź�ؿ�!";
        successReaction = "�Ϻ��ؿ�!";
        failureReaction = "�̰� �� �ƴѵ��䡦";

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
