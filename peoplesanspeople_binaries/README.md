# PeopleSansPeople: A Synthetic Data Generator for Human-Centric Computer Vision

<!--
> **Authors:** Salehe Erfanian Ebadi, You-Cyuan Jhang, Alex Zook, Saurav Dhakad, Adam Crespi, Pete Parisi, Steven Borkman, Jonathan Hogins, Sujoy Ganguly
> <br />
> **Unity Technologies**
-->

<p align="center">
  <a href="https://www.linkedin.com/in/saleheerfanianebadi">Salehe Erfanian Ebadi</a>,
  <a href="https://www.linkedin.com/in/ycjhang">You-Cyuan Jhang</a>, 
  <a href="https://scholar.google.com/citations?user=2nA9bVMAAAAJ&hl=en&oi=ao">Alex Zook</a>, 
  <a href="https://www.linkedin.com/in/sauravdhakad/">Saurav Dhakad</a>, 
  <br>
  <a href="https://www.linkedin.com/in/adam-crespi-81b1287">Adam Crespi</a>,
  <a href="https://www.linkedin.com/in/pete-parisi-81a179">Pete Parisi</a>,
  <a href="https://www.linkedin.com/in/steve-borkman-5983325">Steven Borkman</a>,
  <a href="https://www.linkedin.com/in/jonathan-hogins-1952b919">Jonathan Hogins</a>,
  <a href="https://scholar.google.com/citations?hl=en&user=4XuOFfUAAAAJ">Sujoy Ganguly</a>
  <br>
  Unity Technologies
</p>

## Important Links

<p align="center">
  <a href="https://arxiv.org/abs/2112.09290" style="font-size: 25px; text-decoration: none">Paper</a>
  &nbsp; &nbsp;
  <a href="https://github.com/Unity-Technologies/PeopleSansPeople" style="font-size: 25px; text-decoration: none">Source Code</a>
  &nbsp; &nbsp;
  <a href="https://storage.googleapis.com/peoplesanspeople-gha-binaries/StandaloneOSX_39ff5eb9ab4ce79440a3f743ebeb4f7b3c967024.zip" style="font-size: 25px; text-decoration: none">macOS Binary</a>
  &nbsp; &nbsp;
  <a href="https://storage.googleapis.com/peoplesanspeople-gha-binaries/StandaloneLinux64_39ff5eb9ab4ce79440a3f743ebeb4f7b3c967024.zip" style="font-size: 25px; text-decoration: none">Linux Binary</a>
</p>

## Dataset Generation Instructions

We provide two binary files for Linux and macOS. 
The binary file will generate the synthetic dataset and corresponding labels from the provided `scenarioConfiguration.json` file.
Datasets can be varied by altering the parameters of the randomizers found in `scenarioConfiguration.json`.
Key fields:
* `totalIterations` - the number of frames to generate
* `randomSeed` - the random generation seed (for reproducibility)
* `randomizers` - the [Unity Perception randomizers](https://github.com/Unity-Technologies/com.unity.perception/blob/master/com.unity.perception/Documentation~/Randomization/Index.md) used in the scenes and their exposed parameters and ranges. The default configuration file includes the randomizer configurations that were used to generate the data in our paper. For more information consult the [Unity Perception package documentation](https://github.com/Unity-Technologies/com.unity.perception/blob/master/com.unity.perception/Documentation~/Randomization/Index.md).

##### Note: The generated dataset will start from index 1, which will be a blank image, since the Perception package starts capture at frame 2. In case the user requests 100 frames, then the frame indices will be from 1 to 101, producing 100 valid, non-blank frames with annotations from indices 2 to 101.

### Running the Mac Binary

1. Copy the contents of [this repo](https://github.com/Unity-Technologies/PeopleSansPeople/tree/main/peoplesanspeople_binaries) in a local directory, e.g. in:
```
/Users/<USERNAME>/
```

2. Download and unzip `StandaloneOSX_39ff5eb9ab4ce79440a3f743ebeb4f7b3c967024.zip` file.
```
$ wget https://storage.googleapis.com/peoplesanspeople-gha-binaries/StandaloneOSX_39ff5eb9ab4ce79440a3f743ebeb4f7b3c967024.zip
$ unzip StandaloneOSX_39ff5eb9ab4ce79440a3f743ebeb4f7b3c967024.zip
```

3. Run the contained script `run.sh`. See usage of the script for more details on how to run this script:
```
$ bash run.sh -h
```
For example:
```
$ bash run.sh -t Darwin -d /Users/<USERNAME>/StandaloneOSX -f /Users/<USERNAME>/scenarioConfiguration.json -l /Users/<USERNAME>/StandaloneOSX/log.txt
```

4. On macOS the dataset will be written to
```
/Users/<USERNAME>/Library/Application Support/com.DefaultCompany.HDRPRenderPeople2020.1.17f1/<UUID>
```
where `<USERNAME>` is your user name and `<UUID>` is the folder where the generated dataset from the last simulation is saved.
The dataset output folder will also be shown in the logs in the terminal.

The generated dataset will be in Perception format. The annotations will appear under `DatasetXXXX...` folder in `captures_000.json` and the corresponding images will appear in the `RGBXXXX...` folder. Additionally Perception writes scene metadata to `metrics_XXX.json` files under the `DatasetXXXX...` folder.

### Running the Linux Binary

1. Copy the contents of [this repo](https://github.com/Unity-Technologies/PeopleSansPeople/tree/main/peoplesanspeople_binaries) in a local directory, e.g. in:
```
/home/<USERNAME>/
```

2. Download and unzip `StandaloneLinux64_39ff5eb9ab4ce79440a3f743ebeb4f7b3c967024.zip` file

```
$ wget https://storage.googleapis.com/peoplesanspeople-gha-binaries/StandaloneLinux64_39ff5eb9ab4ce79440a3f743ebeb4f7b3c967024.zip
$ unzip StandaloneLinux64_39ff5eb9ab4ce79440a3f743ebeb4f7b3c967024.zip
```

3. Install the necessary graphics driver and vulkan libraries. For example, assuming you have Ubuntu 16.04/ 18.04/ 20.04 LTS with NVIDIA GPU. You can install the drivers as follows:
    1. ``sudo add-apt-repository ppa:graphics-drivers/ppa``
    2. Check available drivers for your GPU: ``ubuntu-drivers devices``
    3. Install the specific driver: ``sudo apt install <driver_name>``. For 
       example: ``sudo apt install nvidia-340``
    4. Restart the system and verify the driver installation by: 
       ``nvidia-smi``. You should be able to see the GPU info and the driver 
       version.
       
    5. Install vulkan libraries using the command: ``sudo apt install nvidia-settings vulkan-utils``
   
4. Run `run.sh` script. See usage of the script for more details on how to run this script:
```
$ bash run.sh -h
```
For example:
```
$ bash run.sh -t Linux -d /home/<USERNAME>/StandaloneLinux64 -f /home/<USERNAME>/scenarioConfiguration.json -l /home/<USERNAME>/StandaloneLinux64/log.txt
```

4. The dataset will be written to
```
$XDG_CONFIG_HOME/unity3d/DefaultCompany/HDRP\ RenderPeople\ 2020.1.17f1/<UUID>
```
or as an example
```
/home/<USERNAME>/.config/unity3d/DefaultCompany/HDRP\ RenderPeople\ 2020.1.17f1/<UUID>
```
where `<UUID>` is the folder where the generated dataset from the last simulation is saved. The dataset output folder will also be shown in the logs in the terminal.

The generated dataset will be in the [Unity Perception format](https://github.com/Unity-Technologies/com.unity.perception/blob/master/com.unity.perception/Documentation~/Schema/Synthetic_Dataset_Schema.md). The annotations will appear under `DatasetXXXX...` folder in `captures_000.json` and the corresponding images will appear in the `RGBXXXX...` folder. Additionally Perception writes scene metadata to `metrics_XXX.json` files under the `DatasetXXXX...` folder. For more information on the format consult the [Unity Perception documentation](https://github.com/Unity-Technologies/com.unity.perception/blob/master/com.unity.perception/Documentation~/Schema/Synthetic_Dataset_Schema.md).

## License

PeopleSansPeople is licensed under the Apache License, Version 2.0. See [LICENSE](https://github.com/Unity-Technologies/PeopleSansPeople/blob/main/LICENSE.md) for the full license text.
**All rights reserved for Unity Technologies.**
