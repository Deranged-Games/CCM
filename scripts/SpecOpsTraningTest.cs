//  %armor = getArmorDatablock( %client, $NameToInv[%client.favorites[0]] );
//	if (!%client.isAdmin && !%client.isSuperAdmin) {
//		if ($Host::Purebuild == 1) {
//			%client.favorites[0] = "Purebuild";
//			%armor = getArmorDatablock( %client , "Pure");
//		}
//		else {
//			if (%client.favorites[0] $= "Purebuild")
//				%client.favorites[0] = "Scout";
//		}
//		if($Rank::Score[%client.ranknum] < $Ranks::MinPoints[3]){
//		   if (%client.favorites[0] $= "SpecOps")
//			%client.favorites[0] = "Scout"; 
//		}
//		else if($Rank::SpecOpsCert[%client.ranknum] == 1){
//		   if (%client.favorites[0] $= "SpecOps")
//			%client.favorites[0] = "Scout"; 
//		}
//	}
//   if ( %client.lastArmor !$= %armor )
//   {
//      %client.lastArmor = %armor;
//      for ( %x = 0; %x < %client.lastNumFavs; %x++ )
//         messageClient( %client, 'RemoveLineHud', "", 'inventoryScreen', %x );
//      %setLastNum = true;
//   }

$SOTest::numquestion = 10;
$SOTest::question[1] = "What weapon is able to lock onto a target after being fired and is useful against Choppers?";
$SOTest::answers[1] = "M32, Anti Vehicle Rocket Launcher, RPG, AT6";
$SOTest::answer[1] = "AT6";
$SOTest::question[2] = "What vehicle can resupply and rearm other vehicles?";
$SOTest::answers[2] = "Banshee, C-410, M3A2 Faustus, Eagle VII,";
$SOTest::answer[2] = "C-410";
$SOTest::question[3] = "At what rank can one create a squad?";
$SOTest::answers[3] = "Specialist, General, Sergeant, Second Lieutenant";
$SOTest::answer[3] = "Sergeant";
$SOTest::question[4] = "What is an increased height jump using a weapon which all armors come equiped with?";
$SOTest::answers[4] = "Melee-jump, Super-jump, High-jump, Bug-jump";
$SOTest::answer[4] = "Melee-jump";
$SOTest::question[5] = "Which of these is the highest rank?";
$SOTest::answers[5] = "General, Lieutenant General, Major, Major General";
$SOTest::answer[5] = "General";
$SOTest::question[6] = "What rifle has a medium fire rate, with high accuracy and a high damage per hit?";
$SOTest::answers[6] = "M32, MP12, Kreig, RX-12";
$SOTest::answer[6] = "Kreig";
$SOTest::question[7] = "When calling in an aerial strike on a group of zombies, what should you do to mark the group?";
$SOTest::answers[7] = "Beacon and Smokenade, Beacon, Shoot the plane to get its attention, run and hide";
$SOTest::answer[7] = "Beacon and Smokenade";
$SOTest::question[8] = "When there is an enemy highly fortified base which has little or no value to your team if taken, what should you do?";
$SOTest::answers[8] = "Rush in mass, bomb the base, artillery, special-Ops team";
$SOTest::answer[8] = "artillery";
$SOTest::question[9] = "What is the stealthiest way to do a night insertion?";
$SOTest::answers[9] = "forward assault, by foot, high-level Parachuting, by wildcat";
$SOTest::answer[9] = "high-level Parachuting";
$SOTest::question[10] = "What is a new top-of-the-line rifle used by Special Ops only?";
$SOTest::answers[10] = "M32, MP12, Kreig, RX-12";
$SOTest::answer[10] = "RX-12";

function ccSOtest(%sender, %args, %loopnum){
   if(%sender.ranknum $= ""){
	messageClient(%sender, 'MsgClient', "\c2Please wait a minute for your stats to load");
	%sender.takingtest = 0;
	return;
   }

   if($Rank::Score[%sender.ranknum] <= $Ranks::MinPoints[3]){
	messageClient(%sender, 'MsgClient', "\c2You are to low of a rank to do Spec Ops traning");
	%sender.takingtest = 0;
	return;
   }

   if($Rank::Score[%sender.ranknum] >= $Ranks::MinPoints[3] && %sender.takingtest != 1){
	messageClient(%sender, 'MsgClient', "\c2If you wish to take the Special Ops course use /StartSpecOpsTraning");
	%sender.takingtest = 0;
	return;
   }

   if(%sender.teststarted != 1){
	if(%loopnum $= ""){
	   messageClient(%sender, 'MsgClient', "\c2Alright soldier, lets begin with your test. This will ask you a series of questions which will be one of many steps to having Special Ops certifcation and allow you to use Special Ops armor");
	   %loopnum = 0;
	}
	else if(%loopnum == 1)
	   messageClient(%sender, 'MsgClient', "\c2Please use /SOtest 'answer' to answer the questions");
	else if(%loopnum == 2)
	   messageClient(%sender, 'MsgClient', "\c2You will be given a question and then a list of 4 possibles.");
	else if(%loopnum == 3)
	   messageClient(%sender, 'MsgClient', "\c2Please respond with the full answer, simple saying 'c' will not be taken.");
	else if(%loopnum == 3)
	   messageClient(%sender, 'MsgClient', "\c2Answer the question exactly the same as it appears on the test.");
	else if(%loopnum == 5){
	   messageClient(%sender, 'MsgClient', "\c2You must have a 100% to pass. If you pass this you will procede to traning. Good luck solider.");
	   %sender.teststarted = 1;
	   %sender.questionnum = 1;
	   $sender.numcorrect = 0;
	}
	%loopnum++;
	schedule(3000, 0, "ccSOtest", %sender, %args, %loopnum);
   }
   else{
	if(%sender.questionstatus $= "getting" || %sender.questionstatus $= ""){
	   messageClient(%sender, 'MsgClient', $SOTest::question[%sender.questionnum] );
	   %sender.questionstatus = "getting2";
	   schedule(1000, 0, "ccSOtest", %sender, %args);
	}
	else if(%sender.questionstatus $= "getting2"){
	   messageClient(%sender, 'MsgClient', $SOTest::answers[%sender.questionnum]);
	   %sender.questionstatus = "answering";
	}
	
	else if(%sender.questionnum == $SOTest::numquestion && %sender.questionstatus $= "answering"){
	   
	   if(%args $= $SOTest::answer[%sender.questionnum]){
		messageClient(%sender, 'MsgClient', "\c2Correct.");
		%sender.numcorrect++;
	   }
	   else
		messageClient(%sender, 'MsgClient', "\c2Negative "@%args@" is not the correct answer.");

	   %score = (%sender.numcorrect / $SOTest::numquestion) * 100;
	   if(%score >= 100){
		messageClient(%sender, 'MsgClient', "\c2You have passed the test, you are now proceeding with the first phase of traning.");
		schedule(3000, 0, "traningphase1", %sender);
		%sender.completedtest = 1;
		$Rank::testcompleted[%sender.ranknum] = 1;
	   }
	   else{
		%sender.tooktest = 1;
		schedule(60000, 0, "restoreTest", %sender);
		messageClient(%sender, 'MsgClient', "\c2You failed this test, you ended with a "@%score@" return to the field and continue learning, a real Special Forces would know these questions.");
	   }
	   %sender.numcorrect = "";
	   %sender.questionnum = "";
	   %sender.questionstatus = "";
	   %sender.teststared = "";
	   %sender.takingtest = "";
	   return;
	}

	else if(%sender.questionstatus $= "answering"){
	   if(%args $= $SOTest::answer[%sender.questionnum]){
		messageClient(%sender, 'MsgClient', "\c2Correct.");
		%sender.numcorrect++;
	   }
	   else
		messageClient(%sender, 'MsgClient', "\c2Negative "@%args@" is not the correct answer.");
	   %sender.questionstatus = "getting";
	   %sender.questionnum++;
	   schedule(1000, 0, "ccSOtest", %sender, %args);
	}
   }
}

function restoreTest(%sender){
   %sender.tooktest = 0;
   %sender.takingtest = 0;
   %sender.teststarted = 0;
}