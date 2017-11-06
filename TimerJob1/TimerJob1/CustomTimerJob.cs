using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimerJob1
{
    public class CustomTimerJob:SPJobDefinition
    {
        public CustomTimerJob() : base() { }
        public CustomTimerJob(string TimerName,SPWebApplication webapp):base(TimerName,webapp,null,SPJobLockType.ContentDatabase)
        {
            this.Title = "TimerJob1";
        }
        public override void Execute(Guid targetInstanceId)
        {
            SPWebApplication webapp = this.Parent as SPWebApplication;
            SPContentDatabase contentDB = webapp.ContentDatabases[targetInstanceId];

            SPList list = contentDB.Sites[0].RootWeb.Lists["MyStatList"];
            SPListItemCollection itemcoll = list.Items;
            for(int i=0;i<itemcoll.Count;i++)
            {
                SPListItem item = list.GetItemById(itemcoll[i].ID);
                item["Title"] = "The Items's ID is"+item.ID;
                item.SystemUpdate();
            }
            //base.Execute(targetInstanceId);
        }
    }
}
