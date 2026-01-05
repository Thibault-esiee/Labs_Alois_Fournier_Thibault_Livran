using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class GoblinNameGenerator
{
    static string[] NameDatabase1 = { "Ba", "Bax", "Dan",
"Fi", "Fix", "Fiz", }; //... and more
    static string[] NameDatabase2 = { "b", "ba", "be",
"bi", "d", "da", "de","di", }; // ... and more
    static string[] NameDatabase3 = { "ald", "ard", "art",
"az", "azy", "bit","bles", "eek", "eka", "et",
"ex", "ez", "gaz", "geez", "get", "giez",
"iek", }; // ... and more
    static string[] SurnameDatabase1 = { "Bolt", "Boom",
"Bot", "Cog", "Copper","Damp", "Dead", "Far", "Fast",
"Fiz", "Fizz", "Fizzle", "Fuse", "Gear",
"Giga", "Gold", "Grapple" }; // ... and more
    static string[] SurnameDatabase2 = { "basher", "blade",
"blast", "blaster","bolt", "bomb", "boot", "bottom",
"bub", "button", "buttons", "cash",
"clamp", }; // ... and more
    private static string RandomInArray(string[] array)
    {
        return array[Random.Range(0, array.Length)];
    }
    public static string RandomGoblinName()
    {
        return RandomInArray(NameDatabase1) +
        RandomInArray(NameDatabase2) +
        RandomInArray(NameDatabase3) + " " +
        RandomInArray(SurnameDatabase1) +
        RandomInArray(SurnameDatabase2);
    }
}
