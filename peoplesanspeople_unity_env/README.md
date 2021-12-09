# PSP-Unity

<img src="Packages/Documentation~/images/unity-wide-whiteback.png" align="middle" width="3000"/>

[![license badge](https://img.shields.io/badge/license-Apache--2.0-green.svg)](LICENSE.md)
&nbsp;
<img src="https://img.shields.io/badge/unity-2020.3.20f1-green.svg?style=flat-square" alt="unity 2020.3.20f1">
&nbsp;
<img src="https://badge-proxy.cds.internal.unity3d.com/5ab9a162-9dd0-4ba1-ba41-cf25378a927a?style=flat-square" alt="perception 0.9.0-preview.2">
---

This repository provides the **PeopleSansPeople** project environment in HDRP. The project includes custom randomizers and a few sample human assets from the **Plastic SCM RenderPeople**.

[PeopleSansPeople Release Repository](https://github.com/Unity-Technologies/PeopleSansPeople/tree/project_page)

- The project relies on Unity version `2020.3.20f1` and Perception package `0.9.0-preview.2`.

- Currently, all necessary packages come pre-installed with this project, which allows you to press play and expect synth data generation without any extra steps. The synthetic data will be a set of images, semantic/instance segmentations, and annotations containing bounding box and keypoint labels.

- A sample scene named **HumanScene** containing necessary game objects for demoing the custom randomizers has been provided.

- By default all randomizers are enabled in the `Simulation Scenario`.

## Cloning via Command Line

Prior to cloning via command line, ensure that you have [Git LFS](https://docs.github.com/en/github/managing-large-files/installing-git-large-file-storage) installed, otherwise large files will not download correclty.

## Running the simulation in Unity

After cloning the project, open it in Unity version `2020.3.20f1`. Then in the `Project` window open `Assets/Scenes` and then double-click on `HumanScene.unity` to open the sample provided scene.

Before running the simulation:
   
   1. From the menu bar open `Edit > Project Settings`.
   
   ![Project Settings](Packages/Documentation~/images/Project_Settings.png)
   
   2. In `Project Settings` search for `Lit Shader Mode` and set it to `Both`.
   ![Lit Shader Mode](Packages/Documentation~/images/Project_Settings_Lit_Shader_Mode.png)
    
   2. In `Project Settings` search for `Motion Blur` and disable it.
   ![Motion Blur](Packages/Documentation~/images/Project_Settings_Motion_Blur.png)
   
You can then start running the simulation, and should expect randomly generated images with annotations like the ones shown in the example frame below.
![Simulation](Packages/Documentation~/images/Simulation.png)

## Converting the simulation's generated data to COCO

After your dataset is generated, locate the folder where the data is stored, and use [this repo](https://github.cds.internal.unity3d.com/salehe-erfanianebadi/perception2coco) to convert the data into a COCO-compatible annotation format.

## License
PeopleSansPeople is licensed under the Apache License, Version 2.0. See [LICENSE](LICENSE.md) for the full license text.
