
using System;

[Serializable]
public class Health
{
    public int currentHealth;
    public int maxHealth;

    public Action<int> OnChanged;

    public void Reduce(int value)
    {
        currentHealth -= value;
        if (currentHealth < 0) currentHealth = 0;
        OnChanged?.Invoke(currentHealth);
    }
    public void Gain(int value)
    {
        currentHealth += value;
        if (currentHealth > maxHealth) currentHealth = maxHealth;
        OnChanged?.Invoke(currentHealth);
    }
}