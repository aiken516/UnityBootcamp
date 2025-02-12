using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ObjectShooter : MonoBehaviour
{
    private GameObject objectGenerator;

    void Start()
    {
        objectGenerator = GameObject.Find("Object Generator");
        Destroy(gameObject, 10f);
    }

    /// <summary>
    /// 물체를 발사하는 함수
    /// </summary>
    /// <param name="direction"></param>
    public void Shoot(Vector3 direction)
    {
        GetComponent<Rigidbody>().AddForce(direction);
    }

    private void OnCollisionEnter(Collision collision)
    {
        GetComponent<Rigidbody>().isKinematic = true;
        //GetComponent<ParticleSystem>().Play();
        if (collision.gameObject.tag == "Terrain")
        {
            Destroy(gameObject);
        }
        else
        {
            GameManager.instance.ScorePlus(GameManager.instance.CurrentHitValue * GameManager.instance.UpgradeCount);
            Destroy(gameObject);
        }
    }
}
