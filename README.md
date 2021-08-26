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

We provide two binary files for Linux and MacOS. The binary file will generate the synthetic dataset and corresponding labels from the provided `scenarioConfiguration.json` file.
It is possible to vary the randomizer parameters in `scenarioConfiguration.json` to generate different datasets.
For example `totalIterations` is the number of frames generated and `randomSeed` is the generation seed.
Under the `randomizers` you will find different randomizers and their exposed parameters and ranges. We ship the configuration file with the same randomizer configurations that were used to generate the data on our paper.

##### Note: The generated dataset will start from index 1, which will be a blank image, since the Perception package starts capture at frame 2. In case the user requests 100 frames, then the frame indices will be from 1 to 101, producing 100 valid, non-blank frames with annotations from indices 2 to 101.

### Running the Mac Binary

1. Download and unzip `mac_0.1.0.zip` file and navigate inside this directory.
2. Run the script `run.sh`. See usage of the script for more details on how to run this script:

```
$ bash run.sh -h
```
For example:
```
$ bash run.sh run -t Darwin -d /Users/<USERNAME>/mac_0.1.0 -f /Users/<USERNAME>/scenarioConfiguration.json -l /Users/<USERNAME>/mac_0.1.0/log.txt
```

3. On MacOS the dataset will be written to
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

2. Install graphics drivers and vulkan libraries. You can skip the following driver installation instructions (i-v) if you already have installed driver and libraries and are not using a cloud VM.
    1. Assuming you have Ubuntu 18.04 on GCE instance with NVIDIA Tesla T4 GPU. Install NVIDIA and CUDA drivers using these [instructions.](https://cloud.google.com/compute/docs/gpus/install-drivers-gpu) 
    For a GCE VM instance with `n1-standard-8`, `1x NVIDIA Tesla T4 GPU`, `100 GB SSD`, and Ubuntu 18.04 the installation would be:
    ```
    $ wget https://developer.download.nvidia.com/compute/cuda/repos/ubuntu1804/x86_64/cuda-ubuntu1804.pin
    $ sudo mv cuda-ubuntu1804.pin /etc/apt/preferences.d/cuda-repository-pin-600
    $ sudo apt-key adv --fetch-keys https://developer.download.nvidia.com/compute/cuda/repos/ubuntu1804/x86_64/7fa2af80.pub
    $ sudo add-apt-repository "deb https://developer.download.nvidia.com/compute/cuda/repos/ubuntu1804/x86_64/ /"
    $ sudo apt-get update
    $ sudo apt-get -y install cuda
    # reboot the machine and ensure the nvidia drivers are installed
    $ sudo nvidia-smi
    ```
    2. Install vulkan libraries using the command: `sudo apt install nvidia-settings vulkan-utils`
    3. Now install x-server using the command: `sudo apt-get install xserver-xorg`
    4. Create xorg.conf file: `sudo nvidia-xconfig -a --virtual=1280x1024`
    5. Run xserver: `sudo /usr/bin/X :0 &`
        - If this gives you an error edit the `xorg.conf` file and comment or remove `ServerLayout` and `Screen` sections.
3. Run `run.sh` script. See usage of the script for more details on how to run this script:

```
$ cd linux_0.1.0
$ bash run.sh -h
```
For example on a local linux machine:
```
$ bash run.sh run -t Linux -d /home/<USERNAME>/linux_0.1.0 -f /home/<USERNAME>/scenarioConfiguration.json -l /home/<USERNAME>/linux_0.1.0/log.txt
```
If you're running in a cloud VM:
```
$ DISPLAY=:0 bash run.sh run -t Linux -d /home/<USERNAME>/linux_0.1.0 -f /home/<USERNAME>/scenarioConfiguration.json -l /home/<USERNAME>/linux_0.1.0/log.txt
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

The generated dataset will be in Perception format. The annotations will appear under `DatasetXXXX...` folder in `captures_000.json` and the corresponding images will appear in the `RGBXXXX...` folder. Additionally Perception writes scene metadata to `metrics_XXX.json` files under the `DatasetXXXX...` folder.

# PeopleSansPeople Slack Channel
Public slack channel: [#devs-ai-peoplesanspeople](https://unity.slack.com/messages/C01MW8AJU4F/)

# Converting to public repository
Any and all Unity software of any description (including components) (1) whose source is to be made available other than under a Unity source code license or (2) in respect of which a public announcement is to be made concerning its inner workings, may be licensed and released only upon the prior approval of Legal.
The process for that is to access, complete, and submit this [FORM](https://docs.google.com/forms/d/e/1FAIpQLSe3H6PARLPIkWVjdB_zMvuIuIVtrqNiGlEt1yshkMCmCMirvA/viewform).
