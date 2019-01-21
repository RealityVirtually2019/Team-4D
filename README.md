# Magic Mover

To see documentation from what we discovered over the weekend, visit https://github.com/RealityVirtually2019/Team-4D/wiki

## Video Demonstration

[![YouTube Video](https://i.gyazo.com/9596e9c2819c95c7164b5ca364447506.png)](https://www.youtube.com/watch?v=gFib3k2hHVY "Magic Mover")

## Inspiration
AR technologies have been rapidly evolving only recently, and therefore have not been applied yet to the medical fields as much as VR has. However, AR seems to be promising in particular for home-based rehab because, unlike VR, AR overlaps virtual images onto the real world environments during simulation, thus possibly limiting the discomfort in patients. Recent evolutions of AR, like Hololens and Magic Leap One, by tracking the environmental structure where they are in, allow to literally place virtual objects in specific 3D positions, thus opening interesting perspectives for novel iteractive forms of rehabilitation.

We looked for fields where AR based rehab could contribute most, and found that post-stroke treatments could clearly benefit from the engaging interactive technology, which could help motivate and empower the patients to fully recover. In particular, this become important in the later stages of the rehab process or when patients no longer need hospital treatments, since they may want to work on their skills at home to get back to normal mobility and function.

With Magic Mover, we could help by giving them the resources and motivation.

## What it does
We decided to build an AR game involving interacting with (i.e. moving and stacking) virtual objects. The user would move/stack them by looking at the object and placing it on a virtual mat (both of them anchored in the real space). Over time, the levels will get harder, requiring the user to move around the real space with increasing the complexity and magnitude of movements.

The fun looking objects and new technology would better motivate the patient to practice at home, and the app would get the patient up and moving without straining them to move objects that may result too heavy. Each game level would have new objects, allowing the patient to have a diverse experience tailored to their current abilities. They can increase the game difficulty when they feel that they have mastered the level, or repeat the level with the objects in slightly different spots to maintain interest.

## How we built it
We spent a large portion of time designing the different components of the product in a way that would have enough versatility to improve motor, balance, and cognitive skills, but also have a unifying theme throughout. We also made sure that there was possibility for expansion into other fields through our project. Finally, we aimed to make it as fun as possible while working on these skills to keep patients interested and engaged in order to ensure they would actually use at home.

The project has been developed with Unity 3D and targeted to Microsoft Hololens. We chose appealing assets and programmed them to glow when the user is looking at them, and show a timer. When this timer is full, the virual object is picked up and it is displayed in front of the user. Then the user can move it onto the mat, which would also bring up a timer and at the end of the timer, drop the object where you put it (the timer would allow positioning). We programmed each of these actions in Unity, and used the Unity Spacial Mapping Toolkit to randomly generate objects in the desired section of the room.

We designed our interface in Adobe Illustrator and XD. Our interface is made with large clickable buttons to avoid too fine of movement for stroke patients. We also gave our game a catchy name and animated our title to communicate the movement and the new technology the patients would get to use. Our UI/UX will make the product attractive for the patients.

SDKs: Poly Tools V1.1.2, Mixed Reality ToolKit

Assets: AJ1_Dimensions_Apassara_J_dd_IMO_ExC_ , Bamboo_Fence_Panel_Jarlan_Perez_dVwByrifEmj , Crate_Robin_Brook_fKox3UXY7sU , Empty_Chest_Daniel_Timko_3I2OiZ92Nz7 , Fish_Tank_Chris_Ross_2Rb9zxgkDEM , Zub_Sphere_TheWave_MusicForTheM1nd_AKA_Zyro1331_0mlS0GO454d , ZubSpheres_Multi_TheWave_MusicForTheM1nd_AKA_Zyro1331_1PtcTZc49nz

Audio Assets: Music:

Inspired.mp3 ( https://incompetech.com/music/royalty-free/index.html?isrc=usuan1600022) Summer (https://www.bensound.com/royalty-free-music/track/summer)

Sounds:

Start Beep.wav ( ???? ) zapsplat_bell_service_desk_press_single_18040.mp3 (from: Zapsplat.com) zapsplat_fantasy_magic_twinkle_burst_001_25773.mp3 (from: Zapsplat.com) Drop Noise.wav ( ???? ) zapsplat_fantasy_magic_twinkle_burst_001_25773 (from: Zapsplat.com) Bell Ring.wav ( ???? ) zapsplat_fantasy_magic_wand_ping_retro_style_001_24799.mp3 (from: Zapsplat.com)

## Challenges we ran into
Working with the Hololens was a challenge because in the present version it is not possible to integrate or track hand movement in a way that wouldn't be too difficult for the patient (some of us even had trouble doing the pinching motion required for the Hololens). We adapted our project to moving things visually, which instead requires our patients to walk around more and get used to their houses again.

## Accomplishments that we're proud of
We are proud of our development with the Microsoft Hololens, because of the many potential activities that can be done and monitored with our program, and, most of all, because we turned a potential issue (not tracking the hands) into an opportunity, by allowing the user to go through all options without having to use upper limbs, which may be too hard for some of our patients.

We also developed an easily navigable, understandable and aesthetic interface with sound effects that allows the game to look fun and sophisticated.

## What we learned
We learned about poly assets, which allowed us to get much prettier assets for free, improving our project.

Our group came in with many different skill sets and learned quite a bit about others skills and how to implement and work with these skills, allowing a stronger project than any of us individually.

We learned how to work with the Microsoft Hololens in AR, and expanded our knowledge of Unity, including object manipulation and eyesight interaction, and how to randomly place virtual objects onto a real space.

We spoke to experts in the field, Rafael Grossman and Richard Isaacs. Rafael suggested we make sure to cover skills they are trying to work on as well as possible, and also that our product would work for some patients recovering from concussions (Traumatic Brain Injury) Richard Isaacs helped us make sure we had entertaining assets, suggesting ways to use color and balancing and other cool features for maximal engagement. We applied their ideas to our project, and put ideas we didn’t get to implement into our future plans.

## What's next for Magic Mover
From a purely technical point of view, we hope to integrate the Leap Motion controller or the Magic Leap to include hand tracking among the several forms of possible input. This will allow a more natural interaction with virtual objects, easing the picking up virtual objects in the earlier levels, and better grasping and moving them in advanced ones.

We also hope to develop more levels to require more movement around the room, more challenging stacking patterns, and even bimanual activities, pronosupination and fine movement.

Other possible developments would be developing exercises more focused on the cognitive side, i.e. by asking patients to put in the proper sequence virtual objects which include simple actions related to getting dressed or washing teeth or any other daily activities to increasingly challenge the subjects.

We will add more menu options to allow hospitals to create accounts for each patient and provide trackable data on improvement.

One important development would be the transfer of data into a cloud based repository, allowing remote monitoring and continuous supervision of the patients, as well as paving the way to new advanced processing (i.e. big data)

Location: 3rd Floor, E15, outside room 322
