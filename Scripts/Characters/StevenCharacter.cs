using System;
using System.Collections.Generic;

/// <summary>
/// Represents the base structure (skeleton) for Steven Darby in Before Us.
/// This is the logic layer — later, Unity will attach animations and models.
/// </summary>
public class StevenCharacter
{
    // Basic character identity
    public string Name { get; private set; } = "Steven Darby";
    public int Age { get; private set; } = 30;
    public string Role { get; private set; } = "Main Protagonist";

    // Visual description for reference
    public string AppearanceDescription { get; private set; } =
        "Male, mid-30s, light beard, short dark hair, athletic build, wears a dark jacket and jeans.";

    // Physical skeleton structure (simulated)
    public Dictionary<string, string> Skeleton { get; private set; }

    // Stats (we can expand this later for gameplay)
    public float Health { get; private set; } = 100f;
    public float Stamina { get; private set; } = 100f;
    public bool IsAlive { get; private set; } = true;

    // Constructor — builds the skeleton data
    public StevenCharacter()
    {
        Skeleton = new Dictionary<string, string>
        {
            {"Head", "Controls facial direction and camera focus"},
            {"Spine", "Connects upper and lower body"},
            {"LeftArm", "Used for aiming, holding items"},
            {"RightArm", "Used for interacting, fighting"},
            {"LeftLeg", "Supports movement and stance"},
            {"RightLeg", "Supports movement and balance"}
        };
    }

    // Simulated movement (for console testing or logs)
    public void Walk(string direction)
    {
        Console.WriteLine($"{Name} walks {direction}.");
        Stamina -= 5f;
    }

    public void Speak(string line)
    {
        Console.WriteLine($"{Name}: \"{line}\"");
    }

    public void TakeDamage(float amount)
    {
        Health -= amount;
        if (Health <= 0)
        {
            Health = 0;
            IsAlive = false;
            Console.WriteLine($"{Name} has fallen.");
        }
        else
        {
            Console.WriteLine($"{Name} takes {amount} damage. Remaining health: {Health}");
        }
    }

    public void Rest()
    {
        Stamina = Math.Min(100f, Stamina + 20f);
        Console.WriteLine($"{Name} rests to recover stamina.");
    }
}
