using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    [SerializeField] private Vector2Int _bonusCountRange;
    private int _bonusCount;

    [SerializeField] private TMP_Text _view;

    private void Start()
    {
        _bonusCount = Random.Range(_bonusCountRange.x, _bonusCountRange.y);
        _view.text = _bonusCount.ToString();
    }

    public int Collect()
    {
        Destroy(gameObject);
        return _bonusCount;
    }
}
