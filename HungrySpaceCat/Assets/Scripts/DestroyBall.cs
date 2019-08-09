using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBall : MonoBehaviour
{
    private void Update()
    {
		Destroy(this.gameObject, 10f);
    }
}