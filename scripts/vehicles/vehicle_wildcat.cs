//**************************************************************
// WILDCAT GRAV CYCLE
//**************************************************************
//**************************************************************
// SOUNDS
//**************************************************************
datablock EffectProfile(ScoutEngineEffect)
{
   effectname = "vehicles/outrider_engine";
   minDistance = 5.0;
   maxDistance = 10.0;
};

datablock EffectProfile(ScoutThrustEffect)
{
   effectname = "vehicles/outrider_boost";
   minDistance = 5.0;
   maxDistance = 10.0;
};

datablock AudioProfile(ScoutSqueelSound)
{
   filename    = "fx/vehicles/outrider_skid.wav";
   description = ClosestLooping3d;
   preload = true;
};

// Scout
datablock AudioProfile(ScoutEngineSound)
{
   filename    = "fx/vehicles/outrider_engine.wav";
   description = AudioDefaultLooping3d;
   preload = true;
   effect = ScoutEngineEffect;
};

datablock AudioProfile(ScoutThrustSound)
{
   filename    = "fx/vehicles/outrider_boost.wav";
   description = AudioDefaultLooping3d;
   preload = true;
   effect = ScoutThrustEffect;
};

datablock AudioProfile(ScoutturretFireSound)
{
   filename    = "fx/vehicles/tank_chaingun.wav";
   description = AudioDefaultLooping3d;
   preload = true;
   effect = AssaultChaingunFireEffect;
};

//**************************************************************
// LIGHTS
//**************************************************************
datablock RunningLightData(WildcatLight1)
{
   radius = 10.0;
   color = "1.0 1.0 1.0 0.3";
   nodeName = "Headlight_node01";
   direction = "-1.0 1.0 0.0";
   texture = "special/headlight4";
};

datablock RunningLightData(WildcatLight2)
{
   radius = 10.0;
   color = "1.0 1.0 1.0 0.3";
   nodeName = "Headlight_node02";
   direction = "1.0 1.0 0.0";
   texture = "special/headlight4";
};

datablock RunningLightData(WildcatLight3)
{
   type = 2;
   radius = 100.0;
   color = "1.0 1.0 1.0 1.0";
   offset = "0.0 0.0 0.0";
   direction = "0.0 1.0 0.0";
   texture = "special/projheadlight";
};

//**************************************************************
// VEHICLE CHARACTERISTICS
//**************************************************************

datablock HoverVehicleData(ScoutVehicle) : WildcatDamageProfile
{
   spawnOffset = "0 0 1";
   canControl = false;
   floatingGravMag = 3.5;

   catagory = "Vehicles";
   shapeFile = "vehicle_grav_scout.dts";
   computeCRC = true;

   debrisShapeName = "vehicle_grav_scout_debris.dts";
   debris = ShapeDebris;
   renderWhenDestroyed = false;

   drag = 0.0;
   density = 0.9;

   mountPose[0] = scoutRoot;
   cameraMaxDist = 5.0;
   cameraOffset = 0.7;
   cameraLag = 0.5;
   numMountPoints = 1;
   isProtectedMountPoint[0] = false;
   explosion = VehicleExplosion;
	explosionDamage = 0.5;
	explosionRadius = 5.0;

   lightOnly = 1;

   maxDamage = 1.0;
   destroyedLevel = 1.0;

   HDAddMassLevel = 0.8;
   HDMassImage = WCHDMassImage;

   isShielded = false;
   rechargeRate = 0.7;
   energyPerDamagePoint = 75;
   maxEnergy = 150;
   minJetEnergy = 15;
   jetEnergyDrain = 0.1;

   // Rigid Body
   mass = 400;
   bodyFriction = 0.1;
   bodyRestitution = 0.5;
   softImpactSpeed = 20;       // Play SoftImpact Sound
   hardImpactSpeed = 28;      // Play HardImpact Sound

   // Ground Impact Damage (uses DamageType::Ground)
   minImpactSpeed = 29;
   speedDamageScale = 0.010;

   // Object Impact Damage (uses DamageType::Impact)
   collDamageThresholdVel = 23;
   collDamageMultiplier   = 0.030;

   dragForce            = 25 / 45.0;
   vertFactor           = 0.0;
   floatingThrustFactor = 0.35;

   mainThrustForce    = 25;
   reverseThrustForce = 15;
   strafeThrustForce  = 0;
   turboFactor        = 1.35;

   brakingForce = 15;
   brakingActivationSpeed = 3;

   stabLenMin = 2.25;
   stabLenMax = 3.75;
   stabSpringConstant  = 30;
   stabDampingConstant = 16;

   gyroDrag = 16;
   normalForce = 30;
   restorativeForce = 20;
   steeringForce = 35;
   rollForce  = 15;
   pitchForce = 7;

   dustEmitter = VehicleLiftoffDustEmitter;
   triggerDustHeight = 2.5;
   dustHeight = 1.0;
   dustTrailEmitter = TireEmitter;
   dustTrailOffset = "0.0 -1.0 0.5";
   triggerTrailHeight = 3.6;
   dustTrailFreqMod = 15.0;

   jetSound         = ScoutSqueelSound;
   engineSound      = ScoutEngineSound;
   floatSound       = ScoutThrustSound;
   softImpactSound  = GravSoftImpactSound;
   hardImpactSound  = HardImpactSound;
   //wheelImpactSound = WheelImpactSound;

   //
   softSplashSoundVelocity = 10.0;
   mediumSplashSoundVelocity = 20.0;
   hardSplashSoundVelocity = 30.0;
   exitSplashSoundVelocity = 10.0;

   exitingWater      = VehicleExitWaterSoftSound;
   impactWaterEasy   = VehicleImpactWaterSoftSound;
   impactWaterMedium = VehicleImpactWaterSoftSound;
   impactWaterHard   = VehicleImpactWaterMediumSound;
   waterWakeSound    = VehicleWakeSoftSplashSound;

   minMountDist = 4;

   damageEmitter[0] = SmallLightDamageSmoke;
   damageEmitter[1] = SmallHeavyDamageSmoke;
   damageEmitter[2] = DamageBubbles;
   damageEmitterOffset[0] = "0.0 -1.5 0.5 ";
   damageLevelTolerance[0] = 0.3;
   damageLevelTolerance[1] = 0.8;
   numDmgEmitterAreas = 1;

   splashEmitter[0] = VehicleFoamDropletsEmitter;
   splashEmitter[1] = VehicleFoamEmitter;

   shieldImpact = VehicleShieldImpact;

   forwardJetEmitter = WildcatJetEmitter;

   cmdCategory = Tactical;
   cmdIcon = CMDHoverScoutIcon;
   cmdMiniIconName = "commander/MiniIcons/com_landscout_grey";
   targetNameTag = 'WildCat';
   targetTypeTag = 'Grav Cycle';
   sensorData = PlayerSensor;

   checkRadius = 1.7785;
   observeParameters = "1 10 10";

   runningLight[0] = WildcatLight1;
   runningLight[1] = WildcatLight2;
   runningLight[2] = WildcatLight3;

   shieldEffectScale = "0.9375 1.125 0.6";

   replaceTime = 20;
};

//**************************************************************
// WEAPONS
//**************************************************************

datablock TracerProjectileData(Wildcat_CG_Bullet)
{
   doDynamicClientHits = true;

   directDamage        = 0.175;
   directDamageType    = $DamageType::MG;
   explosion           = ChaingunExplosion;
   splash              = ChaingunSplash;

   hasDamageRadius     = false;

   kickBackStrength  = 150;
   sound             = ChaingunProjectile;

   dryVelocity       = 2000.0;
   wetVelocity       = 1500.0;
   velInheritFactor  = 1.0;
   fizzleTimeMS      = 3000;
   lifetimeMS        = 6000;
   explodeOnDeath    = false;
   reflectOnWaterImpactAngle = 0.0;
   explodeOnWaterImpact      = false;
   deflectionOnWaterImpact   = 0.0;
   fizzleUnderwaterMS        = 3000;

   tracerLength    = 20.0;
   tracerAlpha     = false;
   tracerMinPixels = 6;
   tracerColor     = 211.0/255.0 @ " " @ 215.0/255.0 @ " " @ 120.0/255.0 @ " 0.75";
	tracerTex[0]  	 = "special/tracer00";
	tracerTex[1]  	 = "special/tracercross";
	tracerWidth     = 0.15;
   crossSize       = 0.20;
   crossViewAng    = 0.990;
   renderCross     = true;

   decalData[0] = ChaingunDecal1;
   decalData[1] = ChaingunDecal2;
   decalData[2] = ChaingunDecal3;
   decalData[3] = ChaingunDecal4;
   decalData[4] = ChaingunDecal5;
   decalData[5] = ChaingunDecal6;

   hasLight    = true;
   lightRadius = 5.0;
   lightColor  = "0.5 0.5 0.175";
};

datablock ShapeBaseImageData(WildcatChaingunImage)
{
   className = WeaponImage;
   shapeFile = "weapon_chaingun.dts";
   mountPoint = 1;
   offset = "-0.1 -0.3 0.2";

   projectile = Wildcat_CG_Bullet;
   projectileType = TracerProjectile;
   projectileSpread = 1.2 / 1000.0;

   casing              = ShellDebris;
   shellExitDir        = "1.0 0.3 1.0";
   shellExitOffset     = "0.15 -0.56 -0.1";
   shellExitVariance   = 5.0;
   shellVelocity       = 0.0;

   usesEnergy = true;
   useCapacitor = false;
   useMountEnergy = true;
   minEnergy = 1;
   fireEnergy = 0.1;

   activationMS      = 300;
   deactivateDelayMS = 600;
   thinkTimeMS       = 0;
   degPerSecTheta    = 580;
   degPerSecPhi      = 960;
   attackRadius      = 370;

   stateName[0] = "Activate";
   stateSequence[0] = "deploy";
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
   stateSpinThread[3] = SpinUp;
   stateTimeoutValue[3] = 0.2;
   stateWaitForTimeout[3] = false;
   stateTransitionOnTimeout[3] = "Fire";
   stateTransitionOnTriggerUp[3] = "Spindown";

   stateName[4] = "Fire";
   stateSequence[4] = "Fire";
   stateSequenceRandomFlash[4] = true;
   stateSpinThread[4] = FullSpeed;
   stateSound[4] = ChaingunFireSound;
   stateAllowImageChange[4] = false;
   stateScript[4] = "onFire";
   stateFire[4] = true;
   stateEjectShell[4] = true;
   stateTimeoutValue[4] = 0.1;
   stateTransitionOnTimeout[4] = "Fire";
   stateTransitionOnTriggerUp[4] = "Spindown";
   stateTransitionOnNoAmmo[4] = "EmptySpindown";

   stateName[5] = "Spindown";
   stateSpinThread[5] = SpinDown;
   stateTimeoutValue[5] = 0.05;
   stateWaitForTimeout[5] = true;
   stateTransitionOnTimeout[5] = "Ready";
   stateTransitionOnTriggerDown[5] = "Spinup";

   stateName[6] = "EmptySpindown";
   stateSpinThread[6] = SpinDown;
   stateTimeoutValue[6] = 0.5;
   stateTransitionOnTimeout[6] = "NoAmmo";

   stateName[7] = "DryFire";
   stateSound[7] = ShrikeBlasterDryFireSound;
   stateTimeoutValue[7] = 0.5;
   stateTransitionOnTimeout[7] = "NoAmmo";
};

function scoutvehicle::onAdd(%this, %obj)
{
   Parent::onAdd(%this, %obj);
   if (%obj.clientControl)
       serverCmdResetControlObject(%obj.clientControl);

   %obj.schedule(5500, "playThread", $ActivateThread, "activate");
   %obj.mountImage(WildcatChaingunImage,0);
}

function scoutvehicle::deleteAllMounted(%data, %obj){}

function ScoutVehicle::onEnterLiquid(%data, %obj, %coverage, %type)
{
   switch(%type)
   {
      case 0:
         //Water
         %obj.setHeat(0.0);
         %obj.liquidDamage(%data, 0.1, $DamageType::Crash);
      case 1:
         //Ocean Water
         %obj.setHeat(0.0);
         %obj.liquidDamage(%data, 0.1, $DamageType::Crash);
      case 2:
         //River Water
         %obj.setHeat(0.0);
         %obj.liquidDamage(%data, 0.1, $DamageType::Crash);
      case 3:
         //Stagnant Water
         %obj.setHeat(0.0);
         %obj.liquidDamage(%data, 0.1, $DamageType::Crash);
      case 4:
         //Lava
         %obj.liquidDamage(%data, $VehicleDamageLava, $DamageType::Lava);
      case 5:
         //Hot Lava
         %obj.liquidDamage(%data, $VehicleDamageHotLava, $DamageType::Lava);
      case 6:
         //Crusty Lava
         %obj.liquidDamage(%data, $VehicleDamageCrustyLava, $DamageType::Lava);
      case 7:
         //Quick Sand
   }
}
