//--------------------------------------------------------------------------
// Plasma Turret
// 
// 
//--------------------------------------------------------------------------

//--------------------------------------------------------------------------
// Sounds
//--------------------------------------------------------------------------
datablock EffectProfile(PBLSwitchEffect)
{
   effectname = "powered/turret_light_activate";
   minDistance = 2.5;
   maxDistance = 5.0;
};

datablock EffectProfile(PBLFireEffect)
{
   effectname = "powered/turret_plasma_fire";
   minDistance = 2.5;
   maxDistance = 5.0;
};

datablock AudioProfile(PBLSwitchSound)
{
   filename    = "fx/powered/turret_light_activate.wav";
   description = AudioClose3d;
   preload = true;
   effect = PBLSwitchEffect;
};

datablock AudioProfile(PBLFireSound)
{
   filename    = "fx/powered/turret_plasma_fire.wav";
   description = AudioDefault3d;
   preload = true;
   effect = PBLFireEffect;
};

datablock AudioProfile(HeavyCGTurretFireSound)
{
   filename    = "fx/vehicles/tank_mortar_fire.wav";
   description = AudioDefault3d;
   preload = true;
   effect = PBLFireEffect;
};

//--------------------------------------------------------------------------
// Explosion
//--------------------------------------------------------------------------

datablock AudioProfile(PlasmaBarrelExpSound)
{
   filename    = "fx/powered/turret_plasma_explode.wav";
   description = "AudioExplosion3d";
   preload = true;
};


datablock TracerProjectileData(minigunbullet)
{
   doDynamicClientHits = true;

   directDamage        = 0.1; // z0dd - ZOD, 9-27-02. Was 0.0825
   directDamageType    = $DamageType::Bullet;
   explosion           = "ChaingunExplosion";
   splash              = ChaingunSplash;

   kickBackStrength  = 2000.0;
   sound 				= ChaingunProjectile;

   dryVelocity       = 3000.0; // z0dd - ZOD, 8-12-02. Was 425.0
   wetVelocity       = 2500.0;
   velInheritFactor  = 0.0;
   fizzleTimeMS      = 3000;
   lifetimeMS        = 2500;
   explodeOnDeath    = false;
   reflectOnWaterImpactAngle = 0.0;
   explodeOnWaterImpact      = false;
   deflectionOnWaterImpact   = 0.0;
   fizzleUnderwaterMS        = 3000;

   tracerLength    = 10.0;
   tracerAlpha     = false;
   tracerMinPixels = 6;
   tracerColor     = 211.0/255.0 @ " " @ 215.0/255.0 @ " " @ 120.0/255.0 @ " 0.75";
	tracerTex[0]  	 = "special/tracer00";
	tracerTex[1]  	 = "special/tracercross";
	tracerWidth     = 0.06;
   crossSize       = 0.20;
   crossViewAng    = 0.990;
   renderCross     = true;

   decalData[0] = ChaingunDecal1;
   decalData[1] = ChaingunDecal2;
   decalData[2] = ChaingunDecal3;
   decalData[3] = ChaingunDecal4;
   decalData[4] = ChaingunDecal5;
   decalData[5] = ChaingunDecal6;
};

//--------------------------------------------------------------------------
// Plasma Turret Image
//--------------------------------------------------------------------------

datablock TurretImageData(PlasmaBarrelLarge)
{
   shapeFile = "turret_tank_barrelchain.dts";
   item      = PlasmaBarrelPack; // z0dd - ZOD, 4/25/02. Was wrong: PlasmaBarrelLargePack

   projectile = minigunbullet;
   projectileType = TracerProjectile;
   usesEnergy = true;
   fireEnergy = 1;
   minEnergy = 1;
   emap = true;

   projectileSpread = 7.0 / 1000.0;

   // Turret parameters
   activationMS      = 300; // z0dd - ZOD, 3/27/02. Was 1000. Amount of time it takes turret to unfold
   deactivateDelayMS = 1500;
   thinkTimeMS       = 50; // z0dd - ZOD, 3/27/02. Was 200. Amount of time before turret starts to unfold (activate)
   degPerSecTheta    = 90;
   degPerSecPhi      = 135;
   attackRadius      = 450; // z0dd - ZOD, 3/27/02. Was 120


   stateName[0] = "Activate";
   stateSequence[0] = "Activate";
   stateAllowImageChange[0] = false;
   stateTimeoutValue[0] = 0.1;
   stateTransitionOnTimeout[0] = "Ready";
   stateTransitionOnNoAmmo[0] = "NoAmmo";

   stateName[1] = "Ready";
   stateSpinThread[1] = Stop;
   stateTransitionOnTriggerDown[1] = "Spinup";
   stateTransitionOnNoAmmo[1] = "NoAmmo";

   stateName[2] = "NoAmmo";
   stateTransitionOnAmmo[2] = "Ready";
   stateSpinThread[2] = Stop;
   stateTransitionOnTriggerDown[2] = "DryFire";

   stateName[3] = "Spinup";
   stateScript[3] = "onSpinup";
   stateSpinThread[3] = SpinUp;
   stateSound[3] = ChaingunSpinupSound;
   stateTimeoutValue[3] = 0.5;
   stateWaitForTimeout[3] = false;
   stateTransitionOnTimeout[3] = "Fire";
   stateTransitionOnTriggerUp[3] = "Spindown";

   stateName[4] = "Fire";
   stateSequence[4] = "Fire";
   stateTransitionOnTriggerUp[4] = "Spindown";
   stateTransitionOnNoAmmo[4] = "EmptySpindown";
   stateSequenceRandomFlash[4] = true;
   stateSpinThread[4] = FullSpeed;
   stateSound[4] = HeliturretFireSound;
   stateAllowImageChange[4] = false;
   stateScript[4] = "onFire";
   stateFire[4] = true;
   stateEjectShell[4] = true;
   stateTimeoutValue[4] = 0.05;
   stateTransitionOnTimeout[4] = "Fire";

   stateName[5] = "Spindown";
   stateScript[5] = "onSpindown";
   stateSound[5] = ChaingunSpinDownSound;
   stateSpinThread[5] = SpinDown;
   stateTimeoutValue[5] = 0.5;
   stateWaitForTimeout[5] = true;
   stateTransitionOnTimeout[5] = "Ready";
   stateTransitionOnTriggerDown[5] = "Spinup";

   stateName[6] = "EmptySpindown";
   stateScript[6] = "onSpindown";
   stateSound[6] = ChaingunSpinDownSound;
   stateSpinThread[6] = SpinDown;
   stateTimeoutValue[6] = 2.5;
   stateTransitionOnTimeout[6] = "NoAmmo";

   stateName[7] = "DryFire";
   stateSound[7] = ShrikeBlasterDryFireSound;
   stateTimeoutValue[7] = 0.5;
   stateTransitionOnTimeout[7] = "NoAmmo";
};

function PlasmaBarrelLarge::onFire(%data,%obj,%slot){
   Parent::onFire(%data, %obj, %slot);Parent::onFire(%data, %obj, %slot);
}