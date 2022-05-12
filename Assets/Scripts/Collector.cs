using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Collector : MonoBehaviour
{
    public Transform StackParent;
    public GameObject StackableObject;
    public float StackableObjectHeight;
    public List<GameObject> Collectables;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectable"))
        {
            other.transform.SetParent(StackParent);
            Vector3 _stackableObjectFinalPosition = StackableObject.transform.localPosition;

            _stackableObjectFinalPosition.y += StackableObjectHeight;
            _stackableObjectFinalPosition.x = 0;
            _stackableObjectFinalPosition.z = 0;

            // other.transform.rotation = new Quaternion(0, 0, 0, 0);

            other.transform.DOLocalMove(_stackableObjectFinalPosition, 0.3f);
            StackableObject = other.gameObject;
            Collectables.Add(other.gameObject);
            other.gameObject.tag = "Untagged";


        }
    }
}
