using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Customer : MonoBehaviour
{
    public GameManager gm;
    private NavMeshAgent agent;
    public Transform cashier;
    public int desiredProductCount = 1;
    public List<Product> boughtItems = new List<Product>();
    
    private void Start() {
        Debug.Log(gm.productList.Count);
        desiredProductCount = UnityEngine.Random.Range(1, gm.productList.Count);
        Product.OnProductPicked += OnProductPicked;
        agent = GetComponent<NavMeshAgent>();
        Buy();
    }

    private void OnProductPicked(){
        if (desiredProductCount > 0)
        {
            Buy();
        }
        else
        {
            CheckOut();
        }
    }

    private void Buy(){
        var product = gm.GetRandomProduct();
        agent.SetDestination(product.transform.position);
        gm.productList.Remove(product);
        boughtItems.Add(product);
        desiredProductCount--;
    }

    private void CheckOut()
    {
        agent.SetDestination(cashier.position);
    }
}

