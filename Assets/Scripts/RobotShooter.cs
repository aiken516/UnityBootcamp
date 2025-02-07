using UnityEngine;

public class RobotShooter : MonoBehaviour
{
    [SerializeField] private GameObject shootPoint;

    [SerializeField] private GameObject prefab;
    [SerializeField] public float power = 200;

    [SerializeField] bool isSuper = false;

    void Start()
    {
        
    }

    [SerializeField] int time = 0;

    // Update is called once per frame
    void Update()
    {
        time++;

        if (isSuper)
        {
            if (GameManager.instance.SuperRobotUpgradeCount > 0 && time >= 100 / GameManager.instance.SuperRobotUpgradeCount)
            {
                GameObject thrown = Instantiate(prefab, shootPoint.transform.position, shootPoint.transform.rotation);

                GameObject target = GameObject.Find("target");

                thrown.GetComponent<ObjectShooter>().Shoot(((target.transform.position + Vector3.up * 6.5f) - thrown.transform.position) * power);

                time = 0;
            }
        }
        else
        {
            if (GameManager.instance.RobotUpgradeCount > 0 && time >= 500 / GameManager.instance.RobotUpgradeCount)
            {
                GameObject thrown = Instantiate(prefab, shootPoint.transform.position, shootPoint.transform.rotation);

                GameObject target = GameObject.Find("target");

                thrown.GetComponent<ObjectShooter>().Shoot(((target.transform.position + Vector3.up * 6.5f) - thrown.transform.position) * power);

                time = 0;
            }
        }


    }
}
