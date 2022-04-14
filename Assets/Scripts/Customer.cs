using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Customer : MonoBehaviour
{
    public GameManager gm;
    public MoneyManager moneyManager;
    private NavMeshAgent agent;
    public int desiredProductCount = 1;
    public List<Product> boughtItems = new List<Product>();
    [Header("Destinations")]
    public Transform cashier;
    public Transform leaveArea;

    private void Start()
    {
        desiredProductCount = Random.Range(1, gm.productList.Count + 1);
        Product.OnProductPicked += OnProductPicked;
        agent = GetComponent<NavMeshAgent>();
        Buy();
    }

    private void OnProductPicked()
    {
        if (desiredProductCount > 0)
        {
            Buy();
        }
        else
        {
            StartCoroutine(CheckOut());
        }
    }

    private void Buy()
    {
        var product = gm.GetRandomProduct();
        if (product == null) return;
        agent.SetDestination(product.transform.position);
        gm.productList.Remove(product);
        boughtItems.Add(product);
        desiredProductCount--;
    }

    private IEnumerator CheckOut()
    {
        agent.SetDestination(cashier.position);
        yield return new WaitUntil(() => !agent.hasPath);
        
        foreach(var item in boughtItems){
            moneyManager.EarnMoney(10);
        }
        yield return new WaitForSeconds(2f);
        agent.SetDestination(leaveArea.position);
        yield return new WaitForSeconds(2f); 
        Destroy(gameObject);
    }
}

