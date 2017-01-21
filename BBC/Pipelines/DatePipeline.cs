using System;
using Sitecore.Pipelines;

namespace BBC.Pipelines
{
    public class DatePipeline : PipelineArgs
    {
        public string CurrentDate { get; set; }
    }

    public class DateProcessor
    {
        private static string GetResult() => DateTime.Today.ToString("D");

        public void Process(DatePipeline args)
        {
            args.CurrentDate = GetResult();
        }
    }
}