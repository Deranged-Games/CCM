//--------------------------------------
// Mortar
//--------------------------------------

datablock EffectProfile(nukemeExplosionEffect)
{
   effectname = "explosions/explosion.xpl03";
   minDistance = 400;
   maxDistance = 500;
};

datablock AudioProfile(nukemeExplosionSound)
{
   filename    = "fx/weapons/mortar_explode.wav";
   description = AudioBIGExplosion3d;
   preload = true;
   effect = nukemeExplosionEffect;
};

//---------------------------------------------------------------------------
// Nuke Shockwave
//---------------------------------------------------------------------------

datablock ShockwaveData(nukemeShockwave)
{
   width = 20.0;
   numSegments = 32;
   numVertSegments = 6;
   velocity = 1000;
   acceleration = 20.0;
   lifetimeMS = 1000;
   height = 30.0;
   verticalCurve = 0.5;
   is2D = false;

   texture[0] = "special/shockwave4";
   texture[1] = "special/gradient";
   texWrap = 6.0;

   times[0] = 0.0;
   times[1] = 0.5;
   times[2] = 1.0;

   colors[0] = "0.4 1.0 0.4 0.50";
   colors[1] = "0.4 1.0 0.4 0.25";
   colors[2] = "0.4 1.0 0.4 0.0";

   mapToTerrain = true;
   orientToNormal = false;
   renderBottom = false;
};


//--------------------------------------------------------------------------
// Mortar Explosion Particle effects
//--------------------------------------

datablock ParticleData(NukemeExplosionSmoke)
{
   dragCoeffiecient     = 0.4;
   gravityCoefficient   = 0.1;   // rises slowly
   inheritedVelFactor   = 0.025;

   lifetimeMS           = 5000;
   lifetimeVarianceMS   = 250;

   textureName          = "particleTest";

   useInvAlpha =  true;
   spinRandomMin = -100.0;
   spinRandomMax =  100.0;

   textureName = "special/Smoke/bigSmoke";

   colors[0]     = "0.4 0.4 0.4 1.0";
   colors[1]     = "0.4 0.4 0.4 0.5";
   colors[2]     = "0.3 0.3 0.3 0.75";
   colors[3]     = "0.1 0.1 0.1 0.0";
   sizes[0]      = 20.0;
   sizes[1]      = 24.0;
   sizes[2]      = 40.0;
   sizes[3]      = 48.0;
   times[0]      = 0.0;
   times[1]      = 0.333;
   times[2]      = 0.666;
   times[3]      = 1.0;

};

datablock ParticleData(NukemeExplosionSmokeRisers)
{
   dragCoeffiecient     = 0.0;
   gravityCoefficient   = 0.75;   // rises
   inheritedVelFactor   = 0.025;

   lifetimeMS           = 10000;
   lifetimeVarianceMS   = 250;

   textureName          = "particleTest";

   useInvAlpha =  true;
   spinRandomMin = -100.0;
   spinRandomMax =  100.0;

   textureName = "special/Smoke/bigSmoke";

   colors[0]     = "0.4 0.4 0.4 1.0";
   colors[1]     = "0.4 0.4 0.4 0.5";
   colors[2]     = "0.3 0.3 0.3 0.75";
   colors[3]     = "0.1 0.1 0.1 0.0";
   sizes[0]      = 20.0;
   sizes[1]      = 24.0;
   sizes[2]      = 40.0;
   sizes[3]      = 48.0;
   times[0]      = 0.0;
   times[1]      = 0.333;
   times[2]      = 0.666;
   times[3]      = 1.0;
};

datablock ParticleData(NukemeExplosionSmokeFallers)
{
   dragCoeffiecient     = 0.4;
   gravityCoefficient   = -4.0;   // falls
   inheritedVelFactor   = 0.025;

   lifetimeMS           = 20000;
   lifetimeVarianceMS   = 250;

   textureName          = "particleTest";

   useInvAlpha =  true;
   spinRandomMin = -100.0;
   spinRandomMax =  100.0;

   textureName = "special/Smoke/bigSmoke";

   colors[0]     = "0.4 0.4 0.4 1.0";
   colors[1]     = "0.4 0.4 0.4 0.5";
   colors[2]     = "0.3 0.3 0.3 0.75";
   colors[3]     = "0.1 0.1 0.1 0.0";
   sizes[0]      = 20.0;
   sizes[1]      = 24.0;
   sizes[2]      = 40.0;
   sizes[3]      = 48.0;
   times[0]      = 0.0;
   times[1]      = 0.333;
   times[2]      = 0.666;
   times[3]      = 1.0;

};

datablock ParticleEmitterData(NukemeExplosionSmokeEmitter)
{
   ejectionPeriodMS = 1;
   periodVarianceMS = 0;

   ejectionOffset = 250.0;

   ejectionVelocity = 0.0;
   velocityVariance = 0.0;

   thetaMin         = 89.0;
   thetaMax         = 90.0;

   lifetimeMS       = 1000;

   particles = "NukemeExplosionSmoke";

};

datablock ParticleEmitterData(NukemeExplosionSmokeEmitter2)
{
   ejectionPeriodMS = 5;
   periodVarianceMS = 0;

   ejectionOffset = 15.0;

   ejectionVelocity = 200.0;
   velocityVariance = 10.0;

   thetaMin         = 0.0;
   thetaMax         = 90.0;

   lifetimeMS       = 2000;

   particles = "NukemeExplosionSmoke";

};

datablock ParticleEmitterData(NukemeExplosionSmokeEmitter3)
{
   ejectionPeriodMS = 1;
   periodVarianceMS = 0;

   ejectionOffset = 10.0;

   ejectionVelocity = 40.0;
   velocityVariance = 10.0;

   thetaMin         = 60.0;
   thetaMax         = 90.0;

   lifetimeMS       = 750;

   particles = "NukemeExplosionSmokeRisers";

};

datablock ParticleEmitterData(NukemeExplosionSmokeEmitter4)
{
   ejectionPeriodMS = 1;
   periodVarianceMS = 0;

   ejectionOffset = 0.0;

   ejectionVelocity = 40.0;
   velocityVariance = 10.0;

   thetaMin         = 0.0;
   thetaMax         = 60.0;

   lifetimeMS       = 750;

   particles = "NukemeExplosionSmokeRisers";

};

datablock ParticleEmitterData(NukemeExplosionSmokeEmitter5)
{
   ejectionPeriodMS = 25;
   periodVarianceMS = 0;

   ejectionOffset = 12.0;


   ejectionVelocity = 125.0;
   velocityVariance = 10.0;

   thetaMin         = 0.0;
   thetaMax         = 45.0;

   lifetimeMS       = 5000;

   particles = "NukemeExplosionSmokeFallers";

};

datablock ParticleEmitterData(NukemeExplosionSmokeEmitter6)
{
   ejectionPeriodMS = 25;
   periodVarianceMS = 0;

   ejectionOffset = 5.0;


   ejectionVelocity = 150.0;
   velocityVariance = 1.0;

   thetaMin         = 45.0;
   thetaMax         = 90.0;

   lifetimeMS       = 5000;

   particles = "NukemeExplosionSmokeFallers";

};
            
//---------------------------------------------------------------------------
// Explosion
//---------------------------------------------------------------------------

datablock ExplosionData(nukemeSubExplosion1)
{
   explosionShape = "mortar_explosion.dts";
   faceViewer           = true;

   delayMS = 500;

   offset = 0.0;

   playSpeed = 0.5;

   sizes[0] = "500.0 500.0 500.0";
   sizes[1] = "500.0 500.0 500.0";
   times[0] = 0.0;
   times[1] = 1.0;
};             

datablock ExplosionData(nukemeSubExplosion2)
{
   explosionShape = "mortar_explosion.dts";
   faceViewer           = true;

   delayMS = 250;

   offset = 0.0;

   playSpeed = 0.25;

   sizes[0] = "200.0 200.0 200.0";
   sizes[1] = "200.0 200.0 200.0";
   times[0] = 0.0;
   times[1] = 1.0;
};

datablock ExplosionData(nukemeSubExplosion3)
{
   explosionShape = "effect_plasma_explosion.dts";
   faceViewer           = true;
   delayMS = 0;
   offset = 0.0;
   playSpeed = 0.15;

   sizes[0] = "50.0 50.0 50.0";
   sizes[1] = "50.0 50.0 50.0";
   times[0] = 0.0;
   times[1] = 1.0;
};

datablock ExplosionData(nukemeExplosion)
{
   soundProfile   = nukemeExplosionSound;

   shockwave = nukemeShockwave;
   shockwaveOnTerrain = false;

   subExplosion[0] = nukemeSubExplosion1;
   subExplosion[1] = nukemeSubExplosion2;
   subExplosion[2] = nukemeSubExplosion3;

   emitter[0] = NukemeExplosionSmokeEmitter;
   emitter[1] = NukemeExplosionSmokeEmitter2;
   emitter[2] = NukemeExplosionSmokeEmitter3;
   emitter[3] = NukemeExplosionSmokeEmitter4;
   emitter[4] = NukemeExplosionSmokeEmitter5;
   emitter[5] = NukemeExplosionSmokeEmitter6;

   shakeCamera = true;
   camShakeFreq = "24.0 27.0 21.0";
   camShakeAmp = "100.0 100.0 100.0";
   camShakeDuration = 4.0;
   camShakeRadius = 500.0;
};

//--------------------------------------------------------------------------
// Projectile
//--------------------------------------
datablock GrenadeProjectileData(nukemeball)
{
   projectileShapeName = "mortar_projectile.dts";
   emitterDelay        = -1;
   directDamage        = 0.0;
   hasDamageRadius     = true;
   indirectDamage      = 21.0;
   damageRadius        = 250.0; // z0dd - ZOD, 8/13/02. Was 20.0
   radiusDamageType    = $DamageType::nuke;
   kickBackStrength    = 5000;

   explosion           = "nukemeExplosion";
   underwaterExplosion = "nukemeExplosion";
   velInheritFactor    = 0.5;
   splash              = MortarSplash;
   depthTolerance      = 10.0; // depth at which it uses underwater explosion
   
   baseEmitter         = MortarSmokeEmitter;
   bubbleEmitter       = MortarBubbleEmitter;
   
   grenadeElasticity = 0.15;
   grenadeFriction   = 0.4;
   armingDelayMS     = 6000; // z0dd - ZOD, 4/14/02. Was 2000

   gravityMod        = 1.3;  // z0dd - ZOD, 5/18/02. Make mortar projectile heavier, less floaty
   muzzleVelocity    = 70.0; // z0dd - ZOD, 8/13/02. More velocity to compensate for higher gravity. Was 63.7
   drag              = 0.1;
   sound	     = MortarProjectileSound;

   hasLight    = true;
   lightRadius = 4;
   lightColor  = "0.05 0.2 0.05";

   hasLightUnderwaterColor = true;
   underWaterLightColor = "0.05 0.075 0.2";
};

//--------------------------------------------------------------------------
// Ammo
//--------------------------------------

datablock ItemData(nukemeAmmo)
{
   className = Ammo;
   catagory = "Ammo";
   shapeFile = "ammo_mortar.dts";
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
	pickUpName = "nukes";

   computeCRC = true;

};

//--------------------------------------------------------------------------
// Weapon
//--------------------------------------
datablock ItemData(nukeMe)
{
   className = Weapon;
   catagory = "Spawn Items";
   shapeFile = "weapon_mortar.dts";
   image = nukemeImage;
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
	pickUpName = "a nuke launcher";

   computeCRC = true;
   emap = true;
};

datablock ShapeBaseImageData(nukemeImage)
{
   className = WeaponImage;
   shapeFile = "weapon_mortar.dts";
   item = nukeme;
   ammo = nukemeAmmo;
   offset = "0 0 0";
   emap = true;

   projectile = nukemeball;
   projectileType = GrenadeProjectile;

   stateName[0] = "Activate";
   stateTransitionOnTimeout[0] = "ActivateReady";
   stateTimeoutValue[0] = 0.5;
   stateSequence[0] = "Activate";
   stateSound[0] = MortarSwitchSound;

   stateName[1] = "ActivateReady";
   stateTransitionOnLoaded[1] = "Ready";
   stateTransitionOnNoAmmo[1] = "NoAmmo";

   stateName[2] = "Ready";
   stateTransitionOnNoAmmo[2] = "NoAmmo";
   stateTransitionOnTriggerDown[2] = "Fire";
   //stateSound[2] = MortarIdleSound;

   stateName[3] = "Fire";
   stateSequence[3] = "Recoil";
   stateTransitionOnTimeout[3] = "Reload";
   stateTimeoutValue[3] = 0.8;
   stateFire[3] = true;
   stateRecoil[3] = LightRecoil;
   stateAllowImageChange[3] = false;
   stateScript[3] = "onFire";
   stateSound[3] = MortarFireSound;

   stateName[4] = "Reload";
   stateTransitionOnNoAmmo[4] = "NoAmmo";
   stateTransitionOnTimeout[4] = "Ready";
   stateTimeoutValue[4] = 5.0;
   stateAllowImageChange[4] = false;
   stateSequence[4] = "Reload";
   stateSound[4] = MortarReloadSound;

   stateName[5] = "NoAmmo";
   stateTransitionOnAmmo[5] = "Reload";
   stateSequence[5] = "NoAmmo";
   stateTransitionOnTriggerDown[5] = "DryFire";

   stateName[6]       = "DryFire";
   stateSound[6]      = MortarDryFireSound;
   stateTimeoutValue[6]        = 1.5;
   stateTransitionOnTimeout[6] = "NoAmmo";
};
