using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinState : MonoBehaviour {

    bool coinroll = false;

    Vector3 moveDir;
    Vector3 upper, downner;

    private void Start()
    {
        moveDir = transform.position;
        moveDir.y = transform.position.y + 1f;

        upper = transform.position;
        upper.y = transform.position.y + 0.2f;

        downner = transform.position;
        downner.y = transform.position.y - 0.2f;
    }

    private void Update()
    {
        if (coinroll == true)
            StartCoroutine(PickupCoin());
        else
        {
            idleCoin();
        }
    }

    IEnumerator PickupCoin()
    {
        if (transform.localScale.x == 1f)
        {
            yield return new WaitForSeconds(Time.deltaTime * 2f);
            Vector3 CoinScale = transform.localScale;
            CoinScale.x = 0.2f;
            transform.localScale = CoinScale;
        }
        else
        {
            yield return new WaitForSeconds(Time.deltaTime * 2f);
            Vector3 CoinScale = transform.localScale;
            CoinScale.x = 1f;
            transform.localScale = CoinScale;
        }
    }

    void idleCoin()
    {
        if (transform.position.y >= upper.y)
            moveDir = downner;
        else if (transform.position.y <= downner.y)
            moveDir = upper;

        transform.position = Vector3.MoveTowards(transform.position, moveDir, 1f * Time.deltaTime);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            coinroll = true;
            Destroy(gameObject, 1f);
        }
    }
}
