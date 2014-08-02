using JobsNet.Core.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsNet.SiteSearch
{
    public enum USAJobsArgs
    {
        OrganizationID, Title, Series, MinSalary,
        MaxSalary, LocationID, LocationName, Country,
        CountrySubDivision, SES, GradeLow, GradeHigh,
        Keyword, Student, Page, NumberOfJobs
    }

    public enum USAJobsResults
    {
        DocumentID, JobTitle, OrganizationName,
        AgencySubElement, SalaryMin, SalaryMax,
        SalaryBasis, StartDate, EndDate, WhoMayApplyText,
        PayPlan, Series, Grade, WorkType, WorkSchedule,
        Locations, AnnouncementNumber, JobSummary,
        ApplyOnlineURL
    }

    public class USAJobsSearch : SiteBase<USAJobsArgs, USAJobsResults>
    {
        public USAJobsSearch()
            : base(SearcherType.JSON)
        {
            baseUrl = "https://data.usajobs.gov/api/jobs?";
            searcher.SetChildNodes(new string[] { "JobData" });
        }
    }
}
