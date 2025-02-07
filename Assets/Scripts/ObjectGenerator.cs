using TMPro;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class ObjectGenerator : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] public float power = 1000f;

    /// <summary>
    /// ���� �߰�
    /// </summary>
    /// <param name="value">�߰���</param>
    public void ScorePlus(int value)
    {
        GameManager.instance.Score += value;
        GameManager.instance.SetScore();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        { 
            GameObject thrown = Instantiate(prefab, transform.position, transform.rotation);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            thrown.GetComponent<ObjectShooter>().Shoot(ray.direction * power);
        }
    }

}
