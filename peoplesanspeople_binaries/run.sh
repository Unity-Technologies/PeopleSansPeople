#!/bin/bash

ProgName=$(basename $0)

usage(){
    echo "
Usage:
    bash $ProgName -t <TARGET_MACHINE> -d <BINARY_DIRECTORY_PATH> -f <SCENARIO_CONFIG_FILE> -l <LOG_FILE_PATH>

      -h, HELP                           Print this help message and exit.
      -t, TARGET_MACHINE                 Linux/Darwin (MacOS)
      -d, BINARY_DIRECTORY_PATH          Directory where binary file is located
      -f, SCENARIO_CONFIG_FILE           Scenario config file path
      -l, LOG_FILE_PATH                  Log file path (if no logfile is provided it will create a log.txt file in the current directory)

Example Usage:
    bash $ProgName -t Darwin -d /Users/<USERNAME>/mac_0.1.0 -f /Users/<USERNAME>/scenarioConfiguration.json -l /Users/<USERNAME>/mac_0.1.0/log.txt
    bash $ProgName -t Linux -d /home/<USERNAME>/linux_0.1.0 -f /home/<USERNAME>/scenarioConfiguration.json -l /home/<USERNAME>/linux_0.1.0/log.txt

"
}

while getopts ":t:d:f:l:h" opt; do
  case $opt in
    h)
      usage && exit 0
    ;;
    t) target="$OPTARG"
    ;;
    d) binary_dir="$OPTARG"
    ;;
    f) scenario_config="$OPTARG"
    ;;
    l) logfile="$OPTARG"
    ;;
    \?)
      echo -e \\n"Option -$OPTARG not allowed."
      usage && exit 2
    ;;
  esac
done




if [[ -z ${scenario_config} ]] || [[ -z ${binary_dir} ]] || [[ -z ${target} ]]
then
  echo "  [x] One or more argument not provided. Please look usage."
  usage && exit 1
fi


if [[ -z ${logfile} ]]
then
  logfile="log.txt"
fi

if [[ ${target} != "Darwin" ]] && [[ ${target} != "Linux" ]]
then
  echo "  [x] Invalid target. Valid target: Darwin or Linux." && exit 1
fi

begin_time=$(date +%s)
echo "  [*] Starting data generation."

if [[ ${target} == "Darwin" ]]
then
  binary_dir=$binary_dir"/PeopleSansPeople.app/Contents/MacOS/HDRP RenderPeople 2020.1.17f1"
  binary_dir=$(echo $binary_dir | tr -s / /)
  "${binary_dir}" -logfile "-" --scenario-config-file ${scenario_config} | tee  ${logfile}
fi

if [[ ${target} == "Linux" ]]
then
  binary_dir=$binary_dir"/PeopleSansPeople.x86_64"
  binary_dir=$(echo $binary_dir | tr -s / /)
"${binary_dir}" -logfile "-" --scenario-config-file ${scenario_config} | tee  ${logfile}
fi

end_time=$(date +%s)
runtime=$( echo "$end_time - $begin_time" | bc -l)
hours=$((runtime / 3600)); minutes=$(( (runtime % 3600) / 60 )); seconds=$(( (runtime % 3600) % 60 )); echo "  [i] Time taken to generate data: $hours:$minutes:$seconds (hh:mm:ss)"


