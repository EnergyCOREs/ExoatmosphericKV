using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class EKV_FlameEffect : MonoBehaviour
{
    [SerializeField]
    private MeshRenderer _renderer;

    private AudioSource _pulseSound;

    private void Awake()
    {
        _pulseSound = GetComponent<AudioSource>();
        _pulseSound.pitch += Random.Range(-0.1f, 0.1f);
    }

    public void Puff()
    {
        StopAllCoroutines();
        StartCoroutine(MakePuffRoutine());
    }

    private IEnumerator MakePuffRoutine()
    {
        _pulseSound.Play();
        _renderer.enabled = true;
        yield return new WaitForSeconds(0.01f);
        yield return new WaitForEndOfFrame();
        _renderer.enabled = false;
    }

}
