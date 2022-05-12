using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoGenerator : MonoBehaviour
{
    public GameObject ammo, ammoParent;
    public int borderMinX, borderMinZ, borderMaxX, borderZMin;

    private void Update()
    {
        if(ammoParent.transform.childCount <= 10)
        {
            Invoke("GenerateAmmo", 3f);
        }
    }

    public void GenerateAmmo()
    {
        GameObject generatedAmmo = Instantiate(ammo, GenerateRandomPosition(), transform.rotation);
    }

private Vector3 GenerateRandomPosition()
    {
        return new Vector3(Random.Range(borderMaxX,borderMinX), ammo.transform.position.y,Random.Range(borderMinZ,borderZMin));
    }
}
