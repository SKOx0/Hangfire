﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HangFire.Web.Pages
{
    
    #line 2 "..\..\Pages\EnqueuedJobsPage.cshtml"
    using System;
    
    #line default
    #line hidden
    
    #line 3 "..\..\Pages\EnqueuedJobsPage.cshtml"
    using System.Collections.Generic;
    
    #line default
    #line hidden
    
    #line 4 "..\..\Pages\EnqueuedJobsPage.cshtml"
    using System.Linq;
    
    #line default
    #line hidden
    using System.Text;
    
    #line 5 "..\..\Pages\EnqueuedJobsPage.cshtml"
    using Common;
    
    #line default
    #line hidden
    
    #line 7 "..\..\Pages\EnqueuedJobsPage.cshtml"
    using HangFire.Storage;
    
    #line default
    #line hidden
    
    #line 6 "..\..\Pages\EnqueuedJobsPage.cshtml"
    using Pages;
    
    #line default
    #line hidden
    
    #line 8 "..\..\Pages\EnqueuedJobsPage.cshtml"
    using Storage.Monitoring;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    internal partial class EnqueuedJobsPage : RazorPage
    {
#line hidden

        public override void Execute()
        {


WriteLiteral("\r\n");










            
            #line 10 "..\..\Pages\EnqueuedJobsPage.cshtml"
  
    Layout = new LayoutPage
        {
            Title = Queue.ToUpperInvariant(), 
            Subtitle = "Enqueued jobs",
            Breadcrumbs = new Dictionary<string, string>
                {
                    { "Queues", Request.LinkTo("/queues") }
                }
        };

    int from, perPage;

    int.TryParse(Request.QueryString["from"], out from);
    int.TryParse(Request.QueryString["count"], out perPage);

    Pager pager;
    JobList<EnqueuedJobDto> enqueuedJobs;

    using (var monitor = JobStorage.Current.GetMonitoringApi())
    {
        pager = new Pager(from, perPage, monitor.EnqueuedCount(Queue))
        {
            BasePageUrl = Request.LinkTo("/queues/" + Queue)
        };

        enqueuedJobs = monitor
            .EnqueuedJobs(Queue, pager.FromRecord, pager.RecordsPerPage);
    }


            
            #line default
            #line hidden
WriteLiteral("\r\n");


            
            #line 41 "..\..\Pages\EnqueuedJobsPage.cshtml"
 if (pager.TotalPageCount == 0)
{

            
            #line default
            #line hidden
WriteLiteral("    <div class=\"alert alert-info\">\r\n        The queue is empty.\r\n    </div>\r\n");


            
            #line 46 "..\..\Pages\EnqueuedJobsPage.cshtml"
}
else
{
    
            
            #line default
            #line hidden
            
            #line 49 "..\..\Pages\EnqueuedJobsPage.cshtml"
Write(RenderPartial(new PerPageSelector(pager)));

            
            #line default
            #line hidden
            
            #line 49 "..\..\Pages\EnqueuedJobsPage.cshtml"
                                              
    

            
            #line default
            #line hidden
WriteLiteral("    <table class=\"table\">\r\n        <thead>\r\n            <tr>\r\n                <th" +
" class=\"min-width\">Id</th>\r\n                <th>Job</th>\r\n                <th cl" +
"ass=\"align-right\">Enqueued</th>\r\n            </tr>\r\n        </thead>\r\n        <t" +
"body>\r\n");


            
            #line 60 "..\..\Pages\EnqueuedJobsPage.cshtml"
             foreach (var job in enqueuedJobs)
            {

            
            #line default
            #line hidden
WriteLiteral("                <tr class=\"");


            
            #line 62 "..\..\Pages\EnqueuedJobsPage.cshtml"
                       Write(!job.Value.InEnqueuedState ? "obsolete-data" : null);

            
            #line default
            #line hidden
WriteLiteral("\">\r\n                    <td class=\"min-width\">\r\n                        <a href=\"" +
"");


            
            #line 64 "..\..\Pages\EnqueuedJobsPage.cshtml"
                            Write(Request.LinkTo("/job/" + job.Key));

            
            #line default
            #line hidden
WriteLiteral("\">\r\n                            ");


            
            #line 65 "..\..\Pages\EnqueuedJobsPage.cshtml"
                       Write(HtmlHelper.JobId(job.Key));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        </a>\r\n");


            
            #line 67 "..\..\Pages\EnqueuedJobsPage.cshtml"
                         if (!job.Value.InEnqueuedState)
                        {

            
            #line default
            #line hidden
WriteLiteral("                            <span title=\"Job\'s state has been changed while fetch" +
"ing data.\" class=\"glyphicon glyphicon-question-sign\"></span>\r\n");


            
            #line 70 "..\..\Pages\EnqueuedJobsPage.cshtml"
                        }

            
            #line default
            #line hidden
WriteLiteral("                    </td> \r\n                    <td>\r\n                        <sp" +
"an title=\"");


            
            #line 73 "..\..\Pages\EnqueuedJobsPage.cshtml"
                                Write(HtmlHelper.DisplayMethodHint(job.Value.Job));

            
            #line default
            #line hidden
WriteLiteral("\">\r\n                            ");


            
            #line 74 "..\..\Pages\EnqueuedJobsPage.cshtml"
                       Write(HtmlHelper.DisplayMethod(job.Value.Job));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        </span>\r\n                    </td>\r\n                   " +
" <td class=\"align-right\">\r\n");


            
            #line 78 "..\..\Pages\EnqueuedJobsPage.cshtml"
                         if (job.Value.EnqueuedAt.HasValue)
                        {

            
            #line default
            #line hidden
WriteLiteral("                            <span data-moment=\"");


            
            #line 80 "..\..\Pages\EnqueuedJobsPage.cshtml"
                                          Write(JobHelper.ToStringTimestamp(job.Value.EnqueuedAt.Value));

            
            #line default
            #line hidden
WriteLiteral("\">\r\n                                ");


            
            #line 81 "..\..\Pages\EnqueuedJobsPage.cshtml"
                           Write(job.Value.EnqueuedAt);

            
            #line default
            #line hidden
WriteLiteral("        \r\n                            </span>\r\n");


            
            #line 83 "..\..\Pages\EnqueuedJobsPage.cshtml"
                        }

            
            #line default
            #line hidden
WriteLiteral("                    </td>\r\n                </tr>\r\n");


            
            #line 86 "..\..\Pages\EnqueuedJobsPage.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("        </tbody>\r\n    </table>\r\n");


            
            #line 89 "..\..\Pages\EnqueuedJobsPage.cshtml"
    
    
            
            #line default
            #line hidden
            
            #line 90 "..\..\Pages\EnqueuedJobsPage.cshtml"
Write(RenderPartial(new Paginator(pager)));

            
            #line default
            #line hidden
            
            #line 90 "..\..\Pages\EnqueuedJobsPage.cshtml"
                                        
}
            
            #line default
            #line hidden

        }
    }
}
#pragma warning restore 1591
