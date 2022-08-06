using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class EKV_FlameEffect : MonoBehaviour
{
    [SerializeField]
    private MeshRenderer _renderer;

    [SerializeField]
    private EKV_Billboard _flameBillboard;

    private AudioSource _pulseSound;


    private void Awake()
    {
        _pulseSound = GetComponent<AudioSource>();
        _pulseSound.pitch += Random.Range(-0.1f, 0.1f);
        _renderer.enabled = false;
    }

    public void Puff()
    {
        StopAllCoroutines();
        StartCoroutine(MakePuffRoutine());
    }

    private IEnumerator MakePuffRoutine()
    {
        _pulseSound.Play();

        _flameBillboard.RotateToCamera();

        _renderer.enabled = true;
        yield return new WaitForSeconds(0.01f);
        yield return new WaitForEndOfFrame();
        _renderer.enabled = false;
    }




}
