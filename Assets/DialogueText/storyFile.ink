=== EndNode ===
    -> END


=== IntroScene ===
Well, here we are, two days later and out of rations... But we made it. #Rogue
Technically, we had food available. The lichens we found were edibl- #Mage
EDIBLE MY ASS! That thing looked mushy and disgusting, ew! I prefer starving. #Rogue
If someone hadn't kept triggering traps, maybe, just maybe, we would have enough spell slots for goodberries, but given our track record I'm saving all the spells for the heals... #Cleric
I hope you step on a trap, stingy. #Rogue
I mean, you will do all the walking on things we haven't before, "Scout". #Cleric
Alright, alright, everyone... Let's be a dear and stop with the petty squabbles ~ I saw a nice lute in town, and we've got a treasure to hunt. #Bard
Remember, we are not here to plunder, this is a sacred place. #Cleric
Of course, of course, we are just doing... Archeological research. #Mage
Yup. That's it, that sounds totally right. I'm not going to yoink anything at all. #Rogue
    ->EndNode
    
=== MainSceneFirstLoad ===
Seems like the main door is sealed... But there are more paths to take. #Bard 
So, four rooms... four of us. Simple math. #Mage
Wait, how about we don't sp- #Rogue
So we split the party to unseal it faster. #Cleric
Yup. #Bard
Sure. #Mage
... #Rogue
(Seems like everybody already picked the room they are interested in... I should get going too.) #Rogue
    ->EndNode

=== PuzzleRogueFirstLoad ===
Great. Pressure plates. Woohoo. #Rogue
    ->EndNode
    
=== PuzzleRogueFirstTile ===
 ... I really hope the rest also have death traps and I didn't just get the densely packed with traps room. #Rogue
    ->EndNode

=== PuzzleMageFirstLoad ===
Mhmm... An elemental crucible, how quaint. #Mage
Well, if that's here, then surely runes are soon to follow somewhere. It seems to be displaying them in an order... #Mage
I think I could manage to play the order again if I inspect the crucible too... Maybe the order is important? #Mage
Good thing I always keep my grimoire at hand. [Spacebar] #Mage
I never quite bothered to learn rune reading by heart... #Mage
    ->EndNode

=== PuzzleClericFirstLoad ===
Huh, an array of glyph mirrors. These ruins must be from some religious group. #Cleric
Normally you would use these as a password of sorts. It makes sure you are part of the group, as you would need to know the symbol to make. #Cleric
It also makes a nice tool, as it avoids having to draw and erase glyphs on the same space, along with the unsealing mechanism. #Cleric
Well, let's check my book of lore, it should come in handy. [Spacebar] #Cleric
I wonder which symbols are required here... Perhaps I should take a look around. #Cleric
    ->EndNode

=== PuzzleClericOloMask ===
Oh, well that's unexpected, a mask of Olo here... Lucky it was me who found it. I already feel dizzy... #Cleric
The others would have fallen for his aura. Thank you, Father of Preservation for granting me your protection. #Cleric
    ->EndNode
=== PuzzleClericPermasMask ===
A mask of... Is this Permas? or was it Permut? I hope the Boss doesn't get mad. The mask is very damaged. No matter, the other is bound to be nearby. #Cleric
    ->EndNode
=== PuzzleClericPermutMask ===
A mask of... Is this Permut? or was it Permas? I hope the Boss doesn't get mad. The mask is very damaged. No matter, the other is bound to be nearby. #Cleric
    ->EndNode

=== PuzzleBardFirstLoad ===
My! My! What do we have here? #Bard
I did not know we were in the fancy kind of decrepit ruins. If it isn't an Orchestrion! #Bard
I never imagined I would find something like this here! #Bard
I should try and tune it up, make it sound nice, and see if I can listen the recorded song for my repertoire ~ #Bard
    ->EndNode


=== PuzzleRogueWrongCharacter ===
Oh sure, let's swap rooms! #Rogue
. #Rogue
.. #Rogue
...? #Rogue
What do you mean that you have reconsidered? ;-; #Rogue
    -> EndNode
    
=== PuzzleMageWrongCharacter ===
Have you learned runic in these few hours? #Mage
I'm plenty sure you won't stand a chance in there, so just let me handle this one. #Mage
    -> EndNode
    
=== PuzzleClericWrongCharacter ===
There's a certain... holiness to this room, I shall be the one to go in. #Cleric
(I also checked the others and I prefer this one... I refuse to go to the trapped one.) #Cleric
    -> EndNode
    
=== PuzzleBardWrongCharacter ===
Would you mind if I go in this one? I hear a faint melody from within...  #Bard
It's already starting to get stuck on my head! I need to hear it properly.  #Bard
Besides, we all know I'm the only one here that knows how to play an instrument. #Bard
    -> EndNode
    

=== SwapDialogueRogue ===
Is it my turn again? #Rogue
+ [Yes] -> EndNode
+ [No] -> EndNode

=== SwapDialogueMage ===
Shall I take the lead? #Mage
+ [Yes] -> EndNode
+ [No] -> EndNode

=== SwapDialogueCleric ===
Tired of working? I Guess I can give it a go now. #Cleric
+ [Yes] -> EndNode
+ [No] -> EndNode

=== SwapDialogueBard ===
Finally, I can have some action too!  #Bard
+ [Yes] -> EndNode
+ [No] -> EndNode

=== InspectRogueGlyph ===
Any idea what that depicts? No? Great... #Rogue
    ->EndNode
    
=== InspectMageGlyph ===
An arcane symbol, pretty self explanatory. #Mage
    ->EndNode

=== InspectClericGlyph ===
The rune of Spirits, a common holy symbol. #Cleric
    ->EndNode
    
=== InspectBardGlyph ===
Some sort of depiction of a staff. #Bard
    ->EndNode
    
=== InspectEndGlyph ===
And... an empty frame. #Rogue
Weird, one would think such a central piece would have... more to it. #Mage
Maybe it had at some point? #Bard
I've... I've got a bad feeling about it. Don't know why. #Cleric
    ->EndNode

=== RogueStatueInteraction ===
Huh, that's a disgusting looking... What is this exactly? #Rogue
It's...   P   wh...?   H #Rogue?
Oh, yeah... The puzzle. Let's hope I can get through without triggering any traps! #Rogue
    -> EndNode

=== MageStatueInteraction ===
Mhmm... what... an interesting structure... #Mage
Looks biological but th- then again- again-   R   again- again-   A   again- #Mage?
Damn, what was the order again? I’m so going to study rune reading when I get out, would save me so much time. #Mage
    -> EndNode
    
=== ClericStatueInteraction ===
 This doesn’t look too holy... Wait... #Cleric
 It couldn’t b-   C   behh-.   T   b... #Cleric?
 I should focus on the mirrors, better be out quick to heal the cat. #Cleric
    -> EndNode
    
=== BardStatueInteraction ===
What’s that thing? Is it... humming? #Bard
That...   R   whis-pr...   A   I-... #Bard?
Yes the song! I almost lost the rhythm! Silly me, I should better focus. #Bard
    -> EndNode
    
=== PuzzleRogueSolvedAlready ===
    Nope. Nop. Yesn't. Nay. No. Nuh-huh. Not going in there again. #Rogue
    I already had enough ancient magic thrown at me for today, thanks. #Rogue
    -> EndNode
    
=== PuzzleMageSolvedAlready ===
    It should be done already... Did I solve it wrong? Didn't see any red the last go... #Mage
    -> EndNode
    
=== PuzzleClericSolvedAlready ===
    I shouldn't go there again. I already paid enough attention to other gods, and I don't want the Boss to get jealous.  #Cleric
    -> EndNode
    
=== PuzzleBardSolvedAlready ===
    I already tuned it up... I should start noting down the melody instead!  #Bard
    -> EndNode
    
    
=== FinalCorridorScene===
Is everyone done then? #Cleric
I think so... Yes. #Bard
It seems like the door has opened... Your turn now, "Scout". #Cleric
What do you mean "Scout"? I'm not playing your games! #Rogue
I get what she's saying though, I think you should go first too... #Mage
Wait, what? Why?! I'm not even a tank! I have paper-like HP! #Rogue
Same as us... But have you noticed that we are all ranged spellcasters? #Mage
Indeed, we provide "Cover" and "Protection". You attack with knives, melee range... So, go now, "Scout". #Cleric
C'mon don't worry, I'll ready a Shield spell in case anything goes wrong. #Mage
Isn't the Shield spell a self-targetting only spell? #Rogue
... Who the hell taught him magic? #Mage
Bard. #Cleric
I might have taught him a lil' bit of magic... you know, just a cantrip or two... #Bard
Please, I already went throught the pressure plates... ;-; #Rogue
C'mon, We'll be right by you. I'll even cast bardic inspiration! #Bard
Sigh... (She just wants to play her instrument.) Okay... #Rogue
    -> EndNode
    
=== FinalRoom ===
AHA! Trrrreasuuuuuure! ~ #Rogue
Wait, this is all? A fricking coffin? #Rogue
Mind your manners. #Cleric
It is a bit... Dissappointing though... Maybe there's something of value inside? #Mage
Mhmmm, I dunno... I mean it's not like they'll miss it but... Graverobbing? #Bard
It's quite in poor taste, yes. #Cleric
Well, I'm not leaving with my hands empty so dont mind if I do ~ #Rogue
You alright there bud? You went sil- #Bard
WHAT #Rogue?
IS #Mage?
MY #Cleric?
NAME #Bard?
    ->EndNode
    
=== EndingBad ===
Nah. We should just... Leave. #Rogue
Yes, there's nothing here. Nothing worth it. #Bard
An empty room. #Mage
Why did we even come here guys? Haha... #Rogue
No idea, but let's just put this behind us. #Cleric
Yes, better not idle too much here. #Bard
    ->EndNode
    
=== EndingGood ===
And we have... A locket. #Rogue
A locket? Like, the ones you keep a picture in? #Bard
Yup, but this locket, is "locked". #Rogue
I'm gonna kick you. #Mage
Hey it's not my fault! See? It looks like it should have a keyhole or something but I can't see anything of the sort. #Rogue
And how do you know it's a locket and not a pendant? #Cleric
Well, there's a very thin gap in the middle, I can pry it a lil' bit with a claw. But it is very rusted. #Rogue
Rusted? So it isn't even gold? #Bard
Nope, looks like... I dunno, some metal. I'm no goldsmith. #Rogue
Well, I guess it's better than nothing, shall we leave then? #Mage
I guess so. #Rogue

...

.os sseug I ?neht evael ew llahs ,gnihton naht retteb s'ti sseug I ,lleW .htimsdlog on m'I .latem emos ,onnud I ...ekil skool ,epoN ?dlog neve t'nsi ti oS ?detsuR .detsur yrev si ti tuB .walc a htiw lil a ti yrp nac I ,elddim eht ni pag niht yrev a s'ereht ,lleW ?tnadnep a ton dna tekcol a s'ti wonk uoy od woh dnA .tros eht fo gnihtyna ees t'nac I tub gnihtemos ro elohyek a evah dluohs ti ekil skool tI ?eeS !tluaf ym ton s'ti yeH .uoy kcik annog m'I .dekcol si ,tekcol siht tub ,puY ?ni erutcip a peek uoy seno eht ,ekiL ?tekcol A .tekcol A ...evah ew dnA #Phractas
    ->EndNode