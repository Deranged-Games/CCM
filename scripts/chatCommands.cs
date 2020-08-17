function VectToRot(%vec){
	%x = getWord(%vec, 0);
	%y = getWord(%vec, 1);
	%z = getWord(%vec, 2);
	%len = vectorLen(%vec);
	%rotAngleXY = mATan(%z, %len);
	%rotAngleZ = mATan(%x, %y);
	%matrix = MatrixCreateFromEuler("0 0" SPC %rotAngleZ * -1);
	%matrix2 = MatrixCreateFromEuler(%rotAngleXY SPC "0 0");
	%finalMat = MatrixMultiply(%matrix, %matrix2);
	return getWords(%finalMat, 3, 5)@" "@(getWord(%finalMat,6) * 360 / 3.14156);
}

function chatcommands(%sender, %message) {
   %cmd=getWord(%message,0);
   %cmd=stripChars(%cmd,"/");
   %count=getWordCount(%message);
   %args=getwords(%message,1);
   %cmd="cc" @ %cmd;
   if (%cmd $="ccopen") //so u can call //open instead of //opendoor
   	%cmd="ccopendoor";
   if(%cmd $= "ccjoin")
	call(%cmd,%sender,%sender.sqinv);
   else if(%cmd $= "ccJoin")
	call(%cmd,%sender,%sender.sqinv);
   else
	call(%cmd,%sender,%args);
}

function cchelp(%sender,%args){
   if(%args !$= ""){
	if(%args $= "/open" || %args $= "/opendoor"){
	   messageclient(%sender, 'MsgClient', '\c5This command simply opens doors');
	}
	else if(%args $= "/bf"){
	   messageclient(%sender, 'MsgClient', '\c5This command is a buy favorites command only operates when purebuild is on.');
	}
	else if(%args $= "/buyZpack"){
	   messageclient(%sender, 'MsgClient', '\c5ADMIN ONLY: This command allows access to the zombie spawn pack.');
	}
	else if(%args $= "/Zspawnloop"){
	   messageclient(%sender, 'MsgClient', '\c5ADMIN ONLY: This command starts a Zombie spawn loop in a specified area.');
	}
	else if(%args $= "/hack"){
	   messageclient(%sender, 'MsgClient', '\c5This command can be used to hack enemy teleports.');
	}
	else if(%args $= "/checkstats"){
	   messageclient(%sender, 'MsgClient', '\c5This command allows you to check up on your recorded stats on this server.');
	}
	else if(%args $= "/top5"){
	   messageclient(%sender, 'MsgClient', '\c5This command lists the top 5 players on this server.');
	}
	else if(%args $= "/createsquad"){
	   messageclient(%sender, 'MsgClient', '\c5This command allows you to create a squad of players.');
	}
	else if(%args $= "/join"){
	   messageclient(%sender, 'MsgClient', '\c5This command allows you to join a squad youve been invited to.');
	}
	else if(%args $= "/leavesquad"){
	   messageclient(%sender, 'MsgClient', '\c5This command allows you to leave a squad you have joined.');
	}
	else if(%args $= "/invite"){
	   messageclient(%sender, 'MsgClient', '\c5This command allows a squad leader to invite someone into his squad.');
	}
	else if(%args $= "/s"){
	   messageclient(%sender, 'MsgClient', '\c5This command is a in-squad chat feature only messaging people in your squad.');
	}
	else if(%args $= "/listsquads"){
	   messageclient(%sender, 'MsgClient', '\c5This command lists all the squads on the server.');
	}
	else if(%args $= "/requestinvite"){
	   messageclient(%sender, 'MsgClient', '\c5This command requests an invite from a squad leader.');
	}
	else if(%args $= "/o"){
	   messageclient(%sender, 'MsgClient', '\c5This command allows general ranks to give orders to squads.');
	}
	else if(%args $= "/force"){
	   messageclient(%sender, 'MsgClient', '\c5This command allows officers to force people into squads.');
	}
	else if(%args $= "/sol"){
	   messageclient(%sender, 'MsgClient', '\c5This command allows players to spawn on their squad leader when they die.');
	}
	else if(%args $= "/cancelvote"){
	   messageclient(%sender, 'MsgClient', '\c5ADMIN ONLY: This command will cancel a vote in progess.');
	}
	else if(%args $= "/savebuilding"){
	   messageclient(%sender, 'MsgClient', '\c5ADMIN ONLY: This command allows building saving.');
	}
	else if(%args $= "/loadbuilding"){
	   messageclient(%sender, 'MsgClient', '\c5ADMIN ONLY: This command allows building loading.');
	}
	else if(%args $= "/delpieces"){
	   messageclient(%sender, 'MsgClient', '\c5This command allows you to delete your pieces.');
	}
	else if(%args $= "/setscale"){
	   messageclient(%sender, 'MsgClient', '\c5This command allows you to set a piece to a certain size.');
	}
	else if(%args $= "/getscale"){
	   messageclient(%sender, 'MsgClient', '\c5This command allows you to find the size of a piece.');
	}
	else if(%args $= "/power"){
	   messageclient(%sender, 'MsgClient', '\c5This command allows you to set your power freq.');
	}
	else if(%args $= "/killzombies"){
	   messageclient(%sender, 'MsgClient', '\c5ADMIN ONLY: This command allows you to kill all zombies.');
	}
	else if(%args $= "/enablespawn"){
	   messageclient(%sender, 'MsgClient', '\c5ADMIN ONLY: Allows admins to let players back into a survival match.');
	}
	else if(%args $= "/setdoorpass" || %args $= "/listspawns" || %args $= "/choosespawn" || %args $= "/NameSpawn"){
	   messageclient(%sender, 'MsgClient', '\c5This command is self explanitory');
	}
	else{
	   messageclient(%sender, 'MsgClient', '\c5Please specify a command you would like to find out about.');
	   messageclient(%sender, 'MsgClient', '\c5EX: /help /o');
	}
   }
   else{
      messageclient(%sender, 'MsgClient', '\c5/open  /opendoor  /setdoorpass.');
      messageclient(%sender, 'MsgClient', '\c5/bf  /buyZpack  /Zspawnloop.');
      messageclient(%sender, 'MsgClient', '\c5/hack  /listspawns  /choosespawn.');
      messageclient(%sender, 'MsgClient', '\c5/checkstats  /top5  /createsquad.');
      messageclient(%sender, 'MsgClient', '\c5/join  /leavesquad  /invite.');
      messageclient(%sender, 'MsgClient', '\c5/s  /listsquads  /requestinvite.');
      messageclient(%sender, 'MsgClient', '\c5/o  /force  /sol /stopZspawnloop.');
	messageclient(%sender, 'MsgClient', '\c5/dronebattle  /namespawn  /Dtankspawn.');
	messageclient(%sender, 'MsgClient', '\c5/cancelvote  /savebuilding  /loadbuilding.');
	messageclient(%sender, 'MsgClient', '\c5/Delpieces  /setscale  /getscale.');
	messageclient(%sender, 'MsgClient', '\c5/power  /killzombies /enablespawn.');
	messageclient(%sender, 'MsgClient', '\c5Place the command you wish to know more about behind /help to know more information on it.');
   }
}

function ccopendoor(%sender,%args) {
   %pos        = %sender.player.getMuzzlePoint($WeaponSlot);
   %vec        = %sender.player.getMuzzleVector($WeaponSlot);
   %targetpos  = vectoradd(%pos,vectorscale(%vec,100));
   %obj        = containerraycast(%pos,%targetpos,$typemasks::staticshapeobjecttype,%sender.player);
   %obj        = getword(%obj,0);
   %dataBlock  = %obj.getDataBlock();
   %className  = %dataBlock.className;
   %cash       = %obj.amount;
   %owner      = %obj.owner;
   %obj.issliding = 0;
   if (%obj.Collision == true) //if is a colition door
      return;                  //stop here
   if (%obj.canmove == false) //if it cant move
      return;                  //stop here
   if (%obj.isdoor != 1 && %hitobj.getdatablock().getname() !$="DeployedTdoor"){
      messageclient(%sender, 'MsgClient', '\c5No door in range.');
      return;
   }
   if (!isobject(%obj)) {
      messageclient(%sender, 'MsgClient', '\c5No door in range.');
      return;
   }
   if (%obj.powercontrol == 1) {
      messageclient(%sender, 'MsgClient', '\c5This door is controlled by a power supply.');
      return;
   }
   %pass = %args;
   if (%obj.pw $= %pass) {
   	if (%obj.toggletype ==1){
         if (%obj.moving $="close" || %obj.moving $="" || %going $="opening"){
         	schedule(10,0,"open",%obj);
      }
      else if (%obj.moving $="open" || %going $="closeing"){
           schedule(10,0,"close",%obj);
      }
   }
   else
       schedule(10,0,"open",%obj);
   }
   if (%obj.pw !$= %pass)
      messageclient(%sender,'MsgClient',"\c2Password Denied.");

}

function ccsetdoorpass(%sender,%args){
   %pos=%sender.player.getMuzzlePoint($WeaponSlot);
   %vec = %sender.player.getMuzzleVector($WeaponSlot);
   %targetpos=vectoradd(%pos,vectorscale(%vec,100));
   %obj=containerraycast(%pos,%targetpos,$typemasks::staticshapeobjecttype,%sender.player);
   %obj=getword(%obj,0);
   %dataBlock = %obj.getDataBlock();
   %className = %dataBlock.className;
   if (%classname !$= "door") {
   messageclient(%sender, 'MsgClient', '\c2No door in range.');
      return;
   }
   if (%obj.owner!=%sender && %obj.owner !$="")
	messageclient(%sender, 'MsgClient', '\c2You do not own this door.');
   if (!isobject(%obj))
	messageclient(%sender, 'MsgClient', '\c2No door in range.');
   if (%obj.Collision $= true) {
	messageclient(%sender, 'MsgClient', '\c2Collision doors can not have passwords.');
   	return;
   }
   if(isobject(%obj) && %obj.owner==%sender) {
	%pw=getword(%args,0);
	%obj.pw=%pw;
	messageclient(%sender, 'MsgClient', '\c2Password set, password is %1.',%pw);
   }
}

function ccbf(%sender,%args) {
   if($Host::Purebuild == 1)
   	buyFavorites(%sender);
}

function ccBuyZPack(%sender,%args){
   if((%sender.isAdmin || %sender.isSuperAdmin) && isObject(%sender.player))
   {
	if(%sender.player.getMountedImage($Backpackslot) !$= "")
   	   %sender.getControlObject().throwPack();
	%sender.player.setinventory(ZSpawnDeployable,1,true);
   }
}

function ccZspawnloop(%sender, %args){
   if(%sender.isAdmin || %sender.isSuperAdmin){
	%pos = getWords(%args,0,2);
	%radius = getWord(%args,3);
	%freq = getWord(%args,4);
	if(vectorlen(%pos) < 1 || %radius < 1 || (%freq < 1 || %freq > 10)){
	   messageclient(%sender, 'MsgClient', '\c2Please specify the 3 number position to center the spawn around followed by the radius,');
	   messageclient(%sender, 'MsgClient', '\c2and then a number between 1 and 10 specifying the difficulty requested.');
	   messageclient(%sender, 'MsgClient', '\c2EX: /Zspawnloop 1000 0 110 200 8');
	   return;
	}
      zombieSpawnLoop(%pos,%radius,%freq);
   }
}
function ccStopZspawnloop(%sender,%args){
   if(%sender.isAdmin || %sender.isSuperAdmin){
      StopZombieSpawnLoop();
   }
}

function ccdronebattle(%sender,%args){
   if(%sender.isAdmin || %sender.isSuperAdmin){
	%pos = getWords(%args,0,2);
	%radius = getWord(%args,3);
	%num = getWord(%args,4);
	%teamlow = getWord(%args,5);
	%teamhigh = getWord(%args,6);
	%maxskill = getWord(%args,7);
	if(vectorlen(%pos) < 1 || %radius < 1 || %num < 1 || %teamlow $= "" || %teamhigh < %teamlow || %maxskill $= ""){
	   messageclient(%sender, 'MsgClient', '\c2Please specify the 3 number position to center the spawn around followed by the radius,');
	   messageclient(%sender, 'MsgClient', '\c2and then the number of drones you want followed by a team low and team high indicator');
	   messageclient(%sender, 'MsgClient', '\c2followed by a number from 1 to 10 on the max skill of the drones you want.');
	   messageclient(%sender, 'MsgClient', '\c2EX: /dronebattle 0 0 1000 500 10 1 2 5');
	   return;
	}
	dronebattle(%pos,%radius,%num,%teamlow,%teamhigh,%maxskill);
   }
}

function ccDtankspawn(%sender,%args){
   if(%sender.isAdmin || %sender.isSuperAdmin){
	%pos = getWords(%args,0,2);
	%team = getWord(%args,3);
	%skill = getWord(%args,4);
	if(vectorlen(%pos) < 1  || %team $= "" || %skill $= ""){
	   messageclient(%sender, 'MsgClient', '\c2Please specify the 3 number position to center the spawn around followed by the team,');
	   messageclient(%sender, 'MsgClient', '\c2followed by a number from 1 to 10 on the skill of the drone you want.');
	   messageclient(%sender, 'MsgClient', '\c2EX: /DTankspawn 0 0 1000 1 5');
	   return;
	}
	startDtank(%pos,%team,%skill);
   }
}

function cchack(%sender, %args){
   %pos        = %sender.player.getMuzzlePoint($WeaponSlot);
   %vec        = %sender.player.getMuzzleVector($WeaponSlot);
   %targetpos  = vectoradd(%pos,vectorscale(%vec,10));
   %obj        = containerraycast(%pos,%targetpos,$typemasks::staticshapeobjecttype,%sender.player);
   %obj        = getword(%obj,0);
   %dataBlock  = %obj.getDataBlock();
   %className  = %dataBlock.className;
   %DBname	   = %datablock.getName();
   if(%args $= "help"){
	messageClient(%sender, 'MsgClient', "\c2To hack you must guess the 4 digit binary code for each of the numbers in a randomly generated 5 digit code.");
	messageClient(%sender, 'MsgClient', "\c2EX: /hack - you have 2 ones in this code.");
	messageClient(%sender, 'MsgClient', "\c2... /hack 0 0 1 1 - you have 2 correct in this code.");
	messageClient(%sender, 'MsgClient', "\c2... /hack 0 1 0 1 - you have 2 correct in this code.");
	messageClient(%sender, 'MsgClient', "\c2... /hack 0 1 1 0 - you have got this number and you have 4 codes left to go.");
	return;
   }
   if (!isobject(%obj)) {
      messageclient(%sender, 'MsgClient', '\c5No tele in range.');
      return;
   }
   if (%DBname !$= "TelePadDeployedBase") {
      messageclient(%sender, 'MsgClient', '\c5No tele in range.');
      return;
   }
   if(%obj.ishacked != 1){
	if(%args $= ""){
	   %numones = 0;
	   for(%i = 0; %i < 4; %i++){
		if(getWord(%obj.hackcode[(%obj.numhacked + 1)],%i) $= "1")
		   %numones++;
	   }
	   messageClient(%sender, 'MsgClient', "\c2There are "@ %numones @" ones in this code, and you have "@ (5 - %obj.numhacked) @" more codes to find.");
	}
	else{
	   %numsame = 0;
	   for(%i = 0; %i < 4; %i++){
		if(getWord(%obj.hackcode[(%obj.numhacked + 1)],%i) $= getWord(%args,%i))
		   %numsame++;
	   }
	   if(%numsame == 4){
		if(%obj.numhacked $= "")
		   %obj.numhacked = 0;
		%obj.numhacked++;
		if(%obj.numhacked == 5){
		   %obj.ishacked = 1;
		   messageClient(%sender, 'MsgClient', "\c2You have hacked this teleport.");
		   return;
		}
		messageClient(%sender, 'MsgClient', "\c2You have got this number you have "@(5 - %obj.numhacked)@" codes left to go.");
	   }
	   else
		messageClient(%sender, 'MsgClient', "\c2You have "@%numsame@" of the code correct.");
	}
   }
}

function teleresethack(%obj){
   if(!isObject(%obj))
	return;
   if(%obj.ishacked == 1 || %obj.ishacked $= ""){
	%obj.ishacked = 0;
	%obj.numhacked = 0;
	%num[0] = "0 0 0 0";
	%num[1] = "0 0 0 1";
	%num[2] = "0 0 1 0";
	%num[3] = "0 0 1 1";
	%num[4] = "0 1 0 0";
	%num[5] = "0 1 0 1";
	%num[6] = "0 1 1 0";
	%num[7] = "0 1 1 1";
	%num[8] = "1 0 0 0";
	%num[9] = "1 0 0 1";
	for(%i = 1; %i < 6; %i++){
	   %random = getRandom(0,9);
	   %obj.hackcode[%i] = %num[%random];
	}
   }
   schedule(180000, %obj, "teleresethack", %obj);
}

function ccNameSpawn(%sender,%args){
   if(isObject(%sender.player)){
      %pos        = %sender.player.getMuzzlePoint($WeaponSlot);
      %vec        = %sender.player.getMuzzleVector($WeaponSlot);
      %targetpos  = vectoradd(%pos,vectorscale(%vec,20));
      %obj        = containerraycast(%pos,%targetpos,$typemasks::staticshapeobjecttype,%sender.player);
      %obj        = getword(%obj,0);
      if(isObject(%obj)){
         %owner      = %obj.owner;
         %dataBlock  = %obj.getDataBlock();
         %className  = %dataBlock.className;
	   if(%className $= "SpawnPoint" && %owner $= %sender){
		%obj.name = %args;
		messageClient(%sender, 'MsgClient', "\c2SpawnPoint name set to" SPC %args SPC ".");
		return;
	   }
	}
   }
   %sender.SPname = %args;
   messageClient(%sender, 'MsgClient', "\c2The next spawnpoint you create will be named" SPC %args SPC ".");
}

function ccListSpawns(%sender){
   if(%sender.team == 0)
	return;
   %team = %sender.team;
   for(%i = 0; %i < $teamSPs[%team]; %i++){
	if($teamSP[%team,%i].name $= "")
	   $teamSP[%team,%i].name = getWords($teamSP[%team,%i].getPosition(),0,1);
	messageClient(%sender, 'MsgClient', "\c2"@(%i + 1)@". spawnpoint "@$teamSP[%team,%i].name@".");
   }
}

function ccchooseSpawn(%sender,%args){
   %team = %sender.team;
   if(%team == 0)
	return;
   if(%args $= ""){
	if(%sender.SP !$= ""){
	   %sender.SP = "";
	   messageClient(%sender, 'MsgClient', "\c2Spawn Point Reset, you will now spawn at the normal location.");
	   return;
	}
	messageClient(%sender, 'MsgClient', "\c2Please choose a number that corresponds with a spawnpoint.");
	return;
   }
   %num = (firstWord(%args) - 1);
   if(isObject($teamSP[%team,%num])){
	if($teamSP[%team,%num].active == 1){
	   %sender.SP = $teamSP[%team,%num];
	   messageClient(%sender, 'MsgClient', "\c2Spawnpoint "@$teamSP[%team,%i].name@" choosen.");
	}
	else{
	   %sender.SP = $teamSP[%team,%num];
	   messageClient(%sender, 'MsgClient', "\c2Spawnpoint "@$teamSP[%team,%i].name@" choosen, but this point is not currently powered.");
	}
   }
   else
	messageClient(%sender, 'MsgClient', "\c2This spawnpoint dosent exist.");
}

function ccCancelVote(%sender, %args)
{
   if(!%sender.isAdmin)
      return;

   if(Game.ScheduleVote $= "")
   {
      messageClient(%sender, "MsgNo", "\c2There is no vote to cancel!");
      return;
   }

   cancel(Game.scheduleVote);

   Game.votingArgs = "";
   Game.scheduleVote = "";
   Game.kickClient = "";
   clearVotes();

   messageAll('closeVoteHud', "");
   if(%client.team != 0)
      clearBottomPrint(%client);

   messageAll('MsgAdminForce', "\c2"@%sender.nameBase@" has cancelled the vote.");
   messageAll('MsgVoteFailed', "");
}

function ccSaveBuilding(%sender, %args)
{
   if(!%sender.isAdmin)
      return;

   %rad = getword(%args, 0);
   %file = getword(%args, 1);
   SaveBuilding(%sender, %rad, %file, 1, 0);
   messageAll('MsgAdminForce', "\c3"@%sender.nameBase@"\c2 is saving the buildings with a radius of \c3"@%rad@"\c2.");
   messageClient(%sender, "", "\c2Building saved to "@$SaveBuilding::LastFile@".");
}

function ccLoadBuilding(%sender, %args)
{
   if(!%sender.isAdmin)
   {
      messageClient(%sender, "", "\c2Please request an Admin to load the file for you.");
      return;
   }

   if(!isFile($SaveBuilding::SaveFolder @ %args))
   {
      messageClient(%sender, "", "\c2Cannot find specified file.");
      return;
   }

   LoadBuilding(%args);
   messageAll('MsgAdminForce', "\c2"@%sender.nameBase@" has loaded a building.");
}

function ccDelPieces(%sender, %args)
{
   if(!%sender.isAdmin || %args $= "")
   {
      if(!isObject(%sender.player))
      {
         messageClient(%sender, 'MsgClient', "\c2You must be playing in order to remove your pieces.");
         return;
      }

      %group = nameToID("MissionCleanup/Deployables");
      for(%i = 0; %i < %group.getCount(); %i++)
      {
         %obj = %group.getObject(%i);
         if(%obj.getOwner() == %sender && isObject(%obj))
            %obj.getDatablock().schedule(getRandom() * 10000, disassemble, %sender.player, %obj);
      }

      messageClient(%sender, 'MsgYes', "\c2All of your pieces have been removed.");
   }
   else
   {
      %target = plnametocid(%args);
      if(!isObject(%target))
      {
         messageClient(%sender, 'MsgClient', "\c2That person's player object does not exist.");
         return;
      }

      if((!%sender.isSuperAdmin && %target.isAdmin) || %target.isSuperAdmin)
      {
         messageClient(%sender, 'MsgClient', "\c2You must outrank that target in order to remove their pieces.");
         return;
      }

      messageAll('MsgAdminForce', "\c2"@%sender.nameBase@" has forced "@%target.nameBase@" to delete all of their pieces.");
      ccDelPieces(%target, "");
   }
}

function ccSetScale(%sender, %args)
{
   if(!isObject(%sender.player))
   {
      messageClient(%sender, "", "\c2You must be spawned in order to do this!");
      return;
   }

   %pos=%sender.player.getMuzzlePoint($WeaponSlot);
   %vec = %sender.player.getMuzzleVector($WeaponSlot);
   %targetpos=vectoradd(%pos,vectorscale(%vec,100));
   %obj=containerraycast(%pos,%targetpos,$typemasks::staticshapeobjecttype,%sender.player);
   %obj=getword(%obj,0);

   if(!isObject(%obj))
   {
      messageClient(%sender, "", "\c2There is nothing in range.");
      return;
   }

   // These have been moved down here to prevent console spam.
   %dataBlock = %obj.getDataBlock();
   %className = %dataBlock.className;
   if(%obj.owner != %sender && !%sender.isAdmin)
   {
      messageClient(%sender, "", "\c2That piece isn't yours!");
      return;
   }

   if(getwordcount(%args) < 3)
   {
      messageClient(%sender, "", "\c2You must specify all paramenters: X, Y, and Z.");
      return;
   }

   if(getwordcount(%args) > 3)
   {
      messageClient(%sender, "", "\c2Too many parameters. They should be X, Y, and Z.");
      return;
   }

   if(%classname $= "spine" || %classname $= "mspine" || %classname $= "spine2" || %classname $= "floor" || %classname $= "wall" || %classname $= "wwall" || %classname $= "floor" || %classname $= "door")
   {
      %or = %args;
      %args = VectorMultiply(%args, "0.125 0.166666 2");
      %check = EditorCheckScale(%args);
      if(%check == 1)
      {
         messageClient(%sender, "", "\c2Scale is too small.");
         return;
      }

      if(%check == 2)
      {
         messageClient(%sender, "", "\c2Scale is too big.");
         return;
      }

      %obj.setScale(%args);
      messageClient(%sender, "", "\c2Object scale set to "@%or@".");
      return;
   }
}

function ccGetScale(%sender, %args)
{
   if(!isObject(%sender.player))
   {
      messageClient(%sender, "", "\c2You must be spawned in order to do this!");
      return;
   }

   %pos=%sender.player.getMuzzlePoint($WeaponSlot);
   %vec = %sender.player.getMuzzleVector($WeaponSlot);
   %targetpos=vectoradd(%pos,vectorscale(%vec,100));
   %obj=containerraycast(%pos,%targetpos,$typemasks::staticshapeobjecttype,%sender.player);
   %obj=getword(%obj,0);

   if(!isObject(%obj))
   {
      messageClient(%sender, "", "\c2There is nothing in range.");
      return;
   }

   // These have been moved down here to prevent console spam.
   %dataBlock = %obj.getDataBlock();
   %className = %dataBlock.className;
   if(%obj.owner != %sender && !%sender.isAdmin)
   {
      messageClient(%sender, "", "\c2That piece isn't yours!");
      return;
   }

   %scale = %obj.getScale();
   if(%classname $= "spine" || %classname $= "mspine" || %classname $= "spine2" || %classname $= "floor" || %classname $= "wall" || %classname $= "wwall" || %classname $= "floor" || %classname $= "door")
      %scale = getword(%scale, 0) / 0.125 SPC getword(%scale, 1) / 0.166666 SPC getword(%scale, 2) / 2; // Eolk - Capn Power released this in CCM as part of the unofficial Merge Tool. The scale figuring has been used here.
   if(%dataBlock $= "DeployedLTarget")
      %scale = %obj.lMain.getScale();
   messageClient(%sender, "", "\c2The scale of that object is "@%scale@".");
}

function ccPower(%sender, %args)
{
   if(!isObject(%sender.player))
   {
      messageClient(%sender, "", "\c2You have to be playing in order to do this.");
      return;
   }

   %sender.player.powerFreq = %args;
   displayPowerFreq(%sender.player);
}

function ccKillZombies(%sender)
{
   if(!%sender.isAdmin)
      return;

   InitContainerRadiusSearch("0 0 100",30000, $TypeMasks::PlayerObjectType);

   while ((%target = ContainerSearchNext()) != 0) {
      if(%target.iszombie == 1){
         %target.scriptkill();
      } else if(%target.infected == 1){
         %target.infected = 0;
         %target.scriptkill();
      }
   }
   messageAll('MsgAdminForce', "\c2"@%sender.nameBase@" has killed all of the zombies and removed all infected people.");
}