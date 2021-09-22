# PeopleSansPeople: A Synthetic Data Generator for Human-Centric Computer Vision, [NeurIPS 2021](https://arxiv.org/abs/3940169)

<!-- Global site tag (gtag.js) - Google Analytics -->
<!--
<script async src="https://www.googletagmanager.com/gtag/js?id=G-ZCKG4HKTMK"></script>
<script>
  window.dataLayer = window.dataLayer || [];
  function gtag(){dataLayer.push(arguments);}
  gtag('js', new Date());

  gtag('config', 'G-ZCKG4HKTMK');
</script>
-->

<img src="./images/unity/unity-wide-whiteback.png" align="middle" width="3000"/>

[![license badge](https://img.shields.io/badge/license-Apache--2.0-green.svg)](LICENSE.md)

<img src="https://img.shields.io/badge/unity-2020.1.17f1-green.svg?style=flat-square" alt="unity 2020.1.17f1">

<p align="center">
  <img src="./images/teaser_images/rgb_1528.png" width="20%" />
 &nbsp; &nbsp;
  <img src="./images/teaser_images/rgb_2711.png" width="20%" />
 &nbsp; &nbsp;
  <img src="./images/teaser_images/rgb_8687.png" width="20%" />
</p>
<p align="center">
  <img src="./images/teaser_images/img__anns__1528.png" width="20%" />
 &nbsp; &nbsp;
  <img src="./images/teaser_images/img__anns__2711.png" width="20%" />
 &nbsp; &nbsp;
  <img src="./images/teaser_images/img__anns__8687.png" width="20%" />
</p>

<p align="center">
  <a href="https://scholar.google.com/citations?hl=en&user=umudhIEAAAAJ">Salehe Erfanian Ebadi</a>,
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

<!--
> **Authors:** Salehe Erfanian Ebadi, You-Cyuan Jhang, Alex Zook, Saurav Dhakad, Adam Crespi, Pete Parisi, Steven Borkman, Jonathan Hogins, Sujoy Ganguly
> <br />
> **Authors' affiliation:** Unity Technologies
> <br />
> **Submitted to:** NeurIPS 2021 Track Datasets and Benchmarks Round2
> <br />
> **Paper ID:** 54
-->

## Summary
* We introduce PeopleSansPeople, a human-centric privacy-preserving synthetic data generator with highly parametrized domain randomization.
* PeopleSansPeople contains simulation-ready 3D human assets, a parameterized lighting and camera system, and generates 2D and 3D bounding box, 
instance and semantic segmentation, and COCO pose labels. 
* We use naïve ranges for the domain randomization and generate a synthetic dataset with labels. 
* We provide some guarantees and analysis of human activities, poses, and context diversity on our synthetic data.
* We found that pre-training a network using synthetic data and fine-tuning on target real-world data 
([COCO-person train](https://cocodataset.org/#home)) resulted in bbox AP of **57.44** and keypoint AP of **66.83** 
(COCO-person validation) outperforming models trained with the same real data alone (bbox AP of **56.73** and keypoint AP of **65.12**).

<details>
  <summary>Abstract</summary>
  
*In recent years, person detection and human pose estimation have made great strides, helped by large-scale labeled datasets. 
However, these datasets had no guarantees or analysis of human activities, poses, or context diversity. 
Additionally, privacy concerns may limit the ability to collect more data. 
An emerging alternative to real-world data that alleviates some of these issues is synthetic data. 
However, creation of synthetic data generators is incredibly challenging and prevents researchers from exploring their usefulness.
Therefore, we release a human-centric synthetic data generator PeopleSansPeople which contains simulation-ready 3D human assets, 
a parameterized lighting and camera system, and generates 2D and 3D bounding box, instance and semantic segmentation, and COCO pose labels. 
Using PeopleSansPeople, we performed benchmark synthetic data training using a 
[Detectron2 Keypont R-CNN variant](https://github.com/facebookresearch/detectron2). 
We found that pre-training a network using synthetic data and fine-tuning on target real-world data 
([COCO-person train](https://cocodataset.org/#home)) resulted in bbox AP of **57.44** and keypoint AP of **66.83** 
(COCO-person validation) outperforming models trained with the same real data alone (bbox AP of **56.73** and keypoint AP of **65.12**).
This freely available data generator should enable a wide range of research into the emerging field of simulation to 
real transfer learning in the critical area of human-centric computer vision.*
</details>



## Citation
```
@article{ebadi2021peoplesanspeople,
    title={PeopleSansPeople: A Synthetic Data Generator for Human-Centric Computer Vision},
    author={Salehe Erfanian Ebadi and You-Cyuan Jhang and Alex Zook and Saurav Dhakad 
            and Adam Crespi and Pete Parisi and Steven Borkman and Jonathan Hogins and Sujoy Ganguly},
    journal={arXiv},
    year={2021}
}
```

## Source code
Code is available [here](<https://github.com/Unity-Technologies/PeopleSansPeople/>)

## Related links
- [Unity's Perception Package](https://github.com/Unity-Technologies/com.unity.perception)
- [Unity Computer Vision](https://unity.com/products/computer-vision)
- [Unity's Perception Tutorial](https://github.com/Unity-Technologies/com.unity.perception/blob/master/com.unity.perception/Documentation~/Tutorial/TUTORIAL.md)
- [Unity's Human Pose Labeling and Randomization Tutorial](https://github.com/Unity-Technologies/com.unity.perception/blob/master/com.unity.perception/Documentation~/HPTutorial/TUTORIAL.md)
- [SynthDet Project](https://github.com/Unity-Technologies/SynthDet)
- [Robotics Object Pose Estimation Demo](https://github.com/Unity-Technologies/Robotics-Object-Pose-Estimation)
- [Unity Simulation Smart Camera Outdoor Example](https://github.com/Unity-Technologies/Unity-Simulation-Smart-Camera-Outdoor)


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
