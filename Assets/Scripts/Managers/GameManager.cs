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

    // 새로운 손님 등장
    public void StartCustomer()
    {
        currentState = GameState.AwaitingOrder;

        UIManager.Instance.ShowCounterPanel();
        CustomerManager.Instance.SpawnNewCustomer();
    }

    // 주문 수락
    public void OnAcceptOrder()
    {
        currentState = GameState.AcceptOrder;

        UIManager.Instance.ShowKitchenPanel();
    }

    // 완성 후 결과 확인
    public void OnSubmitOrder()
    {
        currentState = GameState.SubmitOrder;

        UIManager.Instance.ShowCounterPanel();

        // n초 후 다음 손님
        StartCoroutine(NextCustmoerAfterDelay(2f));
    }

    private IEnumerator NextCustmoerAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        StartCustomer();
    }
}
