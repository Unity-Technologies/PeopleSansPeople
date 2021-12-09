//using System;
//using UnityEngine;
//using UnityEngine.Perception.GroundTruth;
//using UnityEngine.Perception.Randomization.Randomizers;


//public class CustomAnnotationsAndMetricsRandomizer : Randomizer
//{
//    MetricDefinition m_TestMetricDefinition;
//    const string k_TestGuid = "6cwe6-169w4ef-94cs35e0-cwe057ef";

//    //protected override void OnScenarioStart()
//    //{
//    //    m_TestMetricDefinition = DatasetCapture.RegisterMetricDefinition(
//    //        "scenario_iteration",
//    //        "Iteration information for dataset sequences",
//    //        Guid.Parse(k_TestGuid));
//    //}

//    protected override void OnStartRunning()
//    {
//        Debug.Log(Guid.NewGuid());

//        m_TestMetricDefinition = DatasetCapture.RegisterMetricDefinition(
//            "salehe_cenario_iteration",
//            "Salehe Iteration information for dataset sequences",
//            Guid.Parse(k_TestGuid));
//    }

//    protected override void OnIterationStart()
//    {
//        DatasetCapture.ReportMetric(m_TestMetricDefinition, new[]
//        {
//            new MetricData { iteration = scenario.currentIteration }
//        });
//    }

//    struct MetricData
//    {
//        public int iteration;
//    }


//}
