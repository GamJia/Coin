using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeCoin : MonoBehaviour
{
    public float jumpForce = 13f; // 점프 힘

    void Start()
    {
        GetComponent<Coin>().enabled=false;
        
        JumpRandomDirection();
    }

    void Update()
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);

        if (screenPos.y > Screen.height  || screenPos.y < 0)
        {
            Destroy(gameObject);
        }
    }

    void JumpRandomDirection()
    {        
        Rigidbody2D coinRigidbody = GetComponent<Rigidbody2D>();
        coinRigidbody.isKinematic=false;

        if (coinRigidbody != null)
        {
            float randomAngle = Random.Range(40f, 140f);

            Vector2 jumpDirection = new Vector2(Mathf.Cos(randomAngle * Mathf.Deg2Rad), Mathf.Sin(randomAngle * Mathf.Deg2Rad));
            coinRigidbody.AddForce(jumpDirection * jumpForce, ForceMode2D.Impulse);
        }

    }
}
