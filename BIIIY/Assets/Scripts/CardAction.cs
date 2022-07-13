using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardAction : MonoBehaviour
{
    private Animator _animator;
    public Item _thisItem;
    private PlayerInventory _playerInventory;
    private bool isTouched = false;
    private bool isActive = false;
    private Vector3 velocity = Vector3.zero;

    public System.Action<Item> onItemAdd;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _playerInventory = GameObject.Find("Player").GetComponent<PlayerInventory>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit2D rayHit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));
            if ((rayHit.collider != null))
            {
                if ((rayHit.collider.tag == "Card")&&!isActive)
                {
                    gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
                    gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                    _animator.SetTrigger("isClick");
                    isTouched = true;
                }
                else if ((rayHit.collider.tag == "Card")&&isActive)
                {
                    Destroy(rayHit.collider.gameObject);
                    onItemAdd.Invoke(_thisItem);
                }
            }
        }
        if ((isTouched) && (transform.position != new Vector3(-1.03f, 1.14f, 0f)))
        {
            MoveCard();
        }
        else if (transform.position == new Vector3(-1.03f, 1.14f, 0f))
        {
            isActive = true;    
        }
    }
    void MoveCard()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(-1.03f, 1.14f, 0f), Time.deltaTime*100f);
    }
}
