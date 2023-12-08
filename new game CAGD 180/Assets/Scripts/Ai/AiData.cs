using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiData : MonoBehaviour
{

    public List<Transform> targets = null;
    public Collider[] obstacles = null;

    public Transform currentTarget;

    public int GetTargetCount() => targets == null ? 0 : targets.Count;
}
