//--------------------------------------------------------------------------
// Large Mortar Turret
// 
// 
//--------------------------------------------------------------------------

//--------------------------------------------------------------------------
// Sounds
//--------------------------------------
datablock EffectProfile(MBLSwitchEffect)
{
   effectname = "powered/turret_heavy_activate";
   minDistance = 2.5;
   maxDistance = 5.0;
};

datablock EffectProfile(MBLFireEffect)
{
   effectname = "powered/turret_mortar_fire";
   minDistance = 2.5;
   maxDistance = 5.0;
};

datablock AudioProfile(MBLSwitchSound)
{
   filename    = "fx/powered/turret_heavy_activate.wav";
   description = AudioClose3d;
   preload = true;
   effect = MBLSwitchEffect;
};

datablock AudioProfile(MBLFireSound)
{
   filename    = "fx/powered/turret_mortar_fire.wav";
   description = AudioDefault3d;
   preload = true;
   effect = MBLFireEffect;
};

//--------------------------------------------------------------------------
// Projectile
//--------------------------------------

datablock AudioProfile(MortarTurretProjectileSound)
{
	filename		= "fx/weapons/mortar_projectile.wav";
	description = ProjectileLooping3d;
    preload = true;
};

datablock ParticleData(CLSubExplosionSmoke)
{
   dragCoeffiecient     = 1.0;
   gravityCoefficient   = -0.5;   // rises slowly
   inheritedVelFactor   = 0.025;

   lifetimeMS           = 1250;
   lifetimeVarianceMS   = 0;

   textureName          = "particleTest";

   useInvAlpha =  true;
   spinRandomMin = -200.0;
   spinRandomMax =  200.0;

   textureName = "special/Smoke/smoke_001";

   colors[0]     = "0.5 0.5 0.5 1.0";
   colors[1]     = "0.5 0.5 0.5 0.5";
   colors[2]     = "0.6 0.6 0.6 0.0";
   sizes[0]      = 1.0;
   sizes[1]      = 2.0;
   sizes[2]      = 3.0;
   times[0]      = 0.0;
   times[1]      = 0.5;
   times[2]      = 1.0;

};

datablock ParticleEmitterData(CLSubSmokeEmitter)
{
   ejectionPeriodMS = 2;
   periodVarianceMS = 0;

   ejectionVelocity = 6.0;
   velocityVariance = 6.0;

   thetaMin         = 80.0;
   thetaMax         = 90.0;

   lifetimeMS       = 750;

   particles = "CLSubExplosionSmoke";
};

datablock ParticleData(CLSubSparks)
{
   dragCoefficient      = 1;
   gravityCoefficient   = 0.0;
   inheritedVelFactor   = 0.2;
   constantAcceleration = 0.0;
   lifetimeMS           = 500;
   lifetimeVarianceMS   = 100;
   textureName          = "special/bigspark";
   colors[0]     = "0.56 0.36 0.26 1.0";
   colors[1]     = "0.56 0.36 0.26 1.0";
   colors[2]     = "1.0 0.36 0.26 0.0";
   sizes[0]      = 1.0;
   sizes[1]      = 1.0;
   sizes[2]      = 1.5;
   times[0]      = 0.0;
   times[1]      = 0.5;
   times[2]      = 1.0;

};

datablock ParticleEmitterData(CLSubSparksEmitter)
{
   ejectionPeriodMS = 1;
   periodVarianceMS = 0;

   ejectionVelocity = 15;
   velocityVariance = 10.0;

   ejectionOffset   = 0.0;

   thetaMin         = 0;
   thetaMax         = 90;

   lifetimeMS       = 500;

   particles = "CLSubSparks";
};

//----------------------------------------------------
//  Explosion
//----------------------------------------------------
datablock ExplosionData(ClusterSubExplosion)
{
   soundProfile   = GrenadeExplosionSound;

   faceViewer           = true;
   explosionScale = "1.0 1.0 1.0";

   emitter[0] = CLSubSmokeEmitter;
   emitter[1] = CLSubSparksEmitter;

   shakeCamera = true;
   camShakeFreq = "10.0 6.0 9.0";
   camShakeAmp = "10.0 10.0 10.0";
   camShakeDuration = 1.0;
   camShakeRadius = 10.0;
};

//--------------------------------------------------------------------------
// Projectile
//--------------------------------------

datablock GrenadeProjectileData(MK19round)
{
   projectileShapeName = "grenade_projectile.dts";
   emitterDelay        = -1;
   directDamage        = 0.0;
   hasDamageRadius     = true;
   indirectDamage      = 1.4;
   damageRadius        = 10.0;
   radiusDamageType    = $DamageType::Grenade;
   kickBackStrength    = 1000;

   explosion           = "ClusterSubExplosion";
   velInheritFactor    = 0.0;
   splash              = ChaingunSplash;

   baseEmitter         = TankArtillerySmokeEmitter;
   bubbleEmitter       = GrenadeBubbleEmitter;

   grenadeElasticity = 0.0;
   grenadeFriction   = 0.3;
   armingDelayMS     = -1;
   gravityMod        = 1.2;
   muzzleVelocity    = 95.0;
   drag              = 0.1;

   sound			 = MortarTurretProjectileSound;

   hasLight    = true;
   lightRadius = 3;
   lightColor  = "0.05 0.2 0.05";
};

//--------------------------------------------------------------------------
//-------------------------------------- Fusion Turret Image
//
datablock TurretImageData(MortarBarrelLarge)
{
   shapeFile = "turret_mortar_large.dts";
   // ---------------------------------------------
   // z0dd - ZOD, 5/8/02. Incorrect parameter value
   //item      = MortarBarrelLargePack;
   item = MortarBarrelPack;

   projectile = MK19round;
   projectileType = GrenadeProjectile;
   usesEnergy = true;
   fireEnergy = 15;
   minEnergy = 16;
   emap = true;

	// don't let a mortar turret blow itself up
	dontFireInsideDamageRadius = true;
	damageRadius = 20;

   projectileSpread = 3.0 / 1000.0;

   // Turret parameters
   activationMS      = 250;
   deactivateDelayMS = 500;
   thinkTimeMS       = 100;
   degPerSecTheta    = 90;
   degPerSecPhi      = 135;
   attackRadius      = 450;

   // State transitions
   stateName[0]                  = "Activate";
   stateTransitionOnNotLoaded[0] = "Dead";
   stateTransitionOnLoaded[0]    = "ActivateReady";

   stateName[1]                  = "ActivateReady";
   stateSequence[1]              = "Activate";
   stateSound[1]                 = MBLSwitchSound;
   stateTimeoutValue[1]          = 1;
   stateTransitionOnTimeout[1]   = "Ready";
   stateTransitionOnNotLoaded[1] = "Deactivate";
   stateTransitionOnNoAmmo[1]    = "NoAmmo";

   stateName[2]                    = "Ready";
   stateTransitionOnNotLoaded[2]   = "Deactivate";
   stateTransitionOnTriggerDown[2] = "Fire";
   stateTransitionOnNoAmmo[2]      = "NoAmmo";

   stateName[3]                = "Fire";
   stateTransitionOnTimeout[3] = "Reload";
   stateTimeoutValue[3]        = 0.1;
   stateFire[3]                = true;
   stateRecoil[3]              = LightRecoil;
   stateAllowImageChange[3]    = false;
   stateSequence[3]            = "Fire";
   stateSound[3]               = MBLFireSound;
   stateScript[3]              = "onFire";

   stateName[4]                  = "Reload";
   stateTimeoutValue[4]          = 0.2;
   stateAllowImageChange[4]      = false;
   stateSequence[4]              = "Reload";
   stateTransitionOnTimeout[4]   = "Ready";
   stateTransitionOnNotLoaded[4] = "Deactivate";
   stateTransitionOnNoAmmo[4]    = "NoAmmo";

   stateName[5]                = "Deactivate";
   stateSequence[5]            = "Activate";
   stateDirection[5]           = false;
   stateTimeoutValue[5]        = 1;
   stateTransitionOnLoaded[5]  = "ActivateReady";
   stateTransitionOnTimeout[5] = "Dead";

   stateName[6]               = "Dead";
   stateTransitionOnLoaded[6] = "ActivateReady";

   stateName[7]             = "NoAmmo";
   stateTransitionOnAmmo[7] = "Reload";
   stateSequence[7]         = "NoAmmo";
};


