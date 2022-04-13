using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<Product> productList = new List<Product>();

    public Product GetRandomProduct()
    {
        return productList[Random.Range(0, productList.Count)];
    }

}
