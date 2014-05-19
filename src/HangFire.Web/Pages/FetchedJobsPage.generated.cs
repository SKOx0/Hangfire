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
    
    #line 2 "..\..\Pages\FetchedJobsPage.cshtml"
    using System;
    
    #line default
    #line hidden
    
    #line 3 "..\..\Pages\FetchedJobsPage.cshtml"
    using System.Collections.Generic;
    
    #line default
    #line hidden
    
    #line 4 "..\..\Pages\FetchedJobsPage.cshtml"
    using System.Linq;
    
    #line default
    #line hidden
    using System.Text;
    
    #line 5 "..\..\Pages\FetchedJobsPage.cshtml"
    using Common;
    
    #line default
    #line hidden
    
    #line 7 "..\..\Pages\FetchedJobsPage.cshtml"
    using HangFire.Storage;
    
    #line default
    #line hidden
    
    #line 6 "..\..\Pages\FetchedJobsPage.cshtml"
    using Pages;
    
    #line default
    #line hidden
    
    #line 8 "..\..\Pages\FetchedJobsPage.cshtml"
    using Storage.Monitoring;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    internal partial class FetchedJobsPage : RazorPage
    {
#line hidden

        public override void Execute()
        {


WriteLiteral("\r\n");










            
            #line 10 "..\..\Pages\FetchedJobsPage.cshtml"
  
    Layout = new LayoutPage
        {
            Title = Queue.ToUpperInvariant(),
            Subtitle = "Fetched jobs",
            Breadcrumbs = new Dictionary<string, string>
                {
                    { "Queues", Request.LinkTo("/queues") },
                    { Queue.ToUpperInvariant(), Request.LinkTo("/queues/" + Queue) }
                },
            BreadcrumbsTitle = "Fetched jobs",    
        };

    int from, perPage;

    int.TryParse(Request.QueryString["from"], out from);
    int.TryParse(Request.QueryString["count"], out perPage);

    Pager pager;
    JobList<FetchedJobDto> fetchedJobs;
    
    using (var monitor = JobStorage.Current.GetMonitoringApi())
    {
        pager = new Pager(from, perPage, monitor.FetchedCount(Queue))
        {
            BasePageUrl = Request.LinkTo("/queues/fetched/" + Queue)
        };

        fetchedJobs = monitor
            .FetchedJobs(Queue, pager.FromRecord, pager.RecordsPerPage);
    }


            
            #line default
            #line hidden
WriteLiteral("\r\n");


            
            #line 43 "..\..\Pages\FetchedJobsPage.cshtml"
 if (pager.TotalPageCount == 0)
{

            
            #line default
            #line hidden
WriteLiteral("    <div class=\"alert alert-info\">\r\n        The queue is empty.\r\n    </div>\r\n");


            
            #line 48 "..\..\Pages\FetchedJobsPage.cshtml"
}
else
{
    
            
            #line default
            #line hidden
            
            #line 51 "..\..\Pages\FetchedJobsPage.cshtml"
Write(RenderPartial(new PerPageSelector(pager)));

            
            #line default
            #line hidden
            
            #line 51 "..\..\Pages\FetchedJobsPage.cshtml"
                                              
    

            
            #line default
            #line hidden
WriteLiteral(@"    <table class=""table"">
        <thead>
            <tr>
                <th class=""min-width"">Id</th>
                <th>State</th>
                <th>Job</th>
                <th>Created</th>
                <th class=""align-right"">Fetched</th>
            </tr>
        </thead>
        <tbody>
");


            
            #line 64 "..\..\Pages\FetchedJobsPage.cshtml"
             foreach (var job in fetchedJobs)
            {

            
            #line default
            #line hidden
WriteLiteral("                <tr>\r\n                    <td class=\"min-width\">\r\n               " +
"         <a href=\"");


            
            #line 68 "..\..\Pages\FetchedJobsPage.cshtml"
                            Write(Request.LinkTo("/job/" + job.Key));

            
            #line default
            #line hidden
WriteLiteral("\">");


            
            #line 68 "..\..\Pages\FetchedJobsPage.cshtml"
                                                                Write(HtmlHelper.JobId(job.Key));

            
            #line default
            #line hidden
WriteLiteral("</a>\r\n                    </td>\r\n                    <td>\r\n                      " +
"  <span class=\"label label-default\" style=\"");


            
            #line 71 "..\..\Pages\FetchedJobsPage.cshtml"
                                                             Write(JobHistoryRenderer.ForegroundStateColors.ContainsKey(job.Value.State) ? String.Format("background-color: {0};", JobHistoryRenderer.ForegroundStateColors[job.Value.State]) : null);

            
            #line default
            #line hidden
WriteLiteral("\">\r\n                            ");


            
            #line 72 "..\..\Pages\FetchedJobsPage.cshtml"
                       Write(job.Value.State);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n                    </td>\r\n                    <td>\r\n                   " +
"     <span title=\"");


            
            #line 75 "..\..\Pages\FetchedJobsPage.cshtml"
                                Write(HtmlHelper.DisplayMethodHint(job.Value.Job));

            
            #line default
            #line hidden
WriteLiteral("\">\r\n                            ");


            
            #line 76 "..\..\Pages\FetchedJobsPage.cshtml"
                       Write(HtmlHelper.DisplayMethod(job.Value.Job));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        </span>\r\n                    </td>\r\n                   " +
" <td>\r\n");


            
            #line 80 "..\..\Pages\FetchedJobsPage.cshtml"
                         if (job.Value.CreatedAt.HasValue)
                        {

            
            #line default
            #line hidden
WriteLiteral("                            <span data-moment=\"");


            
            #line 82 "..\..\Pages\FetchedJobsPage.cshtml"
                                          Write(JobHelper.ToStringTimestamp(job.Value.CreatedAt.Value));

            
            #line default
            #line hidden
WriteLiteral("\">\r\n                                ");


            
            #line 83 "..\..\Pages\FetchedJobsPage.cshtml"
                           Write(job.Value.CreatedAt);

            
            #line default
            #line hidden
WriteLiteral(" \r\n                            </span>\r\n");


            
            #line 85 "..\..\Pages\FetchedJobsPage.cshtml"
                        }

            
            #line default
            #line hidden
WriteLiteral("                    </td>\r\n                    <td class=\"align-right\">\r\n");


            
            #line 88 "..\..\Pages\FetchedJobsPage.cshtml"
                         if (job.Value.FetchedAt.HasValue)
                        {

            
            #line default
            #line hidden
WriteLiteral("                            <span data-moment=\"");


            
            #line 90 "..\..\Pages\FetchedJobsPage.cshtml"
                                          Write(JobHelper.ToStringTimestamp(job.Value.FetchedAt.Value));

            
            #line default
            #line hidden
WriteLiteral("\">\r\n                                ");


            
            #line 91 "..\..\Pages\FetchedJobsPage.cshtml"
                           Write(job.Value.FetchedAt);

            
            #line default
            #line hidden
WriteLiteral("\r\n                            </span>\r\n");


            
            #line 93 "..\..\Pages\FetchedJobsPage.cshtml"
                        }

            
            #line default
            #line hidden
WriteLiteral("                    </td>\r\n                </tr>\r\n");


            
            #line 96 "..\..\Pages\FetchedJobsPage.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("        </tbody>\r\n    </table>\r\n");


            
            #line 99 "..\..\Pages\FetchedJobsPage.cshtml"
    
    
            
            #line default
            #line hidden
            
            #line 100 "..\..\Pages\FetchedJobsPage.cshtml"
Write(RenderPartial(new Paginator(pager)));

            
            #line default
            #line hidden
            
            #line 100 "..\..\Pages\FetchedJobsPage.cshtml"
                                        
}
            
            #line default
            #line hidden

        }
    }
}
#pragma warning restore 1591
