using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathZoneAsteroidSpecial : DeathZoneAsteroid
{
    // Polymorphism: handleDestroy() from DeathZoneAsteroid.cs base functionality is extended
    public override void handleDestroy() {
        Debug.Log("SPECIAL COLLISION DETECTED!");
        base.handleDestroy();
    }

}
