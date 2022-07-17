using System;
using UnityEngine;

public class DecoratorPattern : MonoBehaviour
{
    private void Start()
    {
        IPizza pizza = new Pizza();
        IPizza pizzaOnions = new OnionsDecorators(pizza);
        print(pizzaOnions.GetPizza());
    }
}