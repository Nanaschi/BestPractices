using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpheresTween : MonoBehaviour
{

    [SerializeField] private SphereCollider[] _sphereColliders;
    [SerializeField] private float _xAxisMovement;
    [SerializeField] private Vector2 _randomMovementBorders;
    
    private void Start()
    {
        SequenceTween();
        //SpheresTweenLogic();
    }

    private void SpheresTweenLogic()
    {
        

        for (int i = 0; i < _sphereColliders.Length; i++)
        {
            _sphereColliders[0].transform
                .DOMoveX(_xAxisMovement, Random.Range(_randomMovementBorders.x, _randomMovementBorders.y))
                .OnComplete(() =>
                {
                    _sphereColliders[1].transform
                        .DOMoveX(_xAxisMovement, Random.Range(_randomMovementBorders.x, _randomMovementBorders.y))
                        .OnComplete(() =>
                        {
                            _sphereColliders[2].transform
                                .DOMoveX(_xAxisMovement,
                                    Random.Range(_randomMovementBorders.x, _randomMovementBorders.y)).OnComplete(() =>
                                {
                                    foreach (var sphereCollider in _sphereColliders)
                                    {
                                        sphereCollider.transform.DOScale(Vector3.zero, .5f).SetEase(Ease.InBounce);
                                    }
                                });
                        });
                });
        }
    }

    private void SequenceTween()
    {
        var sequence = DOTween.Sequence();

        foreach (var sphereCollider in _sphereColliders)
        {
            sequence.Append(sphereCollider.transform
                .DOMoveX(_xAxisMovement, Random.Range(_randomMovementBorders.x, _randomMovementBorders.y)));
            
        }
        
        sequence.OnComplete(() =>
        {
            foreach (var sphereCollider in _sphereColliders)
            {
                sphereCollider.transform.DOScale(Vector3.zero, .5f).SetEase(Ease.InBounce);
            }
            
        });

  
    }
}
