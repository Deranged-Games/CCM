// DisplayName = Zombie survival

//--- GAME RULES BEGIN ---
//The zombie horde is coming.
//You have 15 minutes to prep your defenses
//survive longer and get a higher point bonus
//Do not go out of bounds or you will be hunted
//--- GAME RULES END ---

//No need to load these unless the games been played.
   $zombie::zombiepts = 2;
   $zombie::ravagerpts = 4;
   $zombie::lordpts = 10;
   $zombie::rapierpts = 5;
   $zombie::demonpts = 5;
   $zombie::motherpts = 25;

   $survival::Hordecoming = 0;
   $survival::timetostart = 15;
   $survival::timesinceHorde = 0;
   $survival::survpts = 10;
   $survival::zombiedamageamount = 0.15;

   //each group is explained in this manner
   //1. wait time before starting, in seconds, after last group is finished
   //2. zombie type
   //3. number that spawn before this group is gone
   //4. time, in seconds, between each one
   $survival::numzombiegroups = 28;
   $survival::zombieGroup[1] = "15 1 40 1";
   $survival::zombieGroup[2] = "140 1 20 1";
   $survival::zombieGroup[3] = "60 2 5 5";
   $survival::zombieGroup[4] = "30 1 20 1";
   $survival::zombieGroup[5] = "60 4 10 3";
   $survival::zombieGroup[6] = "60 2 5 5";
   $survival::zombieGroup[7] = "60 1 30 1";
   $survival::zombieGroup[8] = "45 4 15 1";
   $survival::zombieGroup[9] = "1 3 2 3";
   $survival::zombieGroup[10] = "1 2 8 1";
   $survival::zombieGroup[11] = "1 5 8 1";
   $survival::zombieGroup[12] = "60 4 20 2";
   $survival::zombieGroup[13] = "1 2 12 1";
   $survival::zombieGroup[14] = "1 3 5 4";
   $survival::zombieGroup[15] = "1 5 5 1";
   $survival::zombieGroup[16] = "80 4 20 1";
   $survival::zombieGroup[17] = "1 2 15 1";
   $survival::zombieGroup[18] = "1 5 15 1";
   $survival::zombieGroup[19] = "1 3 8 1 ";
   $survival::zombieGroup[20] = "1 6 1 1";
   $survival::zombieGroup[21] = "120 4 30 1";
   $survival::zombieGroup[22] = "1 3 10 1";
   $survival::zombieGroup[23] = "1 6 2 1";
   $survival::zombieGroup[24] = "1 2 10 0.1";
   $survival::zombieGroup[25] = "1 5 10 0.1";
   $survival::zombieGroup[26] = "120 4 50 1";
   $survival::zombieGroup[27] = "1 3 12 1";
   $survival::zombieGroup[28] = "1 6 3 1";

   
   //after the groups are done the game goes to automatic spawn loops which randomly pick zombie types
   //1. Wait time before starting loop, in seconds, after last spawn
   //2. difficulty of spawn group (1-10)
   //3. how many extra zombies (over max) it should spawn.
   $survival::numzombieloops = 2;
   $survival::zombieloop[1] = "120 10 0";
   $survival::zombieloop[2] = "120 10 15";

   $survival::currentzombiegroup = 0;
   $survival::currentzombieingroup = 0;
   $survival::currentzombieloop = 0;

package SurvivalGame {

function Armor::onCollision(%this,%obj,%col,%forceVehicleNode){
   Parent::onCollision(%this,%obj,%col,%forceVehicleNode);

   %dataBlock = %col.getDataBlock();
   %className = %dataBlock.className;
   if(%className $= "wall" || %className $= "wwall" || %className $= "spine" || %className $= "spine2" || %className $= "mspine" || %className $= "floor" || %className $= "forcefield"){
      %cantear = 1;
   }
   if(%obj.iszombie == 1 && %cantear == 1 )
      %dataBlock.damageobject(%col, 0, %col.getposition(), $survival::zombiedamageamount, $DamageType::Zombie);
}

};

//----------------------------------------------------------------------------
//-------------------------------gameplay stuff-------------------------------
//----------------------------------------------------------------------------
function SurvivalGame::missionLoadDone(%game)
{
   //default version sets up teams - must be called first...
   DefaultGame::missionLoadDone(%game);

   //start running a check for players, we cant start until someones here.
   %game.checkplayers();
}

function SurvivalGame::onClientKilled( %game, %clVictim, %clKiller, %damageType, %implement, %damageLocation, %victim ){
  // Parent handles notifications and lots of other stuff
  Parent::onClientKilled( %game, %clVictim, %clKiller, %damageType, %implement, %damageLocation, %victim );

   if(%clvictim !$= "" && $survival::Hordecoming){
      %actcount = 0;
      %clvictim.isalive = 0;
      %game.calcdeathscore(%clvictim);
      %count = ClientGroup.getCount();
      for(%i = 0; %i < %count; %i++){
         %cl = ClientGroup.getObject(%i);
         if(%cl.isalive == 1)
            %actcount++;
      }
      if(%actcount <= 0){
         %game.gameover();
         cycleMissions();
      }
   }
}

function SurvivalGame::checkplayers(%game){
   %count = ClientGroup.getCount();
   if(%count >= 1){
	%game.startgame();
   }
   else
	%game.schedule(1000,"checkplayers",%game);
}

function SurvivalGame::StartGame(%game){
   if($Host::Purebuild != 1)
      %game.votePurebuild(1);
   if($teamDamage)
      %game.voteTeamDamage(1);
   if($Host::Vehicles == 1)
      %game.VoteVehicles(1);
   if($Host::InvincibleDeployables != 1)
      %game.VoteInvincibleDeployables(1);

   %game.schedule(3000, "timerloop");

   $OldTeamDeployableMax[TurretBasePack] = $TeamDeployableMax[TurretBasePack];
   $TeamDeployableMax[TurretBasePack] = 0;

   $OldTeamDeployableMax[TurretLaserDeployable] = $TeamDeployableMax[TurretLaserDeployable];
   $TeamDeployableMax[TurretLaserDeployable] = 0;

   $OldTeamDeployableMax[DiscTurretDeployable] = $TeamDeployableMax[DiscTurretDeployable];
   $TeamDeployableMax[DiscTurretDeployable] = 0;

   $OldTeamDeployableMax[TurretMissileRackDeployable] = $TeamDeployableMax[TurretMissileRackDeployable];
   $TeamDeployableMax[TurretMissileRackDeployable] = 0;

   $OldTeamDeployableMax[TurretIndoorDeployable] = $TeamDeployableMax[TurretIndoorDeployable];
   $TeamDeployableMax[TurretIndoorDeployable]   = 0;

   $OldTeamDeployableMax[TurretOutdoorDeployable]  = $TeamDeployableMax[TurretOutdoorDeployable];
   $TeamDeployableMax[TurretOutdoorDeployable]  = 0;

   $OldTeamDeployableMin[TurretIndoorDeployable] = $TeamDeployableMin[TurretIndoorDeployable];
   $TeamDeployableMin[TurretIndoorDeployable] = 0;

   $OldTeamDeployableMin[TurretOutdoorDeployable] = $TeamDeployableMin[TurretOutdoorDeployable];
   $TeamDeployableMin[TurretOutdoorDeployable] = 0;

   $OldTeamDeployableMin[TurretBasePack] = $TeamDeployableMin[TurretBasePack];
   $TeamDeployableMin[TurretBasePack] = 0;

   $OldTeamDeployableMin[TurretLaserDeployable] = $TeamDeployableMin[TurretLaserDeployable];
   $TeamDeployableMin[TurretLaserDeployable] = 0;

   $OldTeamDeployableMin[DiscTurretDeployable] = $TeamDeployableMin[DiscTurretDeployable];
   $TeamDeployableMin[DiscTurretDeployable] = 0;

   $OldTeamDeployableMin[TurretMissileRackDeployable] = $TeamDeployableMin[TurretMissileRackDeployable];
   $TeamDeployableMin[TurretMissileRackDeployable] = 0;

   $OldTeamDeployableMax[FloorDeployable] = $TeamDeployableMax[FloorDeployable];
   $TeamDeployableMax[FloorDeployable] = 500;

   $OldTeamDeployableMax[wWallDeployable] = $TeamDeployableMax[wWallDeployable];
   $TeamDeployableMax[wWallDeployable] = 500;

   $OldTeamDeployableMax[mSpineDeployable] = $TeamDeployableMax[mSpineDeployable];
   $TeamDeployableMax[mSpineDeployable] = 500;

   $OldTeamDeployableMax[ForceFieldDeployable] = $TeamDeployableMax[ForceFieldDeployable];
   $TeamDeployableMax[ForceFieldDeployable] = 500;

   $OldTeamDeployableMax[GravityFieldDeployable] = $TeamDeployableMax[GravityFieldDeployable];
   $TeamDeployableMax[GravityFieldDeployable] = 200;
}

function SurvivalGame::timerloop(%game){
   if($survival::timetostart != 0){
      for(%i = 0; %i < ClientGroup.getCount(); %i++) {
         %client = ClientGroup.getObject(%i);
         messageClient(%client, 'MsgClient', '\c0There is now %1 minutes until the horde arrives.', $survival::timetostart);
      }
      $survival::timetostart--;
   } else if($survival::timetostart == 0 && $survival::Hordecoming != 1){
      %game.StartHorde();
      for(%i = 0; %i < ClientGroup.getCount(); %i++) {
         %client = ClientGroup.getObject(%i);
         messageClient(%client, 'MsgClient', '\c0The Horde is coming respawns are disabled.');
      }
   } else {
      $survival::timesinceHorde++;
      for(%i = 0; %i < ClientGroup.getCount(); %i++) {
         %client = ClientGroup.getObject(%i);
         if(%client.isalive == 1)
            messageClient(%client, 'MsgClient', '\c0You Have survived %1 Minutes of this horde.', $survival::timesinceHorde);
      }
   }
   $survival::timerloop = %game.schedule(60000,"timerloop");
}

function SurvivalGame::StartHorde(%game){
   if($Host::Purebuild == 1)
      %game.votePurebuild(1);
   if($teamDamage)
      %game.voteTeamDamage(1);
   if($Host::Vehicles != 1)
      %game.VoteVehicles(1);
   if($Host::InvincibleDeployables == 1)
      %game.VoteInvincibleDeployables(1);

   for(%i = 0; %i < ClientGroup.getCount(); %i++){
      %client = ClientGroup.getObject(%i);
      if(isObject(%client.player))
         %client.isalive = 1;
   } 

   $survival::Hordecoming = 1;
   $survival::currentzombiegroup = 1;
   $zombie::detectdist = 10000;
   $numspawnedzombie = 0;
   %game.schedule(1000, "HordeSpawnLoop");
}

function SurvivalGame::HordeSpawnLoop(%game){
   if(!$survival::Hordecoming)
      return;
   if($survival::currentzombiegroup <= $survival::numzombiegroups){
      %group = $survival::zombieGroup[$survival::currentzombiegroup];
      %pause = getword(%group,0);
      %type = getWord(%group,1);
      %number = getWord(%group,2);
      %delay = getWord(%group,3);
      if($survival::currentzombieingroup == 0){
         $survival::currentzombieingroup++;
         %time = %pause;
      } else if($survival::currentzombieingroup > %number){
         $survival::currentzombieingroup = 0;
         $survival::currentzombiegroup++;
         %time = %delay;
      } else {
         %pos = survivalfindspawnpoint();
         startAzombie(%pos,%type);
         $survival::currentzombieingroup++;
         %time = %delay;
      }
   } else if ($survival::currentzombieloop <= $survival::numzombieloops){
      if($survival::currentzombieloop != 0){
         %group = $survival::zombieloop[$survival::currentzombieloop];
         %lvl = getWord(%group,1);
         %extra = getWord(%group,2);
         %pos = vectorAdd(survivalfindspawnpoint(),"0 0 500");
         zombiespawnloop(%pos,50,%lvl);
         $numspawnedzombies = $numspawnedzombies - %extra;
      }
      
      $survival::currentzombieloop++;
      %time = getWord($survival::zombieloop[$survival::currentzombieloop],0);
   } else
      return;
   %game.schedule((%time * 1000),"HordeSpawnLoop");
}

function Survivalfindspawnpoint(){
   %area = missionarea.area;
   %w = getWord(%area,0);
   %s = getWord(%area,1);
   %e = %w + getWord(%area,2);
   %n = %s + getWord(%area,3);
   %side = getRandom(1,4);
   if(%side == 1){
      %pos = %w SPC getRandom(%s,%n) SPC 300;
      %search = containerRayCast(%Pos, vectorAdd(%Pos,"0 0 -1000"), $TypeMasks::StaticShapeObjectType | $TypeMasks::InteriorObjectType | $TypeMasks::ForceFieldObjectType | $TypeMasks::TerrainObjectType);
      %Pos = getWord(%search,1)@" "@getWord(%search,2)@" "@getWord(%search,3);
   }
   else if(%side == 2){
      %pos = getRandom(%w,%e) SPC %s SPC 300;
      %search = containerRayCast(%Pos, vectorAdd(%Pos,"0 0 -1000"), $TypeMasks::StaticShapeObjectType | $TypeMasks::InteriorObjectType | $TypeMasks::ForceFieldObjectType | $TypeMasks::TerrainObjectType);
      %Pos = getWord(%search,1)@" "@getWord(%search,2)@" "@getWord(%search,3);
   }
   else if(%side == 3){
      %pos = %e SPC getRandom(%s,%n) SPC 300;
      %search = containerRayCast(%Pos, vectorAdd(%Pos,"0 0 -1000"), $TypeMasks::StaticShapeObjectType | $TypeMasks::InteriorObjectType | $TypeMasks::ForceFieldObjectType | $TypeMasks::TerrainObjectType);
      %Pos = getWord(%search,1)@" "@getWord(%search,2)@" "@getWord(%search,3);
   }
   else{
      %pos = getRandom(%w,%e) SPC %n SPC 300;
      %search = containerRayCast(%Pos, vectorAdd(%Pos,"0 0 -1000"), $TypeMasks::StaticShapeObjectType | $TypeMasks::InteriorObjectType | $TypeMasks::ForceFieldObjectType | $TypeMasks::TerrainObjectType);
      %Pos = getWord(%search,1)@" "@getWord(%search,2)@" "@getWord(%search,3);
   }
   return %pos;
}

function SurvivalGame::gameOver(%game){
   $survival::currentzombiegroup = 0;
   $survival::currentzombieingroup = 0;
   $survival::currentzombieloop = 0;
   $survival::Hordecoming = 0;
   $survival::timetostart = 15;
   $survival::timesinceHorde = 0;
   cancel($survival::timerloop);

   //call the default
   DefaultGame::gameOver(%game);

   messageAll('MsgGameOver', "Match has ended.~wvoice/announcer/ann.gameover.wav" );

   messageAll('MsgClearObjHud', "");
   for(%i = 0; %i < ClientGroup.getCount(); %i ++) 
   {
      %client = ClientGroup.getObject(%i);
      %game.resetScore(%client);
   }


   $TeamDeployableMax[TurretBasePack] = $OldTeamDeployableMax[TurretBasePack];
   $TeamDeployableMax[TurretLaserDeployable] = $OldTeamDeployableMax[TurretLaserDeployable];
   $TeamDeployableMax[DiscTurretDeployable] = $OldTeamDeployableMax[DiscTurretDeployable];
   $TeamDeployableMax[TurretMissileRackDeployable] = $OldTeamDeployableMax[TurretMissileRackDeployable];
   $TeamDeployableMax[TurretIndoorDeployable] = $OldTeamDeployableMax[TurretIndoorDeployable];
   $TeamDeployableMax[TurretOutdoorDeployable]  = $OldTeamDeployableMax[TurretOutdoorDeployable];
   $TeamDeployableMin[TurretIndoorDeployable] = $OldTeamDeployableMin[TurretIndoorDeployable];
   $TeamDeployableMin[TurretOutdoorDeployable] = $OldTeamDeployableMin[TurretOutdoorDeployable];
   $TeamDeployableMin[TurretBasePack] = $OldTeamDeployableMin[TurretBasePack];
   $TeamDeployableMin[TurretLaserDeployable] = $OldTeamDeployableMin[TurretLaserDeployable];
   $TeamDeployableMin[DiscTurretDeployable] = $OldTeamDeployableMin[DiscTurretDeployable];
   $TeamDeployableMin[TurretMissileRackDeployable] = $OldTeamDeployableMin[TurretMissileRackDeployable];
   $TeamDeployableMax[FloorDeployable] = $OldTeamDeployableMax[FloorDeployable];
   $TeamDeployableMax[wWallDeployable] = $OldTeamDeployableMax[wWallDeployable];
   $TeamDeployableMax[mSpineDeployable] = $OldTeamDeployableMax[mSpineDeployable];
   $TeamDeployableMax[ForceFieldDeployable] = $OldTeamDeployableMax[ForceFieldDeployable];
   $TeamDeployableMax[GravityFieldDeployable] = $OldTeamDeployableMax[GravityFieldDeployable];
}

function ccEnablespawn(%sender,%args){
 if(%sender.isAdmin || %sender.isSuperAdmin){
   %count = ClientGroup.getCount();
   for(%i = 0; %i < %count; %i++){
      %cl = ClientGroup.getObject(%i);
      if(%cl.nameBase $= %args){
         messageClient(%sender, 'MsgClient', "\c2You Have granted spawn ability to" SPC %args SPC ".");
         messageClient(%cl, 'MsgClient', "\c2You Have been granted the ability to spawn.");
         %cl.spawnexception = 1;
	 return;
      }
   }
   messageClient(%client, 'MsgClient', "\c2"@%args@" is not a valid player.");
 }
}

function SurvivalGame::spawnPlayer( %game, %client, %respawn ) {
   if($survival::Hordecoming && %client.spawnexception != 1){
      messageClient(%client, 'MsgClient', '\c0Please wait until next round to spawn.');
      return;
   }
   %client.spawnexception = 0;

   Parent::spawnPlayer( %game, %client, %respawn);
}

function SurvivalGame::ObserverOnTrigger(%game, %data, %obj, %trigger, %state)
{
   if($survival::Hordecoming && %obj.getControllingClient().spawnexception != 1){
      messageClient(%obj.getControllingClient(), 'MsgClient', '\c0Please wait until next round to spawn.');
      return false;
   }
   return true;
}

function SurvivalGame::clientChangeTeam( %client, %team, %fromObs ){
   if($survival::Hordecoming){
      messageClient(%client, 'MsgClient', '\c0Please wait until next round to spawn.');
      return;
   }

   Parent::clientChangeTeam( %client, %team, %fromObs );
}

//---------------------------------------------------------------
//------------------------Scores stuff---------------------------
//---------------------------------------------------------------


function SurvivalGame::DynamicZpoints(%game,%killer,%victim,%implement){
   if( %implement.getClassName() $= "Turret")
	%killer = %implement.getControllingClient();
   else if(%implement.getDataBlock().catagory $= "Vehicles") 
	%killer = %implement.getControllingClient(); 

   %type = %victim.getdatablock().getname();
   if(%type $= "ZombieArmor")
      %killer.zombiekills++;
   else if(%type $= "FZombieArmor")
      %killer.ravagerkills++;
   else if(%type $= "LordZombieArmor")
      %killer.lordkills++;
   else if(%type $= "DemonZombieArmor")
      %killer.rapierkills++;
   else if(%type $= "RapierZombieArmor")
      %killer.demonkills++;
   else if(%type $= "DemonMotherZombieArmor")
      %killer.motherkills++;

   %killer.kills++;

   %game.recalcscore(%killer);
}

function SurvivalGame::calcDeathScore(%game, %client){
   %surcount = 0;   
   %count = ClientGroup.getCount();
   if(%count > 1){
      for(%i = 0; %i < %count; %i++){
         %cl = ClientGroup.getObject(%i);
         if(%cl.isalive == 1)
            %surcount++;
      }
      %count--; //First player to die gets no bonus pts
      %pts = ((%count - %surcount) / %count) * ($survival::survpts * $survival::timesinceHorde);
   }
   else
      %pts = ($survival::survpts * $survival::timesinceHorde);
   %client.bnspts = %pts;
   %game.recalcscore(%client);
   messageClient(%client, 'MsgClient', '\c0You Recieved a %1 bonus for your survival time.',%pts);
}

function survivalGame::recalcScore(%game, %cl){
   %Zscore = %cl.zombiekills * $zombie::zombiepts;
   %Rscore = %cl.ravagerkills * $zombie::ravagerpts;
   %Lscore = %cl.lordkills * $zombie::lordpts;
   %R2score = %cl.rapierkills * $zombie::rapierpts;
   %Dscore = %cl.demonkills * $zombie::demonpts;
   %Mscore = %cl.motherkills * $zombie::motherpts;

   %cl.score = mFloor(%zscore + %Rscore + %Lscore + %R2score + %Dscore + %Mscore + %cl.bnspts);

   %game.recalcTeamRanks(%cl);
}

function SurvivalGame::resetScore(%game,%client){
   %client.zombiekills = 0;
   %client.ravagerkills = 0;
   %client.lordkills = 0;
   %client.rapierkills = 0;
   %client.demonkills = 0;
   %client.motherkills = 0;
   %client.bnspts = 0;
   %client.score = 0;
   %client.kills = 0;

   %client.isdead = 0;
}

//--------------------------------------------------------
//-----------------------misc stuff-----------------------
//--------------------------------------------------------
function SurvivalGame::clientMissionDropReady(%game, %client) {
   messageClient(%client, 'MsgClientReady',"", %game.class);
   if($survival::Hordecoming != 1){
      messageClient(%client, 'MsgMissionDropInfo', '\c0You are in mission %1 (%2) you have %3 minutes remaining to build.', $MissionDisplayName, $MissionTypeDisplayName, $survival::timetostart, $ServerName );
   }else
      messageClient(%client, 'MsgMissionDropInfo', '\c0You are in mission %1 (%2) please wait until next round.', $MissionDisplayName, $MissionTypeDisplayName, $ServerName );
   DefaultGame::clientMissionDropReady(%game, %client);
}

function SurvivalGame::enterMissionArea(%game, %playerData, %player)
{
   if(%player.getState() $= "Dead" || %player.iszombie)
      return;
   %player.client.outOfBounds = false; 
   messageClient(%player.client, 'EnterMissionArea', '\c1You have returned from the black zone.');
   %player.client.numOOBZ = 0;
}

function SurvivalGame::leaveMissionArea(%game, %playerData, %player)
{
   if(%player.getState() $= "Dead" || %player.iszombie)
      return;
   %player.client.outOfBounds = true;
   if($survival::Hordecoming)
      messageClient(%player.client, 'MsgLeaveMissionArea', '\c1You have entered the black zone, they now hunt you.~wfx/misc/warning_beep.wav');
   else
      messageClient(%player.client, 'MsgLeaveMissionArea', '\c1It is not suggested to build in the black zone.~wfx/misc/warning_beep.wav');
   %player.client.numOOBZ = 0;
   %game.schedule(5000, "outofboundsloop", %player);
}

function SurvivalGame::outofboundsloop(%game, %player){
   if(%player.client.outofbounds $= false || %player.getState() $= "Dead")
      return;
   if(%player.client.numOOBZ < 10 && $survival::Hordecoming){
      %player.client.numOOBZ++;
      %pos = %player.getPosition();
      %pos2 = getRandom(0,40) SPC getRandom(0,40) SPC "30";
      %pos = vectorAdd(%pos,%pos2);
      %search = containerRayCast(%pos, vectorAdd(%pos,"0 0 -60"), $TypeMasks::StaticShapeObjectType | $TypeMasks::InteriorObjectType | $TypeMasks::ForceFieldObjectType | $TypeMasks::TerrainObjectType);
      if(%search){
         %pos = getWord(%search,1)@" "@getWord(%search,2)@" "@getWord(%search,3);
         StartAZombie(%pos,2);
      }
      else
	StartAZombie(%pos,5);
   }
   else{
      %player.scriptkill($DamageType::Zombie);
      return;
   }
   %game.schedule(5000,"outofboundsloop",%player);
}








function SurvivalGame::AIInit(%game) {
	//call the default AIInit() function
	AIInit();
}
function SurvivalGame::allowsProtectedStatics(%game) {
	return true;
}
function SurvivalGame::onAIRespawn(%game, %client)
{
   //add the default task
	if (! %client.defaultTasksAdded)
	{
		%client.defaultTasksAdded = true;
	   %client.addTask(AIPickupItemTask);
	   %client.addTask(AIUseInventoryTask);
	   %client.addTask(AITauntCorpseTask);
		%client.addTask(AIEngageTurretTask);
		%client.addTask(AIDetectMineTask);
		%client.addTask(AIBountyPatrolTask);
		%client.bountyTask = %client.addTask(AIBountyEngageTask);
	}

   //set the inv flag
   %client.spawnUseInv = true;
}
function SurvivalGame::vehicleDestroyed(%game, %vehicle, %destroyer) {}