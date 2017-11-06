using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimerJob1
{
    class CustomTimerJobInstall:SPFeatureReceiver
    {
        const string TimerJobName = "TimerJob";
        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            SPSite site = properties.Feature.Parent as SPSite;
            foreach(SPJobDefinition job in site.WebApplication.JobDefinitions)
            {
                if(job.Title==TimerJobName)
                {
                    job.Delete();
                }
            }
            CustomTimerJob UpdateTitle = new CustomTimerJob(TimerJobName, site.WebApplication);
            SPMinuteSchedule minuteSchedule = new SPMinuteSchedule();
            minuteSchedule.BeginSecond = 0;
            minuteSchedule.EndSecond = 59;
            minuteSchedule.Interval = 1;
            UpdateTitle.Schedule = minuteSchedule;
            UpdateTitle.Update();
        }
        public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
        {
            SPSite site = properties.Feature.Parent as SPSite;
            foreach(SPJobDefinition job in site.WebApplication.JobDefinitions)
            {
                if(job.Title==TimerJobName)
                {
                    job.Delete();
                }
            }
            //base.FeatureDeactivating(properties);
        }
        public override void FeatureInstalled(SPFeatureReceiverProperties properties)
        {
            //base.FeatureInstalled(properties);
        }
        public override void FeatureUninstalling(SPFeatureReceiverProperties properties)
        {
            SPSite site = properties.Feature.Parent as SPSite;
            foreach(SPJobDefinition job in site.WebApplication.JobDefinitions)
            {
                if(job.Title==TimerJobName)
                {
                    job.Delete();
                }
            }
            //base.FeatureUninstalling(properties);
        }
    }
}
