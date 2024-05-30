using UnityEngine;

public class PlayerCondition : MonoBehaviour
{
    public UICondition UICondition;

    public float staminaThreshold;
    private float cooltime;

    public Condition HP { get { return UICondition.conditions[0]; } }
    public Condition Stamina {  get { return UICondition.conditions[1];} }

    private void Update()
    {
        PassiveHealStamina();
    }

    public void Heal(int value)
    {
        HP.AddValue(value);
    }

    public void Damaged(int value) 
    { 
        HP.SubValue(value);
    }

    public void UseStamina(int value)
    {
        Stamina.SubValue(value);
    }

    public void HealStamina(int value)
    {
        Stamina.AddValue(value);
    }

    private void PassiveHealStamina()
    {
        if (Stamina.curValue == Stamina.maxValue) return;

        if(cooltime >= staminaThreshold)
        {
            HealStamina(Stamina.passiveValue);
            cooltime = 0;
            return;
        }

        cooltime += Time.deltaTime;
    }
}