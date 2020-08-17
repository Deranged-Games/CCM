//**************************************************************
// BANSHEE STRIKE TANK
//**************************************************************

datablock AudioProfile(CannonReloadSound)
{
   filename    = "fx/weapons/grenadelauncher_activate.wav";
   description = AudioClose3d;
   preload = true;
   effect = GrenadeDryFireEffect;
};

//**************************************************************
// VEHICLE CHARACTERISTICS
//**************************************************************

datablock HoverVehicleData(CGTank) : TankDamageProfile
{
   spawnOffset = "0 0 4";

   floatingGravMag = 4.5;

   catagory = "Vehicles";
   shapeFile = "vehicle_grav_tank.dts";
   multipassenger = true;
   computeCRC = true;
   renderWhenDestroyed = false;

   weaponNode = 1;

   debrisShapeName = "vehicle_grav_tank.dts";
   debris = GShapeDebris;

   drag = 0.0;
   density = 0.9;

   mountPose[0] = sitting;
   mountPose[1] = sitting;
   numMountPoints = 2;
   isProtectedMountPoint[0] = true;
   isProtectedMountPoint[1] = true;

   cameraMaxDist = 20;
   cameraOffset = 3;
   cameraLag = 1.5;
   explosion = HGVehicleExplosion;
   explosionDamage = 1.5;
   explosionRadius = 25.0;

   maxSteeringAngle = 0.5;  // 20 deg.

   maxDamage = 3.2;
   destroyedLevel = 3.2;

   HDAddMassLevel = 2.24;
   HDMassImage = TankHDMassImage;

   isShielded = false;
   rechargeRate = 1.0;
   energyPerDamagePoint = 300;
   maxEnergy = 400;
   minJetEnergy = 15;
   jetEnergyDrain = 2.0;

   // Rigid Body
   mass = 1500;
   bodyFriction = 0.8;
   bodyRestitution = 0.5;
   minRollSpeed = 3;
   gyroForce = 400;
   gyroDamping = 0.3;
   stabilizerForce = 20;
   minDrag = 10;
   softImpactSpeed = 15;       // Play SoftImpact Sound
   hardImpactSpeed = 18;      // Play HardImpact Sound

   // Ground Impact Damage (uses DamageType::Ground)
   minImpactSpeed = 35;
   speedDamageScale = 0.017;

   // Object Impact Damage (uses DamageType::Impact)
   collDamageThresholdVel = 20;
   collDamageMultiplier   = 0.035;

   dragForce            = 40 / 20;
   vertFactor           = 0.0;
   floatingThrustFactor = 0.15;

   mainThrustForce    = 75;
   reverseThrustForce = 32;
   strafeThrustForce  = 0;
   turboFactor        = 1.4;

   brakingForce = 25;
   brakingActivationSpeed = 4;

   stabLenMin = 3.25;
   stabLenMax = 4;
   stabSpringConstant  = 50;
   stabDampingConstant = 20;

   gyroDrag = 20;
   normalForce = 20;
   restorativeForce = 10;
   steeringForce = 15;
   rollForce  = 5;
   pitchForce = 3;

   dustEmitter = TankDustEmitter;
   triggerDustHeight = 3.5;
   dustHeight = 1.0;
   dustTrailEmitter = TireEmitter;
   dustTrailOffset = "0.0 -1.0 0.5";
   triggerTrailHeight = 3.6;
   dustTrailFreqMod = 15.0;

   jetSound         = AssaultVehicleThrustSound;
   engineSound      = AssaultVehicleEngineSound;
   floatSound       = AssaultVehicleSkid;
   softImpactSound  = GravSoftImpactSound;
   hardImpactSound  = HardImpactSound;
   wheelImpactSound = WheelImpactSound;

   forwardJetEmitter = TankJetEmitter;

   //
   softSplashSoundVelocity = 5.0;
   mediumSplashSoundVelocity = 10.0;
   hardSplashSoundVelocity = 15.0;
   exitSplashSoundVelocity = 10.0;

   exitingWater      = VehicleExitWaterMediumSound;
   impactWaterEasy   = VehicleImpactWaterSoftSound;
   impactWaterMedium = VehicleImpactWaterMediumSound;
   impactWaterHard   = VehicleImpactWaterMediumSound;
   waterWakeSound    = VehicleWakeMediumSplashSound;

   minMountDist = 7;

   damageEmitter[0] = SmallLightDamageSmoke;
   damageEmitter[1] = MeHGHeavyDamageSmoke;
   damageEmitter[2] = DamageBubbles;
   damageEmitterOffset[0] = "0.0 -1.5 3.5 ";
   damageLevelTolerance[0] = 0.3;
   damageLevelTolerance[1] = 0.7;
   numDmgEmitterAreas = 1;

   splashEmitter[0] = VehicleFoamDropletsEmitter;
   splashEmitter[1] = VehicleFoamEmitter;

   shieldImpact = VehicleShieldImpact;

   cmdCategory = "Tactical";
   cmdIcon = CMDGroundTankIcon;
   cmdMiniIconName = "commander/MiniIcons/com_tank_grey";
   targetNameTag = 'Bannshee';
   targetTypeTag = 'Strike tank';
   sensorData = PlayerSensor;

   checkRadius = 5.5535;
   observeParameters = "1 10 10";
   runningLight[0] = TankLight1;
   runningLight[1] = TankLight2;
   runningLight[2] = TankLight3;
   runningLight[3] = TankLight4;
   shieldEffectScale = "0.9 1.0 0.6";
   showPilotInfo = 1;

   max[PlasmaAmmo] = 4;

   replaceTime = 30;
};

//**************************************************************
// WEAPONS
//**************************************************************

//-------------------------------------
// Artillery CHAINGUN CHARACTERISTICS
//-------------------------------------

datablock TurretImageData(CGTurretParam)
{
   mountPoint = 2;
   shapeFile = "turret_muzzlepoint.dts";

   projectile = BomberCGBullet;
   projectileType = TracerProjectile;

   useCapacitor = true;
   usesEnergy = true;

   // Turret parameters
   activationMS      = 1000;
   deactivateDelayMS = 1500;
   thinkTimeMS       = 200;
   degPerSecTheta    = 500;
   degPerSecPhi      = 500;

   attackRadius      = 750;
};

datablock TurretData(CGTurret) : TurretDamageProfile
{
   className      = VehicleTurret;
   catagory       = "Turrets";
   shapeFile      = "Turret_tank_base.dts";
   preload        = true;
   canControl = false;
   cmdCategory = "Tactical";
   cmdIcon = CMDGroundTankIcon;
   cmdMiniIconName = "commander/MiniIcons/com_tank_grey";
   targetNameTag = 'Banshee';
   targetTypeTag = 'turret';
   mass           = 1.0;

   maxEnergy               = 1;
   maxDamage               = CGTank.maxDamage;
   destroyedLevel          = CGTank.destroyedLevel;
   repairRate              = 0;

   // capacitor
   maxCapacitorEnergy      = 500;
   capacitorRechargeRate   = 10.0;

   thetaMin = 0;
   thetaMax = 100;

   inheritEnergyFromMount = true;
   firstPersonOnly = true;
   useEyePoint = true;

   cameraDefaultFov = 90.0;
   cameraMinFov = 5.0;
   cameraMaxFov = 120.0;

   targetNameTag = 'Banshee';
   targetTypeTag = 'Turret';

   numWeapons              = 2;
   max[PlasmaAmmo] = 4;
};

datablock TurretImageData(CGTurretBarrel)
{
   shapeFile = "turret_tank_barrelchain.dts";
   mountPoint = 1;

   projectile = BomberCGBullet;
   projectileType = TracerProjectile;

   casing              = ShellDebris;
   shellExitDir        = "1.0 0.3 1.0";
   shellExitOffset     = "0.15 -0.56 -0.1";
   shellExitVariance   = 15.0;
   shellVelocity       = 3.0;

   projectileSpread = 1 / 1000.0;

   useCapacitor = true;
   usesEnergy = true;
   useMountEnergy = true;
   fireEnergy = 25;
   minEnergy = 25;

   // Turret parameters
   activationMS                        = 2000;
   deactivateDelayMS                   = 1500;
   thinkTimeMS                         = 200;
   degPerSecTheta                      = 360;
   degPerSecPhi                        = 360;
   attackRadius                        = 75;

   stateName[0] = "Activate";
   stateTransitionOnTimeout[0] = "ActivateReady";
   stateTimeoutValue[0] = 0.5;
   stateSequence[0] = "Activate";
   
   stateName[1] = "ActivateReady";
   stateTransitionOnLoaded[1] = "Ready";
   stateTransitionOnNoAmmo[1] = "NoAmmo";

   stateName[2] = "Ready";
   stateTransitionOnNoAmmo[2] = "NoAmmo";
   stateTransitionOnTriggerDown[2] = "Fire";

   stateName[3] = "Fire";
   stateTransitionOnTimeout[3] = "Reload";
   stateTimeoutValue[3] = 0.2;
   stateFire[3] = true;
   stateAllowImageChange[3] = false;
   stateScript[3] = "onFire";
   stateEmitterTime[3] = 0.2;
   stateSound[3] = SniperFireSound;

   stateName[4] = "Reload";
   stateTransitionOnNoAmmo[4] = "NoAmmo";
   stateTransitionOnTimeout[4] = "Ready";
   stateTimeoutValue[4] = 0.3;
   stateAllowImageChange[4] = false;
   stateSound[4] = CannonReloadSound;

   stateName[5] = "NoAmmo";
   stateTransitionOnAmmo[5] = "Reload";
   stateSequence[5] = "NoAmmo";
   stateTransitionOnTriggerDown[5] = "DryFire";

   stateName[6] = "DryFire";
   stateSound[6] = MissileReloadSound;
   stateTimeoutValue[6] = 1.5;
   stateTransitionOnTimeout[6] = "NoAmmo";
};

datablock SeekerProjectileData(TOWMissile)
{
   casingShapeName     = "weapon_missile_casement.dts";
   projectileShapeName = "weapon_missile_projectile.dts";
   hasDamageRadius     = true;
   indirectDamage      = 2.8;
   damageRadius        = 7.0;
   radiusDamageType    = $DamageType::Missile;
   kickBackStrength    = 500;

   explosion           = "MissileExplosion";
   splash              = MissileSplash;
   velInheritFactor    = 1.0;

   baseEmitter         = MissileSmokeEmitter;
   delayEmitter        = MissileFireEmitter;
   puffEmitter         = MissilePuffEmitter;
   bubbleEmitter       = GrenadeBubbleEmitter;
   bubbleEmitTime      = 1.0;

   exhaustEmitter      = MissileLauncherExhaustEmitter;
   exhaustTimeMs       = 300;
   exhaustNodeName     = "muzzlePoint1";

   lifetimeMS          = 10000; // z0dd - ZOD, 4/14/02. Was 6000
   muzzleVelocity      = 50.0;
   maxVelocity         = 200.0; // z0dd - ZOD, 4/14/02. Was 80.0
   turningSpeed        = 40.0;
   acceleration        = 100.0;

   proximityRadius     = 5;

   terrainAvoidanceSpeed         = 1;
   terrainScanAhead              = 1;
   terrainHeightFail             = 1;
   terrainAvoidanceRadius        = 1;  
   
   flareDistance = 200;
   flareAngle    = 30;
   minSeekHeat   = 0.0;

   sound = MissileProjectileSound;

   hasLight    = true;
   lightRadius = 5.0;
   lightColor  = "0.2 0.05 0";

   useFlechette = true;
   flechetteDelayMs = 750;
   casingDeb = FlechetteDebris;

   explodeOnWaterImpact = true;
};

datablock TurretImageData(TOWImage)
{
   className = WeaponImage;
   shapeFile = "turret_mortar_large.dts";
   projectile = TOWMissile;
   projectileType = SeekerProjectile;

   mountPoint = 0;
   offset = "0.93 -0.35 0.4"; // L/R - F/B - T/B
   rotation = "0 0 1 0";

   usesEnergy = true;
   useMountEnergy = true;
   fireEnergy = 100.00;
   minEnergy = 100.00;
   useCapacitor = true;

   stateName[0] = "Activate";
   stateTransitionOnTimeout[0] = "ActivateReady";
   stateTimeoutValue[0] = 0.5;
   stateSequence[0] = "Activate";
   
   stateName[1] = "ActivateReady";
   stateTransitionOnLoaded[1] = "Ready";
   stateTransitionOnNoAmmo[1] = "NoAmmo";

   stateName[2] = "Ready";
   stateTransitionOnNoAmmo[2] = "NoAmmo";
   stateTransitionOnTriggerDown[2] = "Fire";

   stateName[3] = "Fire";
   stateTransitionOnTimeout[3] = "Reload";
   stateTimeoutValue[3] = 8;
   stateFire[3] = true;
   stateAllowImageChange[3] = false;
   stateScript[3] = "onFire";
   stateEmitterTime[3] = 0.2;
   stateSound[3] = MILFireSound;

   stateName[4] = "Reload";
   stateTransitionOnNoAmmo[4] = "NoAmmo";
   stateTransitionOnTimeout[4] = "Ready";
   stateTimeoutValue[4] = 1;
   stateAllowImageChange[4] = false;
   stateSound[4] = MissileReloadSound;

   stateName[5] = "NoAmmo";
   stateTransitionOnAmmo[5] = "Reload";
   stateSequence[5] = "NoAmmo";
   stateTransitionOnTriggerDown[5] = "DryFire";

   stateName[6] = "DryFire";
   stateSound[6] = ShrikeBlasterDryFireSound;
   stateTimeoutValue[6] = 1.5;
   stateTransitionOnTimeout[6] = "NoAmmo";
};

datablock ShapeBaseImageData(TOWDummy) 
{ 
   mountPoint = 0;
   className = WeaponImage;
   ammo = MG42Ammo;
   shapeFile = "turret_mortar_large.dts"; 
   rotation = "0 0 1 180";
   offset = "0.93 -1 0.4"; // L/R - F/B - T/B
}; 

datablock GrenadeProjectileData(Tank60mmMortar)
{
   projectileShapeName = "grenade_projectile.dts";
   emitterDelay        = -1;
   directDamage        = 0.0;
   hasDamageRadius     = true;
   indirectDamage      = 1.1;
   damageRadius        = 30.0;
   radiusDamageType    = $DamageType::MortarTurret;
   kickBackStrength    = 2500;
   bubbleEmitTime      = 1.0;

   sound               = GrenadeProjectileSound;
   explosion           = "GrenadeExplosion";
   underwaterExplosion = "UnderwaterGrenadeExplosion";
   velInheritFactor    = 0.0;
   splash              = GrenadeSplash;

   baseEmitter         = TankArtillerySmokeEmitter;
   bubbleEmitter       = GrenadeBubbleEmitter;

   grenadeElasticity = 0.30;
   grenadeFriction   = 0.2;
   armingDelayMS     = 100;
   muzzleVelocity    = 80.0;
   gravityMod        = 1.0;
};

datablock TurretImageData(TankMortarImage)
{
   shapeFile = "stackable2m.dts";
   offset = "0 0 -0.5";
   mountPoint = 0;

   projectile = Tank60mmMortar;
   projectileType = GrenadeProjectile;

   ammo   = PlasmaAmmo;
   usesEnergy = false;

   // Turret parameters
   activationMS                        = 4000;
   deactivateDelayMS                   = 1500;
   thinkTimeMS                         = 200;
   degPerSecTheta                      = 360;
   degPerSecPhi                        = 360;
   attackRadius                        = 75;

   // State transitions
   stateName[0]                        = "Activate";
   stateTransitionOnNotLoaded[0]       = "NoAmmo";
   stateTransitionOnNoAmmo[0]          = "Active";

   stateName[1]                        = "Active";
   stateTransitionOnNotLoaded[1]       = "NoAmmo";

   stateName[2]                        = "Reload";
   stateSequence[2]                    = "Reload";
   stateTimeoutValue[2]                = 2;
   stateAllowImageChange[2]            = false;
   stateTransitionOnTimeout[2]         = "Active";
   stateSound[2]                       = MissileReloadSound;
   stateWaitForTimeout[2]              = true;

   stateName[15]                        = "NoAmmo";
   stateSequence[15]                    = "NoAmmo";
   stateTransitionOnAmmo[15]            = "Reload";
};

datablock TargetProjectileData(GunshipTlProj)
{
   directDamage        	= 0.0;
   hasDamageRadius     	= false;
   indirectDamage      	= 0.0;
   damageRadius        	= 0.0;
   velInheritFactor    	= 1.0;

   maxRifleRange       	= 1500;
   beamColor           	= "0.0 0.0 0.0";
								
   startBeamWidth			= 0; //0.02
   pulseBeamWidth 	   = 0; //0.025
   beamFlareAngle 	   = 3.0;
   minFlareSize        	= 0.0;
   maxFlareSize        	= 0.0;
   pulseSpeed          	= 6.0;
   pulseLength         	= 0.150;

   textureName[0]      	= "special/nonlingradient";
   textureName[1]      	= "special/flare";
   textureName[2]      	= "special/pulse";
   textureName[3]      	= "special/expFlare";
   beacon               = true;
};

datablock TurretImageData(TOWTL)
{
   className = WeaponImage;
   shapeFile = "turret_muzzlepoint.dts";
   mountPoint = 1;
   offset = "0 1.0 1.0";

   projectile = GunshipTlProj;
   projectileType = TargetProjectile;
   deleteLastProjectile = false;

   usesEnergy = true;
   useMountEnergy = true;
   useCapacitor = true;
   minEnergy = 1.0;
   fireEnergy = 1.0;

   stateName[0]                     = "Activate";
   stateSequence[0]                 = "Activate";
   stateTimeoutValue[0]			= 0.1;
   stateTransitionOnTimeout[0]       = "Ready";

   stateName[1]				= "Ready";
   stateTransitionOnTriggerDown[1]	= "Fire";

   stateName[2]                     = "Fire";
   stateEnergyDrain[2]              = 0;
   stateFire[2]                     = true;
   stateScript[2]                   = "onFire";
   stateTransitionOnTriggerUp[2]	= "Deconstruct";

   stateName[3]				= "Deconstruct";
   stateScript[3]				= "onDecon";
   stateTimeoutValue[3]			= 0.1;
   stateTransitionOnTimeout[3]	= "Ready";
};

//-----------------------------------
//*************Functions*************
//-----------------------------------

function CGTank::onAdd(%this, %obj)
{
   Parent::onAdd(%this, %obj);
   %obj.setInventory(plasmaAmmo, 4);

   %turret = TurretData::create(CGTurret);
   %turret.selectedWeapon = 1;
   MissionCleanup.add(%turret);
   %turret.team = %obj.teamBought;
   %turret.setSelfPowered();
   %obj.mountObject(%turret, 10);
   %turret.mountImage(CGTurretParam, 0);
   %turret.mountImage(CGTurretBarrel, 2);
   %turret.mountImage(TOWImage, 3);
   %turret.mountImage(TOWTL,4);
   %turret.mountImage(TankMortarImage, 5);
   %turret.mountImage(TOWDummy, 6);
   %turret.setInventory(plasmaAmmo, 4);
   %turret.setCapacitorRechargeRate( %turret.getDataBlock().capacitorRechargeRate );
   %obj.turretObject = %turret;
   %turret.setAutoFire(false);
   %obj.schedule(6000, "playThread", $ActivateThread, "activate");
   setTargetSensorGroup(%turret.getTarget(), %turret.team);
   setTargetNeverVisMask(%turret.getTarget(), 0xffffffff);
}

function CGTank::deleteAllMounted(%data, %obj)
{
   %turret = %obj.getMountNodeObject(10);
   if (!%turret)
      return;

   if (%client = %turret.getControllingClient())
   {
      %client.player.setControlObject(%client.player);
      %client.player.mountImage(%client.player.lastWeapon, $WeaponSlot);
      %client.player.mountVehicle = false;
   }
   %turret.schedule(2000, delete);
}

function CGTank::playerMounted(%data, %obj, %player, %node)
{
   if (%obj.clientControl)
       serverCmdResetControlObject(%obj.clientControl);
   if (%node == 0) {
	   commandToClient(%player.client, 'setHudMode', 'Pilot', "Assault", %node);
   }
   else if (%node == 1)
   {
      %turret = %obj.getMountNodeObject(10);
      %player.vehicleTurret = %turret;
      %player.setTransform("0 0 0 0 0 1 0");
      %player.lastWeapon = %player.getMountedImage($WeaponSlot);
      %player.unmountImage($WeaponSlot);
      if (!%player.client.isAIControlled())
      {
         %player.setControlObject(%turret);
         %player.client.setObjectActiveImage(%turret, 2);
      }
      %turret.turreteer = %player;

      $aWeaponActive = 0;
      commandToClient(%player.client,'SetWeaponryVehicleKeys', true);
      %obj.getMountNodeObject(10).selectedWeapon = 1;
	   commandToClient(%player.client, 'setHudMode', 'Pilot', "Assault", %node);
   }

   if ( %player.client.observeCount > 0 )
      resetObserveFollow( %player.client, false );
   %passString = buildPassengerString(%obj);
	for(%i = 0; %i < %data.numMountPoints; %i++)
		if (%obj.getMountNodeObject(%i) > 0)
		   commandToClient(%obj.getMountNodeObject(%i).client, 'checkPassengers', %passString);

   bottomPrint(%player.client, "40MM bofer cannon, Laser guided TOW, Mortars on grenade key.", 5, 2 );
}


function CGTurret::onDamage(%data, %obj)
{
   %newDamageVal = %obj.getDamageLevel();
   if(%obj.lastDamageVal !$= "")
      if(isObject(%obj.getObjectMount()) && %obj.lastDamageVal > %newDamageVal)   
         %obj.getObjectMount().setDamageLevel(%newDamageVal);
   %obj.lastDamageVal = %newDamageVal;
}

function CGTurret::damageObject(%this, %targetObject, %sourceObject, %position, %amount, %damageType ,%vec, %client, %projectile)
{                                           
   //If vehicle turret is hit then apply damage to the vehicle
   %vehicle = %targetObject.getObjectMount();
   if(%vehicle)
      %vehicle.getDataBlock().damageObject(%vehicle, %sourceObject, %position, %amount, %damageType, %vec, %client, %projectile);
}

function CGTank::onTrigger(%data, %obj, %trigger, %state)
{
   if (%trigger ==4){
      switch (%state){
         case 0:
            %obj.fireWeapon = false;
         case 1:
            if (%obj.inv[PlasmaAmmo] > 0){
               %frd = %obj.getForwardVector();
               %vec = vectorNormalize(vectorAdd(%frd,"0 0 1"));
               for(%i = 0; %i < 4;%i++){
                  %x = (getRandom() - 0.5) * 2 * 3.1415926 * 0.3;
                  %y = (getRandom() - 0.5) * 2 * 3.1415926 * 0.3;
                  %z = (getRandom() - 0.5) * 2 * 3.1415926 * 0.05;
                  %mat = MatrixCreateFromEuler(%x @ " " @ %y @ " " @ %z);
                  %vector = MatrixMulVector(%mat, %vec);
		  %obj.decInventory(PlasmaAmmo, 1);
      	          %p = new GrenadeProjectile() {
                     dataBlock        = SmokeGrenadeProj;
                     initialDirection = %vector;
                     initialPosition  = getBoxCenter(%obj.getWorldBox());
                     sourceObject     = %obj;
                     sourceSlot       = 0;
      	          };
               }
               serverPlay3D(GrenadeThrowSound, getBoxCenter(%obj.getWorldBox()));  
               %obj.schedule(30000, "setInventory", PlasmaAmmo, 4);
            }
      }
   }
}

function CGTurret::onTrigger(%data, %obj, %trigger, %state)
{
   switch (%trigger)
   {
      case 0:
         %obj.fireTrigger = %state;
         if(%obj.selectedWeapon == 1){
            %obj.setImageTrigger(3, false);
            if(%state)
               %obj.setImageTrigger(2, true);
            else
               %obj.setImageTrigger(2, false);
         }
         else{
            %obj.setImageTrigger(2, false);
            if(%state)
               %obj.setImageTrigger(3, true);
            else
               %obj.setImageTrigger(3, false);
         }
      case 2:
         if(%state)
            %obj.getDataBlock().playerDismount(%obj);
      case 4:
         if(%state){
            if(%obj.inv[PlasmaAmmo] > 0){
               for(%i = 0; %i < 4; %i++){    
                  schedule((%i * 300), 0, "tankupwardmortar",%obj,5);
               }
               if(!(%obj.cantlaunch)){
                  %obj.schedule(5000, "setInventory", PlasmaAmmo, 4);
                  %obj.cantlaunch = 1;
                  schedule(4500, 0, "resetammoability",%obj);
               }
            }
         }
      case 3:
         if(%state){
            if(isObject(%obj.TL))
               %obj.setImageTrigger(4, false);
            else
               %obj.setImageTrigger(4, true);
	 }
   }
}

function resetammoability(%obj){
   %obj.cantlaunch = 0;
}

function tankupwardmortar(%obj,%slot){
   if(%obj.inv[PlasmaAmmo] <= 0)
      return;
   %pos = %obj.getMuzzlePoint(%slot);
   %tpos = vectorScale(%obj.getMuzzleVector(0),650);
   %tpos = vectorAdd(%tpos,%pos);
   %mask = $TypeMasks::TerrainObjectType | $TypeMasks::InteriorObjectType | $TypeMasks::StaticShapeObjectType | $TypeMasks::ForceFieldObjectType;
   %searchresult = containerRayCast(%pos, %tpos, %mask);
   if(!%searchresult)
      return;
   %tpos = posFromRaycast(%searchresult);
   %dist = vectorDist(%pos,%tpos);
   if(%dist < 650){
      %up = "0 0" SPC %dist;
      %vec = vectorNormalize(vectorSub(%tpos,%pos));
      %var = (%dist / 80);
      %var2 = (%dist / 144);
      %arc = vectorScale(%vec,(%var * %var * (3.5 + %var2)));
      %dir = vectorNormalize(vectorAdd(%up,%arc));

      %x = (getRandom() - 0.5) * 2 * 3.1415926 * 0.01;
      %y = (getRandom() - 0.5) * 2 * 3.1415926 * 0.01;
      %z = (getRandom() - 0.5) * 2 * 3.1415926 * 0.01;
      %mat = MatrixCreateFromEuler(%x @ " " @ %y @ " " @ %z);
      %vector = MatrixMulVector(%mat, %dir);

      %p = new GrenadeProjectile(){
         dataBlock        = Tank60mmMortar;
         initialDirection = %vector;
         initialPosition  = %pos;
         sourceObject     = %obj;
         damageFactor	 = 1;
         sourceSlot       = %slot;
      };
      %obj.decInventory(PlasmaAmmo, 1);

      serverPlay3d("GrenadeFireSound",%obj.getWorldBoxCenter()); 
   }
}

function CGTurret::playerDismount(%data, %obj)
{
   %obj.fireTrigger = 0;
   %obj.setImageTrigger(2, false);
   %obj.setImageTrigger(3, false);
   %obj.setImageTrigger(4, false);
   %client = %obj.getControllingClient();
   %client.player.mountImage(%client.player.lastWeapon, $WeaponSlot);
   %client.player.mountVehicle = false;
   setTargetSensorGroup(%obj.getTarget(), 0);
   setTargetNeverVisMask(%obj.getTarget(), 0xffffffff);
}

function TOWImage::onFire(%data,%obj,%slot) 
{ 
   %p = Parent::onFire(%data, %obj, %slot); 
   MissileSet.add(%p); 
   if(isObject(%obj.TL))
	%p.setObjectTarget(%obj.TL.beacon);
   %p.HATlockon = schedule(500, 0, "HammerATlockon", %p);
}

function TOWTL::onFire(%data,%obj,%slot)
{
   %p = Parent::onFire(%data, %obj, %slot);
   %p.setTarget(%obj.team);
   %obj.TL = %p;
   %p.beacon = new BeaconObject() {
      dataBlock = "SubBeacon";
      beaconType = "vehicle";
      position = %p.getTargetPoint();
   };
   %p.turret = %obj;
   %p.beaconupdate = schedule(100, 0, "GunshipBeaconLoop", %p);
}

function TOWTL::onDecon(%data,%obj,%slot){
   %obj.TL.beacon.delete();
   %obj.TL.delete();
}

function CGTank::onEnterLiquid(%data, %obj, %coverage, %type)
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
