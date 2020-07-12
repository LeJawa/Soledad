using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Relationship {
    Unknown,
    Husband,
    Wife,
    Father,
    Mother,
    Son,
    Daughter,
    Brother,
    Sister,
    Grandmother,
    Grandfather,
    Grandchild_m,
    Grandchild_f,
    Uncle,
    Aunt,
    Cousin_m,
    Cousin_f,
    Niece,
    Nephew,
    FatherInLaw,
    MotherInLaw,
    SonInLaw,
    DaughterInLaw,
    BrotherInLaw,
    SisterInLaw,
    Friend
}

public static class RelationshipExtensions {

    public static Relationship Reciprocate(Relationship relationship, Person me) {
        switch ( relationship ) {
            case Relationship.Husband:
                switch ( me.Sex ) {
                    case Sex.Female:
                        return Relationship.Wife;
                    case Sex.Male:
                        return Relationship.Husband;
                    default:
                        return Relationship.Unknown;
                }
            case Relationship.Wife:
                switch ( me.Sex ) {
                    case Sex.Female:
                        return Relationship.Wife;
                    case Sex.Male:
                        return Relationship.Husband;
                    default:
                        return Relationship.Unknown;
                }
            case Relationship.Father:
                switch ( me.Sex ) {
                    case Sex.Female:
                        return Relationship.Daughter;
                    case Sex.Male:
                        return Relationship.Son;
                    default:
                        return Relationship.Unknown;
                }
            case Relationship.Mother:
                switch ( me.Sex ) {
                    case Sex.Female:
                        return Relationship.Daughter;
                    case Sex.Male:
                        return Relationship.Son;
                    default:
                        return Relationship.Unknown;
                }
            case Relationship.Son:
                switch ( me.Sex ) {
                    case Sex.Female:
                        return Relationship.Mother;
                    case Sex.Male:
                        return Relationship.Father;
                    default:
                        return Relationship.Unknown;
                }
            case Relationship.Daughter:
                switch ( me.Sex ) {
                    case Sex.Female:
                        return Relationship.Mother;
                    case Sex.Male:
                        return Relationship.Father;
                    default:
                        return Relationship.Unknown;
                }
            case Relationship.Brother:
                switch ( me.Sex ) {
                    case Sex.Female:
                        return Relationship.Sister;
                    case Sex.Male:
                        return Relationship.Brother;
                    default:
                        return Relationship.Unknown;
                }
            case Relationship.Sister:
                switch ( me.Sex ) {
                    case Sex.Female:
                        return Relationship.Sister;
                    case Sex.Male:
                        return Relationship.Brother;
                    default:
                        return Relationship.Unknown;
                }
            case Relationship.Grandmother:
                switch ( me.Sex ) {
                    case Sex.Female:
                        return Relationship.Grandchild_f;
                    case Sex.Male:
                        return Relationship.Grandchild_m;
                    default:
                        return Relationship.Unknown;
                }
            case Relationship.Grandfather:
                switch ( me.Sex ) {
                    case Sex.Female:
                        return Relationship.Grandchild_f;
                    case Sex.Male:
                        return Relationship.Grandchild_m;
                    default:
                        return Relationship.Unknown;
                }
            case Relationship.Grandchild_m:
                switch ( me.Sex ) {
                    case Sex.Female:
                        return Relationship.Grandmother;
                    case Sex.Male:
                        return Relationship.Grandfather;
                    default:
                        return Relationship.Unknown;
                }
            case Relationship.Grandchild_f:
                switch ( me.Sex ) {
                    case Sex.Female:
                        return Relationship.Grandmother;
                    case Sex.Male:
                        return Relationship.Grandfather;
                    default:
                        return Relationship.Unknown;
                }
            case Relationship.Uncle:
                switch ( me.Sex ) {
                    case Sex.Female:
                        return Relationship.Niece;
                    case Sex.Male:
                        return Relationship.Nephew;
                    default:
                        return Relationship.Unknown;
                }
            case Relationship.Aunt:
                switch ( me.Sex ) {
                    case Sex.Female:
                        return Relationship.Niece;
                    case Sex.Male:
                        return Relationship.Nephew;
                    default:
                        return Relationship.Unknown;
                }
            case Relationship.Cousin_m:
                switch ( me.Sex ) {
                    case Sex.Female:
                        return Relationship.Cousin_f;
                    case Sex.Male:
                        return Relationship.Cousin_m;
                    default:
                        return Relationship.Unknown;
                }
            case Relationship.Cousin_f:
                switch ( me.Sex ) {
                    case Sex.Female:
                        return Relationship.Cousin_f;
                    case Sex.Male:
                        return Relationship.Cousin_m;
                    default:
                        return Relationship.Unknown;
                }
            case Relationship.Niece:
                switch ( me.Sex ) {
                    case Sex.Female:
                        return Relationship.Aunt;
                    case Sex.Male:
                        return Relationship.Uncle;
                    default:
                        return Relationship.Unknown;
                }
            case Relationship.Nephew:
                switch ( me.Sex ) {
                    case Sex.Female:
                        return Relationship.Aunt;
                    case Sex.Male:
                        return Relationship.Uncle;
                    default:
                        return Relationship.Unknown;
                }
            case Relationship.FatherInLaw:
                switch ( me.Sex ) {
                    case Sex.Female:
                        return Relationship.DaughterInLaw;
                    case Sex.Male:
                        return Relationship.SonInLaw;
                    default:
                        return Relationship.Unknown;
                }
            case Relationship.MotherInLaw:
                switch ( me.Sex ) {
                    case Sex.Female:
                        return Relationship.DaughterInLaw;
                    case Sex.Male:
                        return Relationship.SonInLaw;
                    default:
                        return Relationship.Unknown;
                }
            case Relationship.SonInLaw:
                switch ( me.Sex ) {
                    case Sex.Female:
                        return Relationship.MotherInLaw;
                    case Sex.Male:
                        return Relationship.FatherInLaw;
                    default:
                        return Relationship.Unknown;
                }
            case Relationship.DaughterInLaw:
                switch ( me.Sex ) {
                    case Sex.Female:
                        return Relationship.MotherInLaw;
                    case Sex.Male:
                        return Relationship.FatherInLaw;
                    default:
                        return Relationship.Unknown;
                }
            case Relationship.BrotherInLaw:
                switch ( me.Sex ) {
                    case Sex.Female:
                        return Relationship.SisterInLaw;
                    case Sex.Male:
                        return Relationship.BrotherInLaw;
                    default:
                        return Relationship.Unknown;
                }
            case Relationship.SisterInLaw:
                switch ( me.Sex ) {
                    case Sex.Female:
                        return Relationship.SisterInLaw;
                    case Sex.Male:
                        return Relationship.BrotherInLaw;
                    default:
                        return Relationship.Unknown;
                }
            case Relationship.Friend:
                return Relationship.Friend;
            default:
                return Relationship.Unknown;
        }



    }



}