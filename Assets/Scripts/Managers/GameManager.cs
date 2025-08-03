using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private GameState currentState;
    void Awake() => Instance = this;

    void Start()
    {
        StartCustomer();
    }

    // ���ο� �մ� ����
    public void StartCustomer()
    {
        currentState = GameState.AwaitingOrder;

        UIManager.Instance.ShowCounterPanel();
        CustomerManager.Instance.SpawnNewCustomer();
    }

    // �ֹ� ����
    public void OnAcceptOrder()
    {
        currentState = GameState.AcceptOrder;

        UIManager.Instance.ShowKitchenPanel();
    }

    // �ϼ� �� ��� Ȯ��
    public void OnSubmitOrder()
    {
        currentState = GameState.SubmitOrder;

        UIManager.Instance.ShowCounterPanel();

        // n�� �� ���� �մ�
        StartCoroutine(NextCustmoerAfterDelay(2f));
    }

    private IEnumerator NextCustmoerAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        StartCustomer();
    }
}
