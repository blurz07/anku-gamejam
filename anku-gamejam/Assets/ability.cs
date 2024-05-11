using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ability : MonoBehaviour
{
    public Image imageCooldown;
    public Text textCooldown;

    private bool isCooldown = false;
    private float cooldownTime = 10.0f;
    private float cooldownTimer = 0.0f;
    void Start()
    {
        textCooldown.gameObject.SetActive(false);
        imageCooldown.fillAmount= 0.0f;
    }

   
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            UseSpell();
        }
        if(isCooldown)
        {
            ApplyCooldown();

        }
    }

    void ApplyCooldown()
    {
        cooldownTimer -= Time.deltaTime;


        if(cooldownTimer < 0.0f )
        {
            isCooldown = false;
            textCooldown.gameObject.SetActive(false);
            imageCooldown.fillAmount = 0.0f;
        }
        else
        {
            textCooldown.text = Mathf.RoundToInt(cooldownTimer).ToString();
            imageCooldown.fillAmount = cooldownTimer / cooldownTime;
        }

    }

    public void UseSpell()
    {
        if(isCooldown)
        {
             
        }
        else
        {
            isCooldown = true;
            textCooldown.gameObject.SetActive(true);
            cooldownTimer = cooldownTime;
            
        }
    }
   
}
