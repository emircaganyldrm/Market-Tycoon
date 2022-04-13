using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<Transform> productList = new List<Transform>();

    public Vector3 GetProductPos()
    {
        return productList[Random.Range(0, productList.Count)].position;
    }

}
