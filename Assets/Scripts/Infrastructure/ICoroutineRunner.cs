using System.Collections;
using UnityEngine;

namespace Scripts.Infrasracture
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
    }
}