using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public float timeMax = 1f;
    private float timeInitial = 0;
    public GameObject prefabs;
    public float Altura = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        GameObject gameObject1 = Instantiate(prefabs);
        gameObject1.transform.position = transform.position + new Vector3(0, 0, 0);
        Destroy(gameObject1,8);
    }

    // Update is called once per frame
    void Update()
    {
        if (timeInitial>timeMax)
        {
            GameObject gameObject1 = Instantiate(prefabs);
            gameObject1.transform.position = transform.position + new Vector3(0, Random.Range(-Altura,Altura), 0);
            Destroy(gameObject1,8);
            timeInitial = 0;
        }
        else
        {
            timeInitial += Time.deltaTime;
        }
    }
}
