//**************************************************************
// JERICHO FORWARD BASE (Mobile Point Base)
//**************************************************************

//**************************************************************
// VEHICLE CHARACTERISTICS
//**************************************************************

datablock WheeledVehicleData(FFTransport) : TankDamageProfile
{
   spawnOffset = "0 0 1.0";
   renderWhenDestroyed = false;
   canControl = false;
   catagory = "Vehicles";
   shapeFile = "vehicle_land_mpbase.dts";
   multipassenger = true;
   computeCRC = true;

   debrisShapeName = "vehicle_land_mpbase.dts";
   debris = GShapeDebris;

   drag = 0.0;
   density = 20.0;

   mountPose[0] = sitting;
//   mountPose[1] = sitting;
   numMountPoints = 6;
   isProtectedMountPoint[0] = true;
   isProtectedMountPoint[1] = true;
   isProtectedMountPoint[2] = true;
   isProtectedMountPoint[3] = true;
   isProtectedMountPoint[4] = true;
   isProtectedMountPoint[5] = true;

   cameraMaxDist = 20;
   cameraOffset = 6;
   cameraLag = 1.5;
   explosion = HGVehicleExplosion;
   explosionDamage = 1.0;
   explosionRadius = 20.0;

   maxSteeringAngle = 0.3;  // 20 deg.

   // Rigid Body
   mass = 2000;
   bodyFriction = 0.8;
   bodyRestitution = 0.5;
   minRollSpeed = 3;
   gyroForce = 400;
   gyroDamping = 0.3;
   stabilizerForce = 10;
   minDrag = 10;
   softImpactSpeed = 15;       // Play SoftImpact Sound
   hardImpactSpeed = 25;      // Play HardImpact Sound

   // Ground Impact Damage (uses DamageType::Ground)
   minImpactSpeed = 30;
   speedDamageScale = 0.060;

   // Object Impact Damage (uses DamageType::Impact)
   collDamageThresholdVel = 30;
   collDamageMultiplier   = 0.070;

   // Engine
   engineTorque = 13.0 * 745;
   breakTorque = 9.0 * 745;
   maxWheelSpeed = 30;

   // Springs
   springForce = 10000;
   springDamping = 1000;
   antiSwayForce = 7500;
   staticLoadScale = 2;

   // Tires
   tireRadius = 2.5;
   tireFriction = 50.0;
   tireRestitution = 0.5;
   tireLateralForce = 3000;
   tireLateralDamping = 400;
   tireLateralRelaxation = 1;
   tireLongitudinalForce = 10000;
   tireLongitudinalDamping = 400;
   tireLongitudinalRelaxation = 1;
   tireEmitter = TireEmitter;

   //
   maxDamage = 5.0;
   destroyedLevel = 5.0;

   HDAddMassLevel = 3.5;
   HDMassImage = APCHDMassImage;

   isShielded = false;
   energyPerDamagePoint = 0;
   maxEnergy = 600;
   jetForce = 2800;
   minJetEnergy = 60;
   jetEnergyDrain = 0.1;
   rechargeRate = 1.0;

   jetSound = MPBThrustSound;
   engineSound = MPBEngineSound;
   squeelSound = AssaultVehicleSkid;
   softImpactSound = GravSoftImpactSound;
   hardImpactSound = HardImpactSound;
   //wheelImpactSound = WheelImpactSound;

   //
   softSplashSoundVelocity = 5.0;
   mediumSplashSoundVelocity = 8.0;
   hardSplashSoundVelocity = 12.0;
   exitSplashSoundVelocity = 8.0;

   exitingWater      = VehicleExitWaterSoftSound;
   impactWaterEasy   = VehicleImpactWaterSoftSound;
   impactWaterMedium = VehicleImpactWaterMediumSound;
   impactWaterHard   = VehicleImpactWaterHardSound;
   waterWakeSound    = VehicleWakeMediumSplashSound;

   minMountDist = 10;

   damageEmitter[0] = LightDamageSmoke;
   damageEmitter[1] = MeHGHeavyDamageSmoke;
   damageEmitter[2] = DamageBubbles;
   damageEmitterOffset[0] = "3.0 0.5 0.0 ";
   damageEmitterOffset[1] = "-3.0 0.5 0.0 ";
   damageLevelTolerance[0] = 0.3;
   damageLevelTolerance[1] = 0.7;
   numDmgEmitterAreas = 2;

   splashEmitter[0] = VehicleFoamDropletsEmitter;
   splashEmitter[1] = VehicleFoamEmitter;

   shieldImpact = VehicleShieldImpact;

   cmdCategory = "Tactical";
   cmdIcon = CMDGroundMPBIcon;
   cmdMiniIconName = "commander/MiniIcons/com_mpb_grey";
   targetNameTag = 'Rover';
   targetTypeTag = 'APC';
   sensorData = PlayerSensor;

   checkRadius = 7.5225;

   observeParameters = "1 12 12";

   runningLight[0] = MPBLight1;
   runningLight[1] = MPBLight2;

   shieldEffectScale = "0.85 1.2 0.7";

   replaceTime = 20;
};

datablock TurretData(APCTurret) : TankDamageProfile
{
   className      = VehicleTurret;
   catagory       = "Turrets";
   shapeFile      = "turret_base_large.dts";
   preload        = true;
   canControl = false;
   cmdCategory = "Tactical";
   cmdIcon = CMDGroundTankIcon;
   cmdMiniIconName = "commander/MiniIcons/com_tank_grey";
   targetNameTag = 'APC CG';
   targetTypeTag = 'Turret';
   mass           = 1.0;  // Not really relevant

   maxEnergy               = 1000;
   maxDamage               = FFTransport.maxDamage;
   destroyedLevel          = FFTransport.destroyedLevel;
   repairRate              = 0;

   // capacitor
   maxCapacitorEnergy      = 100;
   capacitorRechargeRate   = 1.5;

   thetaMin = 30;
   thetaMax = 100;

   inheritEnergyFromMount = true;
   firstPersonOnly = true;
   useEyePoint = true;
   numWeapons = 1;

   cameraDefaultFov = 90.0;
   cameraMinFov = 5.0;
   cameraMaxFov = 120.0;

   targetNameTag = 'APC CG';
   targetTypeTag = 'Turret';
};

datablock TurretImageData(APCTurretBarrel)
{
   shapeFile = "turret_mortar_large.dts";
   mountPoint = 0;

   projectile = MK19round;
   projectileType = GrenadeProjectile;

   casing              = ShellDebris;
   shellExitDir        = "1.0 0.3 1.0";
   shellExitOffset     = "0.15 -0.56 -0.1";
   shellExitVariance   = 1.0;
   shellVelocity       = 3.0;

   projectileSpread = 3.5 / 1000.0;

   useCapacitor = true;
   usesEnergy = true;
   useMountEnergy = true;
   fireEnergy = 14.0;
   minEnergy = 15.0;

   // Turret parameters
   activationMS      = 500;
   deactivateDelayMS = 550;
   thinkTimeMS       = 200;
   degPerSecTheta    = 500;
   degPerSecPhi      = 500;
   attackRadius      = 225;

   // State transitions
   stateName[0]                        = "Activate";
   stateTransitionOnNotLoaded[0]       = "Dead";
   stateTransitionOnLoaded[0]          = "ActivateReady";
   stateSound[0]                       = AssaultTurretActivateSound;

   stateName[1]                        = "ActivateReady";
   stateSequence[1]                    = "Activate";
   stateSound[1]                       = AssaultTurretActivateSound;
   stateTimeoutValue[1]                = 1;
   stateTransitionOnTimeout[1]         = "Ready";
   stateTransitionOnNotLoaded[1]       = "Deactivate";

   stateName[2]                        = "Ready";
   stateTransitionOnNotLoaded[2]       = "Deactivate";
   stateTransitionOnTriggerDown[2]     = "CheckWet";
   stateTransitionOnNoAmmo[2]          = "NoAmmo";

   stateName[3]                        = "Fire";
   stateSequence[3]                    = "Fire";
   stateSequenceRandomFlash[3]         = true;
   stateFire[3]                        = true;
   stateAllowImageChange[3]            = false;
   stateSound[3]                       = MBLFireSound;
   stateScript[3]                      = "onFire";
   stateTimeoutValue[3]                = 0.1;
   stateTransitionOnTimeout[3]         = "Fire";
   stateTransitionOnTriggerUp[3]       = "Reload";
   stateTransitionOnNoAmmo[3]          = "noAmmo";

   stateName[4]                        = "Reload";
   stateSequence[4]                    = "Reload";
   stateTimeoutValue[4]                = 0.1;
   stateAllowImageChange[4]            = false;
   stateTransitionOnTimeout[4]         = "Ready";
   stateTransitionOnNoAmmo[4]          = "NoAmmo";
   stateWaitForTimeout[4]              = true;

   stateName[5]                        = "Deactivate";
   stateSequence[5]                    = "Activate";
   stateDirection[5]                   = false;
   stateTimeoutValue[5]                = 3;
   stateTransitionOnTimeout[5]         = "ActivateReady";

   stateName[6]                        = "Dead";
   stateTransitionOnLoaded[6]          = "ActivateReady";
   stateTransitionOnTriggerDown[6]     = "DryFire";

   stateName[7]                        = "DryFire";
   stateSound[7]                       = AssaultChaingunDryFireSound;
   stateTimeoutValue[7]                = 1.0;
   stateTransitionOnTimeout[7]         = "NoAmmo";

   stateName[8]                        = "NoAmmo";
   stateTransitionOnAmmo[8]            = "Reload";
   stateSequence[8]                    = "NoAmmo";
   stateTransitionOnTriggerDown[8]     = "DryFire";

   stateName[9]       			   = "WetFire";
   stateSound[9]      			   = ChaingunDryFireSound;
   stateTimeoutValue[9]        	   = 1.0;
   stateTransitionOnTimeout[9] 	   = "Ready";
   
   stateName[10]               	   = "CheckWet";
   stateTransitionOnWet[10]    	   = "WetFire";
   stateTransitionOnNotWet[10] 	   = "Fire"; 
};

datablock TurretImageData(APCTurretParam)
{
   mountPoint = 0;
   shapeFile = "turret_muzzlepoint.dts";
   offset = "0.0 0.0 3.0";

   projectile = MK19round;
   projectileType = GrenadeProjectile;

   useCapacitor = false;
   usesEnergy = true;

   // Turret parameters
   activationMS      = 500;
   deactivateDelayMS = 550;
   thinkTimeMS       = 200;
   degPerSecTheta    = 500;
   degPerSecPhi      = 500;

   attackRadius      = 225;
};

function APCTurret::onDamage(%data, %obj)
{
   %newDamageVal = %obj.getDamageLevel();
   if(%obj.lastDamageVal !$= "")
      if(isObject(%obj.getObjectMount()) && %obj.lastDamageVal > %newDamageVal)   
         %obj.getObjectMount().setDamageLevel(%newDamageVal);
   %obj.lastDamageVal = %newDamageVal;
}

function APCTurret::damageObject(%this, %targetObject, %sourceObject, %position, %amount, %damageType ,%vec, %client, %projectile)
{
   //If vehicle turret is hit then apply damage to the vehicle
   %vehicle = %targetObject.getObjectMount();
   if(%vehicle)
      %vehicle.getDataBlock().damageObject(%vehicle, %sourceObject, %position, %amount, %damageType, %vec, %client, %projectile);
}

function APCTurret::onTrigger(%data, %obj, %trigger, %state)
{
   switch (%trigger)
   {
      case 0:
         %obj.fireTrigger = %state;
            if(%state)
               %obj.setImageTrigger(2, true);
            else
               %obj.setImageTrigger(2, false);
      case 2:
         if(%state)
         {
            %obj.getDataBlock().playerDismount(%obj);
         }
   }
}

function APCTurret::playerDismount(%data, %obj)
{
   //Passenger Exiting
   %obj.fireTrigger = 0;
   %obj.setImageTrigger(2, false);
   %client = %obj.getControllingClient();
   %client.player.mountImage(%client.player.lastWeapon, $WeaponSlot);
   %client.player.mountVehicle = false;
   setTargetSensorGroup(%obj.getTarget(), 0);
   setTargetNeverVisMask(%obj.getTarget(), 0xffffffff);
}

function APCTurretBarrel::onMount(%this, %obj, %slot) { }
function APCTurretBarrel::onUnmount(%this, %obj, %slot) { }