using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private List<GameObject> _bulletShapeList;

    void Start()
    {
        int upgradeLevel = GameManager.instance.UpgradeCount;

        if (upgradeLevel >= 1 && upgradeLevel <= 7)
        {
            _bulletShapeList[upgradeLevel-1].SetActive(true);
        }
        else
        {
            _bulletShapeList[6].SetActive(true);
        }
    }
}
