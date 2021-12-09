# PeopleSansPeople: A Synthetic Data Generator for Human-Centric Computer Vision

> **Authors:** Salehe Erfanian Ebadi, You-Cyuan Jhang, Alex Zook, Saurav Dhakad, Adam Crespi, Pete Parisi, Steven Borkman, Jonathan Hogins, Sujoy Ganguly
> <br />
> **Authors' affiliation:** Unity Technologies
> <br />
> **Submitted to:** NeurIPS 2021 Track Datasets and Benchmarks Round2
> <br />
> **Paper ID:** 54


## IMPORTANT NOTICE:

**All the files provided are intended only for the NeurIPS 2021 Track Datasets and Benchmarks Round2 review process.**
<br />
**Distribution, making additional copies, or usage for purposes other than reviewing for the NeurIPS conference is strictly prohibited.**
<br />
**All rights reserved for Unity Technologies.**

## License

PeopleSansPeople is licensed under the Apache License, Version 2.0. See [LICENSE](LICENSE.md) for the full license text.


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

1. Download and unzip `mac_0.1.0.zip` file.
```
$ wget https://storage.googleapis.com/peoplesanspeople/mac_0.1.0.zip
$ unzip mac_0.1.0.zip
```

2. Run the contained script `run.sh`. See usage of the script for more details on how to run this script:

```
$ bash run.sh -h
```
For example:
```
$ bash run.sh -t Darwin -d /Users/<USERNAME>/mac_0.1.0 -f /Users/<USERNAME>/scenarioConfiguration.json -l /Users/<USERNAME>/mac_0.1.0/log.txt
```

3. On macOS the dataset will be written to
```
/Users/<USERNAME>/Library/Application Support/com.DefaultCompany.HDRPRenderPeople2020.1.17f1/<UUID>
```
where `<USERNAME>` is your user name and `<UUID>` is the folder where the generated dataset from the last simulation is saved.
The dataset output folder will also be shown in the logs in the terminal.

The generated dataset will be in Perception format. The annotations will appear under `DatasetXXXX...` folder in `captures_000.json` and the corresponding images will appear in the `RGBXXXX...` folder. Additionally Perception writes scene metadata to `metrics_XXX.json` files under the `DatasetXXXX...` folder.

### Running the Linux Binary

1. Download and unzip `linux_0.1.0.zip` file

```
$ wget https://storage.googleapis.com/peoplesanspeople/linux_0.1.0.zip
$ unzip linux_0.1.0.zip
```

2. Install the necessary graphics driver and vulkan libraries. For example, assuming you have Ubuntu 16.04/ 18.04/ 20.04 LTS with NVIDIA GPU. You can install the drivers as follows:
    1. ``sudo add-apt-repository ppa:graphics-drivers/ppa``
    2. Check available drivers for your GPU: ``ubuntu-drivers devices``
    3. Install the specific driver: ``sudo apt install <driver_name>``. For 
       example: ``sudo apt install nvidia-340``
    4. Restart the system and verify the driver installation by: 
       ``nvidia-smi``. You should be able to see the GPU info and the driver 
       version.
       
    5. Install vulkan libraries using the command: ``sudo apt install nvidia-settings vulkan-utils``
   
3. Run `run.sh` script. See usage of the script for more details on how to run this script:
```
$ bash run.sh -h
```
For example:
```
$ bash run.sh -t Linux -d /home/<USERNAME>/linux_0.1.0 -f /home/<USERNAME>/scenarioConfiguration.json -l /home/<USERNAME>/linux_0.1.0/log.txt
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
