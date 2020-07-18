using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RelationshipClass {

    protected Relationship relationship;

    public abstract RelationshipClass ReciprocateToMe(Person me);

    public override string ToString() {
        return relationship.ToString();
    }
}

public class Husband : RelationshipClass {

    public Husband() {
        relationship = Relationship.Husband;
    }

    public override RelationshipClass ReciprocateToMe(Person me) {
        switch ( me.Sex ) {
            case Sex.Female:
                return new Wife();
            case Sex.Male:
                return new Husband();
            default:
                return null;
        }
    }

}
public class Wife : RelationshipClass {

    public Wife() {
        relationship = Relationship.Wife;
    }

    public override RelationshipClass ReciprocateToMe(Person me) {
        switch ( me.Sex ) {
            case Sex.Female:
                return new Wife();
            case Sex.Male:
                return new Husband();
            default:
                return null;
        }
    }
}
public class Father : RelationshipClass {

    public Father() {
        relationship = Relationship.Father;
    }

    public override RelationshipClass ReciprocateToMe(Person me) {
        switch ( me.Sex ) {
            case Sex.Female:
                return new Daughter();
            case Sex.Male:
                return new Son();
            default:
                return null;
        }
    }
}
public class Mother : RelationshipClass {

    public Mother() {
        relationship = Relationship.Mother;
    }

    public override RelationshipClass ReciprocateToMe(Person me) {
        switch ( me.Sex ) {
            case Sex.Female:
                return new Daughter();
            case Sex.Male:
                return new Son();
            default:
                return null;
        }
    }
}
public class Son : RelationshipClass {

    public Son() {
        relationship = Relationship.Son;
    }

    public override RelationshipClass ReciprocateToMe(Person me) {
        switch ( me.Sex ) {
            case Sex.Female:
                return new Mother();
            case Sex.Male:
                return new Father();
            default:
                return null;
        }
    }
}
public class Daughter : RelationshipClass {

    public Daughter() {
        relationship = Relationship.Daughter;
    }

    public override RelationshipClass ReciprocateToMe(Person me) {
        switch ( me.Sex ) {
            case Sex.Female:
                return new Mother();
            case Sex.Male:
                return new Father();
            default:
                return null;
        }
    }

}
public class Brother : RelationshipClass {

    public Brother() {
        relationship = Relationship.Brother;
    }

    public override RelationshipClass ReciprocateToMe(Person me) {
        switch ( me.Sex ) {
            case Sex.Female:
                return new Sister();
            case Sex.Male:
                return new Brother();
            default:
                return null;
        }
    }

    
}
public class Sister : RelationshipClass {

    public Sister() {
        relationship = Relationship.Sister;
    }

    public override RelationshipClass ReciprocateToMe(Person me) {
        switch ( me.Sex ) {
            case Sex.Female:
                return new Sister();
            case Sex.Male:
                return new Brother();
            default:
                return null;
        }
    }

    
}
public class Grandmother : RelationshipClass {

    public Grandmother() {
        relationship = Relationship.Grandmother;
    }

    public override RelationshipClass ReciprocateToMe(Person me) {
        return new Grandchild();
    }

}
public class Grandfather : RelationshipClass {

    public Grandfather() {
        relationship = Relationship.Grandfather;
    }

    public override RelationshipClass ReciprocateToMe(Person me) {
        return new Grandchild();
    }

}
public class Grandchild : RelationshipClass {

    public Grandchild() {
        relationship = Relationship.Grandchild;
    }

    public override RelationshipClass ReciprocateToMe(Person me) {
        switch ( me.Sex ) {
            case Sex.Female:
                return new Grandmother();
            case Sex.Male:
                return new Grandfather();
            default:
                return null;
        }
    }

}
public class Uncle : RelationshipClass {

    public Uncle() {
        relationship = Relationship.Uncle;
    }

    public override RelationshipClass ReciprocateToMe(Person me) {
        switch ( me.Sex ) {
            case Sex.Female:
                return new Niece();
            case Sex.Male:
                return new Nephew();
            default:
                return null;
        }
    }

}
public class Aunt : RelationshipClass {

    public Aunt() {
        relationship = Relationship.Aunt;
    }

    public override RelationshipClass ReciprocateToMe(Person me) {
        switch ( me.Sex ) {
            case Sex.Female:
                return new Niece();
            case Sex.Male:
                return new Nephew();
            default:
                return null;
        }
    }

    
}
public class Nephew : RelationshipClass {

    public Nephew() {
        relationship = Relationship.Nephew;
    }

    public override RelationshipClass ReciprocateToMe(Person me) {
        switch ( me.Sex ) {
            case Sex.Female:
                return new Aunt();
            case Sex.Male:
                return new Uncle();
            default:
                return null;
        }
    }

}
public class Niece : RelationshipClass {

    public Niece() {
        relationship = Relationship.Niece;
    }

    public override RelationshipClass ReciprocateToMe(Person me) {
        switch ( me.Sex ) {
            case Sex.Female:
                return new Aunt();
            case Sex.Male:
                return new Uncle();
            default:
                return null;
        }
    }

}
public class Cousin : RelationshipClass {

    public Cousin() {
        relationship = Relationship.Cousin;
    }

    public override RelationshipClass ReciprocateToMe(Person me) {
        return new Cousin();
    }

}
public class MotherInLaw : RelationshipClass {

    public MotherInLaw() {
        relationship = Relationship.MotherInLaw;
    }

    public override RelationshipClass ReciprocateToMe(Person me) {
        switch ( me.Sex ) {
            case Sex.Female:
                return new DaughterInLaw();
            case Sex.Male:
                return new SonInLaw();
            default:
                return null;
        }
    }
}
public class FatherInLaw : RelationshipClass {

    public FatherInLaw() {
        relationship = Relationship.FatherInLaw;
    }

    public override RelationshipClass ReciprocateToMe(Person me) {
        switch ( me.Sex ) {
            case Sex.Female:
                return new DaughterInLaw();
            case Sex.Male:
                return new SonInLaw();
            default:
                return null;
        }
    }
}
public class SonInLaw : RelationshipClass {

    public SonInLaw() {
        relationship = Relationship.SonInLaw;
    }

    public override RelationshipClass ReciprocateToMe(Person me) {
        switch ( me.Sex ) {
            case Sex.Female:
                return new MotherInLaw();
            case Sex.Male:
                return new FatherInLaw();
            default:
                return null;
        }
    }

}
public class DaughterInLaw : RelationshipClass {

    public DaughterInLaw() {
        relationship = Relationship.DaughterInLaw;
    }

    public override RelationshipClass ReciprocateToMe(Person me) {
        switch ( me.Sex ) {
            case Sex.Female:
                return new MotherInLaw();
            case Sex.Male:
                return new FatherInLaw();
            default:
                return null;
        }
    }
}
public class BrotherInLaw : RelationshipClass {

    public BrotherInLaw() {
        relationship = Relationship.BrotherInLaw;
    }

    public override RelationshipClass ReciprocateToMe(Person me) {
        switch ( me.Sex ) {
            case Sex.Female:
                return new SisterInLaw();
            case Sex.Male:
                return new BrotherInLaw();
            default:
                return null;
        }
    }
}
public class SisterInLaw : RelationshipClass {

    public SisterInLaw() {
        relationship = Relationship.SisterInLaw;
    }

    public override RelationshipClass ReciprocateToMe(Person me) {
        switch ( me.Sex ) {
            case Sex.Female:
                return new SisterInLaw();
            case Sex.Male:
                return new BrotherInLaw();
            default:
                return null;
        }
    }
}
public class Friend : RelationshipClass {

    public Friend() {
        relationship = Relationship.Friend;
    }

    public override RelationshipClass ReciprocateToMe(Person me) {
        return new Friend();
    }
}

