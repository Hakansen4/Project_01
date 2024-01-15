# Project_01 (ONPROGRESS)
- *This is the 2D platformer, puzzle, video game project.*
- *In the documation you can see works with catergories.(Etc. Player Works, Enemy Works...) This is an unfinished project so you will see some works haven't completed.*

# Completed Works Parts

## Player Works
- *Player going to have lots of features. This section is more about basic Player works.*
- *Player can run, jump and stay idle with animations.*


### Player Explode (On Progress)
- *Player Explode is the attack style of the Player. In the game our Player going to use his Explode skill for push his enemies to the deadly positions. Explode is not going to give damage to the enemies.
Just push them to deadly positions.*
- *Player gain push force for himself after the explode. With this force, Player can use his explosion on platforms as well. I want to combine combat with platform with this ability.*
- *You can see Explosion Player animation below to this comment.(Animation is not %100 finalized. There will be Particle Effect as well)*

![ezgif-2-3d1afd1d10](https://github.com/Hakansen4/Project_01/assets/62704352/804e0b0a-2fed-4f22-a7e4-cc58ed5b9fa8)


### Player Push&Pull
- *Player can push or pull some of the objects from the game's world. With this mechanic, player can find his path in platforms.*
- *For push&pull the object, player has to come closer to the object and click the push button. After that Object would move with player's directon with player.*
- *You can see push&pull aniamation below to this comment.*

![ezgif-7-5ec24bdfbb](https://github.com/Hakansen4/Project_01/assets/62704352/90bb2f4c-6404-4493-a731-2f52df0b4453)

### Player Wall Slide (On Progress)
- *Playe can slide on the wall. With this mechanic Player can use walls in platforms.*
- *Player can also double jump with using walls.*
- *Still there are some bugs in this feature.*
- *You can see wall slide and jump animations below to this comment.*

![ezgif-7-e1983ac483](https://github.com/Hakansen4/Project_01/assets/62704352/29c9e02d-1ce0-4cb5-bba0-ba6d3cc974bc)

### Player Ledge Climb
- *Player can climb with using ledges.*
- *With this feature our player can jump between platform much easily*.
- *You can see Ledge Climb below to this comment.*

![ezgif-2-cfe3992dbf](https://github.com/Hakansen4/Project_01/assets/62704352/530fa1d8-a785-4dba-ab0e-03e72a133235)

## Enemy Works
- *This section is about basic Enemy works.*
- *Enemies can Idle, Patrol, Chase and Attack. All enemy types going to have this abilities but the type of this abilities going to change by enemy type.*
- *In this section you will see the standard of the states. New types of these will be on the next features.*

### Enemy Idle
- *Enemy idle is going to same for every enemy.
- *In idle state our enemy just going to stay.*
- *Idle state is important because enemy has to wait in idle if his attack is on cooldown and still in attack range.*

![ezgif-4-4e727f973f](https://github.com/Hakansen4/Project_01/assets/62704352/cfb402ce-d565-4f2a-ac4d-0e8ec53d4a06)


### Enemy Patrol(On Progress)
- *On Enemy Patrol, our enemy patrolling if player is not in chase range.*
- *Enemy Patrol is going to different by the enemy type. Some of the enemies are not going to patrol.*
- *In the basic patrol state, enemy going to patrol between 2 point.*

![ezgif-4-33c968ec9e](https://github.com/Hakansen4/Project_01/assets/62704352/749a1426-f806-4b4b-a56b-5298727f7034)


### Enemy Chase(On Progress)
- *On Enemy Chase, our enemy going to chase enemy till come close enough for attack. Of course if move away enough he will back to patrol state.*
- *Enemy chase is could have different types. It is not finalized yet.*
- *In the basic chase state, enemy move towards player.*

![ezgif-4-2069a457ea](https://github.com/Hakansen4/Project_01/assets/62704352/8754ad7a-7daf-4374-b6a6-f3630441216a)


### Enemy Attack(On Progress)
- *On the Enemy Attack, our enemy animate his attack animation.*
- *There will be different attack types(like range attack and melee attack).*
- *In the basic attack state, enemy animate his attack animation.*

![ezgif-4-5c0280ae28](https://github.com/Hakansen4/Project_01/assets/62704352/313261d7-8994-4f1e-991e-fb3b0d2b3963)


# Currently Working On Parts

## Combat Works
- *In the combat works I will be focused to Player's and Standard Enemy's combat works.*
- *All enemy and player's attack animation and state works have done. This section is just about make theri attack animation real.*
- *Enemy and player health control going to add.*
- *Enemy and player combat controller going to add.*

### Player Combat
- *In player combat I will make Explode real. When player use explode, all the enemies which effected from explode will be pushed according to the player's own position.*
- *Explode not going to give damage to the enemy.*
### Enemy Combat
- *In enemy combat, I will work on range and melee combat system.*
- *With this attacks, player will receive damage.*
### Environment Combat
- *In environment combat, player and enemy will receive damage. Sometimes both of them sometimes just one of them.*
- *Environment combat will be like traps. Player going to try push enemies to the traps.*
