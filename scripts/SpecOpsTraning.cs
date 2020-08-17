exec("scripts/SpecOpsTraningTest.cs");
exec("scripts/SpecOpsTraningP1.cs");
exec("scripts/SpecOpsTraningP2.cs");

function ccStartSpecOpsTraning(%sender, %args){
   if(%sender.ranknum $= ""){
	messageClient(%sender, 'MsgClient', "\c2Please wait a minute for your stats to load");
	return;
   }
   if($Rank::Score[%sender.ranknum] < $Ranks::MinPoints[3]){
	messageClient(%sender, 'MsgClient', "\c2You must be at least a Specialist to take Special Ops traning");
	return;
   }
   if(%sender.tooktest == 1 || %sender.takingtest == 1){
	messageClient(%sender, 'MsgClient', "\c2You have already attempted this test, or are currently takign it.");
	return;
   }
   if($Rank::testCompleted[%sender.ranknum] == 1 && %sender.TP1started != 1){
	schedule(3000, 0, "traningphase1", %sender);
	return;
   }
   else if($Rank::SOT1Completed[%sender.ranknum] == 1 && %sender.TP2started != 1){
//	schedule(3000, 0, "traningphase2", %sender);
	return;
   }
   %sender.takingtest = 1;
   ccSOTest(%sender);
}

function changetonextTraning(%sender){
   if(!isObject($switchFloor)){
      $SwitchFloor = new (StaticShape) () {
	   datablock = "DeployedSpine";
	   position = "0 0 3000";
	   rotation = "1 0 0 90";
	   scale = "1 1 1";
	   team = "1";
	   needsfit = "1";
	   powerFreq = "16";
      };
      addToDeployGroup($SwitchFloor);
   }
   %sender.player.setPosition("0 0 3002");
   %sender.player.setMoveState(true);
}

function SOTremovepieces(%pos, %radius){
   InitContainerRadiusSearch(%pos, %radius, $TypeMasks::StaticShapeObjectType | $TypeMasks::ForceFieldObjectType  | $TypeMasks::TurretObjectType);
   while ((%targetObject = containerSearchNext()) != 0){
	%targetObject = getWord(%targetObject, 0);
	if(%targetObject.SOTremoved != 1){
	   %targetObject.SOTremoved = 1;
	   %targetObject.schedule(100, delete);
	   schedule(50, 0, "SOTremovepieces", %pos, %radius);
	   return;
	}
   }
}

function SOTPlayerSpawn(%client, %pos){
   if(isObject(%client.player) && %client.player.getState() !$= "dead"){
	%client.player.schedule(1, delete);
   }

   if (%client.race $= "Bioderm")
      %armor = "SpecOps" @ "Male" @ %client.race @ Armor;
   else
      %armor = "SpecOps" @ %client.sex @ %client.race @ Armor;
   %client.armor = "SpecOps";

   %player = new Player() {
      dataBlock = %armor;
   };

   %player.setTransform( %pos );
   MissionCleanup.add(%player);

   // setup some info
   %player.setOwnerClient(%client);
   %player.team = 1;
   %client.outOfBounds = false;
   %player.setEnergyLevel(60);
   %client.player = %player;

   // updates client's target info for this player
   %player.setTarget(%client.target);
   setTargetDataBlock(%client.target, %player.getDatablock());
   setTargetSensorData(%client.target, PlayerSensor);
   setTargetSensorGroup(%client.target, 1);
   %client.setSensorGroup(1);

   //make sure the player has been added to the team rank array...
//   %game.populateTeamRankArray(%client);

   %player.setInventory(RepairKit,1);
   %player.setInventory(Beacon, 3);

   %client.setControlObject(%player);
   for(%i =0; %i<$InventoryHudCount; %i++)
	%player.client.setInventoryHudItem($InventoryHudData[%i, itemDataName], 0, 1);
   %player.client.clearBackpackIcon();

   %player.SOTspawned = 1;
}