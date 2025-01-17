using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;

using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
   
    public GameObject bulletprefab;
    public GameObject fireposition;
    public bool b = true;
    private bool c = false;
    private float d=0;
    public TextMeshProUGUI TextMeshPro1;







    public static Player Instance { get; private set; }

    private bool isDie = false;
    private bool isWalking;
    private bool isDash;
    private bool isShoot;
    private bool hasGun= false;
    private bool hasDash= false;
    private float dashPower = 24f;
    private float dashTime =.2f;
    private float dashCooldown=1f;
    private int energyPoint=0;

    [SerializeField] private float Speed;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private TrailRenderer trailRenderer;
    [SerializeField] private GameObject DialogueUI;

    public bool canmove = true;


    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
        
    }

    private void Start()
    {
        GameInput.Instance.OnPlayerShoot += GameInput_OnPlayerShoot;
        GameInput.Instance.OnPlayerDash += GameInput_OnPlayerDash;
        GameInput.Instance.OnPlayerRecharge += GameInput_OnPlayerRecharge;
        
       
       
    }

    private void GameInput_OnPlayerRecharge(object sender, System.EventArgs e)
    {
        if (energyPoint > 0)
        {
            float maxEnergy = Energybar.Instance.MaxBar;
            Energybar.Instance.Recharge(Random.Range(20, maxEnergy));
        }
    }

    private void GameInput_OnPlayerDash(object sender, System.EventArgs e)
    {
        if (hasDash && Energybar.Instance.getBar() >= 5)
        {
        if (isDash) { return; }
        StartCoroutine(Dash());
        }
        
    }

    private void GameInput_OnPlayerShoot(object sender, System.EventArgs e)
    {
        if (hasGun && Energybar.Instance.getBar() >= 3) 
        {
            
        {
            isShoot=true;
            Attack();
            Energybar.Instance.UseEnergy(3);
        }
        }

        
    }


    void Update()
    {
        isWalking = false;  
        isShoot = false;
        SetIsDie();
        if (canmove)
        {
             Move();
        }
       

}
    public bool IsWalking()
    {
        return isWalking;
    }
    public bool IsDash()
    {
        return isDash;
    }
    public bool IsShoot()
    {
        return isShoot;
    }
    public bool IsDie()
    {
        return isDie;
    }
    public void SetIsDie()
    {
        if(Healthbar.Instance.IsAlive() ) {return;}
        isDie=true;

    }
    public void Attack()
    {
        Vector2 BaseVector = GameInput.Instance.BaseShootVector();
        if (BaseVector != new Vector2(0,0))
        {       
            GameObject bullet = Instantiate(bulletprefab, fireposition.transform.position, fireposition.transform.rotation);
            bullet.GetComponent<Rigidbody2D>().AddForce(BaseVector * 1000);
            float angle = Mathf.Atan2(BaseVector.y, BaseVector.x) * Mathf.Rad2Deg;
            bullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        }

        
    }
    private void Move()
    {
        Vector2 BaseVector = GameInput.Instance.BaseVector();
        transform.Translate(BaseVector * Speed * Time.deltaTime);
        if (BaseVector != new Vector2(0,0))
        {
            isWalking = true;
            if (BaseVector.x < 0)
            {
                spriteRenderer.flipX = true;
            }
            else
            {
                spriteRenderer.flipX = false;
            }
        }
        else { isWalking = false; }

    }
    private IEnumerator Dash()
    {
        Vector2 BaseVector = GameInput.Instance.BaseVector();
        isDash = true;
         Speed += dashPower ;
        trailRenderer.emitting = true;
        Energybar.Instance.UseEnergy(5);
        yield return new WaitForSeconds(dashTime);
        Speed -= dashPower;
        trailRenderer.emitting = false;
        yield return new WaitForSeconds(dashCooldown);
        isDash=false;
        
    }
    public void SetPointEnergy( int value)
    {
        energyPoint = value;
    }
    public int GetPointEnergy()
    {
        return energyPoint;                                                                                           
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "gun") { hasGun = true; Destroy(collision.gameObject); }
        if (collision.tag == "dash") { hasDash = true; Destroy(collision.gameObject); }
        if (collision.tag == "energypoint") { energyPoint++; Destroy(collision.gameObject);}

        if (collision.tag == "npc") { DialogueUI.SetActive(true); }
        if (collision.tag == "bulletenemy") { Healthbar.Instance.TakeDamage(2); Destroy(collision.gameObject); }
        if (collision.tag == "poison") { Healthbar.Instance.TakeDamage(1); }
    }

}




