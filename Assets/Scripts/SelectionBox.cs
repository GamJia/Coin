using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionBox : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private Vector2 startMousePosition, currentMousePosition;
    private BoxCollider2D boxCollider;
    public List<GameObject> selectedObjects = new List<GameObject>();

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 0;
    }

    void Update()
    {
        DragLine();

        if(lineRenderer.positionCount<1&&boxCollider!=null)
        {
            Destroy(boxCollider);
        }
    }

    void DragLine()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            lineRenderer.positionCount = 4;

            for (int i = 0; i < 4; i++)
            {
                lineRenderer.SetPosition(i, startMousePosition);
            }

            boxCollider = gameObject.AddComponent<BoxCollider2D>();
            boxCollider.isTrigger = true;
            boxCollider.offset = Vector2.zero;

        }

        if (Input.GetMouseButton(0))
        {
            currentMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            lineRenderer.SetPosition(1, new Vector2(currentMousePosition.x, startMousePosition.y));
            lineRenderer.SetPosition(2, currentMousePosition);
            lineRenderer.SetPosition(3, new Vector2(startMousePosition.x, currentMousePosition.y));   

            Vector2 center = (startMousePosition + currentMousePosition) / 2;

            boxCollider.offset = center;
            boxCollider.size = new Vector2(Mathf.Abs(startMousePosition.x - currentMousePosition.x),

            Mathf.Abs(startMousePosition.y - currentMousePosition.y));    

        }

        if (Input.GetMouseButtonUp(0))
        {
            CheckCoin();            
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        selectedObjects.Add(other.gameObject);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        selectedObjects.Remove(other.gameObject);
    }

    private void CheckCoin()
    {
        int goldCount = 0;
        int silverCount = 0;
        int copperCount = 0;

        // Create a copy of the selectedObjects list
        List<GameObject> selectedObjectsCopy = new List<GameObject>(selectedObjects);

        foreach (GameObject selectedObject in selectedObjectsCopy)
        {
            Coin coin = selectedObject.GetComponent<Coin>();
            if (coin != null)
            {
                switch (coin.coinID)
                {
                    case CoinID.Gold:
                        goldCount++;
                        break;
                    case CoinID.Silver:
                        silverCount++;
                        break;
                    case CoinID.Copper:
                        copperCount++;
                        break;
                    default:
                        break;
                }
            }
        }

        if (goldCount == silverCount && silverCount == copperCount)
        {
            AudioManager.Instance.PlaySFX(AudioID.Merge); 
            foreach (GameObject selectedObject in selectedObjectsCopy)
            {
                Coin coin = selectedObject.GetComponent<Coin>();
                UIManager.Instance.CalculateScore(10);
                if (coin != null)
                {
                    coin.DestroyCoin();
                }
            }

            lineRenderer.positionCount = 0;
            Destroy(boxCollider);
        }

        else
        {
            lineRenderer.positionCount = 0;
            Destroy(boxCollider);
        }

    
    }
 
}