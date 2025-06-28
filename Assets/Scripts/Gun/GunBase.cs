using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class GunBase : MonoBehaviour
{

    public ProjectileBase prefabProjectile;

    public Transform positionToShoot;
    public float timeBetweenShoot = .3f;
    public Transform playerSideReference;

    public AudioRandomPlayAudioClips randomShoot;

    private Coroutine _currentCoroutine;

    private void Awake()
    {
        playerSideReference = GameObject.FindObjectOfType<Player>().transform;
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            _currentCoroutine = StartCoroutine(StartShoot());
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            if(_currentCoroutine != null) StopCoroutine(_currentCoroutine);
        }
    }

    IEnumerator StartShoot()
    {
        while (true)
        {
            Shoot();
            yield return new WaitForSeconds(timeBetweenShoot);
        }
    }


    public void Shoot()
    {
        if (randomShoot != null) randomShoot.PlayRandom();

        var projectile = Instantiate(prefabProjectile);
        projectile.transform.position = positionToShoot.position;
        projectile.side = playerSideReference.transform.localScale.x;
    }
}
