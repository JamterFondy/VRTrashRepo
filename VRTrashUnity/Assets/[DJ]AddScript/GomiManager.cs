using UnityEngine;
using System.Collections;

public class GomiManager : MonoBehaviour
{
    [SerializeField] GameObject[] Trashs;

    int randomTrashNum;

   

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(TrashSpawn());

    }

    // Update is called once per frame
    void Update()
    {
       

    }



    IEnumerator TrashSpawn()
    {
        yield return new WaitForSeconds(0.5f);

        for (int i = 0; i < 20; i++)
        {
            randomTrashNum = Random.Range(0, 6);
            float TrashPosX = Random.Range(-10f, 10f);
            float TrashPosZ = Random.Range(-10f, 10f);
            Object.Instantiate(Trashs[randomTrashNum], new Vector3(TrashPosX, 10, TrashPosZ), Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360)));

        }

        yield return new WaitForSeconds(30f);

        for (int i = 0; i < 20; i++)
        {
            randomTrashNum = Random.Range(0, 6);
            float TrashPosX = Random.Range(-10f, 10f);
            float TrashPosZ = Random.Range(-10f, 10f);
            Object.Instantiate(Trashs[randomTrashNum], new Vector3(TrashPosX, 10, TrashPosZ), Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360)));

        }

        yield return new WaitForSeconds(30f);

        for (int i = 0; i < 20; i++)
        {
            randomTrashNum = Random.Range(0, 6);
            float TrashPosX = Random.Range(-10f, 10f);
            float TrashPosZ = Random.Range(-10f, 10f);
            Object.Instantiate(Trashs[randomTrashNum], new Vector3(TrashPosX, 10, TrashPosZ), Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360)));

        }

        yield return new WaitForSeconds(30f);

        for (int i = 0; i < 20; i++)
        {
            randomTrashNum = Random.Range(0, 6);
            float TrashPosX = Random.Range(-10f, 10f);
            float TrashPosZ = Random.Range(-10f, 10f);
            Object.Instantiate(Trashs[randomTrashNum], new Vector3(TrashPosX, 10, TrashPosZ), Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360)));

        }

    }
}
