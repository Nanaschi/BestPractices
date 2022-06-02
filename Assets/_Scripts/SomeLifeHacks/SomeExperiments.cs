using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class SomeExperiments : MonoBehaviour
{
    private const string ThisIsTheStringValue = nameof(ThisIsTheStringValue);

    [SerializeField] private string _robotName;
    private void Start()
    {

        print(GetRobotName());

    }

    private string GetRobotName() => string.IsNullOrEmpty(_robotName) ? "Default Robot" : "hi";
}
