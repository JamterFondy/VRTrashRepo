using UnityEngine;
using System.Collections;

public class GomiManager : MonoBehaviour
{
    [SerializeField] GameObject[] Trashs;

    int randomTrashNum;

    bool addTrashTime90;
    bool addTrashTime60;
    bool addTrashTime30;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(TrashSpawn());

        addTrashTime90 = false;
        addTrashTime60 = false;
        addTrashTime30 = false;
    }

    // Update is called once per frame
    void Update()
    {
       if(UIManager.cameraTimer <= 90)
        {

            if (!addTrashTime90)
            {
                StartCoroutine(TrashSpawn());
                addTrashTime90 = true;
            }

        }
        else if (UIManager.cameraTimer <= 60)
        {

            if (!addTrashTime60)
            {
                StartCoroutine(TrashSpawn());
                addTrashTime60 = true;
            }

        }
        else if (UIManager.cameraTimer <= 30)
        {

            if (!addTrashTime30)
            {
                StartCoroutine(TrashSpawn());
                addTrashTime30 = true;
            }

        }

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



    }
}
