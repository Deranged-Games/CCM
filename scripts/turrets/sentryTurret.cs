// Sound datablocks
datablock EffectProfile(SentryTurretSwitchEffect)
{
   effectname = "powered/turret_sentry_activate";
   minDistance = 2.5;
   maxDistance = 5.0;
};

datablock AudioProfile(SentryTurretSwitchSound)
{
   filename    = "fx/powered/turret_sentry_activate.wav";
   description = AudioClose3d;
   preload = true;
   effect = SentryTurretSwitchEffect;
};

// Explosion


// Turret data

datablock SensorData(SentryMotionSensor)
{
   detects = true;
   detectsUsingLOS = true;
   detectsActiveJammed = false;
   detectsPassiveJammed = true;
   detectsCloaked = true;
   detectionPings = false;
   detectRadius = 60;
   detectMinVelocity = 2;
};

datablock TurretData(SentryTurret) : TurretDamageProfile
{
   //className = Turret;
   catagory = "Turrets";
   shapeFile = "turret_sentry.dts";

   //Uses the same stats as an outdoor deployable turret (balancing info for Dave)
   mass = 5.0;

   barrel = SentryTurretBarrel;

   maxDamage = 1.2;
   destroyedLevel = 1.2;
   disabledLevel = 0.84;
   explosion      = ShapeExplosion;
   expDmgRadius = 5.0;
   expDamage = 0.4;
   expImpulse = 1000.0;
   repairRate = 0;

   thetaMin = 89;
   thetaMax = 175;
   emap = true;
   

   isShielded           = true;
   energyPerDamagePoint = 100;
   maxEnergy = 150;
   rechargeRate = 0.40;

   canControl = true;
   cmdCategory = "Tactical";
   cmdIcon = CMDTurretIcon;
   cmdMiniIconName = "commander/MiniIcons/com_turret_grey";
   targetNameTag = 'Sentry';
   targetTypeTag = 'Turret';
   sensorData = SentryMotionSensor;
   sensorRadius = SentryMotionSensor.detectRadius;
   sensorColor = "9 136 255";
   firstPersonOnly = true;
};

datablock TurretImageData(SentryTurretBarrel)
{
   shapeFile = "turret_muzzlepoint.dts";

   projectile = MG42Bullet;
   projectileType = TracerProjectile;
   usesEnergy = true;
   fireEnergy = 1.00;
   minEnergy = 1.00;
   emap = true;

   projectileSpread = 6.5 / 1000.0;

   // Turret parameters
   activationMS      = 300;
   deactivateDelayMS = 500;
   thinkTimeMS       = 200;
   degPerSecTheta    = 520;
   degPerSecPhi      = 960;
   attackRadius      = 60;

   // State transitions
   stateName[0]                     = "Activate";
   stateTimeoutValue[0]             = 0.01;
   stateTransitionOnTimeout[0]      = "Ready";
   stateSound[0]                    = SentryTurretSwitchSound;

   stateName[1]                     = "Ready";
   stateTransitionOnTriggerDown[1]  = "Fire";
   stateTransitionOnNoAmmo[1]       = "NoAmmo";

   stateName[2]                     = "Fire";
   stateTransitionOnTimeout[2]      = "Reload";
   stateTimeoutValue[2]             = 0.05;
   stateFire[2]                     = true;
   stateRecoil[2]                   = LightRecoil;
   stateAllowImageChange[2]         = false;
   stateSequence[2]                 = "Fire";
   stateSound[2]                    = KriegFireSound;
   stateScript[2]                   = "onFire";

   stateName[3]                     = "Reload";
   stateTimeoutValue[3]             = 0.05;
   stateAllowImageChange[3]         = false;
   stateTransitionOnTimeout[3]      = "Ready";
   stateTransitionOnNoAmmo[3]       = "NoAmmo";

   stateName[4]                     = "NoAmmo";
   stateTransitionOnAmmo[4]         = "Reload";
   stateSequence[4]                 = "NoAmmo";
};

