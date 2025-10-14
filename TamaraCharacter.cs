using System;
using System.Collections.Generic;

namespace BeforeUs.Characters
{
    /// <summary>
    /// Represents the base structure (skeleton) for Tamara Darby in Before Us.
    /// This defines her identity, visuals, stats, and skeletal functions.
    /// </summary>
    public class TamaraCharacter
    {
        // Basic character identity
        public string Name { get; private set; } = "Tamara Darby";
        public int Age { get; private set; } = 29;
        public string Role { get; private set; } = "Neurologist / Mother";

        // Visual description for reference
        public string AppearanceDescription { get; private set; } =
            "Female, late 20s, warm expression, medium-dark skin tone, reddish-brown braids, casual shirt, confident but kind demeanor.";

        // Physical skeleton structure (simulated)
        public Dictionary<string, string> Skeleton { get; private set; }

        // Character stats
        public float Health { get; private set; } = 90f;
        public float Stamina { get; private set; } = 80f;
        public bool IsAlive { get; private set; } = true;

        // Constructor
        public TamaraCharacter()
        {
            Skeleton = new Dictionary<string, string>
            {
                {"Head", "Facial control, expressions, speech"},
                {"Neck", "Head stability and subtle movement"},
                {"LeftArm", "Used for comforting gestures, carrying objects"},
                {"RightArm", "Used for precision work or holding items"},
                {"Torso", "Supports posture and movement"},
                {"LeftLeg", "Movement and balance"},
                {"RightLeg", "Movement and balance"}
            };
        }

        // Movement simulation (console test or log)
        public void Walk(string direction)
        {
            Console.WriteLine($"{Name} walks {direction} calmly.");
            Stamina -= 3f;
        }

        // Dialogue simulation
        public void Speak(string line)
        {
            Console.WriteLine($"{Name} says: \"{line}\"");
        }

        // Damage system
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

        // Rest system
        public void Rest()
        {
            Stamina = Math.Min(80f, Stamina + 15f);
            Console.WriteLine($"{Name} rests to recover strength.");
        }
    }
}
