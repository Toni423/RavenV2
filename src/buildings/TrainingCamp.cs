using Godot;
using System;

public partial class TrainingCamp : Building {
    private RavenAttributes.types traingingType = RavenAttributes.types.Strength;

    public override void _Ready() {
        base._Ready();
        cooldown = 10f;
        cooldownMax = 10f;
    }

    protected override void work(double delta) {
        for (int i = 0; i < employed.Count; i++) {
            employed[i].levelUp(traingingType);
            GD.Print("levelup: " + traingingType + " " + employed[i].getAttributeLevel(traingingType));
        }
    }

    public bool changeTrainingType(RavenAttributes.types type) {
        if (employed.Count > 0) {
            return false;
        }

        traingingType = type;
        return true;
    }
    
    
    
}
