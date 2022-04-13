using System;
using UnityEngine;
using UnityEngine.AI;

public class Customer : MonoBehaviour
{
    bool pickedProduct;
    private NavMeshAgent agent;
    public GameManager gm;
    
    private void Start() {
        Product.OnProductPicked += OnProductPicked;
        agent = GetComponent<NavMeshAgent>();
        if (!pickedProduct)
        {
            agent.SetDestination(gm.GetProductPos());
        }
    }

    private void OnProductPicked(){
        Debug.Log("Product Picked");
    }
}

