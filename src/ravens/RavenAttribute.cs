using Godot;
using System;

public partial class RavenAttribute : Node {
    
    public readonly RavenAttributes.types type;
    private int level = 1;

    public RavenAttribute(RavenAttributes.types type) {
        this.type = type;
    }

    public RavenAttribute(RavenAttributes.types type, int level) {
        this.type = type;
        this.level = level;
    }
    
    public void levelUp() {
        level++;
    }

    public int getLevel() {
        return level;
    }
}
