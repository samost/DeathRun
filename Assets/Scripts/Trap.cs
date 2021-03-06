using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Trap : MonoBehaviour
{
    [SerializeField]protected List<Transform> MoveableElements;
    protected abstract IEnumerator Activate();
    
}
